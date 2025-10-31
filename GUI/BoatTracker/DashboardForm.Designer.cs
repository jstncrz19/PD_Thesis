namespace BoatTracker
{
    partial class DashboardForm
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblConnectionInfo = new System.Windows.Forms.Label();
            this.chkAutoFollow = new System.Windows.Forms.CheckBox();
            this.chkSoundAlert = new System.Windows.Forms.CheckBox();
            this.panelRightContainer = new System.Windows.Forms.Panel();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.lblNotificationsTitle = new System.Windows.Forms.Label();
            this.listBoxNotifications = new System.Windows.Forms.ListBox();
            this.btnClearNotifications = new System.Windows.Forms.Button();
            this.splitterUnitsNotifications = new System.Windows.Forms.Splitter();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblUnitsTitle = new System.Windows.Forms.Label();
            this.listViewUnits = new System.Windows.Forms.ListView();
            this.colUnitID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLatitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLongitude = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSignal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastUpdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelMap = new System.Windows.Forms.Panel();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.lblMapTitle = new System.Windows.Forms.Label();
            this.panelMapControls = new System.Windows.Forms.Panel();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnCenterAll = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRightContainer.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelMap.SuspendLayout();
            this.panelMapControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.chkSoundAlert);
            this.panelLeft.Controls.Add(this.chkAutoFollow);
            this.panelLeft.Controls.Add(this.lblConnectionInfo);
            this.panelLeft.Controls.Add(this.btnSettings);
            this.panelLeft.Controls.Add(this.btnExport);
            this.panelLeft.Controls.Add(this.btnStatistics);
            this.panelLeft.Controls.Add(this.btnDisconnect);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 1080);
            this.panelLeft.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(15, 20);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(170, 50);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.Text = "⏸ Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.White;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.Location = new System.Drawing.Point(15, 90);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(170, 45);
            this.btnStatistics.TabIndex = 1;
            this.btnStatistics.Text = "📊 Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(15, 145);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(170, 45);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "💾 Export Data";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(15, 200);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(170, 45);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "⚙ Settings";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionInfo.Location = new System.Drawing.Point(15, 270);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(170, 80);
            this.lblConnectionInfo.TabIndex = 4;
            this.lblConnectionInfo.Text = "Connected to:\r\nCOM3 @ 115200\r\n\r\nUptime: 00:00:00";
            // 
            // chkAutoFollow
            // 
            this.chkAutoFollow.AutoSize = true;
            this.chkAutoFollow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoFollow.Location = new System.Drawing.Point(15, 370);
            this.chkAutoFollow.Name = "chkAutoFollow";
            this.chkAutoFollow.Size = new System.Drawing.Size(146, 19);
            this.chkAutoFollow.TabIndex = 5;
            this.chkAutoFollow.Text = "Auto-follow selected unit";
            this.chkAutoFollow.UseVisualStyleBackColor = true;
            // 
            // chkSoundAlert
            // 
            this.chkSoundAlert.AutoSize = true;
            this.chkSoundAlert.Checked = true;
            this.chkSoundAlert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoundAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSoundAlert.Location = new System.Drawing.Point(15, 400);
            this.chkSoundAlert.Name = "chkSoundAlert";
            this.chkSoundAlert.Size = new System.Drawing.Size(125, 19);
            this.chkSoundAlert.TabIndex = 6;
            this.chkSoundAlert.Text = "SOS sound alerts";
            this.chkSoundAlert.UseVisualStyleBackColor = true;
            // 
            // panelRightContainer
            // 
            this.panelRightContainer.Controls.Add(this.panelBottomRight);
            this.panelRightContainer.Controls.Add(this.splitterUnitsNotifications);
            this.panelRightContainer.Controls.Add(this.panelRight);
            this.panelRightContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRightContainer.Location = new System.Drawing.Point(1470, 0);
            this.panelRightContainer.Name = "panelRightContainer";
            this.panelRightContainer.Size = new System.Drawing.Size(450, 1080);
            this.panelRightContainer.TabIndex = 1;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.BackColor = System.Drawing.Color.White;
            this.panelBottomRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottomRight.Controls.Add(this.btnClearNotifications);
            this.panelBottomRight.Controls.Add(this.listBoxNotifications);
            this.panelBottomRight.Controls.Add(this.lblNotificationsTitle);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(0, 650);
            this.panelBottomRight.MinimumSize = new System.Drawing.Size(450, 200);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Size = new System.Drawing.Size(450, 430);
            this.panelBottomRight.TabIndex = 2;
            // 
            // lblNotificationsTitle
            // 
            this.lblNotificationsTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblNotificationsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNotificationsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificationsTitle.ForeColor = System.Drawing.Color.Black;
            this.lblNotificationsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblNotificationsTitle.Name = "lblNotificationsTitle";
            this.lblNotificationsTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblNotificationsTitle.Size = new System.Drawing.Size(448, 40);
            this.lblNotificationsTitle.TabIndex = 0;
            this.lblNotificationsTitle.Text = "🔔 Notifications";
            this.lblNotificationsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxNotifications
            // 
            this.listBoxNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxNotifications.FormattingEnabled = true;
            this.listBoxNotifications.ItemHeight = 15;
            this.listBoxNotifications.Location = new System.Drawing.Point(0, 40);
            this.listBoxNotifications.Name = "listBoxNotifications";
            this.listBoxNotifications.Size = new System.Drawing.Size(448, 348);
            this.listBoxNotifications.TabIndex = 1;
            this.listBoxNotifications.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxNotifications.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxNotifications_DrawItem);
            // 
            // btnClearNotifications
            // 
            this.btnClearNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClearNotifications.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearNotifications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearNotifications.Location = new System.Drawing.Point(0, 388);
            this.btnClearNotifications.Name = "btnClearNotifications";
            this.btnClearNotifications.Size = new System.Drawing.Size(448, 40);
            this.btnClearNotifications.TabIndex = 2;
            this.btnClearNotifications.Text = "Clear All";
            this.btnClearNotifications.UseVisualStyleBackColor = false;
            this.btnClearNotifications.Click += new System.EventHandler(this.btnClearNotifications_Click);
            // 
            // splitterUnitsNotifications
            // 
            this.splitterUnitsNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.splitterUnitsNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterUnitsNotifications.Location = new System.Drawing.Point(0, 647);
            this.splitterUnitsNotifications.MinExtra = 200;
            this.splitterUnitsNotifications.MinSize = 300;
            this.splitterUnitsNotifications.Name = "splitterUnitsNotifications";
            this.splitterUnitsNotifications.Size = new System.Drawing.Size(450, 3);
            this.splitterUnitsNotifications.TabIndex = 4;
            this.splitterUnitsNotifications.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.listViewUnits);
            this.panelRight.Controls.Add(this.lblUnitsTitle);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.MinimumSize = new System.Drawing.Size(450, 300);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(450, 647);
            this.panelRight.TabIndex = 1;
            // 
            // lblUnitsTitle
            // 
            this.lblUnitsTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblUnitsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUnitsTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitsTitle.ForeColor = System.Drawing.Color.White;
            this.lblUnitsTitle.Location = new System.Drawing.Point(0, 0);
            this.lblUnitsTitle.Name = "lblUnitsTitle";
            this.lblUnitsTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblUnitsTitle.Size = new System.Drawing.Size(448, 45);
            this.lblUnitsTitle.TabIndex = 0;
            this.lblUnitsTitle.Text = "🚤 Active Units (0)";
            this.lblUnitsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewUnits
            // 
            this.listViewUnits.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUnitID,
            this.colStatus,
            this.colLatitude,
            this.colLongitude,
            this.colSignal,
            this.colSOS,
            this.colLastUpdate});
            this.listViewUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUnits.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUnits.FullRowSelect = true;
            this.listViewUnits.GridLines = true;
            this.listViewUnits.HideSelection = false;
            this.listViewUnits.Location = new System.Drawing.Point(0, 45);
            this.listViewUnits.MultiSelect = false;
            this.listViewUnits.Name = "listViewUnits";
            this.listViewUnits.Size = new System.Drawing.Size(448, 600);
            this.listViewUnits.TabIndex = 1;
            this.listViewUnits.UseCompatibleStateImageBehavior = false;
            this.listViewUnits.View = System.Windows.Forms.View.Details;
            this.listViewUnits.SelectedIndexChanged += new System.EventHandler(this.listViewUnits_SelectedIndexChanged);
            // 
            // colUnitID
            // 
            this.colUnitID.Text = "Unit ID";
            this.colUnitID.Width = 60;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
            // 
            // colLatitude
            // 
            this.colLatitude.Text = "Latitude";
            this.colLatitude.Width = 90;
            // 
            // colLongitude
            // 
            this.colLongitude.Text = "Longitude";
            this.colLongitude.Width = 90;
            // 
            // colSignal
            // 
            this.colSignal.Text = "Signal";
            this.colSignal.Width = 100;
            // 
            // colSOS
            // 
            this.colSOS.Text = "SOS";
            this.colSOS.Width = 50;
            // 
            // colLastUpdate
            // 
            this.colLastUpdate.Text = "Last Update";
            this.colLastUpdate.Width = 120;
            // 
            // panelMap
            // 
            this.panelMap.BackColor = System.Drawing.Color.White;
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMap.Controls.Add(this.gMapControl);
            this.panelMap.Controls.Add(this.panelMapControls);
            this.panelMap.Controls.Add(this.lblMapTitle);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(200, 0);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(1270, 1080);
            this.panelMap.TabIndex = 3;
            // 
            // lblMapTitle
            // 
            this.lblMapTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblMapTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapTitle.ForeColor = System.Drawing.Color.White;
            this.lblMapTitle.Location = new System.Drawing.Point(0, 0);
            this.lblMapTitle.Name = "lblMapTitle";
            this.lblMapTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblMapTitle.Size = new System.Drawing.Size(1268, 50);
            this.lblMapTitle.TabIndex = 0;
            this.lblMapTitle.Text = "🗺 Real-Time Tracking Map";
            this.lblMapTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            //this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 50);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 18;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1268, 952);
            this.gMapControl.TabIndex = 1;
            this.gMapControl.Zoom = 12D;
            // 
            // panelMapControls
            // 
            this.panelMapControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelMapControls.Controls.Add(this.btnCenterAll);
            this.panelMapControls.Controls.Add(this.btnZoomOut);
            this.panelMapControls.Controls.Add(this.btnZoomIn);
            this.panelMapControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMapControls.Location = new System.Drawing.Point(0, 1002);
            this.panelMapControls.Name = "panelMapControls";
            this.panelMapControls.Size = new System.Drawing.Size(1268, 78);
            this.panelMapControls.TabIndex = 2;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.White;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.Location = new System.Drawing.Point(20, 15);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(60, 50);
            this.btnZoomIn.TabIndex = 0;
            this.btnZoomIn.Text = "➕";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.White;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.Location = new System.Drawing.Point(90, 15);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(60, 50);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Text = "➖";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnCenterAll
            // 
            this.btnCenterAll.BackColor = System.Drawing.Color.White;
            this.btnCenterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCenterAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCenterAll.Location = new System.Drawing.Point(160, 15);
            this.btnCenterAll.Name = "btnCenterAll";
            this.btnCenterAll.Size = new System.Drawing.Size(120, 50);
            this.btnCenterAll.TabIndex = 2;
            this.btnCenterAll.Text = "🎯 Center All";
            this.btnCenterAll.UseVisualStyleBackColor = false;
            this.btnCenterAll.Click += new System.EventHandler(this.btnCenterAll_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelRightContainer);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boat Tracker - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRightContainer.ResumeLayout(false);
            this.panelBottomRight.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelMap.ResumeLayout(false);
            this.panelMapControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblConnectionInfo;
        private System.Windows.Forms.CheckBox chkAutoFollow;
        private System.Windows.Forms.CheckBox chkSoundAlert;
        private System.Windows.Forms.Panel panelRightContainer;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblUnitsTitle;
        private System.Windows.Forms.ListView listViewUnits;
        private System.Windows.Forms.ColumnHeader colUnitID;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colLatitude;
        private System.Windows.Forms.ColumnHeader colLongitude;
        private System.Windows.Forms.ColumnHeader colSignal;
        private System.Windows.Forms.ColumnHeader colSOS;
        private System.Windows.Forms.ColumnHeader colLastUpdate;
        private System.Windows.Forms.Splitter splitterUnitsNotifications;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.Label lblNotificationsTitle;
        private System.Windows.Forms.ListBox listBoxNotifications;
        private System.Windows.Forms.Button btnClearNotifications;
        private System.Windows.Forms.Panel panelMap;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Label lblMapTitle;
        private System.Windows.Forms.Panel panelMapControls;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnCenterAll;
    }
}