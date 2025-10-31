using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BoatTracker
{
    public partial class StatisticsForm : Form
    {
        private Timer updateTimer;

        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            PopulateSignalUnits();
            UpdateStats();
            UpdateLogs();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateStats();
            UpdateLogs();
            UpdateSignalTab();
        }

        private void UpdateStats()
        {
            // Global stats
            uint totalReceived = 0, totalLost = 0, totalWraps = 0;
            foreach (var unit in BoatTrackerData.Units.Values)
            {
                totalReceived += unit.PacketsReceived;
                totalLost += unit.PacketsLost;
                totalWraps += unit.SequenceWraps;
            }
            double lossRate = totalReceived > 0 ? (double)totalLost / totalReceived * 100 : 0;
            lblTotalPackets.Text = $"Total Packets Received: {totalReceived}";
            lblTotalLost.Text = $"Total Packets Lost: {totalLost}";
            lblGlobalLossRate.Text = $"Global Loss Rate: {lossRate:F2}%";
            lblTotalWraps.Text = $"Total Sequence Wraps: {totalWraps}";

            // Per-unit stats
            listViewStats.BeginUpdate();
            listViewStats.Items.Clear();
            foreach (var unit in BoatTrackerData.Units.Values)
            {
                double avgRssi = unit.RSSIHistory.Count > 0 ? unit.RSSIHistory.Average() : 0;
                double avgSnr = unit.SNRHistory.Count > 0 ? unit.SNRHistory.Average() : 0;
                double unitLossRate = unit.PacketsReceived > 0 ? (double)unit.PacketsLost / unit.PacketsReceived * 100 : 0;
                var item = new ListViewItem(unit.UnitID.ToString());
                item.SubItems.Add(unit.PacketsReceived.ToString());
                item.SubItems.Add(unit.PacketsLost.ToString());
                item.SubItems.Add(unitLossRate.ToString("F2"));
                item.SubItems.Add(unit.SequenceWraps.ToString());
                item.SubItems.Add(avgRssi.ToString("F1"));
                item.SubItems.Add(avgSnr.ToString("F1"));
                listViewStats.Items.Add(item);
            }
            listViewStats.EndUpdate();
        }

        private void UpdateLogs()
        {
            richTextBoxLogs.SuspendLayout();
            richTextBoxLogs.Clear();
            foreach (var log in BoatTrackerData.PacketLogs.Skip(Math.Max(0, BoatTrackerData.PacketLogs.Count - 1000)))
            {
                Color color = log.IsValid ? Color.Lime : Color.Red;
                AppendColoredText(richTextBoxLogs, $"[{log.Timestamp:HH:mm:ss}] Unit {log.UnitID}: {log.RawData} ({log.Reason})\n", color);
            }
            if (chkAutoScroll.Checked)
                richTextBoxLogs.ScrollToCaret();
            richTextBoxLogs.ResumeLayout();
        }

        private void AppendColoredText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            BoatTrackerData.PacketLogs.Clear();
            UpdateLogs();
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV Files (*.csv)|*.csv";
            dlg.FileName = "BoatTrackerLogs.csv";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(dlg.FileName))
                {
                    sw.WriteLine("Timestamp,UnitID,RawData,IsValid,Reason");
                    foreach (var log in BoatTrackerData.PacketLogs)
                    {
                        sw.WriteLine($"{log.Timestamp},{log.UnitID},\"{log.RawData}\",{log.IsValid},{log.Reason}");
                    }
                }
                MessageBox.Show("Logs exported successfully.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PopulateSignalUnits()
        {
            cmbSignalUnit.Items.Clear();
            foreach (var unit in BoatTrackerData.Units.Values)
            {
                cmbSignalUnit.Items.Add(unit.UnitID);
            }
            if (cmbSignalUnit.Items.Count > 0)
                cmbSignalUnit.SelectedIndex = 0;
        }

        private void UpdateSignalTab()
        {
            if (cmbSignalUnit.SelectedItem == null) return;
            int unitId = (int)cmbSignalUnit.SelectedItem;
            if (!BoatTrackerData.Units.ContainsKey(unitId)) return;
            var unit = BoatTrackerData.Units[unitId];
            lblSignalInfo.Text = $"Unit {unit.UnitID}\nCurrent RSSI: {unit.RSSI} dBm\nCurrent SNR: {unit.SNR:F1} dB\nAvg RSSI: {(unit.RSSIHistory.Count > 0 ? unit.RSSIHistory.Average().ToString("F1") : "N/A")}\nAvg SNR: {(unit.SNRHistory.Count > 0 ? unit.SNRHistory.Average().ToString("F1") : "N/A")}\nPackets Received: {unit.PacketsReceived}\nPackets Lost: {unit.PacketsLost}\nSequence Wraps: {unit.SequenceWraps}\nLast Update: {unit.LastUpdate:HH:mm:ss}";
        }

        private void cmbSignalUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSignalTab();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            updateTimer.Stop();
            this.Close();
        }
    }
}
