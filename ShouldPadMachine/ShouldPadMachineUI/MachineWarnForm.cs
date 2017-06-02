using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineDAL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class MachineWarnForm : Form
    {
        private PromptInfoFormManager warnInfoFormManager;
        public static event FormHideEventHandle FormHide;
        public MachineWarnForm()
        {
            InitializeComponent();
            warnInfoFormManager = new PromptInfoFormManager(PromptType.WarnInfo);
        }
        public new void Dispose()
        {
            foreach(Control ctl in this.Controls)
            {
                ctl.Dispose();
            }
        }
        private void OnFormHide()
        {
            if (FormHide != null)
                FormHide();
        }
        private String warnString;
        private String warnID;
        public void SetWarnText(String warnText,String warnID)
        {
            warnString = warnText;
            this.warnID = "W" + warnID + "：";
            UInt64 totalMinute = SystemTimeManager.SystemTimerEx.GetRunMinTime();
            warnInfoFormManager.MachineRunTime = totalMinute.ToString();
            warnInfoFormManager.PromptInfoID = Convert.ToInt32(warnID);
            warnInfoFormManager.PromptInfoName = warnText;
        }
        private void MachineWarnForm_Load(object sender, EventArgs e)
        {
            SaveWarnInfo();
        }
        private void SaveWarnInfo()
        {
            lblWarn.Text = warnString;
            lblWarnID.Text = warnID;
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            String strVersion = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardCodeVersion);
            String language = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.UseLanguage);
            String useLanaguage = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.UseLanguage);
            warnInfoFormManager.BoardCodeVersion = strVersion;
            switch (useLanaguage)
            {
                case "中文":
                    lblWarn.Font = new Font(FontFamily.GenericMonospace, 16, FontStyle.Bold);
                    lblWarn.Size = new Size(172, 51);
                    lblWarn.Location = new Point(112, 62);
                    this.Size = new Size(301, 204);
                    this.Location = new Point(100, 300);
                    btnOK.Size = new Size(123, 46);
                    btnOK.Location = new Point(87, 116);
                    break;
                case "英文":
                    lblWarn.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular);
                    lblWarn.Size = new Size(271, 53);
                    lblWarn.Location = new Point(112, 62);
                    this.Size = new Size(385, 214);
                    this.Location = new Point(50, 300);
                    btnOK.Size = new Size(143, 46);
                    btnOK.Location = new Point(121, 128);
                    break;
                default:
                    break;
            }
            String dateTime = String.Empty;
            try
            {
                dateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            }
            catch
            {
                MessageBoxEX.Show("读取系统日期出错！");
            }
            finally
            {
                warnInfoFormManager.PromptOccurTime = dateTime;
            }
            warnInfoFormManager.SavePromptInfo();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            OnFormHide();
            this.Hide();
        }

        private void MachineWarnForm_Activated(object sender, EventArgs e)
        {
            SaveWarnInfo();
        }

    }
   
}