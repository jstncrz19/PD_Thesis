namespace BoatTracker
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.groupBoxGlobal = new System.Windows.Forms.GroupBox();
            this.lblTotalPackets = new System.Windows.Forms.Label();
            this.lblTotalLost = new System.Windows.Forms.Label();
            this.lblGlobalLossRate = new System.Windows.Forms.Label();
            this.lblTotalWraps = new System.Windows.Forms.Label();
            this.groupBoxPerUnit = new System.Windows.Forms.GroupBox();
            this.listViewStats = new System.Windows.Forms.ListView();
            this.colStatsUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsLossRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsWraps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsAvgRSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatsAvgSNR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.panelLogControls = new System.Windows.Forms.Panel();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnExportLogs = new System.Windows.Forms.Button();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.tabPageSignal = new System.Windows.Forms.TabPage();
            this.lblSignalInfo = new System.Windows.Forms.Label();
            this.cmbSignalUnit = new System.Windows.Forms.ComboBox();
            this.lblSelectUnit = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageStats.SuspendLayout();
            this.groupBoxGlobal.SuspendLayout();
            this.groupBoxPerUnit.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.panelLogControls.SuspendLayout();
            this.tabPageSignal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStats);
            this.tabControl.Controls.Add(this.tabPageLogs);
            this.tabControl.Controls.Add(this.tabPageSignal);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1100, 700);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageStats
            // 
            this.tabPageStats.BackColor = System.Drawing.Color.White;
            this.tabPageStats.Controls.Add(this.groupBoxPerUnit);
            this.tabPageStats.Controls.Add(this.groupBoxGlobal);
            this.tabPageStats.Location = new System.Drawing.Point(4, 26);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStats.Size = new System.Drawing.Size(1092, 670);
            this.tabPageStats.TabIndex = 0;
            this.tabPageStats.Text = "📊 Statistics";
            // 
            // groupBoxGlobal
            // 
            this.groupBoxGlobal.Controls.Add(this.lblTotalWraps);
            this.groupBoxGlobal.Controls.Add(this.lblGlobalLossRate);
            this.groupBoxGlobal.Controls.Add(this.lblTotalLost);
            this.groupBoxGlobal.Controls.Add(this.lblTotalPackets);
            this.groupBoxGlobal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxGlobal.Location = new System.Drawing.Point(20, 20);
            this.groupBoxGlobal.Name = "groupBoxGlobal";
            this.groupBoxGlobal.Size = new System.Drawing.Size(1050, 150);
            this.groupBoxGlobal.TabIndex = 0;
            this.groupBoxGlobal.TabStop = false;
            this.groupBoxGlobal.Text = "Global Statistics";
            // 
            // lblTotalPackets
            // 
            this.lblTotalPackets.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPackets.Location = new System.Drawing.Point(30, 40);
            this.lblTotalPackets.Name = "lblTotalPackets";
            this.lblTotalPackets.Size = new System.Drawing.Size(450, 30);
            this.lblTotalPackets.TabIndex = 0;
            this.lblTotalPackets.Text = "Total Packets Received: 0";
            // 
            // lblTotalLost
            // 
            this.lblTotalLost.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLost.Location = new System.Drawing.Point(30, 75);
            this.lblTotalLost.Name = "lblTotalLost";
            this.lblTotalLost.Size = new System.Drawing.Size(450, 30);
            this.lblTotalLost.TabIndex = 1;
            this.lblTotalLost.Text = "Total Packets Lost: 0";
            // 
            // lblGlobalLossRate
            // 
            this.lblGlobalLossRate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGlobalLossRate.Location = new System.Drawing.Point(540, 40);
            this.lblGlobalLossRate.Name = "lblGlobalLossRate";
            this.lblGlobalLossRate.Size = new System.Drawing.Size(450, 30);
            this.lblGlobalLossRate.TabIndex = 2;
            this.lblGlobalLossRate.Text = "Global Loss Rate: 0.0%";
            // 
            // lblTotalWraps
            // 
            this.lblTotalWraps.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWraps.Location = new System.Drawing.Point(540, 75);
            this.lblTotalWraps.Name = "lblTotalWraps";
            this.lblTotalWraps.Size = new System.Drawing.Size(450, 30);
            this.lblTotalWraps.TabIndex = 3;
            this.lblTotalWraps.Text = "Total Sequence Wraps: 0";
            // 
            // groupBoxPerUnit
            // 
            this.groupBoxPerUnit.Controls.Add(this.listViewStats);
            this.groupBoxPerUnit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPerUnit.Location = new System.Drawing.Point(20, 190);
            this.groupBoxPerUnit.Name = "groupBoxPerUnit";
            this.groupBoxPerUnit.Size = new System.Drawing.Size(1050, 460);
            this.groupBoxPerUnit.TabIndex = 1;
            this.groupBoxPerUnit.TabStop = false;
            this.groupBoxPerUnit.Text = "Per-Unit Statistics";
            // 
            // listViewStats
            // 
            this.listViewStats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatsUnit,
            this.colStatsReceived,
            this.colStatsLost,
            this.colStatsLossRate,
            this.colStatsWraps,
            this.colStatsAvgRSSI,
            this.colStatsAvgSNR});
            this.listViewStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewStats.FullRowSelect = true;
            this.listViewStats.GridLines = true;
            this.listViewStats.HideSelection = false;
            this.listViewStats.Location = new System.Drawing.Point(3, 23);
            this.listViewStats.Name = "listViewStats";
            this.listViewStats.Size = new System.Drawing.Size(1044, 434);
            this.listViewStats.TabIndex = 0;
            this.listViewStats.UseCompatibleStateImageBehavior = false;
            this.listViewStats.View = System.Windows.Forms.View.Details;
            // 
            // colStatsUnit
            // 
            this.colStatsUnit.Text = "Unit ID";
            this.colStatsUnit.Width = 100;
            // 
            // colStatsReceived
            // 
            this.colStatsReceived.Text = "Received";
            this.colStatsReceived.Width = 120;
            // 
            // colStatsLost
            // 
            this.colStatsLost.Text = "Lost";
            this.colStatsLost.Width = 120;
            // 
            // colStatsLossRate
            // 
            this.colStatsLossRate.Text = "Loss Rate %";
            this.colStatsLossRate.Width = 120;
            // 
            // colStatsWraps
            // 
            this.colStatsWraps.Text = "Seq Wraps";
            this.colStatsWraps.Width = 120;
            // 
            // colStatsAvgRSSI
            // 
            this.colStatsAvgRSSI.Text = "Avg RSSI";
            this.colStatsAvgRSSI.Width = 120;
            // 
            // colStatsAvgSNR
            // 
            this.colStatsAvgSNR.Text = "Avg SNR";
            this.colStatsAvgSNR.Width = 120;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.BackColor = System.Drawing.Color.White;
            this.tabPageLogs.Controls.Add(this.richTextBoxLogs);
            this.tabPageLogs.Controls.Add(this.panelLogControls);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 26);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogs.Size = new System.Drawing.Size(1092, 670);
            this.tabPageLogs.TabIndex = 1;
            this.tabPageLogs.Text = "📝 Packet Logs";
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogs.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLogs.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxLogs.Location = new System.Drawing.Point(3, 53);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.ReadOnly = true;
            this.richTextBoxLogs.Size = new System.Drawing.Size(1086, 614);
            this.richTextBoxLogs.TabIndex = 0;
            this.richTextBoxLogs.Text = "";
            // 
            // panelLogControls
            // 
            this.panelLogControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelLogControls.Controls.Add(this.chkAutoScroll);
            this.panelLogControls.Controls.Add(this.btnExportLogs);
            this.panelLogControls.Controls.Add(this.btnClearLogs);
            this.panelLogControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogControls.Location = new System.Drawing.Point(3, 3);
            this.panelLogControls.Name = "panelLogControls";
            this.panelLogControls.Size = new System.Drawing.Size(1086, 50);
            this.panelLogControls.TabIndex = 1;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BackColor = System.Drawing.Color.White;
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.Location = new System.Drawing.Point(10, 10);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(100, 30);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // btnExportLogs
            // 
            this.btnExportLogs.BackColor = System.Drawing.Color.White;
            this.btnExportLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLogs.Location = new System.Drawing.Point(120, 10);
            this.btnExportLogs.Name = "btnExportLogs";
            this.btnExportLogs.Size = new System.Drawing.Size(120, 30);
            this.btnExportLogs.TabIndex = 1;
            this.btnExportLogs.Text = "💾 Export Logs";
            this.btnExportLogs.UseVisualStyleBackColor = false;
            this.btnExportLogs.Click += new System.EventHandler(this.btnExportLogs_Click);
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Location = new System.Drawing.Point(260, 15);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(94, 23);
            this.chkAutoScroll.TabIndex = 2;
            this.chkAutoScroll.Text = "Auto-scroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // tabPageSignal
            // 
            this.tabPageSignal.BackColor = System.Drawing.Color.White;
            this.tabPageSignal.Controls.Add(this.lblSignalInfo);
            this.tabPageSignal.Controls.Add(this.cmbSignalUnit);
            this.tabPageSignal.Controls.Add(this.lblSelectUnit);
            this.tabPageSignal.Location = new System.Drawing.Point(4, 26);
            this.tabPageSignal.Name = "tabPageSignal";
            this.tabPageSignal.Size = new System.Drawing.Size(1092, 670);
            this.tabPageSignal.TabIndex = 2;
            this.tabPageSignal.Text = "📡 Signal Strength";
            // 
            // lblSelectUnit
            // 
            this.lblSelectUnit.AutoSize = true;
            this.lblSelectUnit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectUnit.Location = new System.Drawing.Point(20, 20);
            this.lblSelectUnit.Name = "lblSelectUnit";
            this.lblSelectUnit.Size = new System.Drawing.Size(83, 20);
            this.lblSelectUnit.TabIndex = 0;
            this.lblSelectUnit.Text = "Select Unit:";
            // 
            // cmbSignalUnit
            // 
            this.cmbSignalUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSignalUnit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSignalUnit.FormattingEnabled = true;
            this.cmbSignalUnit.Location = new System.Drawing.Point(110, 17);
            this.cmbSignalUnit.Name = "cmbSignalUnit";
            this.cmbSignalUnit.Size = new System.Drawing.Size(200, 28);
            this.cmbSignalUnit.TabIndex = 1;
            this.cmbSignalUnit.SelectedIndexChanged += new System.EventHandler(this.cmbSignalUnit_SelectedIndexChanged);
            // 
            // lblSignalInfo
            // 
            this.lblSignalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSignalInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignalInfo.Location = new System.Drawing.Point(20, 70);
            this.lblSignalInfo.Name = "lblSignalInfo";
            this.lblSignalInfo.Size = new System.Drawing.Size(1050, 580);
            this.lblSignalInfo.TabIndex = 2;
            this.lblSignalInfo.Text = "Select a unit to view signal strength details";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(0, 700);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(1100, 50);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics & Logs";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageStats.ResumeLayout(false);
            this.groupBoxGlobal.ResumeLayout(false);
            this.groupBoxPerUnit.ResumeLayout(false);
            this.tabPageLogs.ResumeLayout(false);
            this.panelLogControls.ResumeLayout(false);
            this.panelLogControls.PerformLayout();
            this.tabPageSignal.ResumeLayout(false);
            this.tabPageSignal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStats;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.TabPage tabPageSignal;
        private System.Windows.Forms.GroupBox groupBoxGlobal;
        private System.Windows.Forms.Label lblTotalPackets;
        private System.Windows.Forms.Label lblTotalLost;
        private System.Windows.Forms.Label lblGlobalLossRate;
        private System.Windows.Forms.Label lblTotalWraps;
        private System.Windows.Forms.GroupBox groupBoxPerUnit;
        private System.Windows.Forms.ListView listViewStats;
        private System.Windows.Forms.ColumnHeader colStatsUnit;
        private System.Windows.Forms.ColumnHeader colStatsReceived;
        private System.Windows.Forms.ColumnHeader colStatsLost;
        private System.Windows.Forms.ColumnHeader colStatsLossRate;
        private System.Windows.Forms.ColumnHeader colStatsWraps;
        private System.Windows.Forms.ColumnHeader colStatsAvgRSSI;
        private System.Windows.Forms.ColumnHeader colStatsAvgSNR;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Panel panelLogControls;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnExportLogs;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Label lblSelectUnit;
        private System.Windows.Forms.ComboBox cmbSignalUnit;
        private System.Windows.Forms.Label lblSignalInfo;
        private System.Windows.Forms.Button btnClose;
    }
}