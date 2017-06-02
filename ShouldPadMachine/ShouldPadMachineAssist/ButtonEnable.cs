using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class ButtonEnable//用于检测按钮的使能
    {
        private static bool RelateCascadeButton(String relateData)//是否为级联相关按钮
        {
            relateData = relateData.ToLower();
            if (relateData.IndexOf("cascade") == -1)
                return false;
            else
                return true;
        }
        public static bool GetButtonEnable(String relateButton)
        {
            bool enable = true;
            //MachineBaseDataDAO baseDataDAO = new MachineBaseDataDAO();
            if (ScreenStatueData.ScreenStatueDataEX.ScreenButtonEnable == false)
                enable = false;
            if (LowerMachineStatueData.LowerMachineStatueDateEx.Working == true && relateButton.IndexOf("Setting")==-1)
                enable = false;
            if (LowerMachineStatueData.LowerMachineStatueDateEx.ReachesPositionWarn == true && relateButton.IndexOf("SingleStepButton") != -1)
                enable = false;
            if (relateButton.IndexOf("SingleStepButton") != -1)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.WorkedStatue != WorkedStatue.WaitToStartStatue || LowerMachineStatueData.LowerMachineStatueDateEx.SendClothStatue != 1)
                {
                    enable = false;
                }
            }
            return enable;
        }
    }
}
