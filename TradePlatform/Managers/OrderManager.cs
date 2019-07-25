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
namespace TradePlatform.Managers
{
    class OrderManager
    {
        public List<OpenOrderMessage> Orders = new List<OpenOrderMessage>();
        private IBClient ibClient;
        private RichTextBox tbLog;

        public OrderManager (IBClient ibClient,ref RichTextBox tbLog)
        {
            this.ibClient = ibClient;
            this.tbLog = tbLog;
        }
        public void resolveOppositeDirectionOrder(String action, double currentPrice)
        {
 
            try
            {
                foreach (OpenOrderMessage openOrder in Orders)
                {
                    //Determine if the parent order has been filled.
                    if (openOrder.Order.ParentId == 0 & openOrder.Order.Action != action)
                    {

                        if (openOrder.OrderState.Status == ApplicationHelper.Order_status_Filled)
                        {
                            Boolean active = true;
                            foreach (OpenOrderMessage childOder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                            {
                                if (childOder.Order.Action.Equals(action))
                                {
                                    if (childOder.OrderState.Status.Equals(ApplicationHelper.FILLED) || childOder.OrderState.Status.Equals(ApplicationHelper.Order_status_Cancelled) || childOder.OrderState.Status.Equals(ApplicationHelper.Order_status_PendingCancel))
                                    {
                                        active = false;
                                    }
                                }

                            }

                            if (active)
                            {
                                //Resubmit stop loss order with current price to exit immediately
                                foreach (OpenOrderMessage childOrder in Orders.Where(x => x.Order.ParentId == openOrder.OrderId))
                                {
                                    //Stop loss order
                                    if (childOrder.OrderId== openOrder.OrderId + 2 & openOrder.Order.AuxPrice != currentPrice)
                                    {
                                        childOrder.Order.AuxPrice = currentPrice;
                                        ibClient.ClientSocket.placeOrder(childOrder.OrderId, childOrder.Contract, childOrder.Order);
                                    }
                                    ApplicationHelper.log(ref tbLog, "Resubmit Stop loss order with current price to exit from parent." + childOrder.OrderId, System.Drawing.Color.Black);
                                }
 
                            }

                        }
                        else //if parent order has not been filled, then cancel it
                             //What happens to partially fill order.
                        {
                            ApplicationHelper.log(ref tbLog, "Parent order id has not been filled. ", System.Drawing.Color.Black);
                            ApplicationHelper.log(ref tbLog, "OrderManager Cancels Parent Order id " + openOrder.OrderId, System.Drawing.Color.Black);
                            ibClient.ClientSocket.cancelOrder(openOrder.OrderId);
                        }
                    }



                    if (openOrder.Order.ParentId != 0 & openOrder.Order.Action == action)
                    {
                        if (openOrder.OrderState.Status.Equals(ApplicationHelper.FILLED) || openOrder.OrderState.Status.Equals(ApplicationHelper.Order_status_Cancelled) || openOrder.OrderState.Status.Equals(ApplicationHelper.Order_status_PendingCancel))
                        {
                            
                        }
                        else
                        {
                            //Stop loss order only
                            if (openOrder.OrderId== openOrder.Order.ParentId + 2  & openOrder.Order.AuxPrice != currentPrice)
                            {
                                openOrder.Order.AuxPrice = currentPrice;
                                ibClient.ClientSocket.placeOrder(openOrder.OrderId, openOrder.Contract, openOrder.Order);
                                ApplicationHelper.log(ref tbLog, "Resubmit Stop loss order with current price to exit from child." + openOrder.OrderId, System.Drawing.Color.Black);
                            }
                            
                        }
                    }
                }


            }
            catch (Exception ex)
            {
 
                ApplicationHelper.log(ref tbLog, System.Reflection.MethodInfo.GetCurrentMethod() + " - " + ex.ToString(), Color.Black);

            }

        }
    }
}
