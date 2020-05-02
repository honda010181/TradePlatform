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
using Microsoft.VisualBasic;
namespace TradePlatform
{
    public partial class Setting : Form
    {
        public int MaxTradePerDay { get; set; }
        public string StartTradingHour { get; set; }
        public string EndTradinghour { get; set; }

        public Boolean MonitorAmiBroker { get; set; }

        public string TradeDirection { get; set; }
        public Setting()
        {
            InitializeComponent();
        }

        public Setting(int maxTradePerDay, string StartTradingHour, string EndTradingHour, Boolean MonitorAmiBroker, string TradeDirection)
        {
            InitializeComponent();
            InitializeControls();
            tbMaxTradePerDay.Text = maxTradePerDay.ToString();
            dtStartTradingHour.Text = DateAndTime.TimeValue(StartTradingHour).TimeOfDay.ToString();
            dtEndTradingHour.Text = DateAndTime.TimeValue(EndTradingHour).TimeOfDay.ToString();
            cbAmibrokerMonitor.Checked = MonitorAmiBroker;
            cbTradeDirection.Text = TradeDirection;
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeControls()
        {
            List<string> tradeDirection = new List<string>();
            tradeDirection.Add("BOTH");
            tradeDirection.Add("BUY");
            tradeDirection.Add("SELL");

            //cboTradeDirection.DataSource = tradeDirection;

            cbTradeDirection.DataSource = tradeDirection;
            tradeDirection.Clear();
        }
        private void TbMaxTradePerDay_TextChanged(object sender, EventArgs e)
        {
            int value = ApplicationHelper.GetIntegerFromTextBox(ref tbMaxTradePerDay);

            if (value != ApplicationHelper.ERROR_CODE)
            {
                MaxTradePerDay = value;
            }
            else
            {
                MessageBox.Show("Invalid Integer Value");
                tbMaxTradePerDay.Text = MaxTradePerDay.ToString();
            }
        }

        private void DtStartTradingHour_ValueChanged(object sender, EventArgs e)
        {
            string time;
            try
            {
                time = dtStartTradingHour.Value.TimeOfDay.ToString();
                StartTradingHour = time;
            }
            catch
            {
                MessageBox.Show("Invalid Time Value");
            }

        }

        private void DtEndTradingHour_ValueChanged(object sender, EventArgs e)
        {
            string time;
            try
            {
                time = dtEndTradingHour.Value.TimeOfDay.ToString();
                EndTradinghour = time;
            }
            catch
            {
                MessageBox.Show("Invalid Time Value");
            }

        }

        private void CbAmibrokerMonitor_CheckedChanged(object sender, EventArgs e)
        {
            this.MonitorAmiBroker = cbAmibrokerMonitor.Checked;
        }

        private void cbTradeDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TradeDirection = cbTradeDirection.Text;
        }
    }
}
