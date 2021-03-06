﻿namespace TradePlatform
{
    partial class Home_1000
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTradeSystems = new System.Windows.Forms.GroupBox();
            this.btnChangeSetting = new System.Windows.Forms.Button();
            this.rbBracket = new System.Windows.Forms.RadioButton();
            this.rbStaggering = new System.Windows.Forms.RadioButton();
            this.lbEndTradingHour = new System.Windows.Forms.Label();
            this.lbStartTradingHour = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDelayTolerance = new System.Windows.Forms.TextBox();
            this.lbDelayTolerance = new System.Windows.Forms.Label();
            this.lbSignalPath = new System.Windows.Forms.Label();
            this.btnSignalPath = new System.Windows.Forms.Button();
            this.cbNotification = new System.Windows.Forms.CheckBox();
            this.btnMartketData = new System.Windows.Forms.Button();
            this.tbMode = new System.Windows.Forms.TextBox();
            this.btnEngine = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnContractDetails = new System.Windows.Forms.Button();
            this.lbclientID = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbHost = new System.Windows.Forms.Label();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMusicAlertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAllowedContract = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLastRun = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.dgContract = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gbTradeSystems.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContract)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbTradeSystems);
            this.panel1.Controls.Add(this.lbEndTradingHour);
            this.panel1.Controls.Add(this.lbStartTradingHour);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbDelayTolerance);
            this.panel1.Controls.Add(this.lbDelayTolerance);
            this.panel1.Controls.Add(this.lbSignalPath);
            this.panel1.Controls.Add(this.btnSignalPath);
            this.panel1.Controls.Add(this.cbNotification);
            this.panel1.Controls.Add(this.btnMartketData);
            this.panel1.Controls.Add(this.tbMode);
            this.panel1.Controls.Add(this.btnEngine);
            this.panel1.Controls.Add(this.btnBuy);
            this.panel1.Controls.Add(this.btnContractDetails);
            this.panel1.Controls.Add(this.lbclientID);
            this.panel1.Controls.Add(this.lbPort);
            this.panel1.Controls.Add(this.lbHost);
            this.panel1.Controls.Add(this.tbClientID);
            this.panel1.Controls.Add(this.tbPort);
            this.panel1.Controls.Add(this.tbHost);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 220);
            this.panel1.TabIndex = 0;
            // 
            // gbTradeSystems
            // 
            this.gbTradeSystems.Controls.Add(this.btnChangeSetting);
            this.gbTradeSystems.Controls.Add(this.rbBracket);
            this.gbTradeSystems.Controls.Add(this.rbStaggering);
            this.gbTradeSystems.Location = new System.Drawing.Point(15, 152);
            this.gbTradeSystems.Name = "gbTradeSystems";
            this.gbTradeSystems.Size = new System.Drawing.Size(294, 52);
            this.gbTradeSystems.TabIndex = 24;
            this.gbTradeSystems.TabStop = false;
            this.gbTradeSystems.Text = "Trade Systems";
            // 
            // btnChangeSetting
            // 
            this.btnChangeSetting.Location = new System.Drawing.Point(181, 23);
            this.btnChangeSetting.Name = "btnChangeSetting";
            this.btnChangeSetting.Size = new System.Drawing.Size(79, 23);
            this.btnChangeSetting.TabIndex = 25;
            this.btnChangeSetting.Text = "Setting";
            this.btnChangeSetting.UseVisualStyleBackColor = true;
            this.btnChangeSetting.Click += new System.EventHandler(this.BtnChangeSetting_Click);
            // 
            // rbBracket
            // 
            this.rbBracket.AutoSize = true;
            this.rbBracket.Checked = true;
            this.rbBracket.Location = new System.Drawing.Point(98, 29);
            this.rbBracket.Name = "rbBracket";
            this.rbBracket.Size = new System.Drawing.Size(62, 17);
            this.rbBracket.TabIndex = 1;
            this.rbBracket.TabStop = true;
            this.rbBracket.Text = "Bracket";
            this.rbBracket.UseVisualStyleBackColor = true;
            // 
            // rbStaggering
            // 
            this.rbStaggering.AutoSize = true;
            this.rbStaggering.Location = new System.Drawing.Point(7, 29);
            this.rbStaggering.Name = "rbStaggering";
            this.rbStaggering.Size = new System.Drawing.Size(76, 17);
            this.rbStaggering.TabIndex = 0;
            this.rbStaggering.Text = "Staggering";
            this.rbStaggering.UseVisualStyleBackColor = true;
            // 
            // lbEndTradingHour
            // 
            this.lbEndTradingHour.AutoSize = true;
            this.lbEndTradingHour.Enabled = false;
            this.lbEndTradingHour.Location = new System.Drawing.Point(347, 116);
            this.lbEndTradingHour.Name = "lbEndTradingHour";
            this.lbEndTradingHour.Size = new System.Drawing.Size(52, 13);
            this.lbEndTradingHour.TabIndex = 23;
            this.lbEndTradingHour.Text = "End Hour";
            // 
            // lbStartTradingHour
            // 
            this.lbStartTradingHour.AutoSize = true;
            this.lbStartTradingHour.Location = new System.Drawing.Point(271, 116);
            this.lbStartTradingHour.Name = "lbStartTradingHour";
            this.lbStartTradingHour.Size = new System.Drawing.Size(55, 13);
            this.lbStartTradingHour.TabIndex = 22;
            this.lbStartTradingHour.Text = "Start Hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Trading Hour:";
            // 
            // tbDelayTolerance
            // 
            this.tbDelayTolerance.Location = new System.Drawing.Point(113, 113);
            this.tbDelayTolerance.MaxLength = 2;
            this.tbDelayTolerance.Name = "tbDelayTolerance";
            this.tbDelayTolerance.Size = new System.Drawing.Size(58, 20);
            this.tbDelayTolerance.TabIndex = 16;
            // 
            // lbDelayTolerance
            // 
            this.lbDelayTolerance.AutoSize = true;
            this.lbDelayTolerance.Location = new System.Drawing.Point(12, 116);
            this.lbDelayTolerance.Name = "lbDelayTolerance";
            this.lbDelayTolerance.Size = new System.Drawing.Size(88, 13);
            this.lbDelayTolerance.TabIndex = 15;
            this.lbDelayTolerance.Text = "Delay Tolerance:";
            // 
            // lbSignalPath
            // 
            this.lbSignalPath.AutoSize = true;
            this.lbSignalPath.Location = new System.Drawing.Point(110, 84);
            this.lbSignalPath.Name = "lbSignalPath";
            this.lbSignalPath.Size = new System.Drawing.Size(61, 13);
            this.lbSignalPath.TabIndex = 14;
            this.lbSignalPath.Text = "Signal Path";
            // 
            // btnSignalPath
            // 
            this.btnSignalPath.Location = new System.Drawing.Point(12, 74);
            this.btnSignalPath.Name = "btnSignalPath";
            this.btnSignalPath.Size = new System.Drawing.Size(79, 23);
            this.btnSignalPath.TabIndex = 13;
            this.btnSignalPath.Text = "Signal Path";
            this.btnSignalPath.UseVisualStyleBackColor = true;
            this.btnSignalPath.Click += new System.EventHandler(this.BtnSignalPath_Click);
            // 
            // cbNotification
            // 
            this.cbNotification.AutoSize = true;
            this.cbNotification.Location = new System.Drawing.Point(12, 51);
            this.cbNotification.Name = "cbNotification";
            this.cbNotification.Size = new System.Drawing.Size(79, 17);
            this.cbNotification.TabIndex = 12;
            this.cbNotification.Text = "Notification";
            this.cbNotification.UseVisualStyleBackColor = true;
            this.cbNotification.CheckedChanged += new System.EventHandler(this.CbNotification_CheckedChanged);
            // 
            // btnMartketData
            // 
            this.btnMartketData.Location = new System.Drawing.Point(1129, 88);
            this.btnMartketData.Name = "btnMartketData";
            this.btnMartketData.Size = new System.Drawing.Size(75, 23);
            this.btnMartketData.TabIndex = 11;
            this.btnMartketData.Text = "Market Data";
            this.btnMartketData.UseVisualStyleBackColor = true;
            this.btnMartketData.Click += new System.EventHandler(this.BtnMartketData_Click);
            // 
            // tbMode
            // 
            this.tbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMode.Location = new System.Drawing.Point(0, 24);
            this.tbMode.Name = "tbMode";
            this.tbMode.Size = new System.Drawing.Size(1326, 20);
            this.tbMode.TabIndex = 10;
            this.tbMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEngine
            // 
            this.btnEngine.Location = new System.Drawing.Point(852, 130);
            this.btnEngine.Name = "btnEngine";
            this.btnEngine.Size = new System.Drawing.Size(133, 23);
            this.btnEngine.TabIndex = 9;
            this.btnEngine.Text = "Start Engine";
            this.btnEngine.UseVisualStyleBackColor = true;
            this.btnEngine.Click += new System.EventHandler(this.BtnEngine_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Enabled = false;
            this.btnBuy.Location = new System.Drawing.Point(1021, 130);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 8;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // btnContractDetails
            // 
            this.btnContractDetails.Enabled = false;
            this.btnContractDetails.Location = new System.Drawing.Point(1021, 89);
            this.btnContractDetails.Name = "btnContractDetails";
            this.btnContractDetails.Size = new System.Drawing.Size(75, 23);
            this.btnContractDetails.TabIndex = 7;
            this.btnContractDetails.Text = "Contract Details";
            this.btnContractDetails.UseVisualStyleBackColor = true;
            this.btnContractDetails.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lbclientID
            // 
            this.lbclientID.AutoSize = true;
            this.lbclientID.Location = new System.Drawing.Point(832, 56);
            this.lbclientID.Name = "lbclientID";
            this.lbclientID.Size = new System.Drawing.Size(47, 13);
            this.lbclientID.TabIndex = 6;
            this.lbclientID.Text = "Client ID";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(659, 56);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 5;
            this.lbPort.Text = "Port";
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.Location = new System.Drawing.Point(488, 56);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(29, 13);
            this.lbHost.TabIndex = 4;
            this.lbHost.Text = "Host";
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(885, 51);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(100, 20);
            this.tbClientID.TabIndex = 3;
            this.tbClientID.Text = "1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(713, 51);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "7497";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(523, 51);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 20);
            this.tbHost.TabIndex = 1;
            this.tbHost.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1021, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.alertToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1326, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.settingToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.SettingToolStripMenuItem_Click);
            // 
            // alertToolStripMenuItem
            // 
            this.alertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopMusicAlertToolStripMenuItem});
            this.alertToolStripMenuItem.Name = "alertToolStripMenuItem";
            this.alertToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.alertToolStripMenuItem.Text = "Alert";
            // 
            // stopMusicAlertToolStripMenuItem
            // 
            this.stopMusicAlertToolStripMenuItem.Name = "stopMusicAlertToolStripMenuItem";
            this.stopMusicAlertToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.stopMusicAlertToolStripMenuItem.Text = "Stop Music Alert";
            this.stopMusicAlertToolStripMenuItem.Click += new System.EventHandler(this.StopMusicAlertToolStripMenuItem_Click);
            // 
            // lbAllowedContract
            // 
            this.lbAllowedContract.FormattingEnabled = true;
            this.lbAllowedContract.Location = new System.Drawing.Point(885, 252);
            this.lbAllowedContract.Name = "lbAllowedContract";
            this.lbAllowedContract.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAllowedContract.Size = new System.Drawing.Size(85, 95);
            this.lbAllowedContract.TabIndex = 2;
            this.lbAllowedContract.SelectedIndexChanged += new System.EventHandler(this.LbAllowedContract_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(882, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Contract To Trade";
            // 
            // lbLastRun
            // 
            this.lbLastRun.AutoSize = true;
            this.lbLastRun.Location = new System.Drawing.Point(37, 618);
            this.lbLastRun.Name = "lbLastRun";
            this.lbLastRun.Size = new System.Drawing.Size(56, 13);
            this.lbLastRun.TabIndex = 15;
            this.lbLastRun.Text = "Last Run: ";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(13, 226);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(856, 355);
            this.tbLog.TabIndex = 16;
            this.tbLog.Text = "";
            // 
            // dgContract
            // 
            this.dgContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContract.Location = new System.Drawing.Point(875, 351);
            this.dgContract.Name = "dgContract";
            this.dgContract.Size = new System.Drawing.Size(439, 230);
            this.dgContract.TabIndex = 19;
            // 
            // Home_1000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 656);
            this.Controls.Add(this.dgContract);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lbLastRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAllowedContract);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home_1000";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_1000_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbTradeSystems.ResumeLayout(false);
            this.gbTradeSystems.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContract)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lbclientID;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Button btnContractDetails;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnEngine;
        private System.Windows.Forms.TextBox tbMode;
        private System.Windows.Forms.ListBox lbAllowedContract;
        private System.Windows.Forms.Button btnMartketData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLastRun;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.CheckBox cbNotification;
        private System.Windows.Forms.Label lbSignalPath;
        private System.Windows.Forms.Button btnSignalPath;
        private System.Windows.Forms.TextBox tbDelayTolerance;
        private System.Windows.Forms.Label lbDelayTolerance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbEndTradingHour;
        private System.Windows.Forms.Label lbStartTradingHour;
        private System.Windows.Forms.GroupBox gbTradeSystems;
        private System.Windows.Forms.RadioButton rbBracket;
        private System.Windows.Forms.RadioButton rbStaggering;
        private System.Windows.Forms.Button btnChangeSetting;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopMusicAlertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgContract;
    }
}

