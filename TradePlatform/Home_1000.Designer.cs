namespace TradePlatform
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
            this.tbLog = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
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
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 151);
            this.panel1.TabIndex = 0;
            // 
            // btnEngine
            // 
            this.btnEngine.Location = new System.Drawing.Point(527, 116);
            this.btnEngine.Name = "btnEngine";
            this.btnEngine.Size = new System.Drawing.Size(133, 23);
            this.btnEngine.TabIndex = 9;
            this.btnEngine.Text = "Start Engine";
            this.btnEngine.UseVisualStyleBackColor = true;
            this.btnEngine.Click += new System.EventHandler(this.BtnEngine_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(696, 116);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 8;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.BtnBuy_Click);
            // 
            // btnContractDetails
            // 
            this.btnContractDetails.Location = new System.Drawing.Point(696, 75);
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
            this.lbclientID.Location = new System.Drawing.Point(507, 42);
            this.lbclientID.Name = "lbclientID";
            this.lbclientID.Size = new System.Drawing.Size(47, 13);
            this.lbclientID.TabIndex = 6;
            this.lbclientID.Text = "Client ID";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(334, 42);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(26, 13);
            this.lbPort.TabIndex = 5;
            this.lbPort.Text = "Port";
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.Location = new System.Drawing.Point(163, 42);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(29, 13);
            this.lbHost.TabIndex = 4;
            this.lbHost.Text = "Host";
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(560, 37);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(100, 20);
            this.tbClientID.TabIndex = 3;
            this.tbClientID.Text = "1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(388, 37);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "7497";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(198, 37);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 20);
            this.tbHost.TabIndex = 1;
            this.tbHost.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(696, 34);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(37, 226);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(748, 361);
            this.tbLog.TabIndex = 1;
            // 
            // Home_1000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 656);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.panel1);
            this.Name = "Home_1000";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_1000_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnEngine;
    }
}

