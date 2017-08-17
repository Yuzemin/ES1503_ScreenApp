using System;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Security;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineModel;
 

namespace ShouldPadMachine.ShouldPadMachineDAL
{
    public abstract class DataBaseDAO//数据库对象----基础类
    {
        protected DataBaseModel dataBaseModel;
        protected String[] defaultHeadNames;
        protected String[] defaultDatas;
        private String[] CreateNewXml(String xmlName)
        {
            String backName = GetBackFileName();
            String[] newXmlDatas = null;
            bool shouldCreatNewXml = true;
            if (backName != String.Empty)
            {
                backName = DefaultPath.DefaultPathEx.DataBasePath + backName;
                if (File.Exists(backName))
                {
                    File.Copy(backName, xmlName);
                    shouldCreatNewXml = false;
                }
            }
            if (shouldCreatNewXml)
            {
                InfoHashTable infoHashTable = GetDefaultInfoHashTable();
                XmlHelper.CreateXml(infoHashTable, xmlName);
                newXmlDatas = defaultDatas;
            }
            return newXmlDatas;
        }
        protected InfoHashTable GetDefaultInfoHashTable()//获得默认的数据表
        {
            InfoHashTable infoHashTable = new InfoHashTable();
            infoHashTable.Add(dataBaseModel.RootElementName, null);
            for (int i = 0; i < defaultHeadNames.Length; i++)  //1
                infoHashTable.Add(defaultHeadNames[i], defaultDatas[i]);
            infoHashTable.Add("End", null);
            return infoHashTable;
        }
        protected virtual String GetBackFileName()//获得该Xml是否有备份文件，有则用备份文件创建一个新的文件
        {
            return String.Empty;
        }
        public virtual void LoadAllData()
        {
            String xmlName = dataBaseModel.FileName;
            xmlName = DefaultPath.DefaultPathEx.DataBasePath + xmlName; //计算XML路径
            String[] xmlDatas = null;
            if (!File.Exists(xmlName))          //该XML不存在则创建
                xmlDatas = CreateNewXml(xmlName);
            if (xmlDatas == null)               //目标XML存在
            {
                InfoHashTable infoHashTable;
                if (defaultHeadNames == null)
                    infoHashTable = XmlHelper.ReadXmlValues(xmlName);  // 读取XML中的数据？？  XML中的元素有哪几个？在哪里添加的？
                else
                    infoHashTable = XmlHelper.ReadXmlValues(xmlName, defaultHeadNames);
                List<String> infoValueList = new List<String>();
                for (int i = 0; i < infoHashTable.Values.Length; i++)
                {
                    if (infoHashTable.Values[i] != null)
                        infoValueList.Add(infoHashTable.Values[i].ToString());
                }
                xmlDatas = infoValueList.ToArray();                                         //将XML中的数据放到xmlDatas中
            }
            dataBaseModel.SetDataBaseValues(xmlDatas);  //什么用？
        }
        public void SaveAllDataBase()
        {
            String xmlName = dataBaseModel.FileName;
            xmlName = DefaultPath.DefaultPathEx.DataBasePath + xmlName;
            defaultDatas = dataBaseModel.DataBaseValues;
            InfoHashTable infoHashTable = GetDefaultInfoHashTable();
            XmlHelper.CreateXml(infoHashTable, xmlName);
        }
        public String GetDataBaseValue(int elementIndex)
        {
            return dataBaseModel[elementIndex];
        }
        public String GetDataBaseValue(String elementName)
        {
            return dataBaseModel[elementName];
        }
        public void SetDataBaseValue(String elementName, String elementValue)
        {
            String xmlName = dataBaseModel.FileName;
            xmlName = DefaultPath.DefaultPathEx.DataBasePath + xmlName;
            dataBaseModel[elementName] = elementValue;
            XmlHelper.SetElementValue(xmlName, elementName, elementValue.ToString());
        }
    }

    public class ShouldPadDAO : DataBaseDAO
    {
        public string FileIndex
        {
            set 
            {
                dataBaseModel.FileName = String.Format("ShouldPadData_{0}.xml", value);
            }
        }
        public ShouldPadDAO()
        {
            dataBaseModel = ShouldPadModel.GetDataBaseModel();
            int endIndex = (int)ShouldPadDataEnum.Null;
            defaultHeadNames = new String[endIndex];
            defaultDatas = new String[endIndex];
            for (int i = 0; i < endIndex; i++)
                defaultHeadNames[i] = Convert.ToString((ShouldPadDataEnum)i);
        }
        protected override string GetBackFileName()
        {
            return "ShouldPadData_1.xml";
        }

        public String GetShapePointInfos()
        {
            return base.GetDataBaseValue((int)ShouldPadDataEnum.ShapePoints);
        }
        public int GetDataBaseValue(ShouldPadDataEnum mouldDataEnum)
        {
            if (mouldDataEnum == ShouldPadDataEnum.ShapePoints)
                return 0;
            else
                return Convert.ToInt32(base.GetDataBaseValue(Convert.ToInt32(mouldDataEnum)));
        }
        public void SetDataBaseValue(ShouldPadDataEnum shouldPadDataEnum, String shouldPadValue)
        {
            base.SetDataBaseValue(shouldPadDataEnum.ToString(), shouldPadValue);
        }
        public void SetDataBaseValue(ShouldPadDataEnum mouldDataEnum, int mouldDataValue)
        {
            base.SetDataBaseValue(mouldDataEnum.ToString(), mouldDataValue.ToString());
        }
    }

    public class MachineBaseDataDAO : DataBaseDAO
    {
        public MachineBaseDataDAO()
        {
            dataBaseModel = BaseDateModel.GetDataBaseModel();
            int endIndex = (int)MachineBaseDataEnum.Null;
            defaultHeadNames = new String[endIndex];
            defaultDatas = new String[endIndex];
            for (int i = 0; i < endIndex; i++)
            {
                defaultHeadNames[i] = Convert.ToString((MachineBaseDataEnum)i);
                defaultDatas[i] = "0";
                if (i == (int)MachineBaseDataEnum.ID)
                    defaultDatas[i] = "1";
            }
        }

        public bool IsParamsInvalid()
        {
            if ((GetDataBaseValue(MachineBaseDataEnum.XZeroModify) == 0) || (GetDataBaseValue(MachineBaseDataEnum.YZeroModify) == 0) || (GetDataBaseValue(MachineBaseDataEnum.UpNeedleCodeValue) == 0))
                return true;
            else
                return false;
        }

        public int GetDataBaseValue(MachineBaseDataEnum machineBaseDataEnum)
        {
            return Convert.ToInt32(base.GetDataBaseValue((int)machineBaseDataEnum));
        }

        public string GetSDataBaseValue(MachineBaseDataEnum machineBaseDataEnum)
        {
            return base.GetDataBaseValue((int)machineBaseDataEnum);
        }

        public void SetDataBaseValue(MachineBaseDataEnum machineBaseDataEnum, int machineDataValue)
        {
            base.SetDataBaseValue(machineBaseDataEnum.ToString(), machineDataValue.ToString());
        }

        public void SetStringValue(MachineBaseDataEnum machineBaseDataEnum, String ele_Value)
        {
            base.SetDataBaseValue(machineBaseDataEnum.ToString(), ele_Value);
        }
    }

    public class InOutDataDAO : DataBaseDAO
    {
        public InOutDataDAO()
        {
            dataBaseModel = InOutDataModel.GetDataBaseModel();
            int endIndex = (int)InOutDataEnum.Null;
            defaultHeadNames = new String[endIndex];
            defaultDatas = new String[endIndex];
            for (int i = 0; i < endIndex; i++)
            {
                defaultHeadNames[i] = Convert.ToString((InOutDataEnum)i);
                defaultDatas[i] = "0";
            }
        }
    }

    public class FlowDataDAO : DataBaseDAO
    {
        public int FileIndex
        {
            set
            {
                dataBaseModel.FileName = String.Format("FlowXml.xml", value);
            }
        }
        public FlowDataDAO()
        {
            dataBaseModel = FlowDataModel.GetDataBaseModel();
            int endIndex = (int)SetDataEnum.Null;
            defaultHeadNames = new String[endIndex];
            defaultDatas = new String[endIndex];
            for (int i = 0; i < endIndex; i++)
            {
                defaultHeadNames[i] = Convert.ToString((SetDataEnum)i);
                defaultDatas[i] = "0";
            }
        }
        protected override string GetBackFileName()
        {
            return "FlowXml.xml";
        }
        public int GetDataBaseValue(SetDataEnum keyHoleDataEnum)
        {
            String baseValue = base.GetDataBaseValue(Convert.ToInt32(keyHoleDataEnum));
            return Convert.ToInt32(baseValue);
        }
        public void SetDataBaseValue(SetDataEnum keyHoleDataEnum, int keyHoleDataValue)
        {
            base.SetDataBaseValue(keyHoleDataEnum.ToString(), keyHoleDataValue.ToString());
        }
    }

    public class PromptInfoDAO
    {
        private String dataBaseName;
        private String rootElementName;
        private String[] headNames;
        private int maxLength;
        public PromptInfoDAO(PromptType promptType)
        {
            maxLength = 100;
            dataBaseName = promptType.ToString() + ".Xml";
            rootElementName = promptType.ToString();
            dataBaseName = DefaultPath.DefaultPathEx.DataBasePath + dataBaseName;
            int endIndex = (int)PromptInfoEnum.Null;
            headNames = new String[endIndex];
            for (int i = 0; i < endIndex; i++)
                headNames[i] = ((PromptInfoEnum)i).ToString();
        }
        public void SetDataBaseValue(PromptInfoModel promptInfoMode)
        {
            InfoHashTable infoHashTable = new InfoHashTable();
            String[] promptNames = promptInfoMode.DefaultValues;
            if (!File.Exists(dataBaseName))
            {
                infoHashTable.Add(rootElementName + "S", null);
                infoHashTable.Add("PromptInfoNumber","1");
                infoHashTable.Add(rootElementName + "1",null);
                for (int i = 0; i < headNames.Length; i++)
                {
                    infoHashTable.Add(headNames[i], promptNames[i]);
                }
                infoHashTable.Add("End",null);
                infoHashTable.Add("End", null);
                XmlHelper.CreateXml(infoHashTable, dataBaseName);
            }
            else
            {
                int infoIndex =Convert.ToInt32(XmlHelper.GetElementValue(dataBaseName, "PromptInfoNumber"));
                bool appendElement = false;
                infoIndex++;
                if (infoIndex > maxLength)
                    infoIndex = 1;
                else
                    appendElement = true;
                XmlHelper.SetElementValue(dataBaseName, "PromptInfoNumber", infoIndex.ToString());
                infoHashTable.Add(rootElementName + infoIndex.ToString(), null);
                for (int i = 0; i < headNames.Length; i++)
                {
                    infoHashTable.Add(headNames[i], promptNames[i]);
                }
                infoHashTable.Add("End", null);
                if (appendElement)
                    XmlHelper.AppendElementValues(infoHashTable, dataBaseName);
                else
                    XmlHelper.ModifyElementValue(dataBaseName, infoHashTable);
            }
        }
        public PromptInfoModel[] ReadPromptInfos()
        {
            InfoHashTable infoHashTable = XmlHelper.ReadXmlValues(dataBaseName);
            List<PromptInfoModel> promptInfoModelList = new List<PromptInfoModel>();
            PromptInfoModel promptInfoModel = null;
            String keyName = String.Empty;
            if (infoHashTable != null)
            {
                foreach (SingleHashTable singleHashTable in infoHashTable)
                {
                    keyName = singleHashTable.Key.ToString();
                    if (keyName == (rootElementName + "S") || keyName == "PromptInfoNumber")
                        continue;
                    if (keyName.IndexOf(rootElementName) != -1)
                        promptInfoModel = new PromptInfoModel();
                    else if (keyName.IndexOf("End") == -1)
                    {
                        PromptInfoEnum promptInfoEnum = (PromptInfoEnum)Enum.Parse(typeof(PromptInfoEnum), keyName, true);
                        switch (promptInfoEnum)
                        {
                            case PromptInfoEnum.OccurTime:
                                promptInfoModel.PromptTime = singleHashTable.Value.ToString();
                                break;
                            case PromptInfoEnum.PromptData:
                                promptInfoModel.PromptInfo = singleHashTable.Value.ToString();
                                break;
                            case PromptInfoEnum.PromptID:
                                promptInfoModel.PromptID = singleHashTable.Value.ToString();
                                break;
                            case PromptInfoEnum.PromptName:
                                promptInfoModel.PromptName = singleHashTable.Value.ToString();
                                break;
                            case PromptInfoEnum.RunTime:
                                promptInfoModel.RunTime = singleHashTable.Value.ToString();
                                break;
                            case PromptInfoEnum.Version:
                                promptInfoModel.CodeVersion = singleHashTable.Value.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (promptInfoModel != null)
                        {
                            promptInfoModelList.Add(promptInfoModel);
                            promptInfoModel = null;
                        }
                    }
                }
            }
            return promptInfoModelList.ToArray();
        }
    }

    public abstract class RegistryDAO
    {
        protected String subKeyName;
        public String GetDataBaseValue(String elementName)
        {
            RegistryKey registryKey = null;
            String keyValue = String.Empty;
            try
            {
                registryKey = Registry.LocalMachine.OpenSubKey(subKeyName);
                if (registryKey != null)
                {
                    object keyObject = registryKey.GetValue(elementName);
                    if (keyObject != null)
                        keyValue = keyObject.ToString();
                }
            }
            catch(Exception ex)
            { 
                PromptMessageType messageType = PromptMessageType.Null;
                if (ex is ObjectDisposedException)
                    messageType = PromptMessageType.ObjectDisposedException;
                else if (ex is SecurityException)
                    messageType = PromptMessageType.SecurityException;
                else
                    messageType = PromptMessageType.RegistryUnKnownException;
                 ErrorMessage.SetErrorMessage(PromptOccurPlace.RegistryError,messageType);
            }
            return keyValue;
        }
        public void SetDataBaseValue(String elementName, String elementValue)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Registry.LocalMachine.OpenSubKey(subKeyName, true);
                if (registryKey == null)
                    registryKey = Registry.LocalMachine.CreateSubKey(subKeyName);
                registryKey.SetValue(elementName, elementValue);
            }
            catch (Exception ex)
            {
                PromptMessageType messageType = PromptMessageType.Null;
                if (ex is ObjectDisposedException)
                    messageType = PromptMessageType.ObjectDisposedException;
                else if (ex is SecurityException)
                    messageType = PromptMessageType.SecurityException;
                else
                    messageType = PromptMessageType.RegistryUnKnownException;
                ErrorMessage.SetErrorMessage(PromptOccurPlace.RegistryError, messageType);
            }
        }
    }

    public class MachineInfoDAO : RegistryDAO
    {
        public MachineInfoDAO()
        {
            subKeyName = "MachineInfo";
        }
        public void SetDataBaseValue(MachineInfoEnum machineInfoEnum, String elementValue)
        {

            base.SetDataBaseValue(machineInfoEnum.ToString(), elementValue);
        }
        public void SetDataBaseValue(MachineInfoEnum machineInfoEnum, bool elementValue)
        {
            String value = Convert.ToInt32(elementValue).ToString();
            base.SetDataBaseValue(machineInfoEnum.ToString(), value);
        }
        public String GetDataBaseValue(MachineInfoEnum machineInfoEnum)
        {
            String machineInfoValue = String.Empty;
            machineInfoValue = base.GetDataBaseValue(machineInfoEnum.ToString());
            return machineInfoValue;
        }

    }

    public class OtherInfoDAO : RegistryDAO
    {
        public OtherInfoDAO()
        {
            subKeyName = "OtherInfo";
        }
        public void SetDataBaseValue(OtherInfoEnum otherInfoEnum, String elementName)
        {
            base.SetDataBaseValue(otherInfoEnum.ToString(), elementName);
        }
        public String GetDataBaseValue(OtherInfoEnum otherInfoEnum)
        {
            String elementValue = base.GetDataBaseValue(otherInfoEnum.ToString());
            return elementValue;
        }
    }
}
