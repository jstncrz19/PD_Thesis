using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace BoatTracker
{
    public partial class DashboardForm : Form
    {
        private GMapOverlay markersOverlay;
        private System.Windows.Forms.Timer updateTimer;
        private DateTime startTime;
        private Dictionary<int, GMapMarker> unitMarkers = new Dictionary<int, GMapMarker>();
        private object syncLock = new object();
        private ConnectionForm connectionFormRef;
        
        // Track active notifications by unit and type
        private Dictionary<(int UnitId, NotificationType Type), DateTime> activeNotifications = new Dictionary<(int UnitId, NotificationType Type), DateTime>();

        public DashboardForm(ConnectionForm connectionForm = null)
        {
            InitializeComponent();
            GMap.NET.MapProviders.OpenStreetMapProvider.UserAgent = "BoatTrackerStudent/1.0 (justincruz38.jc@gmail.com)";
            this.connectionFormRef = connectionForm;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // Map setup
            gMapControl.MapProvider = GMapProviders.OpenCycleMap;
            gMapControl.Position = new PointLatLng(14.5995, 120.9842); // Manila
            gMapControl.MinZoom = 2;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 12;
            gMapControl.ShowCenter = false;
            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            markersOverlay = new GMapOverlay("units");
            gMapControl.Overlays.Add(markersOverlay);
            startTime = DateTime.Now;

            // Serial port event
            if (BoatTrackerData.SerialPortInstance != null)
            {
                BoatTrackerData.SerialPortInstance.DataReceived += SerialPort_DataReceived;
            }

            // Timer for UI updates
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            updateTimer.Stop();
            if (BoatTrackerData.SerialPortInstance != null && BoatTrackerData.SerialPortInstance.IsOpen)
            {
                BoatTrackerData.SerialPortInstance.Close();
                BoatTrackerData.SerialPortInstance = null;
            }
            if (connectionFormRef != null)
            {
                connectionFormRef.Show();
            }
            // Collect forms to close except ConnectionForm
            var formsToClose = new List<Form>();
            foreach (Form f in Application.OpenForms)
            {
                if (f != connectionFormRef)
                    formsToClose.Add(f);
            }
            foreach (Form f in formsToClose)
            {
                f.Close();
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm statsForm = new StatisticsForm();
            statsForm.ShowDialog();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string line = BoatTrackerData.SerialPortInstance.ReadLine();
                this.BeginInvoke((MethodInvoker)delegate {
                    ParseSerialData(line);
                });
            }
            catch { }
        }

        private void ParseSerialData(string line)
        {
            // Format: "1,GND,42,12345,0,14.123456,121.123456,OK,234|-98|7.5"
            try
            {
                string[] mainParts = line.Split('|');
                if (mainParts.Length != 3) return;
                string[] fields = mainParts[0].Split(',');
                if (fields.Length < 9) return; // Updated to expect 9 fields
                int unitId = int.Parse(fields[0]);
                string dest = fields[1];
                ushort seq = ushort.Parse(fields[2]);
                int timestamp = int.Parse(fields[3]);
                bool sos = fields[4] == "1";
                double lat = double.Parse(fields[5]);  // Updated index
                double lng = double.Parse(fields[6]);  // Updated index
                string gpsStatus = fields[7];         // Updated index
                int checksum = int.Parse(fields[8]);  // Updated index
                int rssi = int.Parse(mainParts[1]);
                double snr = double.Parse(mainParts[2]);

                // Checksum validation
                int calcChecksum = 0;
                for (int i = 0; i < line.LastIndexOf(','); i++)
                    calcChecksum += line[i];
                bool valid = (calcChecksum % 256) == checksum;

                // Log packet
                BoatTrackerData.PacketLogs.Add(new PacketLogEntry {
                    Timestamp = DateTime.Now,
                    UnitID = unitId,
                    RawData = line,
                    IsValid = valid,
                    Reason = valid ? "OK" : "Checksum error"
                });

                if (!valid) return;

                // Update unit
                BoatUnit unit;
                if (!BoatTrackerData.Units.TryGetValue(unitId, out unit))
                {
                    unit = new BoatUnit { UnitID = unitId };
                    BoatTrackerData.Units[unitId] = unit;
                }
                // Sequence wrap detection
                if (unit.Sequence > seq && unit.Sequence > 65000 && seq < 1000)
                {
                    unit.SequenceWraps++;
                }
                // Packet loss detection
                if (unit.Sequence != 0 && seq != (ushort)(unit.Sequence + 1))
                {
                    unit.PacketsLost += (uint)((seq + 65536 - unit.Sequence - 1) % 65536);
                }
                unit.PacketsReceived++;
                unit.Sequence = seq;
                unit.Latitude = lat;
                unit.Longitude = lng;
                unit.RSSI = rssi;
                unit.SNR = snr;
                unit.SOS = sos;
                unit.GPSStatus = gpsStatus;
                unit.LastUpdate = DateTime.Now;
                unit.RSSIHistory.Add(rssi);
                unit.SNRHistory.Add(snr);
                if (unit.RSSIHistory.Count > 100) unit.RSSIHistory.RemoveAt(0);
                if (unit.SNRHistory.Count > 100) unit.SNRHistory.RemoveAt(0);

                // Handle notifications
                var notificationKeyNofix = (unitId, NotificationType.GPSNofix);
                var notificationKeySOS = (unitId, NotificationType.SOS);

                // Handle SOS notifications (deduplicated, with duration)
                if (sos)
                {
                    if (!activeNotifications.ContainsKey(notificationKeySOS))
                    {
                        activeNotifications[notificationKeySOS] = DateTime.Now;
                        AddNotification($"SOS from Unit {unitId}", NotificationType.SOS);
                        if (chkSoundAlert.Checked) SystemSounds.Exclamation.Play();
                    }
                    else
                    {
                        // Do NOT update the timestamp, just update the notification
                        TimeSpan duration = DateTime.Now - activeNotifications[notificationKeySOS];
                        UpdateNotification($"SOS from Unit {unitId} ({GetDurationText(duration)})", NotificationType.SOS, unitId);
                        if (chkSoundAlert.Checked) SystemSounds.Exclamation.Play();
                    }
                }
                else if (activeNotifications.ContainsKey(notificationKeySOS))
                {
                    // SOS cleared, show how long it was active
                    DateTime sosStart = activeNotifications[notificationKeySOS];
                    TimeSpan duration = DateTime.Now - sosStart;
                    activeNotifications.Remove(notificationKeySOS);
                    AddNotification($"SOS cleared for Unit {unitId} (active for {GetDurationText(duration, true)})", NotificationType.Info);
                }

                // Handle GPS NOFIX notifications
                if (gpsStatus == "NOFIX")
                {
                    if (!activeNotifications.ContainsKey(notificationKeyNofix))
                    {
                        // First time NOFIX is detected
                        activeNotifications[notificationKeyNofix] = DateTime.Now;
                        AddNotification($"Unit {unitId} GPS NOFIX", NotificationType.GPSNofix);
                    }
                    else
                    {
                        // Update existing NOFIX notification with duration
                        TimeSpan duration = DateTime.Now - activeNotifications[notificationKeyNofix];
                        UpdateNotification(
                            $"Unit {unitId} GPS NOFIX ({GetDurationText(duration)})",
                            NotificationType.GPSNofix,
                            unitId
                        );
                    }
                }
                else if (activeNotifications.ContainsKey(notificationKeyNofix))
                {
                    // GPS fix restored - remove from active notifications
                    activeNotifications.Remove(notificationKeyNofix);
                    AddNotification($"Unit {unitId} GPS Fix restored", NotificationType.Info);
                }

                // Handle weak signal notifications
                var weakSignalKey = (unitId, NotificationType.WeakSignal);
                if (unit.RSSI < -100)
                {
                    if (!activeNotifications.ContainsKey(weakSignalKey))
                    {
                        activeNotifications[weakSignalKey] = DateTime.Now;
                        AddNotification($"Weak signal from Unit {unitId}", NotificationType.WeakSignal);
                    }
                }
                else if (activeNotifications.ContainsKey(weakSignalKey))
                {
                    activeNotifications.Remove(weakSignalKey);
                    AddNotification($"Signal restored for Unit {unitId}", NotificationType.Info);
                }
            }
            catch { }
        }

        private string GetDurationText(TimeSpan duration, bool shortForm = false)
        {
            if (duration.TotalHours >= 1)
                return shortForm ? $"{(int)duration.TotalHours}h {duration.Minutes}m" : $"{(int)duration.TotalHours}h {duration.Minutes}m ago";
            if (duration.TotalMinutes >= 1)
                return shortForm ? $"{(int)duration.TotalMinutes}m" : $"{(int)duration.TotalMinutes}m ago";
            return shortForm ? "less than 1m" : "just now";
        }

        private void UpdateNotification(string message, NotificationType type, int unitId)
        {
            lock (syncLock)
            {
                // Find and update existing notification for the same unit and type
                var existingNotif = BoatTrackerData.Notifications
                    .Where(n =>
                        (type == NotificationType.SOS && n.Item2.StartsWith($"SOS from Unit {unitId}")) ||
                        (type == NotificationType.GPSNofix && n.Item2.StartsWith($"Unit {unitId} GPS NOFIX")) ||
                        (type == NotificationType.WeakSignal && n.Item2.StartsWith($"Weak signal from Unit {unitId}"))
                    )
                    .FirstOrDefault();

                if (existingNotif != null)
                {
                    var notifList = BoatTrackerData.Notifications.ToList();
                    notifList.Remove(existingNotif);
                    BoatTrackerData.Notifications = new System.Collections.Concurrent.ConcurrentQueue<Tuple<DateTime, string, NotificationType>>(notifList);
                }

                AddNotification(message, type);
            }
        }

        private void AddNotification(string message, NotificationType type)
        {
            lock (syncLock)
            {
                BoatTrackerData.Notifications.Enqueue(Tuple.Create(DateTime.Now, message, type));
                while (BoatTrackerData.Notifications.Count > 100)
                {
                    Tuple<DateTime, string, NotificationType> temp;
                    BoatTrackerData.Notifications.TryDequeue(out temp);
                }
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateUnitList();
            UpdateMapMarkers();
            UpdateNotifications();
            UpdateConnectionInfo();
        }

        private void UpdateUnitList()
        {
            listViewUnits.BeginUpdate();
            listViewUnits.Items.Clear();
            foreach (var kvp in BoatTrackerData.Units)
            {
                var unit = kvp.Value;
                var item = new ListViewItem(unit.UnitID.ToString());
                item.SubItems.Add(unit.IsOnline() ? "Online" : "Offline");
                item.SubItems.Add(unit.Latitude.ToString("F6"));
                item.SubItems.Add(unit.Longitude.ToString("F6"));
                item.SubItems.Add($"{unit.RSSI} dBm / {unit.SNR:F1} dB");
                item.SubItems.Add(unit.SOS ? "YES" : "NO");
                item.SubItems.Add(unit.LastUpdate.ToString("HH:mm:ss"));
                Color signalColor = unit.GetSignalColor();
                item.BackColor = signalColor;
                listViewUnits.Items.Add(item);
            }
            lblUnitsTitle.Text = $"🚤 Active Units ({BoatTrackerData.Units.Count})";
            listViewUnits.EndUpdate();
        }

        private void UpdateMapMarkers()
        {
            markersOverlay.Markers.Clear();
            foreach (var kvp in BoatTrackerData.Units)
            {
                var unit = kvp.Value;
                if (!unit.IsOnline()) continue;
                var markerType = unit.SOS ? GMarkerGoogleType.red_dot : GMarkerGoogleType.blue_dot;
                var marker = new GMarkerGoogle(new PointLatLng(unit.Latitude, unit.Longitude), markerType)
                {
                    ToolTipText = $"Unit {unit.UnitID}\nRSSI: {unit.RSSI} dBm\nSNR: {unit.SNR:F1} dB\nStatus: {(unit.SOS ? "SOS" : "Normal")}" 
                };
                markersOverlay.Markers.Add(marker);
                unitMarkers[unit.UnitID] = marker;
            }
            // Auto-follow selected unit
            if (chkAutoFollow.Checked && listViewUnits.SelectedItems.Count > 0)
            {
                int selectedId = int.Parse(listViewUnits.SelectedItems[0].Text);
                if (BoatTrackerData.Units.ContainsKey(selectedId))
                {
                    var unit = BoatTrackerData.Units[selectedId];
                    gMapControl.Position = new PointLatLng(unit.Latitude, unit.Longitude);
                }
            }
        }

        private void UpdateNotifications()
        {
            listBoxNotifications.BeginUpdate();
            listBoxNotifications.Items.Clear();
            foreach (var notif in BoatTrackerData.Notifications.Reverse())
            {
                listBoxNotifications.Items.Add(notif.Item2);
            }
            listBoxNotifications.EndUpdate();
        }

        private void UpdateConnectionInfo()
        {
            if (BoatTrackerData.SerialPortInstance != null)
            {
                lblConnectionInfo.Text = $@"Connected to:
{BoatTrackerData.SerialPortInstance.PortName} @ {BoatTrackerData.SerialPortInstance.BaudRate}

Uptime: {(DateTime.Now - startTime).ToString(@"hh\:mm\:ss")}";
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            gMapControl.Zoom++;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            gMapControl.Zoom--;
        }

        private void btnCenterAll_Click(object sender, EventArgs e)
        {
            if (BoatTrackerData.Units.Count > 0)
            {
                var avgLat = BoatTrackerData.Units.Values.Average(u => u.Latitude);
                var avgLng = BoatTrackerData.Units.Values.Average(u => u.Longitude);
                gMapControl.Position = new PointLatLng(avgLat, avgLng);
            }
        }

        private void btnClearNotifications_Click(object sender, EventArgs e)
        {
            lock (syncLock)
            {
                while (BoatTrackerData.Notifications.TryDequeue(out _)) { }
            }
            listBoxNotifications.Items.Clear();
        }

        private void listBoxNotifications_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var notif = BoatTrackerData.Notifications.Reverse().ElementAt(e.Index);
            Color bg = Color.White;
            switch (notif.Item3)
            {
                case NotificationType.SOS: bg = Color.Red; break;
                case NotificationType.LostConnection: bg = Color.Gray; break;
                case NotificationType.WeakSignal: bg = Color.Yellow; break;
                case NotificationType.UnitReboot: bg = Color.LightBlue; break;
                case NotificationType.GPSNofix: bg = Color.Orange; break;
                default: bg = Color.White; break;
            }
            e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);
            e.Graphics.DrawString(notif.Item2, e.Font, Brushes.Black, e.Bounds);
        }

        private void listViewUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auto-follow handled in UpdateMapMarkers
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnDisconnect.PerformClick();
            }
        }

        // Empty event handlers for designer
        private void btnExport_Click(object sender, EventArgs e) { /* Implement export if needed */ }
        private void btnSettings_Click(object sender, EventArgs e) { /* Implement settings if needed */ }
    }
}
