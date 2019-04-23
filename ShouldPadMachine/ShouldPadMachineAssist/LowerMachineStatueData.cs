using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class LowerMachineStatueData//下位机状态数据
    {
        private static LowerMachineStatueData lowerMachineStatueData;
        private String servoVersion;
        private String stepVersion;
        private uint errorValue;
        private byte errorID;
        private byte warnID;
        private ushort warnValue;
        private bool haveWarnInfo;
        private bool cascadeOver;
        private bool editStatue;
        private byte sendClothStatue;
        private bool singleStepStatue;
        private WorkedStatue workedStatue;
        private short[] xBgnDstErr = new short[20];
        private short[] xEndDstErr = new short[20];
        private short[] yBgnDstErr = new short[20];
        private short[] yEndDstErr = new short[20];

        private LowerMachineStatueData()
        {
            editStatue = false;
            sendClothStatue = 0;
            singleStepStatue = false;
        }
        public static LowerMachineStatueData LowerMachineStatueDateEx
        {
            get {
                if (lowerMachineStatueData == null)
                    lowerMachineStatueData = new LowerMachineStatueData();
                return lowerMachineStatueData;
            }
        }
        public void SetServoVersion(byte versionValue)
        {
            servoVersion = "580.V2." + versionValue.ToString();
        }
        public void SetStepVersion(byte stepVersion)
        {
            this.stepVersion = "580.V2." + stepVersion.ToString();
        }
        public WorkedStatue WorkedStatue
        {
            get {
                return workedStatue;
            }
            set {
                workedStatue = value;
            }
        }
        public byte SendClothStatue
        {
            get {
                return sendClothStatue;
            }
            set {
                sendClothStatue = value;
            }
        }
        public bool SingleStepStatue
        {
            get
            {
                return singleStepStatue;
            }
            set
            {
                singleStepStatue = value;
            }
        }
        public bool EditStatue
        {
            get
            {
                return editStatue;
            }
            set {
                editStatue = value;
            }
        }
        public String ServoVersion
        {
            get
            {
                return servoVersion;
            }
        }
        public String StepVersion
        {
            get
            {
                return stepVersion;
            }
        }
        public ushort WorkedNumber
        {
            get;
            set;
        }
        public bool MachineCanWork
        {
            get;
            set;
        }
        public byte TotalNeedleNumber
        {
            get;
            set;
        }


        public bool ReachesPositionWarn
        {
            get;
            set;
        }


        public bool WorkedNumberOverflowWarn
        {
            get;
            set;
        }
        public bool TotalWorkedNumberOverflowWarn
        {
            get;
            set;
        }

        public bool LineBreakWarn
        {
            get;
            set;
        }
        public bool CrdWarn
        {
            get;
            set;
        }
        public bool ClickSewingButtonWarn
        {
            get;
            set;
        }
        public bool CommunicationWarn
        {
            get;
            set;
        }

        public bool ModeSwitchWarn { get; set; }


        public bool SFLVoltWarn { get; set; }
        public bool STLVoltWarn { get; set; }
        public bool IOLVoltWarn { get; set; }
        public bool SF_QepErrWarn { get; set; }
        public bool SF_NoMotorWarn { get; set; }
        public bool SF_OCurWarn { get; set; }
        public bool SF_OLoadWarn { get; set; }
        public bool SF_NoEcdWarn { get; set; }
        public bool X_QepErrWarn { get; set; }
        public bool X_OLoadWarn { get; set; }
        public bool X_OCurWarn { get; set; }
        public bool X_NoMotorWarn { get; set; }
        public bool Y_QepErrWarn { get; set; }
        public bool Y_OLoadWarn { get; set; }
        public bool Y_OCurWarn { get; set; }
        public bool Y_NoMotorWarn { get; set; }
        public bool SysTimeOutWarn { get; set; }
        public bool SysRePowerWarn { get; set; }            
        public bool UpperSensorErr { get; set; }
        public bool MidSensorErr { get; set; }
        public bool DownSensorErr { get; set; }
        public bool LeftSensorErr { get; set; }
        public bool RightSensorErr { get; set; }
        public bool XSensorErr { get; set; }
        public bool YSensorErr { get; set; }
        public bool ServoSensorErr { get; set; }
        public bool UpperSensorErrL { get; set; }
        public bool MidSensorErrL { get; set; }
        public bool DownSensorErrL { get; set; }
        public bool LeftSensorErrL { get; set; }
        public bool RightSensorErrL { get; set; }

        public short[] XBgnDstErr
        {
            get { return xBgnDstErr; }
            set { xBgnDstErr = value; }
        }
        public short[] XEndDstErr
        {
            get { return xEndDstErr; }
            set { xEndDstErr = value; }
        }
        public short[] YBgnDstErr
        {
            get { return yBgnDstErr; }
            set { yBgnDstErr = value; }
        }
        public short[] YEndDstErr
        {
            get { return yEndDstErr; }
            set { yEndDstErr = value; }
        }

        public uint ErrorValue
        {
            set
            {
                errorValue = value;
                for (int i = 0; i < 32; i++)
                {
                    if ((errorValue & (1 << i)) != 0)
                    {
                        errorID = Convert.ToByte(i + 1);
                        break;
                    }
                }
            }
        }
        public byte ErrorID
        {
            get
            {
                return errorID;
            }
            set
            {
                errorID = value;
            }
        }
        public ErrorInfo ErrorInfo
        {
            set;
            get;
        }
        public bool HaveWarnInfo
        {
            get;
            set;
        }
        public byte WarnID
        {
            get
            {
                return warnID;
            }
        }
        public bool CascadeOver
        {
            set
            {
                if (cascadeOver != value)
                {
                    cascadeOver = value;
                }
            }
            get
            {
                bool flag = cascadeOver;
                cascadeOver = false;
                return flag;
            }
        }
        public bool Working
        {
            set;
            get;
        }
        public int NeedPointIndex
        {
            get;
            set;
        }
        public void SetWarnValue(ushort warnValue)
        {
            ushort lowerWarnValue = warnValue;
            ushort occurData = Convert.ToUInt16(lowerWarnValue ^ this.warnValue);//提取到是否有新的警告发生
            if (occurData != 0 && haveWarnInfo == false)
            {
                haveWarnInfo = true;
                if ((occurData & 0x000C) == 0x000C)
                {
                    this.warnValue |= 0x000C;
                    warnID = 10;
                }
                else
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((occurData & (1 << i)) != 0)
                        {
                            if (i == 2 || i == 3)//2和3 是140电压过高和140电压过低 过滤掉 不检测
                                haveWarnInfo = false;
                            warnID = (byte)(i + 1);
                            this.warnValue |= Convert.ToUInt16(1 << i);
                            break;
                        }
                    }
                }
            }
        }
    }
}
