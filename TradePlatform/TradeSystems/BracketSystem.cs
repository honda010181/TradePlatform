using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatformHelper;
namespace TradePlatform.TradeSystems
{
    public  class BracketSystem
    {
        public float StopAmount { get; set; }
        public float ProfitTakerAmount { get; set; }
        public int ContractQuantity { get; set; }
        public Int64 BuyOrderID { get; set; }
        public string BuyrOrderStatus { get; set; }
        public Int64 StopOrderID { get; set; }
        public string StopOrderStatus { get; set; }
        public Int64 ProfitTakerOrderID { get; set; }
        public string ProfitTakerOrderStatus { get; set; }
        public string Action { get; set; }
        public double EnterPostionPrice { get; set; }
        public int CurrentOrderID { get; set; }

        public Dictionary<string, object> config;

        public BracketSystem (string ConfigPath)
        {
            //Property or indexer cannot be used as parameter.
            //This variable here is only a place holder.
            float StopAmount;
            int ContractQuantity;
            float ProfitTakerAmount;
            config = new Dictionary<string, object>();
            config = ApplicationHelper.ReadXML(ConfigPath);

            float.TryParse(config.First(x => x.Key == ApplicationHelper.StopAmount).Value.ToString(), out StopAmount);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.ProfitTakerAmount).Value.ToString(), out ProfitTakerAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.ContractQuantity).Value.ToString(), out ContractQuantity);

            //Set config value to property
            this.StopAmount = StopAmount;
            this.ContractQuantity = ContractQuantity;
            this.ProfitTakerAmount = ProfitTakerAmount;

            this.BuyrOrderStatus = ApplicationHelper.EMPTY;
            this.ProfitTakerOrderStatus = ApplicationHelper.EMPTY;
            this.StopOrderStatus = ApplicationHelper.EMPTY;

        }
    }
}
