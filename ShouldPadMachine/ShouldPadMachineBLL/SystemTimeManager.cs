using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class SystemTimeManager
    {
        private uint startTimeMinute;
        private static SystemTimeManager systemTimeManager;
        public static SystemTimeManager SystemTimerEx
        {
            get
            {
                if (systemTimeManager == null)
                    systemTimeManager = new SystemTimeManager();
                return systemTimeManager;
            }
        }
        public String NowDate
        {
            get
            {
                String dateTime = String.Empty;
                try
                {
                    dateTime = DateTime.Now.ToString("yyyy-MM-dd");
                }
                catch
                {
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.DataTimeError);
                }
                return dateTime;
            }
        }
        public String NowDateTime
        {
            get
            {
                String dateTime = String.Empty;
                try
                {
                    dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
                }
                catch
                {
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.DataTimeError);
                }
                return dateTime;
            }
        }
        public String GetFileModifyTime(String fileName)
        {
            String dateTime = String.Empty;
            try
            {
                dateTime = File.GetLastWriteTime(fileName).ToString("yyyy-MM-dd");
            }
            catch
            {
                ErrorMessage.SetErrorMessage(PromptOccurPlace.DataTimeError);
            }
            return dateTime;
        }
        public void GetStartTime()
        {
            startTimeMinute = GetNowTimeMinute();
        }
        public uint GetRunMinTime()
        {
            uint nowTime = GetNowTimeMinute();
            return (nowTime - startTimeMinute) / 60;
        }
        private uint GetNowTimeMinute()
        {
            uint timeSencondCount = 0;
            String nowTime = DateTime.Now.ToString("HH:mm:ss");
            String[] timeSplit = nowTime.Split(':');
            timeSencondCount += Convert.ToUInt32(timeSplit[0]) * 60 * 60;
            timeSencondCount += Convert.ToUInt32(timeSplit[1]) * 60;
            timeSencondCount += Convert.ToUInt32(timeSplit[2]);
            return timeSencondCount;
        }

    }
}
