using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class ScreenStatueData
    {
        private static ScreenStatueData screenStatueData;
        private int[] testDatas;//测试数据
        private int cascadeCount;//级联次数
        private bool collectionLowerPoint;//收集下位机点使能
        private bool clearWorkNumber;//清除数据使能
        private bool finishThreadLine;//完成穿线
        private bool knowedWarn;//用户是否点看到警告
        private bool shouldReset;//复位使能
        private byte[] verifyDatas;//版本数据
        private int buttonID;
        private int needPointIndex;
        private bool haveSendShapePoints;
        private InterfaceMode interfaceMode;
        private int selectPointIndex;
        private bool numberOverflow;
        private ushort testIndex;           //运动测试序号 0:无效 1~20:100~2000

        private int installedButton;//装机按钮
        private byte machineTestData;
        private ushort screenButton;//屏幕按键
        private bool sendDesignFlag;//花型参数
        private bool parrentChanged;//花型改变
        private bool normalSpeedChanged;//速度改变
        private bool screenButtonEnable;
        private bool unLock;
        private ScreenWorkedStatue screenWorkedStatue;
       
        public static int patternIndex;//包序号

        public bool AutoEnable { get; set; }

       
        private ScreenStatueData()
        {
            testDatas = new int[10];
            shouldReset = false;
            haveSendShapePoints = true;
            interfaceMode = InterfaceMode.MainFormMode;
            numberOverflow = false;
            machineTestData = 0;
            sendDesignFlag = false;
            parrentChanged = false;
            normalSpeedChanged = false;
            screenWorkedStatue = ScreenWorkedStatue.NormalStatue;
            screenButtonEnable = true;
            unLock = false;
            testIndex = 0;
        }
        public static ScreenStatueData ScreenStatueDataEX
        {
            get{
                if(screenStatueData == null)
                    screenStatueData = new ScreenStatueData();
                return screenStatueData;
            }
        }

        #region get set方法
        public ushort TestIndex
        {
            get
            {
                return testIndex;
            }
            set
            {
                testIndex = value;
            }
        }
        public bool UnLock
        {
            get
            {
                return unLock;
            }
            set
            {

                unLock = value;
            }
        }
        public bool ScreenButtonEnable
        {
            get {
                return screenButtonEnable;
            }
            set {
                screenButtonEnable = value;
            }
        }
        public ScreenWorkedStatue ScreenWorkedStatue
        {
            get {
                return screenWorkedStatue;
            }
            set {
                if (screenWorkedStatue != value)
                {
                    sendDesignFlag = true;
                    screenWorkedStatue = value;
                }
            }
        }
        public bool NormalSpeedChanged
        {
            get {
                bool flag = normalSpeedChanged;
                normalSpeedChanged = false;
                return flag;
            
            }
            set {
                normalSpeedChanged = value;
            }
        }
        public bool ParrentChanged
        {
            get {
                bool flag = parrentChanged;
                parrentChanged = false;
                return flag;
            }
            set {
                parrentChanged = value;
            }
        }
        public bool SendDesignFlag
        {
            get {
                bool flag = sendDesignFlag;
                sendDesignFlag = false;
                return flag;
            }
            set {
                sendDesignFlag = value;
            }
        }
        public ushort ScreenButton
        {
            get { return screenButton; }
            set { screenButton = value; }
        }

        public int PatternIndex
        {
            get { return patternIndex; }
            set { patternIndex = value; }
        }
        public bool NumberOverflow
        {
            get {
                return numberOverflow;
            }
            set {
                numberOverflow = value;
            }
        }
        public int SelectPointIndex
        {
            get {
                return selectPointIndex;
            }
            set {
                selectPointIndex = value;
            }
        }
        public InterfaceMode InterfaceMode
        {
            get {
                return interfaceMode;
            }
            set {
                if (interfaceMode != value)
                {
                    interfaceMode = value;
                }
            }
        }
        public int InstalledButton//装机按钮
        {
            set
            {
                if (installedButton != value)
                {
                    installedButton = value;
                }
            }
            get
            {
                return installedButton;
            }
        }
 
        public bool HaveSendShapePoints
        {
            get {
                return haveSendShapePoints;
            }
            set {
                haveSendShapePoints = value;
            }
        }
        public int NeedPointIndex
        {
            set {
                needPointIndex = value;
            }
            get {
                return needPointIndex;
            }
        }

        //复位按键信号
        public bool ResetBtnFlag
        {
            set
            {
                if (value)
                    screenButton |= 0x01;
                else
                    screenButton &= 0xFE;
            }
        }

        //前进一针
        public bool ForwardNeedle
        {
            set 
            {
                if (value)
                    screenButton |= 0x02;
                else
                    screenButton &= 0xFD;

            }
        }


        //后退一针
        public bool BackwardNeedle
        {
            set
            {
                if (value)
                    screenButton |= 0x04;
                else
                    screenButton &= 0xFB;

            }
        }


       

        public bool BlowCloth//吹布电磁阀
        {
            set
            {
                if (value)
                    machineTestData |= 0x01;
                else
                    machineTestData &= 0xFE;
            }
        }
        public bool CutLine//切布
        {
            set {
                if (value)
                    machineTestData |= 0x02;
                else
                    machineTestData &= 0xFD;
            }
        }
        public bool ClampCloth//夹布
        {
            set {
                if (value)
                    machineTestData |= 0x04;
                else
                    machineTestData &= 0xFB;
            }
        }
        public bool CarryCloth//运布
        {
            set
            {
                if (value)
                    machineTestData |= 0x08;
                else
                    machineTestData &= 0xF7;
            }
        }
        public bool PressCloth//压布
        {
            set
            {
                if (value)
                    machineTestData |= 0x10;
                else
                    machineTestData &= 0xEF;
            }
        }
        public bool LiftCloth//拿布
        {
            set
            {
                if (value)
                    machineTestData |= 0x20;
                else
                    machineTestData &= 0xDF;
            }
        }
        public byte MachineTestData//电磁阀输出设置
        {
            get {
                return machineTestData;
            }
        }
        public bool ShouldReset
        {
            set {
                shouldReset = value;
            }
            get {
                return shouldReset;
            }
        }
        public Byte[] VerifyDatas
        {
            set {
                verifyDatas = value;
            }
            get {
                return verifyDatas;
            }
        }
        public bool KnowedWarn
        {
            set {
                knowedWarn = value;
            }
            get {
                return knowedWarn;
            }
        }
        public int CascadeCount
        {
            set
            {
                cascadeCount = value;
            }
            get
            {
                return cascadeCount;
            }
        }
        public bool ClearWorkNumber
        {
            set
            {
                clearWorkNumber = value;
            }
        }
        public byte ClearNumberID
        {
            get;
            set;
        }
        public bool FinsihThreadLine
        {
            set
            {
                if (value == true)
                    finishThreadLine = false;
                else
                    finishThreadLine = true;
            }
            get
            {
                return finishThreadLine;
            }
        }
        public int ButtonID
        {//按下键的序号
            get {
                return buttonID;
            }
            set
            {
                buttonID = value;
            }
        }
        public uint OutPortStatue//输出端口状态
        {
            set
            {
                testDatas[2] = (int)(value & 0x00FF);
                testDatas[3] = (int)((value >> 8) & 0x00FF);
                testDatas[4] = (int)((value >> 16) & 0x00FF);
                testDatas[5] = (int)((value >> 24) & 0x00FF);
            }
        }
        public int ServoRunMode//伺服调试模式
        {
            set
            {
                testDatas[2] = value;
            }
        }
        public int StepRunMode//步进调试模式
        {
            set
            {
                testDatas[1] = value;
            }
        }
        public int AutoInterval//间隔时间
        {
            set
            {
                testDatas[1] = value;
            }
        }
        public bool CollectionLowerPoint//是否要收集下位机花型的点
        {
            set
            {
                collectionLowerPoint = value;
            }
            get
            {
                return collectionLowerPoint;
            }
        }
        #endregion

        public ushort GetSendCmdFlag()
        {
            ushort flag = 0;
            if (clearWorkNumber == true)
            {
                clearWorkNumber = false;
                flag |= 0x0008;
            }
            return flag;
        }
        public byte[] GetTestDatas()
        {
            byte[] uartDatas = new byte[testDatas.Length];
            for (int i = 0; i < uartDatas.Length; i++)
                uartDatas[i] = Convert.ToByte(testDatas[i]);
            return uartDatas;
        }
        public byte[] GetVerifyDatas()
        {
            byte[] uartData;
            if (verifyDatas == null)
                uartData = new byte[] { };
            else
            {
                uartData = new byte[verifyDatas.Length];
                verifyDatas.CopyTo(uartData, 0);
            }
            return uartData;
        }
        public byte[] GetNeedPointBytes()
        {
            byte[] bytes = new byte[2];
            bytes[0] = Convert.ToByte(needPointIndex & 0xFF);
            bytes[1] = Convert.ToByte((needPointIndex >> 8) & 0xFF);
            return bytes;
        }
        public byte[] GetNormalDatas()
        {
            byte[] uartDatas = new byte[4];
            uartDatas[0] = Convert.ToByte(buttonID);
            uartDatas[1] = Convert.ToByte(finishThreadLine);
            uartDatas[2] = Convert.ToByte(knowedWarn);
            uartDatas[3] = Convert.ToByte(shouldReset);
            return uartDatas;
        }
    }
}
