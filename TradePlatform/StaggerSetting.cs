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
    public partial class StaggerSetting : Form
    {
        public StaggeringSystem StaggeringSystem { get; set; }
        public StaggerSetting(StaggeringSystem staggeringSystem)
        {
            this.StaggeringSystem = staggeringSystem;
            InitializeComponent();

            tbStep1ContractQuantity.Text = staggeringSystem.StepConfig[1].contractQuantity.ToString();
            tbStep1ProfitTaker.Text = staggeringSystem.StepConfig[1].ProfitTakerAmount.ToString();
            tbStep1StopLoss.Text = staggeringSystem.StepConfig[1].StopLossAmount.ToString();

            tbStep2ContractQuantity.Text = staggeringSystem.StepConfig[2].contractQuantity.ToString();
            tbStep2ProfitTaker.Text = staggeringSystem.StepConfig[2].ProfitTakerAmount.ToString();
            tbStep2StopLoss.Text = staggeringSystem.StepConfig[2].StopLossAmount.ToString();

            tbStep3ContractQuantity.Text = staggeringSystem.StepConfig[3].contractQuantity.ToString();
            tbStep3ProfitTaker.Text = staggeringSystem.StepConfig[3].ProfitTakerAmount.ToString();
            tbStep3StopLoss.Text = staggeringSystem.StepConfig[3].StopLossAmount.ToString();

            tbStep4ContractQuantity.Text = staggeringSystem.StepConfig[4].contractQuantity.ToString();
            tbStep4ProfitTaker.Text = staggeringSystem.StepConfig[4].ProfitTakerAmount.ToString();
            tbStep4StopLoss.Text = staggeringSystem.StepConfig[4].StopLossAmount.ToString();



        }

        private void TbStep1ContractQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep1ContractQuantity);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[1].contractQuantity = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep1ContractQuantity.Text = StaggeringSystem.StepConfig[1].contractQuantity.ToString();
            }
        }

        private void TbStep1ProfitTaker_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep1ProfitTaker);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[1].ProfitTakerAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep1ProfitTaker.Text = StaggeringSystem.StepConfig[1].ProfitTakerAmount.ToString();
            }
        }

        private void TbStep1StopLoss_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep1StopLoss);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[1].StopLossAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep1StopLoss.Text = StaggeringSystem.StepConfig[1].StopLossAmount.ToString();
            }
        }

        private void TbStep2ContractQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep2ContractQuantity);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[2].contractQuantity = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep2ContractQuantity.Text = StaggeringSystem.StepConfig[2].contractQuantity.ToString();
            }
        }

        private void TbStep2ProfitTaker_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep2ProfitTaker);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[2].ProfitTakerAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep2ProfitTaker.Text = StaggeringSystem.StepConfig[2].ProfitTakerAmount.ToString();
            }
        }

        private void TbStep2StopLoss_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep2StopLoss);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[2].StopLossAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep2StopLoss.Text = StaggeringSystem.StepConfig[2].StopLossAmount.ToString();
            }
        }

        private void TbStep3ContractQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep3ContractQuantity);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[3].contractQuantity = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep3ContractQuantity.Text = StaggeringSystem.StepConfig[3].contractQuantity.ToString();
            }
        }

        private void TbStep3ProfitTaker_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep3ProfitTaker);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[3].ProfitTakerAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep3ProfitTaker.Text = StaggeringSystem.StepConfig[3].ProfitTakerAmount.ToString();
            }
        }

        private void TbStep3StopLoss_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep3StopLoss);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[3].StopLossAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep3StopLoss.Text = StaggeringSystem.StepConfig[3].StopLossAmount.ToString();
            }
        }

        private void TbStep4ContractQuantity_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep4ContractQuantity);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[4].contractQuantity = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep4ContractQuantity.Text = StaggeringSystem.StepConfig[4].contractQuantity.ToString();
            }
        }

        private void TbStep4ProfitTaker_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep4ProfitTaker);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[4].ProfitTakerAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep4ProfitTaker.Text = StaggeringSystem.StepConfig[4].ProfitTakerAmount.ToString();
            }
        }

        private void TbStep4StopLoss_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbStep4StopLoss);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                StaggeringSystem.StepConfig[4].StopLossAmount = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbStep4StopLoss.Text = StaggeringSystem.StepConfig[4].StopLossAmount.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            StaggerSetting.ActiveForm.Close();
        }
    }
}
