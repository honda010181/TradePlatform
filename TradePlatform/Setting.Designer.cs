namespace TradePlatform
{
    partial class Setting
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
            this.lbMaxTradePerDay = new System.Windows.Forms.Label();
            this.tbMaxTradePerDay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartTradingHour = new System.Windows.Forms.DateTimePicker();
            this.dtEndTradingHour = new System.Windows.Forms.DateTimePicker();
            this.cbAmibrokerMonitor = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTradeDirection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbMaxTradePerDay
            // 
            this.lbMaxTradePerDay.AutoSize = true;
            this.lbMaxTradePerDay.Location = new System.Drawing.Point(41, 59);
            this.lbMaxTradePerDay.Name = "lbMaxTradePerDay";
            this.lbMaxTradePerDay.Size = new System.Drawing.Size(102, 13);
            this.lbMaxTradePerDay.TabIndex = 0;
            this.lbMaxTradePerDay.Text = "Max Trade Per Day:";
            this.lbMaxTradePerDay.Click += new System.EventHandler(this.Label1_Click);
            // 
            // tbMaxTradePerDay
            // 
            this.tbMaxTradePerDay.Location = new System.Drawing.Point(163, 52);
            this.tbMaxTradePerDay.Name = "tbMaxTradePerDay";
            this.tbMaxTradePerDay.Size = new System.Drawing.Size(100, 20);
            this.tbMaxTradePerDay.TabIndex = 1;
            this.tbMaxTradePerDay.TextChanged += new System.EventHandler(this.TbMaxTradePerDay_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Trading Hour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Trading Hour";
            // 
            // dtStartTradingHour
            // 
            this.dtStartTradingHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTradingHour.Location = new System.Drawing.Point(163, 100);
            this.dtStartTradingHour.Name = "dtStartTradingHour";
            this.dtStartTradingHour.Size = new System.Drawing.Size(100, 20);
            this.dtStartTradingHour.TabIndex = 6;
            this.dtStartTradingHour.Value = new System.DateTime(2020, 2, 23, 17, 56, 38, 0);
            this.dtStartTradingHour.ValueChanged += new System.EventHandler(this.DtStartTradingHour_ValueChanged);
            // 
            // dtEndTradingHour
            // 
            this.dtEndTradingHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndTradingHour.Location = new System.Drawing.Point(163, 142);
            this.dtEndTradingHour.Name = "dtEndTradingHour";
            this.dtEndTradingHour.Size = new System.Drawing.Size(100, 20);
            this.dtEndTradingHour.TabIndex = 7;
            this.dtEndTradingHour.Value = new System.DateTime(2020, 2, 23, 17, 56, 38, 0);
            this.dtEndTradingHour.ValueChanged += new System.EventHandler(this.DtEndTradingHour_ValueChanged);
            // 
            // cbAmibrokerMonitor
            // 
            this.cbAmibrokerMonitor.AutoSize = true;
            this.cbAmibrokerMonitor.Location = new System.Drawing.Point(163, 188);
            this.cbAmibrokerMonitor.Name = "cbAmibrokerMonitor";
            this.cbAmibrokerMonitor.Size = new System.Drawing.Size(115, 17);
            this.cbAmibrokerMonitor.TabIndex = 8;
            this.cbAmibrokerMonitor.Text = "Monitor Ami Borker";
            this.cbAmibrokerMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbAmibrokerMonitor.UseVisualStyleBackColor = true;
            this.cbAmibrokerMonitor.CheckedChanged += new System.EventHandler(this.CbAmibrokerMonitor_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Trade Direction:";
            // 
            // cbTradeDirection
            // 
            this.cbTradeDirection.FormattingEnabled = true;
            this.cbTradeDirection.Location = new System.Drawing.Point(163, 217);
            this.cbTradeDirection.Name = "cbTradeDirection";
            this.cbTradeDirection.Size = new System.Drawing.Size(121, 21);
            this.cbTradeDirection.TabIndex = 11;
            this.cbTradeDirection.SelectedIndexChanged += new System.EventHandler(this.cbTradeDirection_SelectedIndexChanged);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 467);
            this.Controls.Add(this.cbTradeDirection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbAmibrokerMonitor);
            this.Controls.Add(this.dtEndTradingHour);
            this.Controls.Add(this.dtStartTradingHour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMaxTradePerDay);
            this.Controls.Add(this.lbMaxTradePerDay);
            this.Name = "Setting";
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaxTradePerDay;
        private System.Windows.Forms.TextBox tbMaxTradePerDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartTradingHour;
        private System.Windows.Forms.DateTimePicker dtEndTradingHour;
        private System.Windows.Forms.CheckBox cbAmibrokerMonitor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTradeDirection;
    }
}