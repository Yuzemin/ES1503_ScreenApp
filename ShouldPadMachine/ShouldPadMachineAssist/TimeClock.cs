using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class TimeData
    {
        private bool timeDataEnable;//标记着是否操作数据
        private int timeCount;//标记着触发次数
        private int timeCountMax;//标记着次数最大值
        private bool enable;//是否已到达触发次数最大值
        public bool TimeDataEnable
        {
            get
            {
                return timeDataEnable;
            }
            set
            {
                if (timeDataEnable != value)
                {
                    timeCount = 0;
                    enable = false;
                    timeDataEnable = value;
                }
            }
        }
        public bool Enable
        {
            get
            {
                bool flag = enable;
                enable = false;
                return flag;
            }
        }
        public int TimeCountMax
        {
            set
            {
                timeCountMax = value;
            }
        }
        public void AddTimeDataCount()
        {
            if (timeDataEnable)
            {
                timeCount++;
                if (timeCount >= timeCountMax)
                {
                    timeCount = 0;
                    enable = true;
                }
            }
        }
        public TimeData(int timeCountMax)
        {
            this.timeCountMax = timeCountMax;
        }
    }
    /// <summary>
    /// 时间类，用一个定时器充当多个定时器
    /// </summary>
    class TimeClock
    {

        private TimeData movePlusTimeData;
        private TimeData getBitmapTimeData;
        private TimeData pressButtonTimeData;
        /// <summary>
        /// interval:外部定时器的中断几个；speedGear：速度档位，移动光标的速度档位
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="speedGear"></param>
        public TimeClock(int interval, int speedGear)
        {
            int countMax = 0;
            getBitmapTimeData = new TimeData(80 / interval);//80MS触发一次，读取图片给界面
            pressButtonTimeData = new TimeData(100 / interval);
            int maxInterval = 50;
            switch (speedGear)
            {
                case 1:
                    maxInterval = 20;
                    break;
                case 2:
                    maxInterval = 10;
                    break;
                case 3:
                    maxInterval = 5;
                    break;
            }
            countMax = maxInterval / interval;
            if (movePlusTimeData == null)
                movePlusTimeData = new TimeData(countMax);
        }
        public TimeClock(int interval)
            : this(interval, 1)
        {

        }
        public void ChangeSpeedGear(int interval, int speedGear)
        {
            int maxInterval = 50;
            int countMax;
            switch (speedGear)
            {
                case 0:
                    maxInterval = 50;
                    break;
                case 1:
                    maxInterval = 20;
                    break;
                case 2:
                    maxInterval = 10;
                    break;
                case 3:
                    maxInterval = 2;
                    break;
            }
            countMax = maxInterval / interval;
            if (movePlusTimeData != null)
                movePlusTimeData.TimeCountMax = countMax;
            else
                movePlusTimeData = new TimeData(countMax);
        }
        private void CloseUpTimeData()
        {
            if (movePlusTimeData != null)
                movePlusTimeData.TimeDataEnable = false;
            if (getBitmapTimeData != null)
                getBitmapTimeData.TimeDataEnable = false;
            if (pressButtonTimeData != null)
                pressButtonTimeData.TimeDataEnable = false;
        }
        public bool ShouldGetBitmapAgain
        {
            get {
                if (movePlusTimeData == null)
                    return false;
                else
                    return movePlusTimeData.TimeDataEnable;
            }
        }
        public bool GetBitmapEnable
        {
            get
            {
                if (getBitmapTimeData == null)
                    return false;
                else
                    return getBitmapTimeData.Enable;
            }
        }
        public bool PressButtonEnable
        {
            set
            {
                if (value == false)
                    CloseUpTimeData();
                if (pressButtonTimeData.TimeDataEnable != value)
                {
                    pressButtonTimeData.TimeDataEnable = value;
                }
            }
            get {
                return pressButtonTimeData.TimeDataEnable;
            }
        }
        public bool MovePlusEnable
        {
            get
            {
                if (movePlusTimeData == null)
                    return false;
                else
                    return movePlusTimeData.Enable;
            }
        }
        public void Timer_Tick()
        {
            pressButtonTimeData.AddTimeDataCount();
            getBitmapTimeData.AddTimeDataCount();
            movePlusTimeData.AddTimeDataCount();
            if (pressButtonTimeData.Enable)
            {
                getBitmapTimeData.TimeDataEnable = true;
                pressButtonTimeData.TimeDataEnable = false;
                movePlusTimeData.TimeDataEnable = true;
            }
        }
    }
}
