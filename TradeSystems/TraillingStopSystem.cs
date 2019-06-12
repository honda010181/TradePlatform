using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatformHelper;
using IBApi;

namespace TradeSystems
{
    public class TraillingStopSystem
    {
        private float TrailingStopPrice { get; set; }
        private int ContractQuantity { get; set; }
        private Int64 BuyOrderID { get; set; }
        private string BuyrOrderStatus { get; set; }
        private Int64 TrailingOrderID { get; set; }
        private string TrailingOrderStatus { get; set; }
        private string Action { get; set; }
        private float EnterPostionPrice { get; set; }
        private int CurrentOrderID { get; set; }

        private Contract contract;

        IBClient ibClient;


        public TraillingStopSystem(IBClient ibClient, Contract contract, int CurrentOrderID)
        {
            this.ibClient = ibClient;
            this.contract = contract;
            this.CurrentOrderID = CurrentOrderID;
        }
        private void Submit()
        {
            try
            {
                if (BuyrOrderStatus.Equals(ApplicationHelper.EMPTY))
                {
                    Order order =  ApplicationHelper.MarketOrder(CurrentOrderID,ApplicationHelper.BUY,ContractQuantity);
                    ibClient.placeOrder(CurrentOrderID, contract,order);
                }

                if (BuyrOrderStatus.Equals(ApplicationHelper.FILLED))
                {
                    Order order = ApplicationHelper.TralingStop(CurrentOrderID, ApplicationHelper.BUY, ContractQuantity,0, TrailingStopPrice);
                    ibClient.placeOrder(CurrentOrderID, contract, order);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
