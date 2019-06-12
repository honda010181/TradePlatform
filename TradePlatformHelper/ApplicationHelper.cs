﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Configuration.Assemblies;
using TradePlatformHelper.Objects;
using System.IO;
using IBApi;
using Microsoft.VisualBasic; 
using System.Drawing;
using System.Threading;
using System.Net.Mail;
using System.Xml;
namespace TradePlatformHelper
{
    public static class ApplicationHelper
    {
        public static string SUCCESS = "SUCCESS";
        public static string FAILURE = "FAILURE";
        public static string LMT = "LMT";
        public static string STP = "STP";
        public static string MKT = "MKT";
        public static string BUY = "BUY";
        public static string SELL = "SELL";
        public static string TRAIL = "TRAIL";
        public static string IBContractPath = "IBContract.xml";
        public static string YES = "YES";
        public static string Y = "Y";
        public static string NO = "NO";
        public static string N = "N";
        public static string PROD = "PROD";
        public static string TEST = "TEST";
        public static string RUNNING = "RUNNING";
        public static string STOP = "STOP";
        public static string ExceptionEmailNotification = "EmailNotificationException";
        public static string ExceptionGetAmiSignal = "ExceptionGetAmiSignal";
        public static string SMTPServer = "smtp.gmail.com";
        public static int SMTPPort = 587;
        public static string EMPTY = "";
        public static string FILLED = "Filled";
        public static string TrailingStopPrice = "TrailingStopPrice";
        public static string ContractQuantity = "ContractQuantity";
        public static string TrailingStopAmount = "TrailingStopAmount";

        public static string Order_status_ApiPending = "ApiPending";
        public static string Order_status_PendingSubmit = "PendingSubmit";
        public static string Order_status_PendingCancel = "PendingCancel";
        public static string Order_status_PreSubmitted = "PreSubmitted";
        public static string Order_status_Submitted = "Submitted";
        public static string Order_status_ApiCancelled = "ApiCancelled";
        public static string Order_status_Filled = "Filled";
        public static string Order_status_Cancelled = "Cancelled";
        public static string Order_status_Inactive = "Inactive";

        private delegate void SafeCallDelegate(ref TextBox tbLog, string msg);

 

        public static void log(ref TextBox tbLog, string msg)
        {
            if (tbLog.InvokeRequired)
            {
                var d = new SafeCallDelegate(log);

                tbLog.Invoke(d, new object[] {tbLog,msg });
            }
            else
            {
                tbLog.AppendText(msg + "\n");
            }            
        }

 
        public static void log(string filePath, string msg)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        foreach (string s in msg.Split('\n'))
                        {
                            sw.WriteLine(s);
                        }

                        return;
                    }
                }

                StreamWriter log = new StreamWriter(filePath,true);

                log.WriteLine(msg);

                log.Dispose();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("Method ApplicationHelper.log - " + ex.Message);
            }
        }


        public static string getConfigValue(string key)
        {
            string value;

            try
            {
                value = ConfigurationManager.AppSettings.Get(key);
            }
            catch (Exception ex)
            {
                value = "";
            }
            return value;
        }

        public static List<AContract> GetAmiSignalContracts(string souce)
        {
            List<AContract> contracts = new List<AContract>();

            try
            {
                int index;
                string csvData = File.ReadAllText(souce);

                //Execute a loop over the rows.  
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {

                        AContract c = new AContract();
                        index = 0;
                        //Execute a loop over the columns.  
                        foreach (string cell in row.Split(','))
                        {

                            switch (index)
                            {
                                case 0:
                                    c.Symbol = cell.ToString().Trim();
                                    break;
                                case 1:
                                    c.SignalClose = float.Parse(cell.ToString().Trim());
                                    break;
                                case 2:
                                    c.SignalDateTime = DateTime.Parse(cell.ToString().Trim());
                                    break;
                                case 3:
                                    c.TimeStamp = DateTime.Parse(cell.ToString().Trim());
                                    break;
                                case 4:
                                    c.Action = cell.ToString().Trim();
                                    break;
                                case 5:
                                    c.LatestClose = float.Parse(cell.ToString().Trim());
                                    break;
                                case 6:
                                    c.LatestDateTime = DateTime.Parse(cell.ToString().Trim());
                                    break;
                                default:
                                    break;
                            }
                            index++;
                        }
                        contracts.Add(c);
                    }

                }
            }
            catch (Exception ex)
            {
                contracts.Clear();
                throw new System.ArgumentException(System.Reflection.MethodInfo.GetCurrentMethod() + ex.Message, ExceptionGetAmiSignal);
            }

            return contracts;
        }



        public static List<Contract> LoadContractFromConfig()
        {
            List< Contract> contracts = new List<Contract>();

            
            return contracts;
        }


        public static Contract BuildContract(string AmiSymbol)
        {
            Contract c = new Contract();
            int i=0;

            foreach (string s in AmiSymbol.Split('-'))
            {
                switch (i)
                {
                    case 0:
                        c.LocalSymbol = s;
                        break;
                    case 1:
                        c.Exchange = s;
                        break;
                    case 2:
                        c.SecType = s;
                        break;
                    case 3:
                        c.Currency = s;
                        break;
                }
                i++;
 
            }

            return c;
        }


        public static void SendNotification(string from,string fromPassword, string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage(from, to, subject,body);

                //Send the message.
                SmtpClient client = new SmtpClient(SMTPServer);
                // Add credentials if the SMTP server requires them.
                client.Port = SMTPPort;
            
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(from, fromPassword);
                client.EnableSsl = true;

                client.Send(message);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(System.Reflection.MethodInfo.GetCurrentMethod()  + ex.Message, ExceptionEmailNotification);
 
            }

        }


        public static Dictionary<string,object> ReadXML(string xmlPath)
        {
            Dictionary<string, object> config = new Dictionary<string, object>();
            XmlTextReader reader = new XmlTextReader(xmlPath);

            string configName="";
            object configValue = new object();
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        configName = reader.Name;
                         break;
                    case XmlNodeType.Text: //Display the text in each element.
                        configValue = reader.Value;
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        if (!config.ContainsKey(configName))
                        {
                            config.Add(configName, configValue);
                        }
                        break;
                }
            }

            return config;

        }

        #region "Build Order"
        public static List<Order> BracketOrder(int parentOrderId, string action, double quantity, double limitPrice, double takeProfitLimitPrice, double stopLossPrice)
        {
            if (Math.Abs(limitPrice - stopLossPrice) > 3 || Math.Abs(limitPrice - takeProfitLimitPrice) > 3)
            {
                throw new System.ArgumentException("ApplicationHelper.BracketOrder - Price margin is too large", "PriceMargin");
            }
            try
             {
                //This will be our main or "parent" order
                Order parent = new Order();
                parent.OrderId = parentOrderId; 
                parent.Action = action;
                parent.OrderType = LMT;
                parent.TotalQuantity = quantity;
                parent.LmtPrice = limitPrice;
                //The parent and children orders will need this attribute set to false to prevent accidental executions.
                //The LAST CHILD will have it set to true, 
                parent.Transmit = false;
                Order takeProfit = new Order();
                takeProfit.OrderId = parent.OrderId + 1;
                takeProfit.Action = action.Equals(BUY) ? SELL : BUY;
                takeProfit.OrderType = LMT;
                takeProfit.TotalQuantity = quantity;
                takeProfit.LmtPrice = takeProfitLimitPrice;
                takeProfit.ParentId = parentOrderId;
                takeProfit.Transmit = false;
                Order stopLoss = new Order();
                stopLoss.OrderId = parent.OrderId + 2;
                stopLoss.Action = action.Equals(BUY) ? SELL : BUY;
                stopLoss.OrderType = STP;
                //Stop trigger price
                stopLoss.AuxPrice = stopLossPrice;
                stopLoss.TotalQuantity = quantity;
                stopLoss.ParentId = parentOrderId;
                //In this case, the low side order will be the last child being sent. Therefore, it needs to set this attribute to true 
                //to activate all its predecessors
                stopLoss.Transmit = true;
                List<Order> bracketOrder = new List<Order>();
                bracketOrder.Add(parent);
                bracketOrder.Add(takeProfit);
                bracketOrder.Add(stopLoss);

                return bracketOrder;
             }
            catch (Exception ex)
            {
                throw ex;
            }
       
        }

        public static List<Order> TrailingStopOrder(int parentOrderId, string action,double LMTPrice, double quantity, double trailAmmount)
        {
            if (trailAmmount > 5)
            {
                throw new System.ArgumentException("ApplicationHelper.TrailingStopOrder - Price margin is too large", "PriceMargin");
            }
            if (quantity > 5)
            {
                throw new System.ArgumentException("ApplicationHelper.TrailingStopOrder - quantity is too large", "quantity");
            }
            try
            {
                //This will be our main or "parent" order
                Order parent = new Order();
                parent.OrderId = parentOrderId;
                parent.Action = action;
                parent.OrderType = LMT;
                parent.LmtPrice = LMTPrice;
                parent.TotalQuantity = quantity;
                //The parent and children orders will need this attribute set to false to prevent accidental executions.
                //The LAST CHILD will have it set to true, 
                parent.Transmit = false;

                Order trailingStop = new Order();
                trailingStop.OrderId = parent.OrderId + 1;
                trailingStop.Action = action.Equals(BUY) ? SELL : BUY;
                trailingStop.OrderType = TRAIL;
                trailingStop.TotalQuantity = quantity;
                trailingStop.AuxPrice = trailAmmount;
                trailingStop.ParentId = parentOrderId;
                trailingStop.Transmit = true;
 
                List<Order> TrailingStopOrder = new List<Order>();
                TrailingStopOrder.Add(parent);
                TrailingStopOrder.Add(trailingStop);
 
                return TrailingStopOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public static Order MarketOrder(int orderID, string action, double quantity)
        {

            Order order = new Order();
            try
            {
                order.OrderId = orderID;
                order.Action = action;
                order.OrderType = MKT;
                order.TotalQuantity = quantity;

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Order TralingStop (int OrderID, string action, int quantity, double trailingPercent, double trailStopPrice)
        {

            Order order = new Order();
            
            try
            {
                order.OrderId = OrderID;
                order.Action = action;
                order.OrderType = TRAIL;
                order.TotalQuantity = quantity;
                order.TrailingPercent = trailingPercent;
                order.TrailStopPrice = trailStopPrice;
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        #endregion
    }
}
