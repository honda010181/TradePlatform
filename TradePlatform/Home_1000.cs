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
        private int EngineCount = 0;

        private string EngineStatus;
        public Home_1000()
        {
            InitializeComponent();
            ibClient = new IBClient(signal);
            CurrentOrderID = ibClient.NextOrderId;
            EngineStatus = ApplicationHelper.STOP;
            LoadConfig();

            ibClient.Error += ibClient_Error;
            ibClient.ConnectionClosed += ibClient_ConnectionClosed;


            ibClient.ContractDetails += HandleContractDetails;
            ibClient.ContractDetailsEnd += reqId => UpdateUI(new ContractDetailsEndMessage());


            ibClient.OrderStatus += HandleOrderStatus;
            ibClient.OpenOrder += HandleOpenOrder;

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
            Order order = new Order();
            order.Action = "buy";
            order.OrderType = "MKT";
            order.TotalQuantity = 1;

            IBApi.Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LocalSymbol = "ESM9";


            ibClient.ClientSocket.reqIds(-1);
 
            List<Order> brackerOrder = ApplicationHelper.BracketOrder(CurrentOrderID, ApplicationHelper.BUY, 1, 2800, 2801, 2799);
            CurrentOrderID = CurrentOrderID + 3;
            //ibClient.ClientSocket.placeOrder(12,contract, brackerOrder);

 
            foreach (Order o in brackerOrder)
            {
                ibClient.ClientSocket.placeOrder(o.OrderId, contract, o);
            }
             
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
        }
        private void HandleOpenOrder(OpenOrderMessage openOrder)
        {
            string str;

            str = string.Format("Order ID: {0} - Contract: {1} - Status: {2}", openOrder.OrderId, openOrder.Contract, openOrder.OrderState);
            ApplicationHelper.log(ref tbLog, str);
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
                btnEngine.Text = "Stop Engine";
                KeepRunning = true;
                Task t = Task.Run(() => RetrieveSignal());
                 
            }
            else
            {
                btnEngine.Text ="Start Engine" ;
                KeepRunning = false;
            }
        }



        private void LoadConfig()
        {
            try
            {
                signalPath = ApplicationHelper.getConfigValue("SignalPath");
                SleepSeconds = int.Parse(ApplicationHelper.getConfigValue("SleepSeconds"));
                ContractLog = ApplicationHelper.getConfigValue("ContractLog");
                Mode = ApplicationHelper.getConfigValue("Mode");
                KeepRunning = true;
            }
            catch (Exception ex)
            {

                //Stop the app if config fails to load.
                KeepRunning = false;
                ApplicationHelper.log(ref tbLog, "FAIL TO LOAD CONFIG: " + ex.ToString());
            }
        }
        #region "Form Events"
        private void Home_1000_FormClosing(object sender, FormClosingEventArgs e)
        {
            ibClient.NextOrderId = CurrentOrderID;
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
                        if (!AContracts.Exists(x => x.Symbol == c.Symbol && x.DateTime.Equals(c.DateTime)))
                        {
                            AContracts.Add(c);
                            ApplicationHelper.log(ContractLog, string.Format("{0} - {1} - {2} - {3}", c.Symbol, c.Close, c.DateTime, c.TimeStamp));

                            ApplicationHelper.log(ref tbLog, string.Format("{0} - {1} - {2} - {3} - {4}",c.Action, c.Symbol, c.Close, c.DateTime, c.TimeStamp));

                            if (Mode.Equals(ApplicationHelper.PROD))
                            {
                                if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.BUY))
                                {
                                
                                }
                                if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.SELL))
                                {

                                }
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
    }
}
