using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatform.CustomModels;
using IBSampleApp.messages;
using IBApi;
using TradePlatformHelper;
using System.Windows.Forms;
using System.Drawing;
using TradePlatformHelper.Objects;
using Microsoft.VisualBasic;
namespace TradePlatform.Managers
{
    class OrderManager
    {
        public List<OpenOrderMessage> Orders = new List<OpenOrderMessage>();
        public List<AContract> AContracts = new List<AContract>();
        private IBClient ibClient;
        private RichTextBox tbLog;
        private String FromEmail;
        private String ToEmail;
        private String FromEmailPassword;
        public int signalTimeDisappearFor { get; set; } //in minute
        public int StopMonitorSignalDisappearAfter { get; set; }//in minute
        public OrderManager (IBClient ibClient,ref RichTextBox tbLog, String FromEmail , String FromEmailPassword, String ToEmail)
        {
            this.ibClient = ibClient;
            this.tbLog = tbLog;
            this.FromEmail = FromEmail;
            this.ToEmail = ToEmail;
            this.FromEmailPassword = FromEmailPassword;
        }
        public void resolveOppositeDirectionOrder(String action, double currentPrice)
        {
 
            try
            {
                foreach (OpenOrderMessage openOrder in Orders)
                {
                    ResolveOpenOrderMessage(action, currentPrice, openOrder);
                }


            }
            catch (Exception ex)
            {
 
                ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);

            }

        }

        public void ResolveOpenOrderMessage(String action,double currentPrice ,OpenOrderMessage openOrder)
        {
            //Determine if the parent order has been filled.
            if (openOrder.Order.ParentId == 0 & openOrder.Order.Action != action)
            {

                if (openOrder.OrderState.Status == ApplicationHelper.Order_status_Filled)
                {
                    Boolean active = true;
                    foreach (OpenOrderMessage childOder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                    {
                        if (childOder.OrderState.Status.Trim().Equals(ApplicationHelper.FILLED) || childOder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Cancelled) || childOder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_PendingCancel))
                        {
                            active = false;
                        }
                    }

                    if (active)
                    {

                        //Resubmit stop loss order with current price to exit immediately
                        foreach (OpenOrderMessage childOrder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                        {
                            //Stop loss order
                            if (childOrder.OrderId == openOrder.OrderId + 2 & childOrder.Order.AuxPrice != currentPrice)
                            {
                                childOrder.Order.AuxPrice = currentPrice;
                                ibClient.ClientSocket.placeOrder(childOrder.OrderId, childOrder.Contract, childOrder.Order);
                                if (action.Equals(ApplicationHelper.EMPTY))
                                {
                                    ApplicationHelper.log(ref tbLog, "Signal has disappeared." + openOrder.OrderId, System.Drawing.Color.Black);
                                }
                                ApplicationHelper.log(ref tbLog, string.Format("Reverse Direction Resubmit Stop loss order with current price to exit from child.Child Order ID - {0} Child current Status {1} ", childOrder.OrderId, childOrder.OrderState.Status.ToString()), System.Drawing.Color.Black);

                            }


                        }

                    }

                }
                else //if parent order has not been filled, then cancel it
                     //What happens to partially fill order.
                {

                    if (openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Cancelled)|| openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_PendingCancel))
                    {

                    }
                    else
                    {
                        if (action.Equals(ApplicationHelper.EMPTY))
                        {
                            ApplicationHelper.log(ref tbLog, "Signal has disappeared." + openOrder.OrderId, System.Drawing.Color.Black);
                        }
                        ApplicationHelper.log(ref tbLog, "Reverse Direction Parent order id has not been filled.Current Status " + openOrder.OrderState.Status.ToString(), System.Drawing.Color.Black);
                        ApplicationHelper.log(ref tbLog, "Reverse Direction OrderManager Cancels Parent Order id " + openOrder.OrderId, System.Drawing.Color.Black);

                        ibClient.ClientSocket.cancelOrder(openOrder.OrderId);
                    }
 
                }
            }



            if (openOrder.Order.ParentId != 0 & openOrder.Order.Action == action)
            {
                if (openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.FILLED) || openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Cancelled) || openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_PendingCancel))
                {

                }
                else
                {
                    //Stop loss order only
                    if (openOrder.OrderId == openOrder.Order.ParentId + 2 & openOrder.Order.AuxPrice != currentPrice)
                    {
                        if (openOrder.Order.AuxPrice != currentPrice)
                        {
                            openOrder.Order.AuxPrice = currentPrice;
                            ibClient.ClientSocket.placeOrder(openOrder.OrderId, openOrder.Contract, openOrder.Order);
                            ApplicationHelper.log(ref tbLog, "Reverse Direction Resubmit Stop loss order with current price to exit from child." + openOrder.OrderId, System.Drawing.Color.Black);
                        }
                    }

                }
            }
        }

        public void stopMonitor(double currentPrice, List<AContract> contractSignal)
        {
            try
            {
                if (currentPrice == 0)
                {
                    return;
                }
                foreach(OpenOrderMessage order in getActiveStopOrder())
                {
                    if (order.Order.Action.Equals(ApplicationHelper.BUY))
                    {
                        if (order.Order.AuxPrice < currentPrice)
                        {
                            ApplicationHelper.log(ref tbLog,String.Format("ALERT:{3} Did not stop at stop.Action-{2} - Stop price {0} - Current price {1} - Current Status {6} - Current Order ID: {4} Parent Order ID: {5}", order.Order.AuxPrice, currentPrice, order.Order.Action, order.Contract.ToString(), order.OrderId, order.Order.ParentId, order.OrderState.Status), System.Drawing.Color.DarkRed);
                            ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "ALERT: Did not stop at stop", tbLog.Text);
                            order.Order.AuxPrice = currentPrice;
                            ibClient.ClientSocket.placeOrder(order.OrderId, order.Contract, order.Order);
                            ApplicationHelper.log(ref tbLog, "Resubmit Stop loss order with current price to exit from child." + order.OrderId, System.Drawing.Color.Black);
                        }
                    }
                    else if(order.Order.Action.Equals(ApplicationHelper.SELL))
                    {
                        if (order.Order.AuxPrice > currentPrice)
                        {
                            ApplicationHelper.log(ref tbLog, String.Format("ALERT:{3} Did not stop at stop.Action-{2} - Stop price {0} - Current price {1} - Current Status {6} - Current Order ID: {4} Parent Order ID: {5}", order.Order.AuxPrice, currentPrice, order.Order.Action, order.Contract.ToString(), order.OrderId, order.Order.ParentId, order.OrderState.Status), System.Drawing.Color.DarkRed);
                            ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "ALERT: Did not stop at stop.", tbLog.Text);
                            order.Order.AuxPrice = currentPrice;
                            ibClient.ClientSocket.placeOrder(order.OrderId, order.Contract, order.Order);
                            ApplicationHelper.log(ref tbLog, "Resubmit Stop loss order with current price to exit from child." + order.OrderId, System.Drawing.Color.Black);
                        }
                    }
                }


                //Get latest signal heartbeat
                var query = contractSignal.GroupBy(x => new { Action = x.Action, Symbol = x.Symbol, SignalDateTime = x.SignalDateTime })
                    .Select(c => new { Action = c.Key.Action, Symbol = c.Key.Symbol, SignalDateTime = c.Key.SignalDateTime, SignalStartDateTime = c.Min(x => x.TimeStamp), TimeStamp = c.Max(x => x.TimeStamp) });
                                           
                foreach (var c in query.ToList())
                {
                    if (DateAndTime.DateDiff(DateInterval.Minute, c.TimeStamp, DateAndTime.Now) > signalTimeDisappearFor & DateAndTime.DateDiff(DateInterval.Minute,c.SignalStartDateTime, c.TimeStamp) < StopMonitorSignalDisappearAfter) //Signal has disappeared for longer than 20
                    {

                        //ApplicationHelper.log(ref tbLog,String.Format("Signal has disappeared for longer than {2} minutes. Last signal at {0} Current Time {1}", c.TimeStamp, DateAndTime.Now, signalTimeDisappearFor), System.Drawing.Color.DarkRed);

                        foreach (AContract aContract in AContracts.Where(x => x.Symbol == c.Symbol & x.Action == c.Action & x.SignalDateTime == c.SignalDateTime))
                        {
                            foreach (OpenOrderMessage openOrder in Orders.Where(x => x.OrderId == aContract.ParentOrderID))
                            {

                                //ApplicationHelper.log(ref tbLog, String.Format("Signal has disappeared for longer than 120 seconds. Last signal at {0} Current Time {1}", c.TimeStamp, DateAndTime.Now), System.Drawing.Color.DarkRed);
                  
                                ResolveOpenOrderMessage(ApplicationHelper.EMPTY, currentPrice, openOrder);
                            }
                        }
                        //ApplicationHelper.SendNotification(FromEmail, FromEmailPassword, ToEmail, "ALERT: Signal Has Disappeared.", tbLog.Text);
                    }
                }



            }
            catch (Exception ex)
            {
                ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);
            }
        }
 
        public List<OpenOrderMessage> getActiveStopOrder()
        {
            List<OpenOrderMessage> ActiveStopOrders = new List<OpenOrderMessage>();

            try
            {
                foreach (OpenOrderMessage openOrder in Orders)
                {

                    if (openOrder.Order.ParentId == 0 & openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Filled))
                    {

                        Boolean active = true;
                        foreach (OpenOrderMessage childOder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                        {
                            if (childOder.OrderState.Status.Trim().Equals(ApplicationHelper.FILLED) || childOder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Cancelled) || childOder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_PendingCancel))
                            {
                                active = false;
                            }
                        }

                        if (active)
                        {
                            foreach (OpenOrderMessage childOder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                            {
                                if (childOder.OrderId == childOder.Order.ParentId + 2)
                                {
                                    ActiveStopOrders.Add(childOder);
                                }
                            }
                        }
                        //if (openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.FILLED) || openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_Cancelled) || openOrder.OrderState.Status.Trim().Equals(ApplicationHelper.Order_status_PendingCancel))
                        //{

                        //}
                        //else //only care about active order
                        //{
                        //    if (openOrder.OrderId == openOrder.Order.ParentId + 2 )
                        //    {
                        //        ActiveStopOrders.Add(openOrder);
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ActiveStopOrders;

        }
    }
}
