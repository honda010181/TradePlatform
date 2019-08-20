namespace TradePlatform
{
    partial class BracketSetting
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
            this.lbContractQuantity = new System.Windows.Forms.Label();
            this.lbProfitTakerAmount = new System.Windows.Forms.Label();
            this.lbStopLossAmount = new System.Windows.Forms.Label();
            this.tbContractQuantity = new System.Windows.Forms.TextBox();
            this.tbProfitTaker = new System.Windows.Forms.TextBox();
            this.tbStopLoss = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbContractQuantity
            // 
            this.lbContractQuantity.AutoSize = true;
            this.lbContractQuantity.Location = new System.Drawing.Point(44, 63);
            this.lbContractQuantity.Name = "lbContractQuantity";
            this.lbContractQuantity.Size = new System.Drawing.Size(89, 13);
            this.lbContractQuantity.TabIndex = 0;
            this.lbContractQuantity.Text = "Contract Quantity";
            // 
            // lbProfitTakerAmount
            // 
            this.lbProfitTakerAmount.AutoSize = true;
            this.lbProfitTakerAmount.Location = new System.Drawing.Point(44, 105);
            this.lbProfitTakerAmount.Name = "lbProfitTakerAmount";
            this.lbProfitTakerAmount.Size = new System.Drawing.Size(101, 13);
            this.lbProfitTakerAmount.TabIndex = 1;
            this.lbProfitTakerAmount.Text = "Profit Taker Amount";
            // 
            // lbStopLossAmount
            // 
            this.lbStopLossAmount.AutoSize = true;
            this.lbStopLossAmount.Location = new System.Drawing.Point(44, 147);
            this.lbStopLossAmount.Name = "lbStopLossAmount";
            this.lbStopLossAmount.Size = new System.Drawing.Size(93, 13);
            this.lbStopLossAmount.TabIndex = 2;
            this.lbStopLossAmount.Text = "Stop Loss Amount";
            // 
            // tbContractQuantity
            // 
            this.tbContractQuantity.Location = new System.Drawing.Point(151, 56);
            this.tbContractQuantity.Name = "tbContractQuantity";
            this.tbContractQuantity.Size = new System.Drawing.Size(100, 20);
            this.tbContractQuantity.TabIndex = 3;
            this.tbContractQuantity.TextChanged += new System.EventHandler(this.TbContractQuantity_TextChanged);
            // 
            // tbProfitTaker
            // 
            this.tbProfitTaker.Location = new System.Drawing.Point(151, 98);
            this.tbProfitTaker.Name = "tbProfitTaker";
            this.tbProfitTaker.Size = new System.Drawing.Size(100, 20);
            this.tbProfitTaker.TabIndex = 4;
            this.tbProfitTaker.TextChanged += new System.EventHandler(this.TbProfitTaker_TextChanged);
            // 
            // tbStopLoss
            // 
            this.tbStopLoss.Location = new System.Drawing.Point(151, 140);
            this.tbStopLoss.Name = "tbStopLoss";
            this.tbStopLoss.Size = new System.Drawing.Size(100, 20);
            this.tbStopLoss.TabIndex = 5;
            this.tbStopLoss.TextChanged += new System.EventHandler(this.TbStopLoss_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(151, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BracketSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 241);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbStopLoss);
            this.Controls.Add(this.tbProfitTaker);
            this.Controls.Add(this.tbContractQuantity);
            this.Controls.Add(this.lbStopLossAmount);
            this.Controls.Add(this.lbProfitTakerAmount);
            this.Controls.Add(this.lbContractQuantity);
            this.Name = "BracketSetting";
            this.Text = "BraketSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbContractQuantity;
        private System.Windows.Forms.Label lbProfitTakerAmount;
        private System.Windows.Forms.Label lbStopLossAmount;
        private System.Windows.Forms.TextBox tbContractQuantity;
        private System.Windows.Forms.TextBox tbProfitTaker;
        private System.Windows.Forms.TextBox tbStopLoss;
        private System.Windows.Forms.Button btnSave;
    }
}