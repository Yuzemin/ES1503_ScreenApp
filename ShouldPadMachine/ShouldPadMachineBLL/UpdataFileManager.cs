using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist;


namespace ShouldPadMachine.ShouldPadMachineBLL
{    
    class UpdataFileManager
    {
        private String sourceFilePath = @"\Hard Disk";
        private string XmlFilePath = @"\ResidentFlash\xml";
        private string TargetPath = @"\Hard Disk\xml";
        public int Total_Num = 0;
        private bool bflag = true;

        //private long freeBytes = 0, totalBytes = 0, totalFreeBytes = 0;
        //#region 获取存储设备的大小信息
        ////变量声明          
        //[DllImport("coredll.dll")]
        //private static extern bool GetDiskFreeSpaceEx(string directoryName, ref long freeBytesAvailable, ref long totalBytes, ref long totaFreeBytes);
        //#endregion  

        private bool CheckLogicalDish()
        {
            return true;//GetDiskFreeSpaceEx(@"\Hard Disk", ref freeBytes, ref totalBytes, ref totalFreeBytes);

            //SelectQuery selectQuery = new SelectQuery("select * from win32_logicaldisk where DriveType='2'");
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

            //if (searcher.Get().Count == 1)
            //    return true;
            //else
            //    return false;
        }

        public bool CheckExeUpData()
        {
            String messageInfo = String.Empty;
            bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
                messageInfo = "没有找到U盘!";
            else if (!File.Exists(sourceFilePath + @"\ShouldPadMachine.exe"))
                messageInfo = "U盘内没有找到屏升级文件";
            else
            {
                MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
                machineInfoDAO.SetDataBaseValue(MachineInfoEnum.ScreenLoadTime, SystemTimeManager.SystemTimerEx.NowDate);
                machineInfoDAO.SetDataBaseValue(MachineInfoEnum.ScreenModifyTime, SystemTimeManager.SystemTimerEx.GetFileModifyTime(sourceFilePath + @"\ShouldPadMachine.exe"));
                machineInfoDAO.SetDataBaseValue(MachineInfoEnum.CreateImageEnable, true);
                return true;
            }

            ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, messageInfo);
            return false;
        }

        public bool CheckEcoUpData()
        {
            String messageInfo = String.Empty;
            bflag = bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
                messageInfo = "没有找到U盘!";
            else
            {
                String[] fileNames = Directory.GetFiles(sourceFilePath, "*.eco");
                if (fileNames.Length > 1)
                    messageInfo = "U盘内ECO文件过多!";
                else if (fileNames.Length == 0)
                    messageInfo = "U盘内ECO升级文件没找到!";
                else
                {
                    MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
                    machineInfoDAO.SetDataBaseValue(MachineInfoEnum.BoardLoadTime, SystemTimeManager.SystemTimerEx.NowDate);
                    machineInfoDAO.SetDataBaseValue(MachineInfoEnum.BoardModifyTime, SystemTimeManager.SystemTimerEx.GetFileModifyTime(fileNames[0]));
                    machineInfoDAO.SetDataBaseValue(MachineInfoEnum.CreateImageEnable, true);
                    return true;
                }
            }

            ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, messageInfo);
            return false;
        }

        public bool CheckBootLoad()
        {
            String messageInfo = String.Empty;
            bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
                messageInfo = "没有找到U盘!";
            else if (!File.Exists(sourceFilePath + @"\BootLoader.exe"))
                messageInfo = "U盘内没找到BootLoader程序!";

            if (messageInfo != String.Empty)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, messageInfo);
                return false;
            }
            else
                return true;
        }

        public bool CheckCopyCur(string Style_ID)
        {
            string ID = String.Format("ShouldPadData_{0}.xml", Style_ID);
            bflag = bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到U盘!");
                return false;
            }
            else if (!File.Exists(Path.Combine(XmlFilePath, ID)))
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "当前花型文件查找失败");
                return false;
            }

            Total_Num = 1;
            return true;
        }

        public bool CheckCopyAll()
        {
            bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到U盘!");
                return false;
            }

            string[] XmlNames = Directory.GetFiles(XmlFilePath, "*.xml");
            if (XmlNames.Length == 0)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "XML文件未找到!");
                return false;
            }

            List<String> XmlNameList = new List<string>(XmlNames);
            for (int i = XmlNameList.Count - 1; i >= 0; i--)
            {
                string SingleName = XmlNameList[i].Substring(XmlFilePath.Length + 1);
                if (SingleName == "BaseData.xml" || SingleName == "FlowXml.xml" || SingleName == "InOutData.xml")
                    XmlNameList.RemoveAt(i);
            }

            if (XmlNameList.Count == 0)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到花型文件!");
                return false;
            }

            Total_Num = XmlNameList.Count;
            return true;
        }

        public bool CheckGetXml()
        {
            bflag = CheckLogicalDish();

            if (!Directory.Exists(sourceFilePath) || bflag == false)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到U盘!");
                return false;
            }
            else if (!Directory.Exists(TargetPath))
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到XML文件夹!");
                return false;
            }

            string[] XmlNames = Directory.GetFiles(TargetPath, "*.xml");
            if (XmlNames.Length == 0)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到XML文件!");
                return false;
            }

            List<String> XmlNameList = new List<string>(XmlNames);
            for (int i = XmlNameList.Count - 1; i >= 0; i--)
            {
                string SingleName = XmlNameList[i].Substring(TargetPath.Length + 1);
                if (SingleName == "BaseData.xml" || SingleName == "FlowXml.xml" || SingleName == "InOutData.xml")
                    XmlNameList.RemoveAt(i);
            }

            if (XmlNameList.Count == 0)
            {
                ErrorMessage.SetErrorMessage(PromptMessageType.PromptMessageType, "没有找到XML花型文件!");
                return false;
            }
            Total_Num = XmlNameList.Count;
            return true;
        }            
    }
}
