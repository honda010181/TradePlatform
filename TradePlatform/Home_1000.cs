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
using TradePlatform.TradeSystems;

namespace TradePlatform
{
    public partial class Home_1000 : Form
    {
 

        private EReaderMonitorSignal signal = new EReaderMonitorSignal();
        private IBClient ibClient;
        private bool IsConnected { get; set; }
        //private List<AContract> AContracts = new List<AContract>();

 
        private Dictionary<string, object> IBContract = new Dictionary<string, object>();
        
        private BracketSystem BracketSystem;
        private string Notification = ApplicationHelper.Y;
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
        private string FromEmail;
        private string FromEmailPassword;
        private string ToEmail;
        private int MaxTradesPerDay;
        private string StartTradingHour;
        private string EndTradingHour;
        private int DelaySecondUntillSignalValid;
        private bool PositionOpen { get; set; }

        Dictionary<string, object> config;
        float TrailingStopAmount;
        int ContractQuantity;


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

            ibClient.ExecDetails +=  HandleExecutionMessage;
            ibClient.ExecDetailsEnd += reqId => addMessageToLog("ExecDetailsEnd. " + reqId + "\n");


            //Getting snapshot streaming every 11 seconds
            ibClient.TickPrice += ibClient_Tick;
            ibClient.TickSize += ibClient_Tick;
            ibClient.TickString += (tickerId, tickType, value) => addMessageToLog("Tick string. Ticker Id: " + tickerId + " , Type: " + TickType.getField(tickType) + ", Value: " + value + "\n");
            //ibClient.TickGeneric += (tickerId, field, value) => addMessageToLog("Tick Generic. Ticker Id:" + tickerId + ", Field: " + TickType.getField(field) + ", Value: " + value + "\n");
            ibClient.TickEFP += (tickerId, tickType, basisPoints, formattedBasisPoints, impliedFuture, holdDays, futureLastTradeDate, dividendImpact, dividendsToLastTradeDate) => addMessageToLog("TickEFP. " + tickerId + ", Type: " + tickType + ", BasisPoints: " + basisPoints + ", FormattedBasisPoints: " + formattedBasisPoints + ", ImpliedFuture: " + impliedFuture + ", HoldDays: " + holdDays + ", FutureLastTradeDate: " + futureLastTradeDate + ", DividendImpact: " + dividendImpact + ", DividendsToLastTradeDate: " + dividendsToLastTradeDate + "\n");
            ibClient.TickSnapshotEnd += tickerId => addMessageToLog("TickSnapshotEnd: " + tickerId + "\n");


            InitializedControls();
 
        }

        #region "Button Click"
        private void BtnMartketData_Click(object sender, EventArgs e)
        {

            GetMarketData();

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

                GetMarketData();
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
            contract.LocalSymbol = "ESU9";

            //PlaceTrailingStopOrder(contract,2875);
            PlaceBracketOrder(contract, 2875,ApplicationHelper.SHORT);
        }

        #endregion


        #region "Handle Connection"
        void ibClient_ConnectionClosed()
        {
            IsConnected = false;
             
        }

        void ibClient_Error(int id, int errorCode, string str, Exception ex)
        {
            if (ex != null)
            {
 
                ApplicationHelper.log(ref tbLog,"Error: " + ex.ToString(), Color.Black);
                return;
            }

            if (id == 0 || errorCode == 0)
            {
                 ApplicationHelper.log(ref tbLog, "Error: "  +str, Color.Black);
                return;
            }
            ApplicationHelper.log(ref tbLog, str, Color.Black);
            ErrorMessage error = new ErrorMessage(id, errorCode, str);

            HandleErrorMessage(error);
        }

        void ibClient_Tick(TickPriceMessage msg)
        {
                HandleTickMessage(msg);
        }
        void ibClient_Tick(TickSizeMessage msg)
        {
 
                HandleTickMessage(msg);
 
        }
        private void HandleTickMessage(MarketDataMessage tickMessage)
        {
            //ApplicationHelper.log(ref tbLog,string.Format("Request ID: {0} - Field: {1}", tickMessage.RequestId, tickMessage.Field));
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
            ApplicationHelper.log(ref tbLog, str, Color.Black);
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
            ApplicationHelper.log(ref tbLog, str, Color.Black);

            CurrentOrderID = statusMessage.OrderId > CurrentOrderID ? statusMessage.OrderId : CurrentOrderID;

        }
        private void HandleOpenOrder(OpenOrderMessage openOrder)
        {
            string str;

            str = string.Format("Order ID: {0} - Contract: {1} - Status: {2}", openOrder.OrderId, openOrder.Contract, openOrder.OrderState);
            ApplicationHelper.log(ref tbLog, str, Color.Black);
            CurrentOrderID = openOrder.OrderId > CurrentOrderID ? openOrder.OrderId : CurrentOrderID;
        }

        #endregion
        private void HandleExecutionMessage(ExecutionMessage message)
        {
        }
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

                ApplicationHelper.log(ref tbLog, "Allowed Contracts" + "\n", Color.Black);
                foreach (string s in AllowedContractList)
                {
                    ApplicationHelper.log(ref tbLog, s, Color.Black);
                }
                ApplicationHelper.log(ref tbLog, "DelayTolerance: " + DelayTolerance + "\n", Color.Black);
                ApplicationHelper.log(ref tbLog, "Notification:" + Notification + "\n", Color.Black);

                btnEngine.Text = "Stop Engine";
                KeepRunning = true;


                ApplicationHelper.log(ref tbLog, "Application mode: " + Mode +"\n", Color.Black);
                ApplicationHelper.log(ref tbLog, "MaxTradesPerDay: " + MaxTradesPerDay + "\n", Color.Black);
                ApplicationHelper.log(ref tbLog, "Engine Starts: " + DateTime.Now.ToString(), Color.Black);


                foreach (string filePath in Directory.GetFiles(signalPath,"signal*.txt"))
                {
                    ApplicationHelper.log(ref tbLog,"Signal File: " + filePath, Color.Black);
                    Task t = Task.Run(() => RetrieveSignal(filePath));
                }
 
            }
            else
            {
                btnEngine.Text ="Start Engine" ;
                KeepRunning = false;

                lbAllowedContract.Enabled = true;
            }
        }

        private void HandleTickSnapshotEnd()
        {

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
                //Notification = ApplicationHelper.getConfigValue("Notification");
                FromEmail = ApplicationHelper.getConfigValue("FromEmail");
                FromEmailPassword = ApplicationHelper.getConfigValue("FromEmailPassword");
                ToEmail = ApplicationHelper.getConfigValue("ToEmail");
                MaxTradesPerDay = int.Parse(ApplicationHelper.getConfigValue("MaxTradesPerDay"));
                DelaySecondUntillSignalValid = int.Parse(ApplicationHelper.getConfigValue("DelaySecondUntillSignalValid"));

                StartTradingHour =  ApplicationHelper.getConfigValue("StartTradingHour");
                EndTradingHour =  ApplicationHelper.getConfigValue("EndTradingHour");


                IBContract = ApplicationHelper.ReadXML("Config/IBContract.xml");

 
                foreach (string s in ApplicationHelper.getConfigValue("AllowedContractList").Split(','))
                {
                    if (! AllowedContractList.Contains(s))
                    {
                        AllowedContractList.Add(s);
                    }
                }

                LoadSystemConfig();
                AfterLoadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail to load config");
                ApplicationHelper.log(ref tbLog, "FAIL TO LOAD CONFIG: " + ex.ToString(), Color.Black);
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

        private void BtnSignalPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            signalPath = folderBrowserDialog.SelectedPath + "\\";
            lbSignalPath.Text = signalPath;
        }
        private void TbDelayTolerance_TextChanged(object sender, EventArgs e)
        {
            int delay;
            int.TryParse(tbDelayTolerance.Text.Trim().ToString(), out delay);

            //if (delay > 25 || delay < 10)//never allow
            //{
            //    DelayTolerance = delay;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Delay Tolerance.");
            //}

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

        private void LoadSystemConfig()
        {
            //LoadTrailingStopConfig();
            LoadBraketSystemConfig();
        }

        private void AfterLoadConfig()
        {
            lbSignalPath.Text = signalPath;
            tbDelayTolerance.Text = DelayTolerance.ToString();
        }
        private void GetMarketData()
        {
            ApplicationHelper.log(ref tbLog, "Start streaming live data", Color.Black);

            foreach (KeyValuePair<string, object> c in IBContract)
            {
                IBApi.Contract contract = new Contract();
                contract.Symbol = c.Key.ToString();

                int index = 0;
                foreach (string s in c.Value.ToString().Split('-'))
                {
                    if (index == 0)
                    {
                        contract.LocalSymbol = s;
                    }
                    if (index == 1)
                    {
                        contract.Exchange = s;
                    }
                    if (index == 2)
                    {
                        contract.SecType = s;
                    }
                    if (index == 3)
                    {
                        contract.Currency = s;
                    }
                    index++;
                }
                //Each regulatory snapshot made will incur a fee of 0.01 USD to the account. This applies to both live and paper accounts.

                if (contract.Symbol.Trim().Equals(ApplicationHelper.ES))
                {
                    ibClient.ClientSocket.reqMktData((int)(ApplicationHelper.marketReqID.ES), contract, "233", false, false, null);
                }
                if (contract.Symbol.Trim().Equals(ApplicationHelper.MES))
                {
                    ibClient.ClientSocket.reqMktData((int)(ApplicationHelper.marketReqID.MES), contract, "233", false, false, null);
                }

            }

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

        private void CbNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNotification.Checked)
            {
                Notification = ApplicationHelper.Y;
            }
            else
            {
                Notification = ApplicationHelper.N;
            }
        }
        #endregion


        private void RetrieveSignal(string signalPath)
        {
            FileInfo fileInfo = new FileInfo(signalPath);
            String fileName;
            int TradeCount = 0;
            //This keeps track of valid contracts
            List<AContract> AContracts = new List<AContract>();
            fileName = fileInfo.Name;
     

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
            EngineStatus = ApplicationHelper.RUNNING;


            //Set position
            PositionOpen = false;
            List<AContract> tempAContractList = new List<AContract>();
 

            while (KeepRunning)
            {

           
                try //Global Try
                {

                    ApplicationHelper.setLable(ref lbLastRun, "Last Run: " + DateTime.Now.ToString());

                    try
                    {
                        tempAContractList = ApplicationHelper.GetAmiSignalContracts(signalPath);

                        tempAContractList = filterSigal(tempAContractList);

                        foreach (AContract c in tempAContractList)
                        {


                            if (!AContracts.Exists(x => x.Symbol == c.Symbol && x.SignalDateTime.Equals(c.SignalDateTime)))
                            {

                                AContracts.Add(c);

                                Contract contract = new Contract();

                                contract = ApplicationHelper.BuildContract(c.Symbol);

                                long timeDelay = 0;


                                //Check if the time delay is valid
                                if (DateAndTime.DateDiff(DateInterval.Minute, c.SignalDateTime, DateAndTime.Now) >= DelayTolerance)
                                {

                                    if (Mode.Equals(ApplicationHelper.TEST) & timeDelay <= DelayTolerance)
                                    {
                                        timeDelay = DateAndTime.DateDiff(DateInterval.Minute, c.SignalDateTime, c.TimeStamp);
                                        ApplicationHelper.log(ref tbLog, string.Format("{5} - {4} Signal: {0} - TimeStamp: {1} - Current Time: {2} - Current Price: {6} - Delay: {3}", c.SignalDateTime, c.TimeStamp, DateAndTime.Now, timeDelay, c.Action, fileName, getLatestPrice(contract)), Color.Green);
                                    }
                                    else
                                    {
                                        timeDelay = DateAndTime.DateDiff(DateInterval.Minute, c.SignalDateTime, DateAndTime.Now);
                                        ApplicationHelper.log(ref tbLog, string.Format("SIGNAL TOO LATE:{5} - {4} Signal: {0} - TimeStamp: {1} - Current Time: {2} - Delay: {3}", c.SignalDateTime, c.TimeStamp, DateAndTime.Now, timeDelay, c.Action, fileName), Color.OrangeRed);
                                    }

                                    continue;
                                }

                                if (DateAndTime.Now.TimeOfDay < DateAndTime.TimeValue(StartTradingHour).TimeOfDay & DateAndTime.Now.TimeOfDay > DateAndTime.TimeValue(EndTradingHour).TimeOfDay)
                                {
                                    ApplicationHelper.log(ref tbLog, string.Format("{0} is out side of trading hour {1} and {2}", DateAndTime.Now.TimeOfDay, StartTradingHour, EndTradingHour), Color.OrangeRed);
                                    continue;
                                }


                                timeDelay = DateAndTime.DateDiff(DateInterval.Minute, c.SignalDateTime, DateAndTime.Now);

                                ApplicationHelper.log(ref tbLog, string.Format("{5} - {4} Signal: {0} - TimeStamp: {1} - Current Time: {2} - Current Price: {6} - Delay: {3}", c.SignalDateTime, c.TimeStamp, DateAndTime.Now, timeDelay, c.Action, fileName, getLatestPrice(contract)), Color.Green);

                                if (Notification.Trim().ToUpper().Equals(ApplicationHelper.Y))
                                {
                                    ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "Ami Signal", tbLog.Text);
                                }




                                //Check if contract is allowed to trade.
                                if (AllowedContractList.Contains(contract.LocalSymbol))
                                {
                                    ApplicationHelper.log(ref tbLog, string.Format("Contract: {0} - {1} - {2} - {3}", contract.LocalSymbol, contract.Exchange, contract.SecType, contract.Currency), Color.Black);

                                    //Write to the text file log.
                                    ApplicationHelper.log(ContractLog, string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", c.Action, c.Symbol, c.SignalClose, c.SignalDateTime, c.TimeStamp, c.LatestClose, c.LatestDateTime));

                                    //if (PositionOpen)
                                    //{
                                    //    ApplicationHelper.log(ref tbLog, string.Format("Postiion is currently open. This signal will be skipped."));
                                    //    continue;
                                    //}
                                    if (Mode.Equals(ApplicationHelper.PROD) & TradeCount <= MaxTradesPerDay)
                                    {

                                        TradeCount++;

                                        if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.BUY))
                                        {
                                            //PlaceTrailingStopOrder(contract, c.LatestClose);
                                            PlaceBracketOrder(contract, c.LatestClose, ApplicationHelper.BUY);

                                            ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "Trade Has Been Processed.", tbLog.Text);
                                        }
                                        if (c.Action.Trim().ToUpper().Equals(ApplicationHelper.SHORT))
                                        {
                                            //PlaceTrailingStopOrder(contract, c.LatestClose);
                                            PlaceBracketOrder(contract, c.LatestClose, ApplicationHelper.SHORT);
                                        }
                                        //In case of multiple signals, sleep 3 seconds
                                        Thread.Sleep(3000);
                                    }
                                }
                                else
                                {
                                    ApplicationHelper.log(ref tbLog, string.Format("NOT ALLOWED - TRADE WILL NOT OCCUR - Contract: {0} - {1} - {2} - {3}", contract.LocalSymbol, contract.Exchange, contract.SecType, contract.Currency), Color.Black);
                                }

                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        //These are not fatal exception and the system should keep running
                        HandleCustomException(ex);
                        //ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "Exception", tbLog.Text);
                    }
                    catch (Exception ex)
                    {

                        //KeepRunning = false;
                        ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);

                        ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "Exception", tbLog.Text);
                    }
                }
                catch (Exception ex)
                {
                    ApplicationHelper.log(ref tbLog, ex.Message.ToString(), Color.Black);
                }
                finally
                {
                    tempAContractList.Clear();
                }
 
                
                Thread.Sleep(SleepSeconds * 1000);

            }
            EngineStatus = ApplicationHelper.STOP;
            ApplicationHelper.log(ref tbLog, "Engine Ends: " + DateTime.Now.ToString(), Color.Black);
        }

        private void PlaceBracketOrder(IBApi.Contract contract, double LatestClose, string action)
        {

            //Get latest close value from IB
            LatestClose = getLatestPrice(contract);

            if (LatestClose ==0)
            {
                ApplicationHelper.log(ref tbLog, "Unable to determine price. Trade will not happen. ", Color.Black);
                return;
            }
            CurrentOrderID = ibClient.NextOrderId > CurrentOrderID ? ibClient.NextOrderId : CurrentOrderID;
                       
            BracketSystem.CurrentOrderID = CurrentOrderID;
            BracketSystem.EnterPostionPrice = LatestClose;

            Double ProfitTakerPrice ;
            Double StopPrice  ;

            ProfitTakerPrice = action.Equals(ApplicationHelper.BUY) ? BracketSystem.ProfitTakerAmount + LatestClose : LatestClose - BracketSystem.ProfitTakerAmount;
            StopPrice = action.Equals(ApplicationHelper.BUY) ? LatestClose - Math.Abs(BracketSystem.StopAmount) : LatestClose + Math.Abs(BracketSystem.StopAmount);

            ApplicationHelper.log(ref tbLog, "ibClient.NextOrderId: " + ibClient.NextOrderId, Color.Black);
            ApplicationHelper.log(ref tbLog, "CurrentOrderID: " + CurrentOrderID, Color.Black);
            ApplicationHelper.log(ref tbLog, "Enter Position Price: " + BracketSystem.EnterPostionPrice, Color.Black);
            ApplicationHelper.log(ref tbLog, "Profit Taker Price: " + ProfitTakerPrice, Color.Black);
            ApplicationHelper.log(ref tbLog, "Stop Price: " + StopPrice, Color.Black);

            List<Order> brackerOrder = new List<Order>();

            if (action.Equals(ApplicationHelper.BUY))
            {
                brackerOrder = ApplicationHelper.BracketOrder(++CurrentOrderID, ApplicationHelper.BUY, BracketSystem.ContractQuantity, BracketSystem.EnterPostionPrice, ProfitTakerPrice, StopPrice);
            }
            if (action.Equals(ApplicationHelper.SHORT))
            {
                brackerOrder = ApplicationHelper.BracketOrder(++CurrentOrderID, ApplicationHelper.SELL, BracketSystem.ContractQuantity, BracketSystem.EnterPostionPrice, ProfitTakerPrice, StopPrice);
            }

            foreach (Order o in brackerOrder)
            {
                ibClient.ClientSocket.placeOrder(o.OrderId, contract, o);
            }
            CurrentOrderID = CurrentOrderID + 3;

            ApplicationHelper.log(ref tbLog, "Trade has been placed."  , Color.Black);
                                   
        }

 
        private void addMessageToLog(string text)
        {

            //ApplicationHelper.log(ref tbLog, text);

            if (text.Contains("RTVolume"))
            {

                double lastPrice = ApplicationHelper.ParseLastPrice(text);

                int ES =(int)ApplicationHelper.marketReqID.ES;

                if (text.ToString().Contains(ES.ToString()))
                {
                    ApplicationHelper.setLable(ref lbESPrice, lastPrice.ToString());
                }

            }

            HandleErrorMessage(new ErrorMessage(-1, -1, text));

        }

        private double getLatestPrice(Contract contract)
        {
            double LatestPrice=0;


            double.TryParse(lbESPrice.Text.ToString(), out LatestPrice);


            return LatestPrice;
        }

        #region "Trailing Stop"
        private void PlaceTrailingStopOrder(IBApi.Contract contract, double LatestClose)
        {
            CurrentOrderID = ibClient.NextOrderId > CurrentOrderID ? ibClient.NextOrderId : CurrentOrderID;

            ApplicationHelper.log(ref tbLog, "ibClient.NextOrderId: " + ibClient.NextOrderId, Color.Black);
            ApplicationHelper.log(ref tbLog, "CurrentOrderID: " + CurrentOrderID, Color.Black);

            //I want to get filled.
            LatestClose = LatestClose + 2;

            List<Order> brackerOrder = ApplicationHelper.TrailingStopOrder(++CurrentOrderID, ApplicationHelper.BUY, LatestClose, ContractQuantity, TrailingStopAmount);

            foreach (Order o in brackerOrder)
            {
                ibClient.ClientSocket.placeOrder(o.OrderId, contract, o);
            }
            CurrentOrderID = CurrentOrderID + 3;


            ApplicationHelper.log(ref tbLog, "PlaceTrailingStopOrder Submitted", Color.Black);

            PositionOpen = true;
        }


        private void LoadTrailingStopConfig()
        {
            config = new Dictionary<string, object>();
            config = ApplicationHelper.ReadXML("Config/TraillingStopSystem.xml");

            float.TryParse(config.First(x => x.Key == ApplicationHelper.TrailingStopAmount).Value.ToString(), out TrailingStopAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.ContractQuantity).Value.ToString(), out ContractQuantity);


            ApplicationHelper.log(ref tbLog, "Trailing Stop System Config BEGIN", Color.Black);
            ApplicationHelper.log(ref tbLog, "TrailingStopAmount : " + TrailingStopAmount, Color.Black);
            ApplicationHelper.log(ref tbLog, "ContractQuantity : " + ContractQuantity, Color.Black);
            ApplicationHelper.log(ref tbLog, "Trailing Stop System Config END", Color.Black);
        }

        private void LoadBraketSystemConfig()
        {

            this.BracketSystem = new BracketSystem("Config/BracketSystem.xml");

            ApplicationHelper.log(ref tbLog, "Bracket System Config BEGIN", Color.Black);
            ApplicationHelper.log(ref tbLog, "Contract Quantity: " + BracketSystem.ContractQuantity, Color.Black);
            ApplicationHelper.log(ref tbLog, "ProfitTakerAmount: " + BracketSystem.ProfitTakerAmount, Color.Black);
            ApplicationHelper.log(ref tbLog, "StopAmount: " + BracketSystem.StopAmount, Color.Black);
            ApplicationHelper.log(ref tbLog, "Bracket System Config END", Color.Black);

        }
        #endregion

        #region "Exception Handling"

        private void HandleCustomException(ArgumentException ex)
        {
            try
            {

                if (ex.ParamName.Equals(ApplicationHelper.ExceptionEmailNotification))
                {
                    HandleEmailException(ex);
                }
                if (ex.ParamName.Equals(ApplicationHelper.ExceptionGetAmiSignal))
                {
                    HandleGetAmiSignal(ex);
                }
                else //If the exception is not custom, then stop program.
                {
                    ApplicationHelper.log(ref tbLog, "Not a custom error. System will stop.", Color.Black);
                    ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);
                    //KeepRunning = false;
                }
            }
            catch (Exception e)
            {
                ApplicationHelper.log(ref tbLog, "Unable to handle custom error. Details Error below.", Color.Black);
                ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);

            }


        }

        private void HandleGetAmiSignal(ArgumentException ex)
        {
            //If the IOException due to the file is being blocked. Continues
            if (ex.Message.Contains(signalPath))
            {
                //ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + "Cannot access the SignalPath. The system will continue. This is not a fatal error. Details Error below.", Color.Black);
               //ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString());

                //Thread.Sleep(SleepSeconds * 1000);
            }
            else //Exit application
            {
                //KeepRunning = false;
                ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);
            }
        }

        private void HandleEmailException(ArgumentException ex)
        {
            ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + "Unable to send Email. The system will continue. This is not a fatal error. Details Error below.", Color.Black);
            //ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString());
        }


        #endregion

        #region "Validation and Filtering"
        private List<AContract> filterSigal(List<AContract> tempAContractList)
        {


            ////Remove signals that have been processed.
            //if (Mode.Equals(ApplicationHelper.PROD))
            //{
            //    foreach(AContract c in AContracts)
            //    {
            //        tempAContractList.RemoveAll(x => x.Symbol == c.Symbol & x.SignalClose == c.SignalClose);
            //    }
            //}
                 
            //List<AContract> temp = new List<AContract>(tempAContractList);

            //foreach (AContract aContract in temp)
            //{
            //    aContract.TimeStamp =DateTime.Parse( string.Format(aContract.TimeStamp.ToString("MM/dd/yyyy HH:mm:00")));
            //}

            //Wait until the signal is fully formed.
            //var query = tempAContractList.GroupBy(x => new {Action =x.Action,Symbol= x.Symbol, SignalClose= x.SignalClose, TimeStamp = x.TimeStamp })
            //                        .Select(c => new { Action = c.Key.Action, Symbol = c.Key.Symbol, SignalClose = c.Key.SignalClose ,TimeStamp = c.Key.TimeStamp, count = c.Count()});

            //            query.ToList();       

            //            foreach (var c in query.ToList())
            //            {
            //                if (c.count <= DelaySecondUntillSignalValid)
            //                {
            //                    tempAContractList.RemoveAll(x => x.SignalClose == c.SignalClose & x.TimeStamp == c.TimeStamp);
            //                }
            //            }


            var query = tempAContractList.GroupBy(x => new { Action = x.Action, Symbol = x.Symbol, SignalDateTime = x.SignalDateTime  })
            .Select(c => new { Action = c.Key.Action, Symbol = c.Key.Symbol, SignalDateTime = c.Key.SignalDateTime, count = c.Count() });

            query.ToList();

            foreach (var c in query.ToList())
            {
                if (c.count <= DelaySecondUntillSignalValid)
                {
                    tempAContractList.RemoveAll(x => x.SignalDateTime == c.SignalDateTime);
                }
            }

            return tempAContractList;
        }






        #endregion

 
    }
}
