using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineBLL;


namespace ShouldPadMachine.ShouldPadMachineModel
{
    public abstract class LowerDataInfo
    {
        protected LowerDataType lowerDataType;
        public LowerDataType LowerDataType
        {
            get {
                return lowerDataType;
            }
        }
        protected ushort GetShortData(byte byte1, byte byte2)
        {
            ushort data = byte2;
            data <<= 8;
            data = Convert.ToUInt16(data + byte1);
            return data;
        }

        protected short GetInt16Data(byte byte1, byte byte2)
        {
            short data = byte2;
            data <<= 8;
            data = Convert.ToInt16(data + byte1);
            return data;
        }
        /// <summary>
        /// 加载下位机数据
        /// </summary>
        /// <param name="lowerDatas"></param>
        public abstract void LoadLowerData(byte[] backDatas);
    }
    public class MachineBasicDataInfo : LowerDataInfo//机器基本数据
    {
        private ushort workNeedleNumber;            //当前工作针数
        private ushort bootomWorkedNumber;          //底缝件数
        private ushort workedNumber;                //已完成的生产件数
        private short servoCodeValue;
        private ushort reciveGroupIndex;            //请求数据包信号
       // private ushort workedStatue;//工作状态
        private WorkedStatue workedStatue;
        private UInt32 errorValue;                  //错误数据
        private bool clickSewingButton = false;     //点击了缝纫按钮
        private bool errorOccur;                    //错误是否发生
        private byte testReport;                    //测试数据反馈  

        private bool modeSwitchWarn;                //模式切换错误
        private bool totalworkedNumberOverflowWarn; //总生产件数达到警告
        private bool workedNumberOverflowWarn;      //底线当前生产件数达到 提示信息
        private bool lineBreakWarn;                 //断线警告 
        private bool crdWarn;                       //坐标警告

        private bool sfLVoltWarn;//伺服电压过低警告
        private bool stLVoltWarn;//步进电压过低警告
        private bool ioLVoltWarn;//IO电源电压过低警告
        private bool sf_QepErrWarn;//伺服编码器错误
        private bool sf_NoMotorWarn;//伺服无电机错误
        private bool sf_OCurWarn;//伺服过流
        private bool sf_OLoadWarn;//伺服过载
        private bool sf_NoEcdWarn;//伺服无编码器
        private bool x_QepErrWarn;//X电机编码器错误
        private bool x_OLoadWarn;//X电机过载错误
        private bool x_OCurWarn;//X电机过流错误
        private bool x_NoMotorWarn;//X无电机 
        private bool y_QepErrWarn;//Y电机编码器错误
        private bool y_OLoadWarn;           //Y电机过载错误
        private bool y_OCurWarn;            //Y电机过流错误
        private bool y_NoMotorWarn;         //Y无电机 
        private bool sysTimeOutWarn { get; set; }
        private bool sysRePowerWarn { get; set; } 
        private bool UpperSensorErr;        //取布上端传感器错误
        private bool MidSensorErr;          //取布中端传感器错误
        private bool DownSensorErr;         //取布下端传感器错误
        private bool LeftSensorErr;         //取布左端传感器错误
        private bool RightSensorErr;        //取布右端传感器错误
        private bool xSensorErr;            //x回零错误
        private bool ySensorErr;            //y回零错误
        private bool servoSensorErr;        //伺服回零错误
        private bool UpperSensorErrL;       //取布上端传感器常量错误
        private bool MidSensorErrL;         //取布中端传感器常量错误
        private bool DownSensorErrL;        //取布下端传感器常量错误
        private bool LeftSensorErrL;        //取布左端传感器常量错误
        private bool RightSensorErrL;       //取布右端传感器常量错误

        private byte sendClothStatue;
        private bool singleStepStatue;
        private bool stReqstData;           //花型参数请求标志位

        public MachineBasicDataInfo()
        {
            lowerDataType = LowerDataType.MachineBasicDataType;
        }

        #region get set 方法

        public byte TestReport
        {
            get { return testReport; }

        }

        public bool StReqstData
        {
            get { return stReqstData; }

        }

        public bool SFLVoltWarn
        {
            get
            {
                return sfLVoltWarn;
            }
        }

        public bool STLVoltWarn
        {
            get
            {
                return stLVoltWarn;
            }
        }

        public bool IOLVoltWarn
        {
            get
            {
                return ioLVoltWarn;
            }
        }

        public bool SF_QepErrWarn
        {
            get
            {
                return sf_QepErrWarn;
            }
        }

        public bool SF_NoMotorWarn
        {
            get
            {
                return sf_NoMotorWarn;
            }
        }

        public bool SF_OCurWarn
        {
            get
            {
                return sf_OCurWarn;
            }
        }

        public bool SF_OLoadWarn
        {
            get
            {
                return sf_OLoadWarn;
            }
        }

        public bool SF_NoEcdWarn
        {
            get
            {
                return sf_NoEcdWarn;
            }
        }

        public bool X_QepErrWarn
        {
            get
            {
                return x_QepErrWarn;
            }
        }

        public bool X_OLoadWarn
        {
            get
            {
                return x_OLoadWarn;
            }
        }

        public bool X_OCurWarn
        {
            get
            {
                return x_OCurWarn;
            }
        }

        public bool X_NoMotorWarn
        {
            get
            {
                return x_NoMotorWarn;
            }
        }

        public bool Y_QepErrWarn
        {
            get
            {
                return y_QepErrWarn;
            }
        }

        public bool Y_OLoadWarn
        {
            get
            {
                return y_OLoadWarn;
            }
        }

        public bool Y_OCurWarn
        {
            get
            {
                return y_OCurWarn;
            }
        }

        public bool Y_NoMotorWarn
        {
            get
            {
                return y_NoMotorWarn;
            }
        }

        public bool SysTimeOutWarn
        {
            get
            {
                return sysTimeOutWarn;
            }
        }

        public bool SysRePowerWarn
        {
            get
            {
                return sysRePowerWarn;
            }
        }

        public bool takeClothUpperSensorErr
        {
            get {
                return UpperSensorErr;
            }
        }
        public bool takeClothUpperSensorErrL
        {
            get
            {
                return UpperSensorErrL;
            }
        }
        public bool takeClothMidSensorErr
        {
            get {
                return MidSensorErr;
            }
        }
        public bool takeClothMidSensorErrL
        {
            get
            {
                return MidSensorErrL;
            }
        }
        public bool takeClothDownSensorErr
        {
            get {
                return DownSensorErr;
            }
        }
        public bool takeClothDownSensorErrL
        {
            get
            {
                return DownSensorErrL;
            }
        }
        public bool takeClothLeftSensorErr
        {
            get {
                return LeftSensorErr;
            }
        }
        public bool takeClothLeftSensorErrL
        {
            get
            {
                return LeftSensorErrL;
            }
        }
        public bool takeClothRightSensorErr
        {
            get {
                return RightSensorErr;
            }
        }
        public bool takeClothRightSensorErrL
        {
            get
            {
                return RightSensorErrL;
            }
        }
        public bool xBackToZeroSensorErr
        {
            get {
                return xSensorErr;
            }
        }
        public bool yBackToZeroSensorErr
        {
            get {
                return ySensorErr;
            }
        }
        public bool servoBackToZeroSensorErr
        {
            get {
                return servoSensorErr;
            }
        }


        public bool ModeSwitchWarn
        {
            get {
                return modeSwitchWarn;
            }
        }
        public bool WorkedNumberOverflowWarn
        {
            get {
                return workedNumberOverflowWarn;
            }
        }
        public bool TotalWorkedNumberOverflowWarn
        {
            get
            {
                return totalworkedNumberOverflowWarn;
            }
        }
        public bool LineBreakWarn
        {
            get
            {
                return lineBreakWarn;
            }
        }
        public bool CrdWarn
        {
            get
            {
                return crdWarn;
            }
        }


        public short ServoCodeValue
        {
            get { return servoCodeValue; }
        } 
        public byte SendClothStatue
        {
            get {
                return sendClothStatue;
            }
        }
        public bool SingleStepStatue
        {
            get
            {
                return singleStepStatue;
            }
        }
        public ushort ReciveGroupIndex
        {
            get { return reciveGroupIndex; }
            set { reciveGroupIndex = value; }
        }
        public bool ClickSewingButton
        {
            get {
                return clickSewingButton;
            }
        }
        public UInt32 ErrorValue
        {
            get {
                return errorValue;
            }
        }
        public bool ErrorOccur
        {
            get {
                return errorOccur;
            }
        }

        public ushort WorkNeedleNumber
        {
            get
            {
                return workNeedleNumber;
            }
        }

        public ushort WorkedNumber
        {
            get
            {
                return workedNumber;
            }
        }
        public ushort BootomWorkedNumber
        {
            get {
                return bootomWorkedNumber;
            }
        }
        public WorkedStatue WorkedStatue
        {
            get
            {
                return workedStatue;
            }
            set
            {
                workedStatue = value;
            }
        }
        #endregion

        public override void LoadLowerData(byte[] backDatas)
        {
            int arrarLength = 20;

            if (backDatas.Length > arrarLength)
                arrarLength = backDatas.Length;
            byte[] lowerDatas = new byte[arrarLength];
            backDatas.CopyTo(lowerDatas, 0);

        //解析0x30命令
            //当前完成针数
            workNeedleNumber = GetShortData(lowerDatas[0], lowerDatas[1]);
            //已生产件数 
            workedNumber = GetShortData(lowerDatas[2], lowerDatas[3]);             
            //底线当前生产件数
            bootomWorkedNumber = GetShortData(lowerDatas[4], lowerDatas[5]);
            //伺服编码器值
            servoCodeValue = (short)(GetShortData(lowerDatas[6], lowerDatas[7]));
            //请求数据包序号
            reciveGroupIndex = GetShortData(lowerDatas[8], lowerDatas[9]);
            //花型参数请求标志位
            stReqstData = Convert.ToBoolean((lowerDatas[10] != 0) ? 1 : 0);
            //缝纫模块工作状态  0空闲 1初始化 2等待启动 3运行
            workedStatue = (WorkedStatue)lowerDatas[11];
            //运布装置状态 0:初始化 1:等待启动 2:运行
            sendClothStatue = lowerDatas[12]; 
            //单步缝纫状态位
            singleStepStatue = (lowerDatas[13] == 1 ? true : false);

            //获取系统警告和报错信号
            GetMachineWarn(lowerDatas[14], lowerDatas[15], lowerDatas[16], lowerDatas[17], lowerDatas[18]);

            //测试数据报告标志位
            testReport = lowerDatas[19];
        }

        private void GetMachineWarn(byte Warn_Msg, byte byte1, byte byte2, byte byte3,byte byte4)
        {
            UInt16 i = 0;
            UInt32 Err_Msg = 0;
            Err_Msg += Convert.ToUInt32(byte4) << 24;
            Err_Msg += Convert.ToUInt32(byte3) << 16;
            Err_Msg += Convert.ToUInt32(byte2) << 8;
            Err_Msg += Convert.ToUInt32(byte1);

            //模式切换错误报错
            modeSwitchWarn = ((Warn_Msg & 0x01) != 0);
            //总生产件数警告
            totalworkedNumberOverflowWarn = ((Warn_Msg & 0x02) != 0);
            //底线件数警告
            workedNumberOverflowWarn = ((Warn_Msg & 0x04) != 0);
            //断线警告
            lineBreakWarn = ((Warn_Msg & 0x08) != 0);
            //坐标警告
            crdWarn = ((Warn_Msg & 0x10) != 0);

            //0伺服电源电压过低
            sfLVoltWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //1步进电源电压过低
            stLVoltWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //2IO口电源电压过低
            ioLVoltWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //3伺服无编码器
            sf_NoEcdWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //4伺服无电机
            sf_NoMotorWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //5伺服编码值错误
            sf_QepErrWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //6伺服过载
            sf_OLoadWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //7伺服过流
            sf_OCurWarn = ((Err_Msg & (0x01U << i++)) != 0);

            //8X无电机
            x_NoMotorWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //9X电机编码值错误
            x_QepErrWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //10X电机过载
            x_OLoadWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //11X电机过流
            x_OCurWarn = ((Err_Msg & (0x01U << i++)) != 0);

            //12Y无电机
            y_NoMotorWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //13Y电机编码值错误
            y_QepErrWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //14Y电机过载
            y_OLoadWarn = ((Err_Msg & (0x01U << i++)) != 0);
            //15Y电机过流
            y_OCurWarn = ((Err_Msg & (0x01U << i++)) != 0);

            //16程序超时报错
            sysTimeOutWarn = ((Err_Msg & (0x01U << i++)) != 0);

            //17取布上端传感器错误
            UpperSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //18取布中端传感器错误
            MidSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //19取布下端传感器错误
            DownSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //20取布左端传感器错误
            LeftSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //21取布右端传感器错误
            RightSensorErr = ((Err_Msg & (0x01U << i++)) != 0);

            //22x回零错误
            xSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //23y回零错误
            ySensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //24伺服回零错误
            servoSensorErr = ((Err_Msg & (0x01U << i++)) != 0);
            //25电源波动报错
            sysRePowerWarn = ((Err_Msg & (0x01U << i++)) != 0);

            //26取布上端传感器错误
            UpperSensorErrL = ((Err_Msg & (0x01U << i++)) != 0);
            //27取布中端传感器错误
            MidSensorErrL = ((Err_Msg & (0x01U << i++)) != 0);
            //28取布下端传感器错误
            DownSensorErrL = ((Err_Msg & (0x01U << i++)) != 0);
            //29取布左端传感器错误
            LeftSensorErrL = ((Err_Msg & (0x01U << i++)) != 0);
            //30取布右端传感器错误
            RightSensorErrL = ((Err_Msg & (0x01U << i++)) != 0);

            i = 0;
        }

        private void GetErrorID(byte byte1, byte byte2, byte byte3, byte byte4)
        {
            UInt32 data32 = 0;
            if (errorValue == 0)
            {
                data32 += Convert.ToUInt32(byte4) << 24;//错误ID，标记在10，11，12，13组成的32位中,当
                data32 += Convert.ToUInt32(byte3) << 16;//当这四个组成的32位数据不为0时，将标记lowerData.OccurError为True,
                data32 += Convert.ToUInt32(byte2) << 8;//当occurError为true时,串口将发送0x28(提取错误信息),当接收
                data32 += Convert.ToUInt32(byte1);      //到0x38时，OccurError为false，提取到errorDatas并在lowerData组装成ErrorInfo
                errorValue = data32;                    //在主界面中，若HaveErrorInfo(标记着ErrorDatas是否为Null)为true,显示错误信息
                if (errorValue != 0)
                    errorOccur = true;
            }
        }

    }
    public class ShouldPadPointInfo : LowerDataInfo//垫肩点的信息
    {
        public ShouldPadPointInfo()
        {
            lowerDataType = LowerDataType.ShouldPadPointInfoType;
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            byte[] lowerDatas = new byte[backDatas.Length];
            backDatas.CopyTo(lowerDatas, 0);
            if (lowerDatas.Length > 0)
            {
                LowerShouldPointCollect.LowerShouldPointCollectEx.ReceiveGroupIndex = lowerDatas[0];
            }
        }
    }

    public class EncstaInfo : LowerDataInfo //加密系统状态的信息
    {
        public EncstaInfo()
        {
            lowerDataType = LowerDataType.EncStaInfoType;
        }

        public override void LoadLowerData(byte[] backDatas)
        {
            for (int i = 0; i < 4; i++)
                MenuFormManager.EncNum[i] = backDatas[i];  //获得上传的加密码

            MenuFormManager.IsActed = backDatas[4];  //获得激活状态
            MenuFormManager.IsLocked = backDatas[5]; //获得加锁状态
        }
    }

    public class EncResInfo : LowerDataInfo//解锁结果信息
    {
        public EncResInfo()
        {
            lowerDataType = LowerDataType.EncResInfoType;
        }

        public override void LoadLowerData(byte[] backDatas)
        {
            MenuFormManager.LockResult = backDatas[0];
        }
    }

    public class TestReportInfo : LowerDataInfo //运动测试
    {
        private ushort  rptID;
        private short xBgnDstErr;
        private short xEndDstErr;
        private short yBgnDstErr;
        private short yEndDstErr;

        #region   get set 方法

        public ushort RptID
        {
            get { return rptID; }
            set { rptID = value; }
        }
        public short XBgnDstErr
        {
            get { return xBgnDstErr; }
            set { xBgnDstErr = value; }
        }
        public short XEndDstErr
        {
            get { return xEndDstErr; }
            set { xEndDstErr = value; }
        }
        public short YBgnDstErr
        {
            get { return yBgnDstErr; }
            set { yBgnDstErr = value; }
        }
        public short YEndDstErr
        {
            get { return yEndDstErr; }
            set { yEndDstErr = value; }
        }

        #endregion

        public TestReportInfo()
        {
            lowerDataType = LowerDataType.TestReptDataType;
        }

        public override void LoadLowerData(byte[] backDatas)
        {
            //测试0x36回复解析
            byte[] lowerDatas = new byte[backDatas.Length];
            backDatas.CopyTo(lowerDatas, 0);

            //电磁阀 与 按钮状态读取
            rptID = GetShortData(lowerDatas[0], lowerDatas[1]);
            xBgnDstErr = GetInt16Data(lowerDatas[2], lowerDatas[3]);
            xEndDstErr = GetInt16Data(lowerDatas[4], lowerDatas[5]);
            yBgnDstErr = GetInt16Data(lowerDatas[6], lowerDatas[7]);
            yEndDstErr = GetInt16Data(lowerDatas[8], lowerDatas[9]);
        }
    }

    public class TestDataInfo : LowerDataInfo
    {
        private bool servoSensor;//伺服光电
        private bool xSensor;//X光电
        private bool ySensor;//Y光电
        private bool greenKey1;//绿按键1
        private bool redKey1;//红按键1
        private bool greenKey2;//绿按键2
        private bool redKey2;//红按键2
        private bool clampSensorLower;//压布电磁阀下感应
        private bool clampSensorMid;//压布电磁阀中感应
        private bool clampSensorUp;//压布电磁阀上感应
        private bool carrySensorLeft;//运布装置在左侧触发的开关
        private bool carrySensorRight;//运布装置在右侧触发的开关

        #region   get set 方法
        public int Xstep_EnCode { get; set; }
        public int Ystep_EnCode { get; set; }
        public int SF_EnCode { get; set; }
        public int SF_HallValue { get; set; }
        public int IO_VOLT { get; set; }

        public bool CarrySensorRight
        {
            get { return carrySensorRight; }
            set { carrySensorRight = value; }
        }

        public bool CarrySensorLeft
        {
            get { return carrySensorLeft; }
            set { carrySensorLeft = value; }
        }

        public bool ClampSensorUp
        {
            get { return clampSensorUp; }
            set { clampSensorUp = value; }
        }

        public bool ClampSensorMid
        {
            get { return clampSensorMid; }
            set { clampSensorMid = value; }
        }

        public bool ClampSensorLower
        {
            get { return clampSensorLower; }
            set { clampSensorLower = value; }
        }

        public bool RedKey2
        {
            get { return redKey2; }
            set { redKey2 = value; }
        }

        public bool GreenKey2
        {
            get { return greenKey2; }
            set { greenKey2 = value; }
        }

        public bool RedKey1
        {
            get { return redKey1; }
            set { redKey1 = value; }
        }

        public bool GreenKey1
        {
            get { return greenKey1; }
            set { greenKey1 = value; }
        }

        public bool YSensor
        {
            get { return ySensor; }
            set { ySensor = value; }
        }

        public bool XSensor
        {
            get { return xSensor; }
            set { xSensor = value; }
        }
        public bool ServoSensor
        {
            get { return servoSensor; }
            set { servoSensor = value; }
        }


        #endregion

        public TestDataInfo()
        {
            lowerDataType = LowerDataType.TestDataType;
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            //测试0x33回复解析
            int length = 12;
            if (backDatas.Length > length)
                length = backDatas.Length;
            byte[] lowerDatas = new byte[length];
            backDatas.CopyTo(lowerDatas, 0);

            //电磁阀 与 按钮状态读取
            GetSolenoidValState(GetShortData(lowerDatas[0], lowerDatas[1]));
            Xstep_EnCode = GetShortData(lowerDatas[2], lowerDatas[3]);
            Ystep_EnCode = GetShortData(lowerDatas[4], lowerDatas[5]);
            SF_EnCode = GetShortData(lowerDatas[6], lowerDatas[7]);
            SF_HallValue = GetShortData(lowerDatas[8], lowerDatas[9]);
            IO_VOLT = GetShortData(lowerDatas[10], lowerDatas[11]);
        }

        //电磁阀 与 按钮状态读取
        private void GetSolenoidValState(ushort solenoidValState)
        {
            ushort machineStatue = solenoidValState;
            if ((machineStatue & 0x01) == 0)   //伺服光电
                servoSensor = false;
            else
                servoSensor = true;
            if ((machineStatue & 0x02) == 0)   //X光电
                xSensor = false;
            else
                xSensor = true;
            if ((machineStatue & 0x04) == 0)   //Y光电
                ySensor = false;
            else
                ySensor = true;
            if ((machineStatue & 0x08) == 0)   //绿按键1
                greenKey1 = false;
            else
                greenKey1 = true;
            if ((machineStatue & 0x10) == 0)   //红按键1
                redKey1 = false;
            else
                redKey1 = true;
            if ((machineStatue & 0x20) == 0)   //绿按键2
                greenKey2 = false;
            else
                greenKey2 = true;
            if ((machineStatue & 0x40) == 0)   //红按键2
                redKey2 = false;
            else
                redKey2 = true;
            if ((machineStatue & 0x80) == 0)   //压布电磁阀下感应
                clampSensorLower = false;
            else
                clampSensorLower = true;
            if ((machineStatue & 0x100) == 0)   //压布电磁阀中感应
                clampSensorMid = false;
            else
                clampSensorMid = true;
            if ((machineStatue & 0x200) == 0)   //压布电磁阀上感应
                clampSensorUp = false;
            else
                clampSensorUp = true;
            if ((machineStatue & 0x400) == 0)   //运布装置在左侧触发的开关
                carrySensorLeft = false;
            else
                carrySensorLeft = true;
            if ((machineStatue & 0x800) == 0)   //运布装置在右侧触发的开关
                carrySensorRight = false;
            else
                carrySensorRight = true;

        }



    }
    public class ServoDataInfo : LowerDataInfo//伺服数据
    {
        private ushort inPutData;//输入值
        private ushort encodeX;
        private ushort encodeY;
        private ushort encodeZ;
        private ushort encodeS;
        private bool working;    //机器是否在工作
        private bool cascadeOver; //级联是否结束
        public bool Working
        {
            get {
                return working;
            }
        }
        public bool CascadeOver
        {
            get {
                return cascadeOver;
            }
        }
        public ushort InPutData
        {
            get {
                return inPutData;
            }
        }
        public ushort EncodeX
        {
            get {
                return encodeX;
            }
        }
        public ushort EncodeY
        {
            get {
                return encodeY;
            }
        }
        public ushort EncodeZ
        {
            get {
                return encodeZ;
            }
        }
        public ushort EncodeS
        {
            get {
                return encodeS;
            }
        }
        public ServoDataInfo()
        {
            lowerDataType = LowerDataType.ServoDataType;
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            byte[] lowerDatas = new byte[backDatas.Length];
            backDatas.CopyTo(lowerDatas, 0);
            inPutData = GetShortData(backDatas[0], backDatas[1]);                                                             
            encodeX = GetShortData(backDatas[2], backDatas[3]);
            encodeY = GetShortData(backDatas[4], backDatas[5]);
            encodeZ = GetShortData(backDatas[6], backDatas[7]);
            encodeS = GetShortData(backDatas[8], backDatas[9]);
            if (backDatas.Length > 10)
                working = backDatas[10] == 0 ? false : true;
            if (backDatas.Length > 11)
                cascadeOver = backDatas[11] == 1 ? true : false;
        }
    }
    public class LowerSingleStepInfo : LowerDataInfo
    { 
        private bool reachesPositionWarn;//是否到达位置
        private bool upNeedleLocatWarn;
        public bool ReachasPositionWarn
        {
            get {
                return reachesPositionWarn;
            }
        }
        public bool UpNeedleLocatWarn
        {
            get {
                return upNeedleLocatWarn;
            }
        }
        public LowerSingleStepInfo()
        {
            lowerDataType = LowerDataType.LowerSingleStepInfoType;
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            int length = 1;
            if (backDatas.Length > length)
                length = backDatas.Length;
            byte[] lowerDatas = new byte[length];
            backDatas.CopyTo(lowerDatas,0);
            GetMachineWarn(lowerDatas[0]);
        }
        private void GetMachineWarn(byte warnValue)
        {
            byte warnNumber = warnValue;
            if ((warnNumber & 0x01) == 0)
                reachesPositionWarn = false;
            else
                reachesPositionWarn = true;
            if ((warnNumber & 0x02) == 0)
                upNeedleLocatWarn = false;
            else
                upNeedleLocatWarn = true;
        }
    }
    public class ButtonPointInfo : LowerDataInfo//纽扣点信息,用于模拟下位机缝纫的纽扣图形
    {
        private Location[] pointLocations;//点的坐标的集合
        private int pointIndex;
        private int monitoringValue;
        public int PointIndex
        {
            get {
                return pointIndex;
            }
        }
        public int MonitoringValue
        {
            get {
                return monitoringValue;
            }
        }
        public ButtonPointInfo()
        {
            lowerDataType = LowerDataType.ButtonPointType;
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            byte[] lowerDatas = new byte[backDatas.Length];
            backDatas.CopyTo(lowerDatas, 0);
            if (pointLocations == null)
                pointLocations = new Location[5];
            pointIndex = (int)GetShortData(lowerDatas[0], lowerDatas[1]);
            monitoringValue = (int)GetShortData(lowerDatas[2], lowerDatas[3]);
            int startIndex = 0;
            if (lowerDatas.Length < 34)
                return;
            for (int i = 0; i < pointLocations.Length; i++)
            {
                pointLocations[i] = new Location();
                startIndex = i * 6;
                pointLocations[i].X = (double)GetShortData(lowerDatas[4 + startIndex], lowerDatas[5 + startIndex]);
                pointLocations[i].Y = (double)GetShortData(lowerDatas[6 + startIndex], lowerDatas[7 + startIndex]);
                pointLocations[i].Z = (double)GetShortData(lowerDatas[8 + startIndex], lowerDatas[9 + startIndex]);
            }
            //throw new NotImplementedException();
        }
        public int GetLocationIndex()
        {
            return pointIndex;
        }
        public Location[] GetLocationData()
        {
            return pointLocations;
        }
    }
    public class ErrorDataInfo : LowerDataInfo
    {
        private short[] errorDatas;
        public ErrorDataInfo()
        {
            lowerDataType = LowerDataType.ErrorDataType;
        }
        private void SetErrorDatas(byte[] byteErrorDatas)
        {
            int length = byteErrorDatas.Length / 2;
            byte[] datas = new byte[byteErrorDatas.Length];
            byteErrorDatas.CopyTo(datas, 0);
            errorDatas = new Int16[length];
            ushort data;
            for (int i = 0; i < length; i++)
            {
                data = GetShortData(datas[i * 2], datas[i * 2 + 1]);
                errorDatas[i] = (Int16)data;
            }
        }
        public ErrorInfo GetErrorInfo()
        {
            byte errorID = 0;
            errorID = LowerMachineStatueData.LowerMachineStatueDateEx.ErrorID;
            LowerMachineStatueData.LowerMachineStatueDateEx.ErrorID = 0;
            return new ErrorInfo(errorID, errorDatas);
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            byte[] lowerDatas = new byte[backDatas.Length];
            backDatas.CopyTo(lowerDatas, 0);
            if (lowerDatas[0] == 1)//第0位标记着这批数据是否有效
            {
                byte[] currentDatas = new byte[lowerDatas.Length - 1];
                for (int i = 1; i < currentDatas.Length; i++)
                    currentDatas[i - 1] = lowerDatas[i];
                SetErrorDatas(currentDatas);
                //??
            }
        }
    }
    public class VersionDataInfo : LowerDataInfo
    {
        private byte servoVersion;
        private byte stepVersion;
        public VersionDataInfo()
        {
            lowerDataType = LowerDataType.VersionDataType;
        }
        public byte ServoVersion
        {
            get {
                return servoVersion;
            }
        }
        public byte StepVersion
        {
            get {
                return stepVersion;
            }
        }
        public override void LoadLowerData(byte[] backDatas)
        {
            int arrarLength = 2;
            if (backDatas.Length > arrarLength)
                arrarLength = backDatas.Length;
            byte[] lowerDatas = new byte[arrarLength];
            backDatas.CopyTo(lowerDatas, 0);
            servoVersion = lowerDatas[0];
            stepVersion = lowerDatas[1];
        }
    }
    public class UartComdEventArgs : EventArgs
    {
        private LowerDataInfo lowerDataInfo;
        private LowerDataType lowerDataType;
        public UartComdEventArgs(LowerDataType lowerDataType)
        {
            this.lowerDataType = lowerDataType;
        }
        public UartComdEventArgs(LowerDataInfo lowerDataInfo)
        {
            this.lowerDataInfo = lowerDataInfo;
            this.lowerDataType = lowerDataInfo.LowerDataType;
        }
        public LowerDataInfo LowerDataInfo
        {
            get
            {
                return lowerDataInfo;
            }
        }
        public LowerDataType LowerDataType
        {
            get
            {
                return lowerDataType;
            }
        }
    }
}
