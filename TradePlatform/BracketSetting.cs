using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradePlatform.TradeSystems;
using TradePlatformHelper;
namespace TradePlatform
{
    public partial class BracketSetting : Form
    {
        public BracketSystem bracketSystem { get; set; }
        public BracketSetting(BracketSystem bracketSystem)
        {
            this.bracketSystem = bracketSystem;
            InitializeComponent();
            tbContractQuantity.Text = bracketSystem.ContractQuantity.ToString();
            tbProfitTaker.Text = bracketSystem.ProfitTakerAmount.ToString();
            tbStopLoss.Text = bracketSystem.StopAmount.ToString();
        }

        private void TbContractQuantity_TextChanged(object sender, EventArgs e)
        {
            if (ApplicationHelper.IsInteger(tbContractQuantity.Text.ToString()))
            {
                bracketSystem.ContractQuantity = int.Parse(tbContractQuantity.Text.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbContractQuantity.Text = bracketSystem.ContractQuantity.ToString();
            }

        }

        private void TbProfitTaker_TextChanged(object sender, EventArgs e)
        {
            if (ApplicationHelper.IsInteger(tbProfitTaker.Text.ToString()))
            {
                bracketSystem.ProfitTakerAmount = int.Parse(tbProfitTaker.Text.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbProfitTaker.Text = bracketSystem.ProfitTakerAmount.ToString();
            }
        }

        private void TbStopLoss_TextChanged(object sender, EventArgs e)
        {
            if (ApplicationHelper.IsInteger(tbStopLoss.Text.ToString()))
            {
                bracketSystem.StopAmount = int.Parse(tbStopLoss.Text.ToString());
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStopLoss.Text = bracketSystem.StopAmount.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BracketSetting.ActiveForm.Close();
        }
    }
}
