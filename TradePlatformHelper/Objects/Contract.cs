using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradePlatformHelper.Objects
{
   public class AContract
    {
        public string Symbol { get; set; }
        public float SignalClose { get; set; }
        public DateTime SignalDateTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Action { get; set; }
        public string status { get; set; }
        public float LatestClose { get; set; }
        public DateTime LatestDateTime { get; set; }
        public int ParentOrderID { get; set; }
    }
}
