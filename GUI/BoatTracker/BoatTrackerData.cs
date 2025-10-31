using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.IO.Ports;

namespace BoatTracker
{
    public static class BoatTrackerData
    {
        // Thread-safe dictionary for units
        public static ConcurrentDictionary<int, BoatUnit> Units = new ConcurrentDictionary<int, BoatUnit>();
        // Thread-safe notification queue (max 100)
        public static ConcurrentQueue<Tuple<DateTime, string, NotificationType>> Notifications = new ConcurrentQueue<Tuple<DateTime, string, NotificationType>>();
        // Log list for statistics
        public static List<PacketLogEntry> PacketLogs = new List<PacketLogEntry>();
        // Serial port reference
        public static SerialPort SerialPortInstance = null;
    }

    public enum NotificationType
    {
        SOS,
        LostConnection,
        WeakSignal,
        UnitReboot,
        GPSNofix,
        Info
    }

    public class PacketLogEntry
    {
        public DateTime Timestamp { get; set; }
        public int UnitID { get; set; }
        public string RawData { get; set; }
        public bool IsValid { get; set; }
        public string Reason { get; set; }
    }
}
