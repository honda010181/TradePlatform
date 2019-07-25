using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBApi;
namespace TradePlatform.CustomModels
{
    class OrderModel : Order
    {
        public string OrderStatus { get; set; }
    }
}
