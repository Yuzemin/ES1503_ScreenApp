using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineBLL;
using System.Reflection;
using System.IO;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class InfoForm : Form
    {
        private RegistryKey registryKey = null;

        public InfoForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height - 40) / 2);
            this.Size = new Size(317, 261);
            InfoBgImg.Dock = DockStyle.Fill;
            InfoBgImg.SizeMode = PictureBoxSizeMode.Normal;
            ibOKbtn.SetMap(Properties.Resources.ButtonOK_OFF, Properties.Resources.ButtonOK_ON);

            registryKey = Registry.LocalMachine.OpenSubKey("MachineInfo");
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            BoardIndex.Text = GetBoardIndex();
            BoardVer.Text = GetBoardVer();
            ScreenVer.Text = "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MacID.Text = MenuFormManager.ShowEncNum().ToString();
            BtlVer.Text = GetBtlVer();

            if (MenuFormManager.IsActed == 1)
                SysSta.Text = "正式版";
            else
                SysSta.Text = "试用版";
        }

        private string GetBoardIndex()
        {
            if (registryKey != null)
            {
                object obj = registryKey.GetValue("BoardID");
                if (obj != null)
                    return obj.ToString();
            }
            return "未能读到设备序列号";
        }

        private string GetBoardVer()
        {
            if (registryKey != null)
            {
                object obj = registryKey.GetValue("BoardCodeVersion");
                if (obj != null)
                    return obj.ToString();
            }
            return "V0.0.0";
        }

        private string GetBtlVer()
        {
            string BtlPath = @"\ResidentFlash\BootLoader.exe";


            if (!File.Exists(BtlPath))
                return "Unknown";
            try
            {
                Assembly assembly = Assembly.LoadFrom(BtlPath);
                return "V" + assembly.GetName().Version.ToString();
            }
            catch (Exception)
            {
                return "Unknown";
            }
        }

        private void ImgBtn_MouseDown(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickDown();
        }

        private void ImgBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickUp();
        }

        private void ibOKbtn_Click(object sender, EventArgs e)
        {
            if (registryKey != null)
                registryKey.Close();
            this.Close();
        }
    }
}