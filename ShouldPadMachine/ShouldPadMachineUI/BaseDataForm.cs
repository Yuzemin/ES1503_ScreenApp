using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;

using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class BaseDataForm : Form
    {
        private Boolean mParamUnlock = false;

        public BaseDataForm()
        {
            InitializeComponent();
            ibReturn.SetMap(Properties.Resources.imgBacktype1_1, Properties.Resources.imgBacktype1_2);
            swUnlockParam.SetMap(Properties.Resources.imgUnlock1, Properties.Resources.imgUnlock2);
            ibSysReset.SetMap(Properties.Resources.imgSysRe1, Properties.Resources.imgSysRe2);
        }

        private BaseDataFormFlagData flagData;
        private void DataButton_Click(object sender, EventArgs e)
        {
            DataButton dataButton = sender as DataButton;
            DataInfo dataInfo = dataButton.ButtonDataInfo;
            Calculator calculator = new Calculator();
            calculator.InitStrNum = dataButton.Text;
            calculator.PointButtonEnable = dataInfo.PointEnable;
            calculator.MinusButtonEnable = dataInfo.MinusEnable;
            calculator.MaxValue = dataInfo.MaxValue;
            calculator.MinValue = dataInfo.MinValue;
            calculator.ShowDialog();
            dataButton.HasClick = true;
            if (calculator.LastNumber.ToString() != dataButton.Text)
            {
                dataButton.Text = calculator.LastNumber.ToString();
            }
            calculator.Dispose();
        }

        private void RightButton_MouseDown(object sender, MouseEventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InstalledButton = 1;
        }

        private void LeftButton_MouseDown(object sender, MouseEventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InstalledButton = 2;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            SerialDataManager.Feedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            this.Close();
        }
        private void LRButton_MouseUp(object sender, MouseEventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InstalledButton = 0;
        }

        private void BaseDataForm_Load(object sender, EventArgs e)
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            BaseDateModel.GetDataBaseModel().HaveDataChanged = true;
            dataButton5.Text = shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.CutLineDistance).ToString();
            SerialDataManager.Feedback += new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
        }
        private void ReflectToObject(object sender, String text)
        {
            Control ctl = sender as Control;
            if (ctl.InvokeRequired)
            {
                object[] ob = new object[2] { sender, text };
                ctl.Invoke(new ReflectToObjectDelegate(ReflectToObject), ob);
                return;
            }
            if (sender is DataButton)
            {
                DataButton dataButton = sender as DataButton;
                dataButton.Text = text;
            }
        }
        void SerialDataManager_Feedback(UartComdEventArgs lowerDataInfo)
        {
            if (lowerDataInfo.LowerDataType == LowerDataType.MachineBasicDataType)
            {
                MachineBasicDataInfo machineBasicDataInfo = lowerDataInfo.LowerDataInfo as MachineBasicDataInfo;
                if (flagData == null)
                    flagData = new BaseDataFormFlagData();

                if (flagData.ServoCodeValue1 != machineBasicDataInfo.ServoCodeValue)
                {
                    flagData.ServoCodeValue1 = machineBasicDataInfo.ServoCodeValue;
                    ReflectToObject(btnUpShowNeedleCodeNumber, flagData.ServoCodeValue1.ToString());
                }
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

        private void ibSysReset_Click(object sender, EventArgs e)
        {
            //强制发28 屏幕按键
            SerialDataManager.ScreenButton = true;
            ScreenStatueData.ScreenStatueDataEX.ResetBtnFlag = true;
        }


        private void swUnlock_Click(object sender, EventArgs e)
        {
            ImgSwitch swBtn = sender as ImgSwitch;

            if (this.mParamUnlock) return;

            if (!swBtn.IsCheck)
            {
                Calculator myCal = new Calculator();
                myCal.InitStrNum = "";
                myCal.IsSercet = true;
                myCal.MaxValue = double.MaxValue;
                myCal.MinValue = 0;
                myCal.ShowDialog();

                string KeyBoard_Val = myCal.LastNumber.ToString();
                myCal.Dispose();

                if (KeyBoard_Val == "1058")
                {
                    xModify.Enabled = true;
                    yModify.Enabled = true;
                    zModify.Enabled = true;
                    xModify.ForeColor = Color.Black;
                    yModify.ForeColor = Color.Black;
                    zModify.ForeColor = Color.Black;
                    this.mParamUnlock = true;
                    swBtn.SwitchClick();
                }
            }

        }
    }
}
