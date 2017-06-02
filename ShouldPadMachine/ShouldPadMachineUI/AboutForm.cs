using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class AboutForm : Form
    {

        public AboutForm()
        {
            InitializeComponent();
        }
        private void AboutForm_Load(object sender, EventArgs e)
        {
            MachineInfoManager machineInfoManager = new MachineInfoManager();
            String strBoardModifyTime = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardModifyTime);
            if (strBoardModifyTime.Length < 10 && strBoardModifyTime.Length > 7)
            {
                strBoardModifyTime = strBoardModifyTime.Substring(0, 4) + "-" + strBoardModifyTime.Substring(4, 2) + "-" + strBoardModifyTime.Substring(6, 2);
            }
            lbl580LoadTime.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardLoadTime);
            lbl580ModifyTime.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardModifyTime);
            lblHardWareBoard.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardID);
            //lblHardWareLcd.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.ScreenID);
            lblLcdLoadTime.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.ScreenLoadTime);
            lblLcdModifyTime.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.ScreenModifyTime);
            lblLcdVersion.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.ScreenCodeVersion);
            lblSewingVersion.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardCodeVersion);
            lblMachineID.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.BoardID);
            lblServoVersion.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.ServoMotorVersion);
            lblStepVersion.Text = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.StepMotorVersion);
            String sequenceID = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.SequenceID);
            String totalNumberInfo = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.TotalNumber);
            UInt64 totalNumber = Convert.ToUInt64(totalNumberInfo == String.Empty ? "0" : totalNumberInfo);
            totalNumber += LowerMachineStatueData.LowerMachineStatueDateEx.WorkedNumber;
            //lblRuntime.Text = ShareData.CreateShareData().GetRunMinTime().ToString();
            if (sequenceID.Length >= 20)
            {
                String sequence = String.Empty;
                for (int i = 0; i < 5; i++)
                    sequence += sequenceID.Substring(i * 4, 4) + "-";
                sequenceID = sequence.Substring(0, sequence.Length - 1);
            }
            lblSerialNumber.Text = sequenceID;
            this.Size = new Size(726, 417);
        }
        public new void Dispose()
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.Dispose();
            }
            base.Dispose();
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 4), this.ClientRectangle.X + 1, this.ClientRectangle.Y + 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height - 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label1.Location.Y + label1.Height + 2, this.Width, label1.Location.Y + label1.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label2.Location.Y + label2.Height + 2, this.Width, label2.Location.Y + label2.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label3.Location.Y + label3.Height + 2, this.Width, label3.Location.Y + label3.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label4.Location.Y + label4.Height + 2, this.Width, label4.Location.Y + label4.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label5.Location.Y + label5.Height + 2, this.Width, label5.Location.Y + label5.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label6.Location.Y + label6.Height + 2, this.Width, label6.Location.Y + label6.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label7.Location.Y + label7.Height + 2, this.Width, label7.Location.Y + label7.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label9.Location.Y + label9.Height + 2, this.Width, label9.Location.Y + label9.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label15.Location.Y + label15.Height + 2, this.Width, label15.Location.Y + label15.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label10.Location.Y + label10.Height + 2, this.Width, label10.Location.Y + label10.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label13.Location.Y + label13.Height + 2, this.Width, label13.Location.Y + label13.Height + 2);
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, label14.Location.Y + label14.Height + 2, this.Width, label14.Location.Y + label14.Height + 2);
        }

    }
}