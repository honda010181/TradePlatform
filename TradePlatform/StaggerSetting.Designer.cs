namespace TradePlatform
{
    partial class StaggerSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpStep1 = new System.Windows.Forms.GroupBox();
            this.tbStep1StopLoss = new System.Windows.Forms.TextBox();
            this.tbStep1ProfitTaker = new System.Windows.Forms.TextBox();
            this.tbStep1ContractQuantity = new System.Windows.Forms.TextBox();
            this.gbStep2 = new System.Windows.Forms.GroupBox();
            this.tbStep2StopLoss = new System.Windows.Forms.TextBox();
            this.tbStep2ProfitTaker = new System.Windows.Forms.TextBox();
            this.tbStep2ContractQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpStep3 = new System.Windows.Forms.GroupBox();
            this.tbStep3StopLoss = new System.Windows.Forms.TextBox();
            this.tbStep3ProfitTaker = new System.Windows.Forms.TextBox();
            this.tbStep3ContractQuantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbStep4 = new System.Windows.Forms.GroupBox();
            this.tbStep4StopLoss = new System.Windows.Forms.TextBox();
            this.tbStep4ProfitTaker = new System.Windows.Forms.TextBox();
            this.tbStep4ContractQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpStep1.SuspendLayout();
            this.gbStep2.SuspendLayout();
            this.gpStep3.SuspendLayout();
            this.gbStep4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contract Quantity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Profit Taker:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stop Loss:";
            // 
            // gpStep1
            // 
            this.gpStep1.Controls.Add(this.tbStep1StopLoss);
            this.gpStep1.Controls.Add(this.tbStep1ProfitTaker);
            this.gpStep1.Controls.Add(this.tbStep1ContractQuantity);
            this.gpStep1.Controls.Add(this.label1);
            this.gpStep1.Controls.Add(this.label2);
            this.gpStep1.Controls.Add(this.label3);
            this.gpStep1.Location = new System.Drawing.Point(35, 26);
            this.gpStep1.Name = "gpStep1";
            this.gpStep1.Size = new System.Drawing.Size(324, 112);
            this.gpStep1.TabIndex = 12;
            this.gpStep1.TabStop = false;
            this.gpStep1.Text = "Step 1";
            // 
            // tbStep1StopLoss
            // 
            this.tbStep1StopLoss.Location = new System.Drawing.Point(127, 76);
            this.tbStep1StopLoss.Name = "tbStep1StopLoss";
            this.tbStep1StopLoss.Size = new System.Drawing.Size(100, 20);
            this.tbStep1StopLoss.TabIndex = 5;
            this.tbStep1StopLoss.TextChanged += new System.EventHandler(this.TbStep1StopLoss_TextChanged);
            // 
            // tbStep1ProfitTaker
            // 
            this.tbStep1ProfitTaker.Location = new System.Drawing.Point(127, 47);
            this.tbStep1ProfitTaker.Name = "tbStep1ProfitTaker";
            this.tbStep1ProfitTaker.Size = new System.Drawing.Size(100, 20);
            this.tbStep1ProfitTaker.TabIndex = 4;
            this.tbStep1ProfitTaker.TextChanged += new System.EventHandler(this.TbStep1ProfitTaker_TextChanged);
            // 
            // tbStep1ContractQuantity
            // 
            this.tbStep1ContractQuantity.Location = new System.Drawing.Point(127, 18);
            this.tbStep1ContractQuantity.Name = "tbStep1ContractQuantity";
            this.tbStep1ContractQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbStep1ContractQuantity.TabIndex = 3;
            this.tbStep1ContractQuantity.TextChanged += new System.EventHandler(this.TbStep1ContractQuantity_TextChanged);
            // 
            // gbStep2
            // 
            this.gbStep2.Controls.Add(this.tbStep2StopLoss);
            this.gbStep2.Controls.Add(this.tbStep2ProfitTaker);
            this.gbStep2.Controls.Add(this.tbStep2ContractQuantity);
            this.gbStep2.Controls.Add(this.label4);
            this.gbStep2.Controls.Add(this.label5);
            this.gbStep2.Controls.Add(this.label6);
            this.gbStep2.Location = new System.Drawing.Point(35, 156);
            this.gbStep2.Name = "gbStep2";
            this.gbStep2.Size = new System.Drawing.Size(324, 110);
            this.gbStep2.TabIndex = 13;
            this.gbStep2.TabStop = false;
            this.gbStep2.Text = "Step 2";
            // 
            // tbStep2StopLoss
            // 
            this.tbStep2StopLoss.Location = new System.Drawing.Point(127, 80);
            this.tbStep2StopLoss.Name = "tbStep2StopLoss";
            this.tbStep2StopLoss.Size = new System.Drawing.Size(100, 20);
            this.tbStep2StopLoss.TabIndex = 8;
            this.tbStep2StopLoss.TextChanged += new System.EventHandler(this.TbStep2StopLoss_TextChanged);
            // 
            // tbStep2ProfitTaker
            // 
            this.tbStep2ProfitTaker.Location = new System.Drawing.Point(127, 49);
            this.tbStep2ProfitTaker.Name = "tbStep2ProfitTaker";
            this.tbStep2ProfitTaker.Size = new System.Drawing.Size(100, 20);
            this.tbStep2ProfitTaker.TabIndex = 7;
            this.tbStep2ProfitTaker.TextChanged += new System.EventHandler(this.TbStep2ProfitTaker_TextChanged);
            // 
            // tbStep2ContractQuantity
            // 
            this.tbStep2ContractQuantity.Location = new System.Drawing.Point(127, 19);
            this.tbStep2ContractQuantity.Name = "tbStep2ContractQuantity";
            this.tbStep2ContractQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbStep2ContractQuantity.TabIndex = 6;
            this.tbStep2ContractQuantity.TextChanged += new System.EventHandler(this.TbStep2ContractQuantity_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contract Quantity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Profit Taker:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Stop Loss:";
            // 
            // gpStep3
            // 
            this.gpStep3.Controls.Add(this.tbStep3StopLoss);
            this.gpStep3.Controls.Add(this.tbStep3ProfitTaker);
            this.gpStep3.Controls.Add(this.tbStep3ContractQuantity);
            this.gpStep3.Controls.Add(this.label7);
            this.gpStep3.Controls.Add(this.label8);
            this.gpStep3.Controls.Add(this.label9);
            this.gpStep3.Location = new System.Drawing.Point(35, 292);
            this.gpStep3.Name = "gpStep3";
            this.gpStep3.Size = new System.Drawing.Size(324, 110);
            this.gpStep3.TabIndex = 13;
            this.gpStep3.TabStop = false;
            this.gpStep3.Text = "Step 3";
            // 
            // tbStep3StopLoss
            // 
            this.tbStep3StopLoss.Location = new System.Drawing.Point(127, 76);
            this.tbStep3StopLoss.Name = "tbStep3StopLoss";
            this.tbStep3StopLoss.Size = new System.Drawing.Size(100, 20);
            this.tbStep3StopLoss.TabIndex = 6;
            this.tbStep3StopLoss.TextChanged += new System.EventHandler(this.TbStep3StopLoss_TextChanged);
            // 
            // tbStep3ProfitTaker
            // 
            this.tbStep3ProfitTaker.Location = new System.Drawing.Point(127, 48);
            this.tbStep3ProfitTaker.Name = "tbStep3ProfitTaker";
            this.tbStep3ProfitTaker.Size = new System.Drawing.Size(100, 20);
            this.tbStep3ProfitTaker.TabIndex = 5;
            this.tbStep3ProfitTaker.TextChanged += new System.EventHandler(this.TbStep3ProfitTaker_TextChanged);
            // 
            // tbStep3ContractQuantity
            // 
            this.tbStep3ContractQuantity.Location = new System.Drawing.Point(127, 19);
            this.tbStep3ContractQuantity.Name = "tbStep3ContractQuantity";
            this.tbStep3ContractQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbStep3ContractQuantity.TabIndex = 4;
            this.tbStep3ContractQuantity.TextChanged += new System.EventHandler(this.TbStep3ContractQuantity_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Contract Quantity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Profit Taker:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Stop Loss:";
            // 
            // gbStep4
            // 
            this.gbStep4.Controls.Add(this.tbStep4StopLoss);
            this.gbStep4.Controls.Add(this.tbStep4ProfitTaker);
            this.gbStep4.Controls.Add(this.tbStep4ContractQuantity);
            this.gbStep4.Controls.Add(this.label10);
            this.gbStep4.Controls.Add(this.label11);
            this.gbStep4.Controls.Add(this.label12);
            this.gbStep4.Location = new System.Drawing.Point(35, 424);
            this.gbStep4.Name = "gbStep4";
            this.gbStep4.Size = new System.Drawing.Size(324, 129);
            this.gbStep4.TabIndex = 13;
            this.gbStep4.TabStop = false;
            this.gbStep4.Text = "Step 4";
            // 
            // tbStep4StopLoss
            // 
            this.tbStep4StopLoss.Location = new System.Drawing.Point(127, 78);
            this.tbStep4StopLoss.Name = "tbStep4StopLoss";
            this.tbStep4StopLoss.Size = new System.Drawing.Size(100, 20);
            this.tbStep4StopLoss.TabIndex = 6;
            this.tbStep4StopLoss.TextChanged += new System.EventHandler(this.TbStep4StopLoss_TextChanged);
            // 
            // tbStep4ProfitTaker
            // 
            this.tbStep4ProfitTaker.Location = new System.Drawing.Point(127, 49);
            this.tbStep4ProfitTaker.Name = "tbStep4ProfitTaker";
            this.tbStep4ProfitTaker.Size = new System.Drawing.Size(100, 20);
            this.tbStep4ProfitTaker.TabIndex = 5;
            this.tbStep4ProfitTaker.TextChanged += new System.EventHandler(this.TbStep4ProfitTaker_TextChanged);
            // 
            // tbStep4ContractQuantity
            // 
            this.tbStep4ContractQuantity.Location = new System.Drawing.Point(127, 19);
            this.tbStep4ContractQuantity.Name = "tbStep4ContractQuantity";
            this.tbStep4ContractQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbStep4ContractQuantity.TabIndex = 4;
            this.tbStep4ContractQuantity.TextChanged += new System.EventHandler(this.TbStep4ContractQuantity_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Contract Quantity:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Profit Taker:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Stop Loss:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(162, 581);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // StaggerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 636);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbStep4);
            this.Controls.Add(this.gpStep3);
            this.Controls.Add(this.gbStep2);
            this.Controls.Add(this.gpStep1);
            this.Name = "StaggerSetting";
            this.Text = "StaggerSetting";
            this.gpStep1.ResumeLayout(false);
            this.gpStep1.PerformLayout();
            this.gbStep2.ResumeLayout(false);
            this.gbStep2.PerformLayout();
            this.gpStep3.ResumeLayout(false);
            this.gpStep3.PerformLayout();
            this.gbStep4.ResumeLayout(false);
            this.gbStep4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpStep1;
        private System.Windows.Forms.TextBox tbStep1StopLoss;
        private System.Windows.Forms.TextBox tbStep1ProfitTaker;
        private System.Windows.Forms.TextBox tbStep1ContractQuantity;
        private System.Windows.Forms.GroupBox gbStep2;
        private System.Windows.Forms.TextBox tbStep2StopLoss;
        private System.Windows.Forms.TextBox tbStep2ProfitTaker;
        private System.Windows.Forms.TextBox tbStep2ContractQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gpStep3;
        private System.Windows.Forms.TextBox tbStep3StopLoss;
        private System.Windows.Forms.TextBox tbStep3ProfitTaker;
        private System.Windows.Forms.TextBox tbStep3ContractQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbStep4;
        private System.Windows.Forms.TextBox tbStep4StopLoss;
        private System.Windows.Forms.TextBox tbStep4ProfitTaker;
        private System.Windows.Forms.TextBox tbStep4ContractQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
    }
}