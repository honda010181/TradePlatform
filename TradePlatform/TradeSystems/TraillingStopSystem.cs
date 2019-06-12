using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatformHelper;
using IBApi;

namespace TradePlatform
{
    public class TraillingStopSystem
    {
        public float TrailingStopPrice { get; set; }
        public int ContractQuantity { get; set; }
        public Int64 BuyOrderID { get; set; }
        public string BuyrOrderStatus { get; set; }
        public Int64 TrailingOrderID { get; set; }
        public string TrailingOrderStatus { get; set; }
        public string Action { get; set; }
        public float EnterPostionPrice { get; set; }
        public int CurrentOrderID { get; set; }

        public Contract contract { get; set; }
 
        public Dictionary<string, object> config;

        public string Status { get; set; }
        public TraillingStopSystem ()
        {
            //Property or indexer cannot be used as parameter.
            //This variable here is only a place holder.
            float TrailingStopPrice;
            int ContractQuantity;
            config = new Dictionary<string, object>();
            config = ApplicationHelper.ReadXML("Config/TraillingStopSystem.xml");

            float.TryParse(config.First(x => x.Key == ApplicationHelper.TrailingStopPrice).Value.ToString(), out TrailingStopPrice);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.ContractQuantity).Value.ToString(), out ContractQuantity);

            //Set config value to property
            this.TrailingStopPrice = TrailingStopPrice;
            this.ContractQuantity = ContractQuantity;
            this.BuyrOrderStatus = ApplicationHelper.EMPTY;
            this.TrailingOrderStatus = ApplicationHelper.EMPTY;

        }
        public Order GetOrder(int CurrentOrderID)
        {
            try
            {
                Order order = new Order() ;
                if (BuyrOrderStatus.Equals(ApplicationHelper.EMPTY))
                {
                    BuyOrderID = CurrentOrderID;
                    order = ApplicationHelper.MarketOrder(CurrentOrderID, ApplicationHelper.BUY, ContractQuantity);
                    BuyrOrderStatus = ApplicationHelper.Order_status_PreSubmitted;
                    return order;
                    //ibClient.placeOrder(CurrentOrderID, contract,order);
                }

                if (BuyrOrderStatus.Equals(ApplicationHelper.Order_status_Filled))
                {
                    TrailingOrderID = CurrentOrderID;
                    order = ApplicationHelper.TralingStop(CurrentOrderID, ApplicationHelper.BUY, ContractQuantity, 0, TrailingStopPrice);
                    TrailingOrderStatus = ApplicationHelper.Order_status_PreSubmitted;
                    return order;
                    //ibClient.placeOrder(CurrentOrderID, contract, order);
                }

                order.OrderId = 0;
                return order;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

 
 
    }
}
