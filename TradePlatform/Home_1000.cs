using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradePlatformHelper;
using IBSampleApp;
using IBApi;
using IBSampleApp.messages;
using System.IO;
using TradePlatformHelper.Objects;
using Microsoft.VisualBasic;
namespace TradePlatform
{
    public partial class Home_1000 : Form
    {
 

        private EReaderMonitorSignal signal = new EReaderMonitorSignal();
        private IBClient ibClient;
        private bool IsConnected { get; set; }
        private List<AContract> AContracts = new List<AContract>();
        
        private string signalPath;
        private string ContractLog;
        private int CurrentOrderID;
        private int SleepSeconds;
        private bool KeepRunning;
        private string Mode;
        private string ApplicationLogFolder;
        private string EngineStatus;
        private List<string> AllowedContractList = new List<string>();
        private int DelayTolerance;
        public Home_1000()
        {
            InitializeComponent();
            ibClient = new IBClient(signal);
            EngineStatus = ApplicationHelper.STOP;
            LoadConfig();

            ibClient.Error += ibClient_Error;
            ibClient.ConnectionClosed += ibClient_ConnectionClosed;


            ibClient.ContractDetails += HandleContractDetails;
            ibClient.ContractDetailsEnd += reqId => UpdateUI(new ContractDetailsEndMessage());


            ibClient.OrderStatus += HandleOrderStatus;
            ibClient.OpenOrder += HandleOpenOrder;


            InitializedControls();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string host;
            int clientID;
            int port;



            if (tbHost.Text.Trim().Length == 0)
            {
                MessageBox.Show("Enter host address.");
                return;
            }
            int.TryParse(tbClientID.Text,out clientID);
            int.TryParse(tbPort.Text, out port);
            host = tbHost.Text;
            

            try
            {
 
                ibClient.ClientId = clientID;
                ibClient.ClientSocket.eConnect(host, port, ibClient.ClientId);

                if (!ibClient.ClientSocket.IsConnected())
                {
                    MessageBox.Show("Unable to connect");
                    return;
                }
                var reader = new EReader(ibClient.ClientSocket, signal);

                reader.Start();
                new Thread(() => { while (ibClient.ClientSocket.IsConnected()) { signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();
 
                 
            }
            catch (Exception)
            {
                MessageBox.Show("Fuck ");
                //HandleErrorMessage(new ErrorMessage(-1, -1, "Please check your connection attributes."));
            }
 
        }
 

        private void Button1_Click(object sender, EventArgs e)
        {
            IBApi.Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LocalSymbol = "ESM9";

            ibClient.ClientSocket.reqContractDetails(1, contract);
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {

            IBApi.Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LocalSymbol = "ESM9";

            PlaceBracketOrder(contract);
        }


        #region "Handle Connection"
        void ibClient_ConnectionClosed()
        {
            IsConnected = false;
             
        }

        void ibClient_Error(int id, int errorCode, string str, Exception ex)
        {
            if (ex != null)
            {
 
                ApplicationHelper.log(ref tbLog,"Error: " + ex.ToString());
                return;
            }

            if (id == 0 || errorCode == 0)
            {
                 ApplicationHelper.log(ref tbLog, "Error: "  +str);
                return;
            }
            ApplicationHelper.log(ref tbLog, str);
            ErrorMessage error = new ErrorMessage(id, errorCode, str);

            HandleErrorMessage(error);
        }
        private void HandleErrorMessage(ErrorMessage message)
        {
            //ShowMessageOnPanel("Request " + message.RequestId + ", Code: " + message.ErrorCode + " - " + message.Message);

            //if (message.RequestId > MarketDataManager.TICK_ID_BASE && message.RequestId < DeepBookManager.TICK_ID_BASE)
            //    marketDataManager.NotifyError(message.RequestId);
            //else if (message.RequestId > DeepBookManager.TICK_ID_BASE && message.RequestId < HistoricalDataManager.HISTORICAL_ID_BASE)
            //{
            //    if (message.ErrorCode != 2151)
            //    {
            //        deepBookManager.NotifyError(message.RequestId);
            //    }
            //}
            //else if (message.RequestId == ContractManager.CONTRACT_DETAILS_ID)
            //{
            //    contractManager.HandleRequestError(message.RequestId);
            //    searchContractDetails.Enabled = true;
            //}
            //else if (message.RequestId == ContractManager.FUNDAMENTALS_ID)
            //{
            //    contractManager.HandleRequestError(message.RequestId);
            //    fundamentalsQueryButton.Enabled = true;
            //}
            //else if (message.RequestId == OptionsManager.OPTIONS_ID_BASE)
            //{
            //    optionsManager.Clear();
            //    queryOptionChain.Enabled = true;
            //}
            //else if (message.RequestId > OptionsManager.OPTIONS_ID_BASE)
            //{
            //    queryOptionChain.Enabled = true;
            //}
            //if (message.ErrorCode == 202)
            //{
            //}
        }

        private void HandleContractDetails(ContractDetailsMessage message)
        {
            string str;

            str = string.Format("Order ID: {0} - Parent Order ID: {1} - Status: {2}", message.RequestId, message.ContractDetails.Contract.Symbol, message.ContractDetails.Contract.LocalSymbol,message.ContractDetails);
            ApplicationHelper.log(ref tbLog, str);
        }
        private void HandleContractDetailsEnd(ContractDetailsEndMessage message)
        {

        }

        private void UpdateUI(ContractDetailsEndMessage message)
        {
            HandleContractDetailsEnd(message);
        }


        private void HandleOrderStatus(OrderStatusMessage statusMessage)
        {
            string str;

            str = string.Format("Order ID: {0} - Parent Order ID: {1} - Status: {2}", statusMessage.OrderId, statusMessage.ParentId, statusMessage.Status);
            ApplicationHelper.log(ref tbLog, str);

            CurrentOrderID = statusMessage.OrderId > CurrentOrderID ? statusMessage.OrderId : CurrentOrderID;
        }
        private void HandleOpenOrder(OpenOrderMessage openOrder)
        {
            string str;

            str = string.Format("Order ID: {0} - Contract: {1} - Status: {2}", openOrder.OrderId, openOrder.Contract, openOrder.OrderState);
            ApplicationHelper.log(ref tbLog, str);
            CurrentOrderID = openOrder.OrderId > CurrentOrderID ? openOrder.OrderId : CurrentOrderID;
        }

        #endregion

        private void BtnEngine_Click(object sender, EventArgs e)
        {

            if (EngineStatus.Equals(ApplicationHelper.RUNNING) && btnEngine.Text.Equals("Start Engine"))
            {
                MessageBox.Show("Only one engine allow.");
                return;
            }
            if (EngineStatus.Equals(ApplicationHelper.STOP))
            {

                if (AllowedContractList.Count == 0 && lbAllowedContract.Enabled)
                {
                    DialogResult result = MessageBox.Show("There is no contract selected to trade. Do you want to continue?", "Select Allowed Contracts", MessageBoxButtons.YesNo);

                    if (!result.ToString().ToUpper().Equals(ApplicationHelper.YES))
                    {
                        return;
                    }
                }

                //Once engine start, do not allow to change selected contracts;
                lbAllowedContract.Enabled = false;
                ApplicationHelper.log(ref tbLog, "Allowed Contracts");
                foreach (string s in AllowedContractList)
                {
                    ApplicationHelper.log(ref tbLog, s);
                }
                ApplicationHelper.log(ref tbLog, "DelayTolerance: " + DelayTolerance);


                btnEngine.Text = "Stop Engine";
                KeepRunning = true;
                Task t = Task.Run(() => RetrieveSignal());                 
            }
            else
            {
                btnEngine.Text ="Start Engine" ;
                KeepRunning = false;

                lbAllowedContract.Enabled = true;
            }
        }



        private void LoadConfig()
        {
            try
            {
                Mode = ApplicationHelper.getConfigValue("Mode");
                if (Mode.Equals(ApplicationHelper.PROD))
                {
                    MessageBox.Show("You are running in PROD");
                    tbMode.Text = Mode;
                    tbMode.BackColor = Color.DeepSkyBlue;
                    tbMode.ForeColor = Color.White;
                    tbMode.Enabled = false;
                }
                else
                {
                    tbMode.Text = Mode;
                    tbMode.BackColor = Color.Firebrick;
                    tbMode.ForeColor = Color.White;
                    tbMode.Enabled = false;
                }
                signalPath = ApplicationHelper.getConfigValue("SignalPath");
                SleepSeconds = int.Parse(ApplicationHelper.getConfigValue("SleepSeconds"));
                ContractLog = ApplicationHelper.getConfigValue("ContractLog");
                ApplicationLogFolder = ApplicationHelper.getConfigValue("ApplicationLogFolder");
                DelayTolerance = int.Parse(ApplicationHelper.getConfigValue("DelayTolerance"));

                foreach (string s in ApplicationHelper.getConfigValue("AllowedContractList").Split(','))
                {
                    if (! AllowedContractList.Contains(s))
                    {
                        AllowedContractList.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load config");
                ApplicationHelper.log(ref tbLog, "FAIL TO LOAD CONFIG: " + ex.ToString());
                this.Enabled = false;

            }
        }
        #region "Form Events"
        private void Home_1000_FormClosing(object sender, FormClosingEventArgs e)
        {
            string logFileName;

            logFileName = ApplicationLogFolder + DateTime.Now.ToString("yyyy-MM-dd-h-m-s.") + "txt";

            ApplicationHelper.log(logFileName, tbLog.Text);
        }

        private void InitializedControls()
        {
            //Initialize Contract Allowed List Box
            foreach(string s in AllowedContractList)
            {
                lbAllowedContract.Items.Add(s);
            }
            //Once the lbAllowedContract is loaded, clear AllowContractList and drive it by what is selected in the lbAllowedContract
            AllowedContractList.Clear();

        }


        private void LbAllowedContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowedContractList.Clear();
            foreach (string s in lbAllowedContract.SelectedItems)
            {
                if (!AllowedContractList.Contains(s))
                {
                    AllowedContractList.Add(s);
                }
            }
            
        }
        #endregion


        private void RetrieveSignal()
        {

            if (signalPath.Length == 0)
            {
                MessageBox.Show("Unable to locate path. Check if key \"SingalPath\" exists in app config");
                KeepRunning = false;
            }


            if (!File.Exists(signalPath))
            {
                MessageBox.Show(String.Format("The path: {0} does not exist", signalPath));
                KeepRunning = false;
            }

            ApplicationHelper.log(ref tbLog,"Application mode: " + Mode);

            EngineStatus = ApplicationHelper.RUNNING;
            ApplicationHelper.log(ref tbLog, "Engine Starts: " + DateTime.Now.ToString());

            while (KeepRunning)
            {

                try
                {
                    foreach (AContract c in ApplicationHelper.GetAmiSignalContracts(signalPath))
                    {
                        if (!AContracts.Exists(x => x.Symbol == c.Symbol && x.SignalDateTime.Equals(c.SignalDateTime)))
                        {
                            AContracts.Add(c);


                            ApplicationHelper.log(ref tbLog, string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", c.Action, c.Symbol, c.SignalClose, c.SignalDateTime, c.TimeStamp, c.LatestClose, c.LatestDateTime));
 
                            Contract contract = new Contract();

                            contract = ApplicationHelper.BuildContract(c.Symbol);


                            //Check if contract is allowed to trade.
                            if (AllowedContractList.Contains(contract.LocalSymbol))
                            {
                                ApplicationHelper.log(ref tbLog, string.Format("Contract: {0} - {1} - {2} - {3}", contract.LocalSymbol, contract.Exchange, contract.SecType, contract.Currency));

                                //Check if the time delay is valid
                                if (DateAndTime.DateDiff(DateInterval.Minute, c.SignalDateTime, DateAndTime.Now) > DelayTolerance)
                                {
                                    ApplicationHelper.log(ref tbLog, string.Format("ERROR: SIGNAL TOO LATE: Signal: {0} - Current Time: {1} - Delaytolerance: {2}", c.SignalDateTime, DateAndTime.Now, DelayTolerance));
                                    continue;
                                }

                                ApplicationHelper.log(ContractLog, string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", c.Action, c.Symbol, c.SignalClose, c.SignalDateTime, c.TimeStamp, c.LatestClose, c.LatestDateTime));

                                if (Mode.Equals(ApplicationHelper.PROD))
                                {
                                    if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.BUY))
                                    {

                                        PlaceBracketOrder(contract);

                                    }
                                    if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.SELL))
                                    {

                                    }
                                    //In case of multiple signals, sleep 3 seconds
                                    Thread.Sleep(3000);
                                 }
                            }
                            else
                            {
                                ApplicationHelper.log(ref tbLog, string.Format("NOT ALLOWED - TRADE WILL NOT OCCUR - Contract: {0} - {1} - {2} - {3}", contract.LocalSymbol, contract.Exchange, contract.SecType, contract.Currency));
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    KeepRunning = false;
                    ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString());
                }

                Thread.Sleep(SleepSeconds * 1000);

            }
            EngineStatus = ApplicationHelper.STOP;
            ApplicationHelper.log(ref tbLog, "Engine Ends: " + DateTime.Now.ToString());
        }




        private void PlaceBracketOrder(IBApi.Contract contract)
        {
            CurrentOrderID = ibClient.NextOrderId > CurrentOrderID ? ibClient.NextOrderId : CurrentOrderID;

            ApplicationHelper.log(ref tbLog, "ibClient.NextOrderId: " + ibClient.NextOrderId);
            ApplicationHelper.log(ref tbLog, "CurrentOrderID: " + CurrentOrderID);

            List<Order> brackerOrder = ApplicationHelper.BracketOrder(++CurrentOrderID, ApplicationHelper.BUY, 1, 2800, 2801, 2799);

            foreach (Order o in brackerOrder)
            {
                ibClient.ClientSocket.placeOrder(o.OrderId, contract, o);
            }
            CurrentOrderID = CurrentOrderID + 3;
        }
 

    }
}
