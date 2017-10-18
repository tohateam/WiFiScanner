using System.Reflection;
using System.Windows.Forms;

namespace WifiScanner
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThirtySecMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OneMinMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FiveMinMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TenMinMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FreezeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OnTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelUpload = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDownload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelBytesSent = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelBytesReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewAccessPoints = new System.Windows.Forms.ListView();
            this.SSID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SignalQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dbm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Encryption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Authentication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageWifi = new System.Windows.Forms.TabPage();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAdaptersList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSsid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMac = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStrength = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageWifi.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // timer1
            //
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLogToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            //
            // saveLogToolStripMenuItem
            //
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            //
            // toolStripMenuItem1
            //
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 6);
            //
            // exitToolStripMenuItem
            //
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            //
            // toolsToolStripMenuItem
            //
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            //
            // optionsToolStripMenuItem
            //
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerToolStripMenuItem,
            this.OnTopMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            //
            // timerToolStripMenuItem
            //
            this.timerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalToolStripMenuItem,
            this.FreezeMenuItem});
            this.timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            this.timerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.timerToolStripMenuItem.Text = "Timer";
            //
            // intervalToolStripMenuItem
            //
            this.intervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThirtySecMenuItem,
            this.OneMinMenuItem,
            this.FiveMinMenuItem1,
            this.TenMinMenuItem2});
            this.intervalToolStripMenuItem.Name = "intervalToolStripMenuItem";
            this.intervalToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.intervalToolStripMenuItem.Text = "Interval";
            //
            // ThirtySecMenuItem
            //
            this.ThirtySecMenuItem.Name = "ThirtySecMenuItem";
            this.ThirtySecMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ThirtySecMenuItem.Text = "30 sek";
            this.ThirtySecMenuItem.Click += new System.EventHandler(this.ThirtySecMenuItem_Click);
            //
            // OneMinMenuItem
            //
            this.OneMinMenuItem.Name = "OneMinMenuItem";
            this.OneMinMenuItem.Size = new System.Drawing.Size(110, 22);
            this.OneMinMenuItem.Text = "1 min";
            this.OneMinMenuItem.Click += new System.EventHandler(this.OneMinMenuItem_Click);
            //
            // FiveMinMenuItem1
            //
            this.FiveMinMenuItem1.Name = "FiveMinMenuItem1";
            this.FiveMinMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.FiveMinMenuItem1.Text = "5 min";
            this.FiveMinMenuItem1.Click += new System.EventHandler(this.FiveMinMenuItem1_Click);
            //
            // TenMinMenuItem2
            //
            this.TenMinMenuItem2.Name = "TenMinMenuItem2";
            this.TenMinMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.TenMinMenuItem2.Text = "10 min";
            this.TenMinMenuItem2.Click += new System.EventHandler(this.TenMinMenuItem2_Click);
            //
            // FreezeMenuItem
            //
            this.FreezeMenuItem.Name = "FreezeMenuItem";
            this.FreezeMenuItem.Size = new System.Drawing.Size(113, 22);
            this.FreezeMenuItem.Text = "Freeze";
            this.FreezeMenuItem.Click += new System.EventHandler(this.FreezeMenuItem_Click);
            //
            // OnTopMenuItem
            //
            this.OnTopMenuItem.Name = "OnTopMenuItem";
            this.OnTopMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OnTopMenuItem.Text = "Always on Top";
            this.OnTopMenuItem.Click += new System.EventHandler(this.OnTopMenuItem_Click);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelUpload,
            this.labelDownload,
            this.toolStripStatusLabel3,
            this.labelBytesSent,
            this.toolStripStatusLabel5,
            this.labelBytesReceived,
            this.toolStripStatusLabel7,
            this.labelTotal,
            this.sbProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 453);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            //
            // labelUpload
            //
            this.labelUpload.AutoSize = false;
            this.labelUpload.Image = global::WifiScanner.Properties.Resources.agt_uninstall_product;
            this.labelUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUpload.Name = "labelUpload";
            this.labelUpload.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelUpload.Size = new System.Drawing.Size(100, 17);
            this.labelUpload.Text = "0.00 Kb/s";
            this.labelUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // labelDownload
            //
            this.labelDownload.AutoSize = false;
            this.labelDownload.Image = global::WifiScanner.Properties.Resources.agt_upgrade_misc;
            this.labelDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDownload.Name = "labelDownload";
            this.labelDownload.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.labelDownload.Size = new System.Drawing.Size(100, 17);
            this.labelDownload.Text = "0.00 Kb/s";
            this.labelDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // toolStripStatusLabel3
            //
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel3.Text = "Sent:";
            //
            // labelBytesSent
            //
            this.labelBytesSent.AutoSize = false;
            this.labelBytesSent.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.labelBytesSent.Name = "labelBytesSent";
            this.labelBytesSent.Size = new System.Drawing.Size(80, 17);
            this.labelBytesSent.Text = "0.00 Kb";
            this.labelBytesSent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // toolStripStatusLabel5
            //
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel5.Text = "Received:";
            //
            // labelBytesReceived
            //
            this.labelBytesReceived.AutoSize = false;
            this.labelBytesReceived.Name = "labelBytesReceived";
            this.labelBytesReceived.Size = new System.Drawing.Size(80, 17);
            this.labelBytesReceived.Text = "0.00 Kb";
            this.labelBytesReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // toolStripStatusLabel7
            //
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel7.Text = "Total:";
            //
            // labelTotal
            //
            this.labelTotal.AutoSize = false;
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(80, 17);
            this.labelTotal.Text = "0.00 Kb";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // sbProgressBar
            //
            this.sbProgressBar.AutoToolTip = true;
            this.sbProgressBar.Name = "sbProgressBar";
            this.sbProgressBar.Size = new System.Drawing.Size(100, 16);
            //
            // splitContainer1
            //
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            this.splitContainer1.Panel1.Controls.Add(this.listViewAccessPoints);
            //
            // splitContainer1.Panel2
            //
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 393);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1_SplitterMoved);
            //
            // listViewAccessPoints
            //
            this.listViewAccessPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SSID,
            this.MAC,
            this.SignalQuality,
            this.dbm,
            this.Channel,
            this.Encryption,
            this.Authentication});
            this.listViewAccessPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAccessPoints.Location = new System.Drawing.Point(0, 0);
            this.listViewAccessPoints.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewAccessPoints.Name = "listViewAccessPoints";
            this.listViewAccessPoints.Size = new System.Drawing.Size(760, 133);
            this.listViewAccessPoints.TabIndex = 4;
            this.listViewAccessPoints.UseCompatibleStateImageBehavior = false;
            this.listViewAccessPoints.View = System.Windows.Forms.View.Details;
            //
            // SSID
            //
            this.SSID.Text = "SSID";
            this.SSID.Width = 124;
            //
            // MAC
            //
            this.MAC.Text = "MAC";
            this.MAC.Width = 124;
            //
            // SignalQuality
            //
            this.SignalQuality.Text = "SignalQuality";
            this.SignalQuality.Width = 96;
            //
            // dbm
            //
            this.dbm.Text = "dbm";
            this.dbm.Width = 80;
            //
            // Channel
            //
            this.Channel.Text = "Channel";
            this.Channel.Width = 78;
            //
            // Encryption
            //
            this.Encryption.Text = "Encryption";
            this.Encryption.Width = 96;
            //
            // Authentication
            //
            this.Authentication.Text = "Authentication";
            this.Authentication.Width = 124;
            //
            // pictureBox1
            //
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            //
            // tabControl1
            //
            this.tabControl1.Controls.Add(this.tabPageConnection);
            this.tabControl1.Controls.Add(this.tabPageWifi);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 429);
            this.tabControl1.TabIndex = 8;
            //
            // tabPageWifi
            //
            this.tabPageWifi.Controls.Add(this.splitContainer1);
            this.tabPageWifi.Location = new System.Drawing.Point(4, 26);
            this.tabPageWifi.Name = "tabPageWifi";
            this.tabPageWifi.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWifi.Size = new System.Drawing.Size(766, 399);
            this.tabPageWifi.TabIndex = 0;
            this.tabPageWifi.Text = "Wi-Fi List";
            this.tabPageWifi.UseVisualStyleBackColor = true;
            //
            // tabPageConnection
            //
            this.tabPageConnection.Controls.Add(this.panel1);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 26);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(766, 399);
            this.tabPageConnection.TabIndex = 1;
            this.tabPageConnection.Text = "Current Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.labelStrength);
            this.panel1.Controls.Add(this.labelMac);
            this.panel1.Controls.Add(this.labelSsid);
            this.panel1.Controls.Add(this.labelType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbAdaptersList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 163);
            this.panel1.TabIndex = 0;
            //
            // cbAdaptersList
            //
            this.cbAdaptersList.FormattingEnabled = true;
            this.cbAdaptersList.Location = new System.Drawing.Point(11, 12);
            this.cbAdaptersList.Name = "cbAdaptersList";
            this.cbAdaptersList.Size = new System.Drawing.Size(230, 25);
            this.cbAdaptersList.TabIndex = 0;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interfece:";
            //
            // labelType
            //
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(108, 48);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 17);
            this.labelType.TabIndex = 2;
            this.labelType.Text = "N/A";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "SSID:";
            //
            // labelSsid
            //
            this.labelSsid.AutoSize = true;
            this.labelSsid.Location = new System.Drawing.Point(108, 76);
            this.labelSsid.Name = "labelSsid";
            this.labelSsid.Size = new System.Drawing.Size(31, 17);
            this.labelSsid.TabIndex = 2;
            this.labelSsid.Text = "N/A";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "MAC Address:";
            //
            // labelMac
            //
            this.labelMac.AutoSize = true;
            this.labelMac.Location = new System.Drawing.Point(108, 104);
            this.labelMac.Name = "labelMac";
            this.labelMac.Size = new System.Drawing.Size(31, 17);
            this.labelMac.TabIndex = 2;
            this.labelMac.Text = "N/A";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Strength:";
            //
            // labelStrength
            //
            this.labelStrength.AutoSize = true;
            this.labelStrength.Location = new System.Drawing.Point(108, 132);
            this.labelStrength.Name = "labelStrength";
            this.labelStrength.Size = new System.Drawing.Size(31, 17);
            this.labelStrength.TabIndex = 2;
            this.labelStrength.Text = "N/A";
            //
            // Main
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wi-Fi Scanner";
            this.Load += new System.EventHandler(this.FormScanner_Load);
            this.Shown += new System.EventHandler(this.FormScanner_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageWifi.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelUpload;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewAccessPoints;
        private System.Windows.Forms.ColumnHeader SSID;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.ColumnHeader SignalQuality;
        private System.Windows.Forms.ColumnHeader dbm;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.ColumnHeader Encryption;
        private System.Windows.Forms.ColumnHeader Authentication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel labelDownload;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel labelBytesSent;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel labelBytesReceived;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThirtySecMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OneMinMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FiveMinMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TenMinMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem FreezeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OnTopMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel labelTotal;
        private System.Windows.Forms.ToolStripProgressBar sbProgressBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWifi;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbAdaptersList;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStrength;
        private System.Windows.Forms.Label labelMac;
        private System.Windows.Forms.Label labelSsid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }

    // Исправление мигания ListView
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }

}

