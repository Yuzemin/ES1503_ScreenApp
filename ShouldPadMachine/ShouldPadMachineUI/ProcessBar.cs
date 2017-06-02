using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineBLL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class ProcessBar : Form
    {
        private string XmlFilePath = @"\ResidentFlash\xml";
        private string TargetPath = @"\Hard Disk\xml";
        private string ExeTargetPath = @"\ResidentFlash\UpdataExe";
        private string EcoTargetPath = @"\ResidentFlash\Updata";
        private string UsbPath = @"\Hard Disk";
        private FileCtrlEnum Work_Type = FileCtrlEnum.Null;
        private string CurStyleID;

        public ProcessBar(int max)
        {
            InitializeComponent();
            FileBar.Maximum = max;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public void SetNotifyInfo(int percent, string message)
        {
            PB_Msg.Text = string.Format("正在处理 {0}", message);
            PB_Msg.Refresh();

            FileBar.Value = percent;
        }


        private void UpDataExe()
        {
            if (!Directory.Exists(ExeTargetPath))
                Directory.CreateDirectory(ExeTargetPath);

            SetNotifyInfo(0, "屏升级程序");
            File.Copy(@"\Hard Disk\ShouldPadMachine.exe", ExeTargetPath + @"\ShouldPadMachine.exe", true);
            SetNotifyInfo(1, "屏升级程序");
        }

        private uint GetEcoAddInfo(string Path)
        {
            uint result = 0;
            using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(Path)))
            {
                byte length;
                byte[] infoDatas;
                string fileAddInfo;

                for (int i = 0; i < 3; i++)
                {
                    length = (byte)(binaryReader.ReadByte() ^ 0xFF);
                    infoDatas = binaryReader.ReadBytes(length);
                    if (i == 2)
                    {
                        for (int j = 0; j < infoDatas.Length; j++)
                            infoDatas[j] ^= 0xFF;

                        fileAddInfo = Encoding.UTF8.GetString(infoDatas, 0, infoDatas.Length);
                        try
                        {
                            result = uint.Parse(fileAddInfo);
                        }
                        catch (ArgumentNullException)
                        {
                            result = 0;
                        }
                        catch (FormatException)
                        {
                            result = 0;
                        }
                        catch (OverflowException)
                        {
                            result = 0;
                        }
                    }
                }
            }
            return result;
        }

        private void UpDataEco()
        {
            if (Directory.Exists(EcoTargetPath))
                Directory.Delete(EcoTargetPath, true);
            Directory.CreateDirectory(EcoTargetPath);

            String[] fileNames = Directory.GetFiles(UsbPath, "*.eco");
            string EcoName = fileNames[0].Substring(UsbPath.Length + 1);

            SetNotifyInfo(0, EcoName);
            File.Copy(fileNames[0], EcoTargetPath + @"\" + EcoName, true);
            MenuFormManager.SetUnLockPW(GetEcoAddInfo(EcoTargetPath + @"\" + EcoName));
            SetNotifyInfo(1, EcoName);           
        }

        private void UpDataBtl()
        {
            SetNotifyInfo(0, "BootLoader.exe");
            File.Copy(@"\Hard Disk\BootLoader.exe", @"\ResidentFlash\BootLoader.exe", true);
            SetNotifyInfo(1, "BootLoader.exe");
        }

        private void CopyCurXmlFile()
        {
            if (!Directory.Exists(TargetPath))
                Directory.CreateDirectory(TargetPath);

            SetNotifyInfo(1, CurStyleID);
            File.Copy(Path.Combine(XmlFilePath, CurStyleID), Path.Combine(TargetPath, CurStyleID), true);
        }

        private void CopyAllXMLFile()
        {
            int count = 0;

            if (!Directory.Exists(TargetPath))
                Directory.CreateDirectory(TargetPath);

            string[] filenames = Directory.GetFiles(XmlFilePath, "*.xml");
            foreach (string file in filenames)
            {
                string CurStyleID = file.Substring(XmlFilePath.Length + 1);
                if (CurStyleID != "InOutData.xml" && CurStyleID != "BaseData.xml" && CurStyleID != "FlowXml.xml")
                {
                    SetNotifyInfo(++count, CurStyleID);
                    File.Copy(file, Path.Combine(TargetPath, CurStyleID), true);
                }
            }
        }

        private void GetXmlFiles()
        {
            int count = 0;

            string[] filenames = Directory.GetFiles(TargetPath, "*.xml");
            foreach (string file in filenames)
            {
                string CurStyleID = file.Substring(TargetPath.Length + 1);
                if (CurStyleID != "InOutData.xml" && CurStyleID != "BaseData.xml" && CurStyleID != "FlowXml.xml")
                {
                    SetNotifyInfo(++count, CurStyleID);
                    File.Copy(file, Path.Combine(XmlFilePath, CurStyleID), true);
                }
            }
        }

        public void UpDataExeFile()
        {
            Work_Type = FileCtrlEnum.ExeUpData;
            this.ShowDialog();
        }

        public void UpDataEcoFile()
        {
            Work_Type = FileCtrlEnum.EcoUpData;
            this.ShowDialog();
        }

        public void UpDataBootLoader()
        {
            Work_Type = FileCtrlEnum.BootLoadUpData;
            this.ShowDialog();
        }

        public void CopyCurXml(string ID)
        {
            CurStyleID = String.Format("ShouldPadData_{0}.xml", ID);
            Work_Type = FileCtrlEnum.CopyCurXml;
            this.ShowDialog();
        }

        public void CopyAllXml()
        {
            Work_Type = FileCtrlEnum.CopyAllXml;
            this.ShowDialog();
        }

        public void GetAllXml()
        {
            Work_Type = FileCtrlEnum.GetXml;
            this.ShowDialog();
        }

        private void ProcessBar_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Update();
            this.Invalidate();

            switch (Work_Type)
            {
                case FileCtrlEnum.CopyCurXml:
                    CopyCurXmlFile();
                    break;
                case FileCtrlEnum.CopyAllXml:
                    CopyAllXMLFile();
                    break;
                case FileCtrlEnum.GetXml:
                    GetXmlFiles();
                    break;
                case FileCtrlEnum.ExeUpData:
                    UpDataExe();
                    break;
                case FileCtrlEnum.EcoUpData:
                    UpDataEco();
                    break;
                case FileCtrlEnum.BootLoadUpData:
                    UpDataBtl();
                    break;
            }
            this.Dispose();
            this.Close();
        }
    }
}