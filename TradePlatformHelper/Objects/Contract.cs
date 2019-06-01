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
        public float Close { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Action { get; set; }
        public string status { get; set; }
        
    }
}
