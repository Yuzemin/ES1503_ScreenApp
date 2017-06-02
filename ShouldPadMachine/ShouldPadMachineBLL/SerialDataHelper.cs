using System;

using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    internal class SerialDataHelper
    {
        private bool haveReceiveData;
        private bool communicationError;
        private int sendDataTime;
        private int communicatTime;
        private int sendDataTickCount;//发送数据的定时次数
        private int communicatTickCount;//超时的定时次数
        private int sendTimeTickCount;
        private int communicatTimeTickCount;
        public ushort SendComdFlag { get; set; }//发送指令标记位
        public bool HaveReceiveData
        {
            get
            {
                return haveReceiveData;
            }
            set
            {
                haveReceiveData = value;
                if (value == true)
                    communicatTimeTickCount = 0;

            }
        }
        public bool CommunicationError
        {
            get
            {
                bool backFlag = communicationError;
                communicationError = false;
                return backFlag;
            }
        }
        public bool AddTimeTick()
        {
            bool backFlag = false;
            sendTimeTickCount++;
            communicatTimeTickCount++;
            if (sendTimeTickCount == sendDataTickCount)
            {
                sendTimeTickCount = 0;
                backFlag = true;
            }
            if (communicatTickCount == communicatTimeTickCount)
            {
                communicationError = true;
                communicatTimeTickCount = 0;
            }
            return backFlag;
        }
        public SerialDataHelper()
        {
            sendTimeTickCount = 0;
            communicatTimeTickCount = 0;
            sendDataTime = 200;
            communicatTime = 10000;
        }
        public SerialDataHelper(int timeInterval)
            : this()
        {
            sendDataTickCount = (sendDataTime + timeInterval - 1) / timeInterval;
            communicatTickCount = (communicatTime + timeInterval - 1) / timeInterval;
        }
    }
}
