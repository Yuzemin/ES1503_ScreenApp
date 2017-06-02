using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist;


namespace ShouldPadMachine.ShouldPadMachineModel
{
    public abstract class DataBaseModel
    {
        protected String[] dataBaseValues;//数据库中的数据
        protected bool dataChanged;//标记着数据是否改变
        protected String fileName;//该数据模型属于哪一个Xml文件
        protected String rootElementName;
        public String[] DataBaseValues
        {
            get {
                return dataBaseValues;
            }
        }
        public String RootElementName
        {
            get {
                return rootElementName;
            }
            set {
                rootElementName = value;
            }
        }
        public String FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName =  value;
            }
        }
        public bool HaveDataChanged
        {
            get
            {
                bool flag = dataChanged;
                dataChanged = false;
                return flag;
            }
            set {
                dataChanged = value;
            }
        }
        public String this[int index]
        {
            get
            {
                String value = "0";
                if (dataBaseValues != null && index < dataBaseValues.Length)
                    value = dataBaseValues[index];
                else
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.SQLiteModelError,PromptMessageType.IndexOutOfRangeException);
                return value;
            }
            set
            {
                if (dataBaseValues != null && index < dataBaseValues.Length)
                {
                    dataBaseValues[index] = value;
                    if (IsUartDatas(index))
                        dataChanged = true;
                }
                else
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.SQLiteModelError, PromptMessageType.IndexOutOfRangeException);
            }
        }
        public String this[String enumName]
        {
            set
            {
                int index = GetEnumValueByEnumName(enumName);
                this[index] = value;
            }
            get
            {
                int index = GetEnumValueByEnumName(enumName);
                return this[index];
            }
        }
        public virtual void SetDataBaseValues(String[] dataBaseValues)
        {
            this.dataBaseValues = dataBaseValues;
            dataChanged = true;
        }
        public virtual String[] GetDataBaseValues()
        {
            return dataBaseValues;
        }
        protected virtual bool IsUartDatas(int index)
        {
            return true;
        }
        protected abstract int GetEnumValueByEnumName(String enumName);//通过枚举名称得到枚举的值
        public DataBaseModel()
        {
        }
    }
    public class ShouldPadModel : DataBaseModel//模具数据模型
    {
        private static DataBaseModel dataBaseModel;
        private ShouldPadModel()
        {
            fileName = "ShouldPadData_1.xml";
            rootElementName = "ShouldPadData";
        }
        protected override bool IsUartDatas(int index)
        {
            ShouldPadDataEnum shouldPadDataEnum = (ShouldPadDataEnum)index;
            if (shouldPadDataEnum == ShouldPadDataEnum.ShapePoints)
                ScreenStatueData.ScreenStatueDataEX.ParrentChanged = true;
            if (shouldPadDataEnum == ShouldPadDataEnum.NormalSpeed)
                ScreenStatueData.ScreenStatueDataEX.NormalSpeedChanged = true;
            if (shouldPadDataEnum == ShouldPadDataEnum.NormalSpeed || shouldPadDataEnum == ShouldPadDataEnum.CutLineDistance||shouldPadDataEnum == ShouldPadDataEnum.ClothNumberLimit)
                return true;
            else
                return false;
        }
        public override void SetDataBaseValues(string[] dataBaseValues)
        {
            ScreenStatueData.ScreenStatueDataEX.ParrentChanged = true;
            base.SetDataBaseValues(dataBaseValues);
        }
        public static DataBaseModel GetDataBaseModel()
        {
            if (dataBaseModel == null)
                dataBaseModel = new ShouldPadModel();
            return dataBaseModel;
        }
        protected override int GetEnumValueByEnumName(string enumName)
        {
            int mouldDataIndex = 0;
            ShouldPadDataEnum mouldDataEnum = (ShouldPadDataEnum)Enum.Parse(typeof(ShouldPadDataEnum),enumName,true);
            mouldDataIndex = (int)mouldDataEnum;
            return mouldDataIndex;
        }
    }

    public class FlowDataModel : DataBaseModel//数据模型
    {
        private static FlowDataModel dataBaseModel;

        private FlowDataModel()
        {
            fileName = "FlowXml.xml";
            rootElementName = "FlowDataXml";
        }
        public static FlowDataModel GetDataBaseModel()
        {
            if (dataBaseModel == null)
                dataBaseModel = new FlowDataModel();
            return dataBaseModel;
        }       

        protected override int GetEnumValueByEnumName(string enumName)//返回数据模型
        {
            SetDataEnum setDataEnum = (SetDataEnum)Enum.Parse(typeof(SetDataEnum),enumName,true);
            return (int)setDataEnum;
        }
    }

    public class BaseDateModel : DataBaseModel//机器基本参数数据模型
    {
        private static DataBaseModel dataBaseModel;
        private BaseDateModel()
        {
            fileName = "BaseData.xml";
            rootElementName = "BaseData";
        }
        protected override bool IsUartDatas(int index)
        {
            MachineBaseDataEnum[] baseDataEnums = new MachineBaseDataEnum[] { MachineBaseDataEnum.ID};
            bool flag = true;
            for (int i = 0; i < baseDataEnums.Length; i++)
            {
                if (((int)baseDataEnums[i]) == index)
                    flag = false;
            }
            return flag;
        }
        public static DataBaseModel GetDataBaseModel()
        {
            if (dataBaseModel == null)
                dataBaseModel = new BaseDateModel();
            return dataBaseModel;
        }
        protected override int GetEnumValueByEnumName(string enumName)
        {
            MachineBaseDataEnum baseDataEnum = (MachineBaseDataEnum)Enum.Parse(typeof(MachineBaseDataEnum), enumName, true);
            return (int)baseDataEnum;
        }
    }
    public class InOutDataModel : DataBaseModel
    {
        private static DataBaseModel dataBaseModel;
        private InOutDataModel()
        {
            fileName = "InOutData.xml";
            rootElementName = "InOutData";
        }
        public static DataBaseModel GetDataBaseModel()
        {
            if (dataBaseModel == null)
                dataBaseModel = new InOutDataModel();
            return dataBaseModel;
        }
        protected override int GetEnumValueByEnumName(string enumName)
        {
            InOutDataEnum inOutDataEnum = (InOutDataEnum)Enum.Parse(typeof(InOutDataEnum), enumName, true);
            return (int)inOutDataEnum;
        }
    }
    public class CascasdeDataModel : DataBaseModel
    {
        private static DataBaseModel dataBaseModel;
        private CascasdeDataModel()
        {
            fileName = "CascadeData.xml";
            rootElementName = "CascadeData";
        }
        public static DataBaseModel GetDataBaseModel()
        {
            if (dataBaseModel == null)
                dataBaseModel = new CascasdeDataModel();
            return dataBaseModel;
        }
        protected override int GetEnumValueByEnumName(string enumName)
        {
            CascadeDataEnum cascasdeDataEnum = (CascadeDataEnum)Enum.Parse(typeof(CascadeDataEnum), enumName, true);
            return (int)cascasdeDataEnum;
        }
    }
    class MachineInfoModel
    {
        private String stepMotorVersion;
        private String servoMotorVersion;
        private String boardCodeVersion;
        private String boardModifyTime;
        private String machineID;
        private String createImageEnable;
        private String screenCodeVersion;
        private String screenModifyTime;
        private String boardLoadTime;
        private String screenLoadTime;
        private String openVerifyEnable;
        private String boardID;
        private String screenID;
        private String useLanguage;
        private String totalNumber;
        private String expiratData;
        private String sequenceID;

        public String StepMotorVersion
        {
            get
            {
                return stepMotorVersion;
            }
            set
            {
                stepMotorVersion = value;
            }
        }
        public String ServoMotorVersion
        {
            get
            {
                return servoMotorVersion;
            }
            set
            {
                servoMotorVersion = value;
            }
        }
        public String BoardID
        {
            get { return boardID; }
            set { boardID = value; }
        }
        public String ScreenID
        {
            get { return screenID; }
            set { screenID = value; }
        }
        public String UseLanguage
        {
            get { return useLanguage; }
            set { useLanguage = value; }
        }
        public String TotalNumber
        {
            get { return totalNumber; }
            set { totalNumber = value; }
        }
        public String ExpiratData
        {
            get { return expiratData; }
            set { expiratData = value; }
        }
        public String SequenceID
        {
            get { return sequenceID; }
            set { sequenceID = value; }
        }
        public String BoardModifyTime
        {
            get { return boardModifyTime; }
            set { boardModifyTime = value; }
        }
        public String BoardCodeVersion
        {
            get { return boardCodeVersion; }
            set { boardCodeVersion = value; }
        }
        public String MachineID
        {
            get { return machineID; }
            set { machineID = value; }
        }
        public String CreateImageEnable
        {
            get { return createImageEnable; }
            set { createImageEnable = value; }
        }
        public String ScreenCodeVersion
        {
            get { return screenCodeVersion; }
            set { screenCodeVersion = value; }
        }
        public String ScreenModifyTime
        {
            get { return screenModifyTime; }
            set { screenModifyTime = value; }
        }
        public String BoardLoadTime
        {
            get { return boardLoadTime; }
            set { boardLoadTime = value; }
        }
        public String ScreenLoadTime
        {
            get { return screenLoadTime; }
            set { screenLoadTime = value; }
        }
        public String OpenVerifyEnable
        {
            get { return openVerifyEnable; }
            set { openVerifyEnable = value; }
        }
    }
    public class PromptInfoModel
    {
        private String[] defaultValues;
        public PromptInfoModel()
        {
            defaultValues = new String[6];
            for (int i = 0; i < defaultValues.Length; i++)
                defaultValues[i] = String.Empty;
        }
        public String[] DefaultValues
        {
            set {
                defaultValues = value;
            }
            get {
                return defaultValues;
            }
        }
        public String PromptName//提示名称
        {
            set
            {
                defaultValues[3] = value;
            }
            get
            {
                return defaultValues[3];
            }
        }
        public String PromptID//提示代码
        {
            set
            {
                defaultValues[0] = value;
            }
            get
            {
                return defaultValues[0];
            }
        }
        public String PromptInfo//提示信息
        {
            set
            {
                defaultValues[4] = value;
            }
            get
            {
                return defaultValues[4];
            }
        }
        public String RunTime//提示出现时的运行时间
        {
            set
            {
                defaultValues[5] = value;
            }
            get
            {
                return defaultValues[5];
            }
        }
        public String CodeVersion//代码版本
        {
            set
            {
                defaultValues[1] = value;
            }
            get
            {
                return defaultValues[1];
            }
        }
        public String PromptTime//提示发生时间
        {
            set
            {
                defaultValues[2] = value;
            }
            get
            {
                return defaultValues[2];
            }
        }
    }
}
