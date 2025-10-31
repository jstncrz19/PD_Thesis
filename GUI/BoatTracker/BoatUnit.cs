using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatTracker
{
    public class BoatUnit
    {
        public int UnitID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int RSSI { get; set; }
        public double SNR { get; set; }
        public bool SOS { get; set; }
        public string GPSStatus { get; set; }
        public DateTime LastUpdate { get; set; }
        public ushort Sequence { get; set; }
        public uint PacketsReceived { get; set; }
        public uint PacketsLost { get; set; }
        public uint SequenceWraps { get; set; }
        public List<int> RSSIHistory { get; set; }
        public List<double> SNRHistory { get; set; }

        public BoatUnit()
        {
            RSSIHistory = new List<int>();
            SNRHistory = new List<double>();
            GPSStatus = "UNKNOWN";
            LastUpdate = DateTime.Now;
        }

        public bool IsOnline()
        {
            return (DateTime.Now - LastUpdate).TotalSeconds < 10;
        }

        public string GetSignalQuality()
        {
            if (RSSI > -80) return "Excellent";
            if (RSSI > -100) return "Good";
            if (RSSI > -110) return "Fair";
            return "Poor";
        }

        public Color GetSignalColor()
        {
            if (RSSI > -80) return Color.Green;
            if (RSSI > -100) return Color.Yellow;
            if (RSSI > -110) return Color.Orange;
            return Color.Red;
        }
    }
}
