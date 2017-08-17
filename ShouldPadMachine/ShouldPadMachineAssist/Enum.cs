using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    namespace Enum
    {
        public enum PromptOccurPlace : byte//警告发生在哪里
        {
            SerialPortReceiveError,//串口接收时发生错误
            SerialPortSendError,//串口发送时出错
            FileError,          //对文件操作时出错，
            ImageError,         //对图片操作时出错
            XmlWriteError,      //对数据文件操作时出错
            XmlReadError,       //对数据文件读取是出错
            SQLiteModelError,   //逻辑出现错误
            DataTimeError,      //系统时间操作时出错
            RegistryError,      //对注册表操作时出错
            OpenOtherFormError, //打开对话框时出错
            UnKnown,            //不可预知的地方         
            Null,
        }
        public enum PromptMessageType : byte//警告信息类型
        {
            IndexOutOfRangeException,//下标溢出
            SecurityException,       //加密文件，用户没有读取注册表所需的权限
            ObjectDisposedException, //对象已经被破坏
            RegistryUnKnownException,//发生不可预知的错误
            ReadSystemDateException, //读取系统时间时出错
            XmlException,            //Xml中有加载或分析错误----格式被错误
            IOException,             //打开文件时发生了I/O错误
            UnauthorizedAccessException,//当前平台不支持此操作或指定了一个只读文件
            NullReferenceException,//未被引用错误
            StackOverflowException,//无限递归错误
            ArgumentOutOfRangeException,//属性无效错误
            InvalidOperationException,//指定端口已经打开
            TimeoutException,         //该操作未在超时时间到期之前完成
            EndOfStreamException,     //已经操纵的文件末端错误
            UnKnown,                  //不可预知的错误
            PromptMessageType,        //
            ShouldUpdataFile,         //
            Null,
        }
        public enum SerialDataType
        {
            SendData,
            ReceiveData,
        }
        public enum PromptType : byte
        {
            ErrorInfo,
            WarnInfo
        }
        public enum DataTypeName
        {
            ShouldPadDataTable,
            BaseDataTable,
            InOutDataTable,
            MachineInfoDataTable,
            CascadeDataTable,
            ErrorInfoTable,
            WarnInfoTable,
            FlowDataTable,
            Null,
        }

        public enum ShouldPadDataEnum : byte
        {
            ShapePoints,            //点的坐标
            LeftClothClipSpace,              //左夹布夹间隙4 
            MiddClothChipSpace,               //主夹布夹间隙5
            RightClothChipSpace,             //右夹布夹间隙6
            ShouldPadLength,              //花形长度1
            ShouldPadWidth,               //花形宽度2
            ShouldPadHalfLength,          //花形半长度3
            RowNum,                 //半个花型行数8
            XDirectGauge,                 //半个花型列数7
            GapX,                   //X轴方向间距12  
            YDirectGauge,                   //纵向针距9
            JagVal,                 //振动幅度 仅用于内锯齿花型11
            RadianLevel,             //弧度程度 仅用于标准花型10                
            NormalSpeed,            //普通缝纫速度
            CutLineDistance,        //剪线距离
            ClothNumberLimit,       //底缝件数限制
            Null
        }


        public enum MachineBaseDataEnum : byte
        {
            ID,                    //ShouldPadXMl的序列
            MaxSpeed,                //速度
            XZeroModify,           //X零位修正
            YZeroModify,           //Y零位修正
            UpNeedleCodeValue,     //上针位编码器值（伺服零位修正值）
            TotalClothNumberLimit, //总件数限制（件数限制（批次））
            ProductCount,          //记录已经生产的件数
            Machine_ID,            //机器码
            Null
        }
        public enum UserOperType : byte
        {
            CalculationOper,//计算
            EnlargementOPer,//放大
            ModifyOper,     //修改
            Null
        }
        public enum InOutDataEnum : byte
        {
            Out1,
            Input1,
            Null
        }
        public enum CascadeDataEnum : byte
        {
            ID1,
            SET1,
            Null
        }

        public enum SetDataEnum : byte//画园参数
        {
            angleOfX,
            angleOfX1,
            angleOfX2,
            angleOfX3,
            angleOfX4,
            angleOfX5,
            angleOfX6,
            angleOfX7,
            angleOfX8,
            angleOfX9,
            angleOfY,
            angleOfY1,
            angleOfY2,
            angleOfY3,
            angleOfY4,
            angleOfY5,
            angleOfY6,
            angleOfY7,
            angleOfY8,
            angleOfY9,
            RotationAngleOfX,
            RotationAngleOfX1,
            RotationAngleOfX2,
            RotationAngleOfX3,
            RotationAngleOfX4,
            RotationAngleOfX5,
            RotationAngleOfX6,
            RotationAngleOfX7,
            RotationAngleOfX8,
            RotationAngleOfX9,
            RotationAngleOfY,
            RotationAngleOfY1,
            RotationAngleOfY2,
            RotationAngleOfY3,
            RotationAngleOfY4,
            RotationAngleOfY5,
            RotationAngleOfY6,
            RotationAngleOfY7,
            RotationAngleOfY8,
            RotationAngleOfY9,
            Null
        }
        public enum OtherStringType : byte
        {
            Pin,
            MM,
            ExpiratPrompt,
            ID,
            SerialNumber,
        }
        public enum UnitType : byte
        {
            Pin,
            MM,
            Null
        }
        public enum WarnType : byte
        {
            CommunicationError,
            ModeSwitchWarn,
            WorkedNumberOverflowWarn,
            TotalWorkedNumberOverflowWarn,
            LineBreakWarn,
            CrdWarn,
            SFLVoltWarn,
            STLVoltWarn,
            IOLVoltWarn,            
            SF_NoEcdWarn,
            SF_NoMotorWarn,
            SF_QepErrWarn,
            SF_OLoadWarn,
            SF_OCurWarn,
            X_NoMotorWarn,            
            X_QepErrWarn,
            X_OLoadWarn,
            X_OCurWarn,
            Y_NoMotorWarn,
            Y_QepErrWarn,
            Y_OLoadWarn,
            Y_OCurWarn,            
            SysTimeOutWarn,
            UpperSensorErr,
            MidSensorErr,
            DownSensorErr,
            LeftSensorErr,
            RightSensorErr,
            UpperSensorErrL,
            MidSensorErrL,
            DownSensorErrL,
            LeftSensorErrL,
            RightSensorErrL,
            XSensorErr,
            YSensorErr,
            ServoSensorErr,
            SysRePowerErr,
            ModifiedValueWarn,
            Null,
        }
        public enum LowerDataType : byte
        {
            ShouldPadPointInfoType,
            MachineBasicDataType,
            ServoDataType,
            TestDataType,
            ButtonPointType,
            ErrorDataType,
            CommunicatError,
            VersionDataType,
            LowerSingleStepInfoType,
            EncStaInfoType,
            EncResInfoType,
            NULL
        }
        public enum ImageType : byte
        {
            SaveImage,           //保持图片
            NeedleImage,         //针的图片
            NumberImage,         //件数图片
            MoveRightImage,      //向右移动图片
            MoveLeftImage,       //向左移动图片
            MoveUpImage,         //向上移动图片
            MoveDownImage,       //向下移动图片
            MoveRightUpImage,    //向右上移动图片
            MoveLeftUpImage,     //向左上移动图片
            MoveRightDownImage,  //向右下移动图片
            MoveLeftDownImage,   //向左下移动图片
            AddPointImage,       //增加点按钮
            DeletePointImage,    //删除点按钮
            MakeSureImage,       //确定按钮
            ReturnImgae,         //返回按钮
            RevokedImage,        //撤销
            //MovePointImage,      //移动光标
            CoilingImage,        //绕线模式图片
            SettingImage,        //设置图片
            EditImage,           //编辑
            ShapeFixedImage,     //图形修正
            DrawBitmapImage,     //图形修正
            SingleStepImage,     
            MirrorImage,         //镜像图片
            RightImage,
            LeftImage,
            SewingStatueImage,
            NeedleOperImage,
            MoveTypeImage,
            ModeImage,
            LeftPatternImage,   //左半花型绘制
            RightPatternImage,  //右半花型绘制


            Null, 
        }
        public enum ButtonStatus : byte
        {
            Normal,
            Press,
        }
        public enum MachineInfoEnum : byte
        {
            BoardCodeVersion,
            BoardModifyTime,
            BoardID,
            CreateImageEnable,
            ScreenCodeVersion,
            ScreenModifyTime,
            BoardLoadTime,
            ScreenLoadTime,
            OpenVerifyEnable,
            ScreenID,
            MachineID,
            UseLanguage,
            TotalNumber,
            ExpiratDate,
            SequenceID,
            StepMotorVersion,
            ServoMotorVersion,
            Null
        }
        public enum OtherInfoEnum : byte
        {
            UpdataFileName,
            //ChangedFileName,
            //ErrorFileName,
        }

        public enum FileCtrlEnum : byte
        {
            ExeUpData,
            EcoUpData,
            BootLoadUpData,
            CopyCurXml,
            CopyAllXml,
            GetXml,
            Null
        }

        public enum SearchType : byte
        {
            PromptTime,
            PromptVersion,
            PromptID,
            Null
        }
        public enum DialogResultEx
        {
            None = 0,
            OK = 1,
            Cancel = 2,
            Abort = 3,
            Retry = 4,
            Ignore = 5,
            Yes = 6,
            No = 7,
            GetInfo = 8,
            Delete = 9,
            Updata = 10,
            GoToSystem = 11,
        }
        public enum MessageBoxButtonType
        {
            None,
            OK,
            YesCancel,
            Repair,
            RetryCancel,
            RetryGetCancel,
            InputUpdata,
            InPutGetUpdata,
            InPutDeleteUpdata,
        }
        public enum PromptInfoEnum : byte
        {
            PromptID,               //错误ID
            Version,                //版本
            OccurTime,              //错误发生时间
            PromptName,              //错误名称
            PromptData,              //错误数据信息
            RunTime,                //运行时间
            Null
        }
        public enum ButtonType
        {
            PressButton,    //按下后改变放开后又改变的按钮
            ClickButton,    //点击了才会改变的按钮
            NoChangeButton, //不是点击事件控制的按钮
        }
        public enum MoveType : byte
        {
            MoveShapeSelectPoint,
            MoveShapeUnSelectPoint,
            MoveShape,
            Null,
        }
        public enum PointOperType : byte
        {
            DeletePoint,
            AppendPoint,
            MovePoint,
        }
        public enum DirectionType : byte
        {
            MoveLeftUp,
            MoveUp,
            MoveRightUp,
            MoveRight,
            MoveRightDown,
            MoveDown,
            MoveLeftDown,
            MoveLeft,
            MoveNext,
            MovePrevious,
        }
        public enum BackInfoType : byte
        {
            Success,
            Continue,
            CircleError,
            SamePoint,//相同点
        }
        public enum SendDataType
        {
            NormalSerialData = 0x20,   //普通的串口数据
            DesignParam = 0x21,//花型参数  
            TestSerialData = 0x23,     //测试数据
            ClearComdSerailData = 0x24,//清除下位机件数
            MachineSerialData = 0x25,  //机器参数           
            ShouldPadPointsData = 0x27,//VersionCheckSerialData = 0x27,
            SingleStepSerialData =0x28,//屏幕按键           
            LockStaSerialData = 0x29,  //加密系统状态
            UnLockSerialData = 0x2A    //尝试解密
        }
        public enum UpdataType : byte
        {
            LowerMachine,
            MainProgram,
        }
        public enum InterfaceMode
        {
            MainFormMode = 0,//正常缝纫
            EditFormMode=3,//编辑模式
            ModifyFormMode = 4,//修正模式
            SingleStepMode = 1,//单步缝纫
            BaseFormMode = 5,//
            TestFormMode = 2,//测试模式
            FlowDrawForm = 6,
            MenuForm = 7,
            Null
        }
        public enum ScreenWorkedStatue : byte
        { 
            NormalStatue,//正常状态
            SingleStepStatue,//单步状态
        }
        public enum WorkedStatue : byte
        {
            IdealStatue = 0,        //空闲
            InitializeStatue = 1,   //初始化状态
            WaitToStartStatue = 2,  //等待启动
            WorkingStatue = 3,      //运行中  
            Null
        }
    }
}
