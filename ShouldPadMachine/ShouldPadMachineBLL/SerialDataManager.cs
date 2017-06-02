using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineSPL;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;
using System.Windows.Forms;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class SerialDataManager
    {
        private SerialPortEx serialPortEx;
        private SerialDataHelper serialDataHelper;
        private SendDataManager sendDataManager; 
        private SerialDataModelCollect serialDataModelCollect;
        private Timer formTimer;
        private byte oldComd = 0;               //未知
        private bool haveSendData;
        public static event ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle Feedback;
        public static bool FirstMachine = true;//第一次发机器参数
        public static bool ScreenButton = false;//28 屏幕按键
        public static bool FlowFlag = false;   //27 坐标

        private object key;//锁
        public SerialDataModelCollect SerialDataModelCollect
        {
            get
            {
                return serialDataModelCollect;
            }
        }
        public SerialDataManager()
        {
            int tickInterval = 100;
            key = new object();//创建一个资源
            serialPortEx = new SerialPortEx();
            serialPortEx.DataArrived += new ShouldPadMachineAssist.DelegateEx.DataArrivedEventHandle(SerialPortEx_DataArrived);
            serialDataHelper = new SerialDataHelper(tickInterval);
            sendDataManager = new SendDataManager();
            formTimer = new Timer();
            formTimer.Interval = tickInterval;
            formTimer.Tick += new EventHandler(FormTimer_Tick);
            serialDataModelCollect = new SerialDataModelCollect();
        }

        void FormTimer_Tick(object sender, EventArgs e)
        {
            if (serialDataHelper.HaveReceiveData == false)//100毫秒没接受到数据，清楚数据
                serialPortEx.ClearRecieveData();
            else
                serialDataHelper.HaveReceiveData = false;
            if (serialDataHelper.AddTimeTick())
                 SendSerialData();
            if (serialDataHelper.CommunicationError)
            {
                OnFeedBack(new UartComdEventArgs(LowerDataType.CommunicatError));
            }
        }
        private void SendSerialData()
        {
            ushort Rx_SData = 0;                            //  应该是发下来的 0x20 0x30 之类的命令头
            byte uartCmd = 0;
            int value = 0;

            Rx_SData = serialDataHelper.SendComdFlag;
            Rx_SData |= sendDataManager.GetSendCmdFlag();
            serialDataHelper.SendComdFlag = Rx_SData;
            
            for (int i = 0; i < 16; i++)
            {
                value = (Rx_SData >> i) & 0x01;
                if (value != 0)
                {
                    uartCmd = (byte)(0x21 + i);
                    break;
                }
                else
                    uartCmd = 0x20;
            }
            byte[] serialDatas = sendDataManager.GetSerialSendData(uartCmd);  //key 2 获得串口数据
            if (serialDatas != null)
            {
                if (uartCmd != oldComd || uartCmd != 0x20) //当前指令和原先的指令不同 或者 当前指令不为0x20
                {
                    haveSendData = true;
                    oldComd = uartCmd;
                    serialDataModelCollect.Add(new SerialDataModel(SerialDataType.SendData, uartCmd, serialDatas)); //??新建了一条指令？
                }                                                                                                   //应该有一个指令池 
                serialPortEx.SendSerialData(serialDatas, uartCmd);
            }
        }
        public void OpenSerialPort()
        {
            if (serialPortEx != null)
                serialPortEx.OpenSerialPort();
            if (formTimer != null)
                formTimer.Enabled = true;
        }
        public void CloseSerialPort()
        {
            if (serialPortEx != null)
                serialPortEx.CloseSerialPort();
            formTimer.Enabled = false;
            formTimer.Dispose();
        }
        public void OnFeedBack(UartComdEventArgs uartComdEventArgs)
        {
            if (Feedback != null)
                Feedback(uartComdEventArgs);
        }
        public void SerialSend_Tick(Object obj)//串口发送数据定时
        {
            lock (key)
            {
                if (serialDataHelper.HaveReceiveData == false)//100毫秒没接受到数据，清楚数据
                    serialPortEx.ClearRecieveData();
                else
                    serialDataHelper.HaveReceiveData = false;
                if (serialDataHelper.AddTimeTick())
                    SendSerialData();
                if (serialDataHelper.CommunicationError)
                    OnFeedBack(new UartComdEventArgs(LowerDataType.CommunicatError));
            }
        }
        protected void SerialPortEx_DataArrived(byte[] uartDatas, byte comd)  //从串口接收数据的功能函数
        {
            LowerDataInfo lowerDataInfo = null;
            if (uartDatas != null)
            {
                switch (comd)
                {
                    case 0x30:
                        lowerDataInfo = new MachineBasicDataInfo();
                        break;
                    case 0x31:
                        serialDataHelper.SendComdFlag &= 0xFFFE;
                        ScreenStatueData.ScreenStatueDataEX.SendDesignFlag = false;
                        break;
                    case 0x32:
                        serialDataHelper.SendComdFlag &= 0xFFFD;
                        break;
                    case 0x33:
                        lowerDataInfo = new TestDataInfo();
                        serialDataHelper.SendComdFlag &= 0xFFFB;
                        break;
                    case 0x34:
                        serialDataHelper.SendComdFlag &= 0xFFF7;
                        break;
                    case 0x35:
                        serialDataHelper.SendComdFlag &= 0xFFEF;
                        break;
                    case 0x36:                        
                        serialDataHelper.SendComdFlag &= 0xFFDF;
                        break;
                    case 0x37:
                        serialDataHelper.SendComdFlag &= 0xFFBF;
                        lowerDataInfo = new ShouldPadPointInfo();
                        SerialDataManager.FlowFlag = false;
                        break;
                    case 0x38:
                        serialDataHelper.SendComdFlag &= 0xFF7F;
                        SerialDataManager.ScreenButton = false;
                        ScreenStatueData.ScreenStatueDataEX.ResetBtnFlag = false;
                        ScreenStatueData.ScreenStatueDataEX.BackwardNeedle = false;
                        ScreenStatueData.ScreenStatueDataEX.ForwardNeedle = false;
                        break;
                    case 0x39:
                        serialDataHelper.SendComdFlag &= 0xFEFF;
                        lowerDataInfo = new EncstaInfo();
                        break;
                    case 0x3a:
                        serialDataHelper.SendComdFlag &= 0xFDFF;
                        MenuFormManager.SendUnLockFlag = false;
                        lowerDataInfo = new EncResInfo();
                        break;
                    default:
                        break;
                }
                if (haveSendData || comd != 0x30)
                {
                    haveSendData = false;
                    serialDataModelCollect.Add(new SerialDataModel(SerialDataType.ReceiveData, comd, uartDatas));
                }
                if (lowerDataInfo != null)
                {
                    lowerDataInfo.LoadLowerData(uartDatas);
                    OnFeedBack(new UartComdEventArgs(lowerDataInfo));
                }
            }
            serialDataHelper.HaveReceiveData = true;
        }
    }
}
