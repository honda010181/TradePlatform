using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradePlatformHelper;

namespace TradePlatform.TradeSystems
{
    public class StaggeringSystem
    {
     public   Dictionary<int, StepConfig> StepConfig = new Dictionary<int, StepConfig>();


        public Dictionary<string, object> config;
        public StaggeringSystem(string ConfigPath)
        {
            float StopAmount;
            int ContractQuantity;
            float ProfitTakerAmount;
            int stepNumber;
            config = new Dictionary<string, object>();
            config = ApplicationHelper.ReadXML(ConfigPath);

            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step1).Value.ToString(), out stepNumber);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step1StopAmount).Value.ToString(), out StopAmount);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step1ProfitTakerAmount).Value.ToString(), out ProfitTakerAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step1ContractQuantity).Value.ToString(), out ContractQuantity);

            StepConfig.Add(stepNumber, new StepConfig { stepNumber = stepNumber
                                            , ProfitTakerAmount = ProfitTakerAmount
                                            , StopLossAmount = StopAmount
                                            , contractQuantity = ContractQuantity}) ;


            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step2).Value.ToString(), out stepNumber);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step2StopAmount).Value.ToString(), out StopAmount);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step2ProfitTakerAmount).Value.ToString(), out ProfitTakerAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step2ContractQuantity).Value.ToString(), out ContractQuantity);

            StepConfig.Add(stepNumber, new StepConfig
            {
                stepNumber = stepNumber
                                            ,
                ProfitTakerAmount = ProfitTakerAmount
                                            ,
                StopLossAmount = StopAmount
                                            ,
                contractQuantity = ContractQuantity
            });


            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step3).Value.ToString(), out stepNumber);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step3StopAmount).Value.ToString(), out StopAmount);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step3ProfitTakerAmount).Value.ToString(), out ProfitTakerAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step3ContractQuantity).Value.ToString(), out ContractQuantity);

            StepConfig.Add(stepNumber, new StepConfig
            {
                stepNumber = stepNumber
                                            ,
                ProfitTakerAmount = ProfitTakerAmount
                                            ,
                StopLossAmount = StopAmount
                                            ,
                contractQuantity = ContractQuantity
            });

            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step4).Value.ToString(), out stepNumber);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step4StopAmount).Value.ToString(), out StopAmount);
            float.TryParse(config.First(x => x.Key == ApplicationHelper.Step4ProfitTakerAmount).Value.ToString(), out ProfitTakerAmount);
            int.TryParse(config.First(x => x.Key == ApplicationHelper.Step4ContractQuantity).Value.ToString(), out ContractQuantity);

            StepConfig.Add(stepNumber, new StepConfig
            {
                stepNumber = stepNumber
                                            ,
                ProfitTakerAmount = ProfitTakerAmount
                                            ,
                StopLossAmount = StopAmount
                                            ,
                contractQuantity = ContractQuantity
            });



        }



    }


    public class StepConfig
    {
        public int stepNumber { get; set; }
        public float ProfitTakerAmount { get; set; }
        public float StopLossAmount { get; set; }
        public int contractQuantity { get; set; }

    }

}
