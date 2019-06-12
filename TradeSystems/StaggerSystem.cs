using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBApi;
using TradePlatformHelper;
namespace TradeSystems
{
    class StaggerSystem
    {
        private float StopLoss { get; set; }
        private int NumberOfStep { get; set; }
        private float StepSize { get; set; }
        private Contract Contract { get; set; }

        private string Action { get; set; }
        private Int64 CurrentOrderID { get; set; }
        private int ContractPerStep { get; set; }
        private void Submit()
        {
            try
            {
                for(int i= 0; i< NumberOfStep; i++)
                {
                    //ApplicationHelper.BracketOrder(CurrentOrderID,Action, ContractPerStep,);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
