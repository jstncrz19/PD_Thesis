using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace BoatTracker
{
    public partial class ConnectionForm : Form
    {
        private SerialPort serialPort;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            PopulateComPorts();
            cmbBaudRate.SelectedIndex = 0;
        }

        private void PopulateComPorts()
        {
            cmbComPort.Items.Clear();
            var ports = SerialPort.GetPortNames();
            cmbComPort.Items.AddRange(ports);
            if (ports.Length > 0)
                cmbComPort.SelectedIndex = 0;
            else
                lblStatus.Text = "No COM ports found.";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateComPorts();
            lblStatus.Text = "Ports refreshed.";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (cmbComPort.SelectedItem == null || cmbBaudRate.SelectedItem == null)
            {
                MessageBox.Show("Please select a COM port and baud rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string portName = cmbComPort.SelectedItem.ToString();
                int baudRate = int.Parse(cmbBaudRate.SelectedItem.ToString());
                serialPort = new SerialPort(portName, baudRate);
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();
                BoatTrackerData.SerialPortInstance = serialPort;
                lblStatus.Text = $"Connected to {portName} @ {baudRate}";
                DashboardForm dashboard = new DashboardForm(this);
                dashboard.FormClosed += (s, args) => { this.Show(); };
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Connection failed.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                BoatTrackerData.SerialPortInstance = null;
            }
            this.Close();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Data will be handled in DashboardForm
        }
    }
}
