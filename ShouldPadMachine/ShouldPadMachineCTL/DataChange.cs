using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public static class DataChange
    {
        public static double ChangeXmlDataToShowData(DataInfo dataButtonInfo, int xmlData)
        {
            double midValue;
            midValue = Convert.ToDouble(xmlData);
            if (dataButtonInfo != null)
            {
                double addValue;
                bool pointEnable = dataButtonInfo.PointEnable;
                bool minusEnable = dataButtonInfo.MinusEnable;
                double maxValue = dataButtonInfo.MaxValue;
                double minValue = dataButtonInfo.MinValue;
                if (maxValue > Math.Abs(minValue))
                    addValue = maxValue;
                else
                    addValue = Math.Abs(minValue);
                if (pointEnable == true)
                    midValue /= 10;
                if (minusEnable == true)
                    midValue = Math.Round(midValue - addValue, 1);
            }
            return midValue;
        }
        public static int ChangeShowDataToXmlData(DataInfo dataButtonInfo, double showData)
        {
            double midValue = showData;
            if (dataButtonInfo != null)
            {
                double addValue;
                bool pointEnable = dataButtonInfo.PointEnable;
                bool minusEnable = dataButtonInfo.MinusEnable;
                double maxValue = dataButtonInfo.MaxValue;
                double minValue = dataButtonInfo.MinValue;
                if (maxValue > Math.Abs(minValue))
                    addValue = maxValue;
                else
                    addValue = Math.Abs(minValue);
                if (minusEnable == true)
                    midValue += addValue;
                if (pointEnable == true)
                    midValue *= 10;
            }
            return Convert.ToUInt16(midValue);
        }
    }
}
