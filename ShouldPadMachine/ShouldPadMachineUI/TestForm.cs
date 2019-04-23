using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class TestForm : Form
    {
        private TestFormFlag formFlag;

        public TestForm()
        {
            InitializeComponent();
            ibTestReturn.SetMap(Properties.Resources.imgReturn1, Properties.Resources.imgReturn2);
            ibBlow.SetMap(Properties.Resources.imgBlow1, Properties.Resources.imgBlow2);
            ibCarry.SetMap(Properties.Resources.imgCarry1, Properties.Resources.imgCarry2);
            ibCatch.SetMap(Properties.Resources.imgCatch1, Properties.Resources.imgCatch2);
            ibClamp.SetMap(Properties.Resources.imgClamp1, Properties.Resources.imgClamp2);
            ibCut.SetMap(Properties.Resources.imgCut1, Properties.Resources.imgCut2);
            ibPressure.SetMap(Properties.Resources.imgPress1, Properties.Resources.imgPress2);
        }

        private void MachineTestData_Click(object sender, EventArgs e)
        { 
            ImgSwitch imageButton = sender as ImgSwitch;
            bool Switch_Sta = false;

            if (imageButton.Name == "ibCarry")
            {
                if (ibPressure.IsCheck == true && ibCarry.IsCheck == false)
                    return;
            }
            imageButton.SwitchClick();
            Switch_Sta = imageButton.IsCheck;

            switch (imageButton.Name)
            {
                case "ibCut":
                    ScreenStatueData.ScreenStatueDataEX.CutLine = Switch_Sta;
                    break;
                case "ibBlow":
                    ScreenStatueData.ScreenStatueDataEX.BlowCloth = Switch_Sta;
                    break;
                case "ibClamp":
                    ScreenStatueData.ScreenStatueDataEX.ClampCloth = Switch_Sta;
                    break;
                case "ibCarry":
                    ScreenStatueData.ScreenStatueDataEX.CarryCloth = Switch_Sta;
                    break;
                case "ibPressure":
                    ScreenStatueData.ScreenStatueDataEX.PressCloth = Switch_Sta;
                    break;
                case "ibCatch":
                    ScreenStatueData.ScreenStatueDataEX.LiftCloth = Switch_Sta;
                    break;
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.BlowCloth = false;
            ScreenStatueData.ScreenStatueDataEX.CutLine = false;
            ScreenStatueData.ScreenStatueDataEX.ClampCloth = false;
            ScreenStatueData.ScreenStatueDataEX.CarryCloth = false;
            ScreenStatueData.ScreenStatueDataEX.PressCloth = false;
            ScreenStatueData.ScreenStatueDataEX.LiftCloth = false;
            SerialDataManager.FirstMachine = true;
            SerialDataManager.Feedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            this.Close();            
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
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
            if (sender is ImageButton)
            {
                ImageButton dataButton = sender as ImageButton;
                dataButton.Text = text;
            }
            else if (sender is DataButton)
            {
                DataButton dataButton = sender as DataButton;
                dataButton.Text = text;
            }
        }

        void SerialDataManager_Feedback(ShouldPadMachine.ShouldPadMachineModel.UartComdEventArgs lowerDataInfo)
        {
            if (lowerDataInfo.LowerDataType == ShouldPadMachine.ShouldPadMachineAssist.Enum.LowerDataType.TestDataType)
            {
                TestDataInfo testDataInfo = lowerDataInfo.LowerDataInfo as TestDataInfo;
                if (formFlag == null)
                    formFlag = new TestFormFlag();
                if (formFlag.ServoSensor != testDataInfo.ServoSensor)
                {
                    formFlag.ServoSensor = testDataInfo.ServoSensor;
                    ReflectToObject(btnSFSensor, formFlag.ServoSensor == true ? "ON" : "OFF");
                }
                if (formFlag.xSensor != testDataInfo.XSensor)
                {
                    formFlag.xSensor = testDataInfo.XSensor;
                    ReflectToObject(btnXSensor, formFlag.xSensor == true ? "ON" : "OFF");
                }
                if (formFlag.ySensor != testDataInfo.YSensor)
                {
                    formFlag.ySensor = testDataInfo.YSensor;
                    ReflectToObject(btnYSensor, formFlag.ySensor == true ? "ON" : "OFF");
                }
                if (formFlag.greenKey1 != testDataInfo.GreenKey1)
                {
                    formFlag.greenKey1 = testDataInfo.GreenKey1;
                    ReflectToObject(btnGreenKey1, formFlag.greenKey1 == true ? "ON" : "OFF");
                }
                if (formFlag.redKey1 != testDataInfo.RedKey1)
                {
                    formFlag.redKey1 = testDataInfo.RedKey1;
                    ReflectToObject(btnRedKey1, formFlag.redKey1 == true ? "ON" : "OFF");
                }

                if (formFlag.greenKey2 != testDataInfo.GreenKey2)
                {
                    formFlag.greenKey2 = testDataInfo.GreenKey2;
                    ReflectToObject(btnGreenKey2, formFlag.greenKey2 == true ? "ON" : "OFF");
                }
                if (formFlag.redKey2 != testDataInfo.RedKey2)
                {
                    formFlag.redKey2 = testDataInfo.RedKey2;
                    ReflectToObject(btnRedKey2, formFlag.redKey2 == true ? "ON" : "OFF");
                }
                if (formFlag.clampSensorLower != testDataInfo.ClampSensorLower)
                {
                    formFlag.clampSensorLower = testDataInfo.ClampSensorLower;
                    ReflectToObject(btnClampSensorLower, formFlag.clampSensorLower == true ? "ON" : "OFF");
                }
                if (formFlag.clampSensorMid != testDataInfo.ClampSensorMid)
                {
                    formFlag.clampSensorMid = testDataInfo.ClampSensorMid;
                    ReflectToObject(btnClampSensorMid, formFlag.clampSensorMid == true ? "ON" : "OFF");
                }
                if (formFlag.clampSensorUp != testDataInfo.ClampSensorUp)
                {
                    formFlag.clampSensorUp = testDataInfo.ClampSensorUp;
                    ReflectToObject(btnClampSensorUp, formFlag.clampSensorUp == true ? "ON" : "OFF");
                }
                if (formFlag.carrySensorLeft != testDataInfo.CarrySensorLeft)
                {
                    formFlag.carrySensorLeft = testDataInfo.CarrySensorLeft;
                    ReflectToObject(btnCarrySensorLeft, formFlag.carrySensorLeft == true ? "ON" : "OFF");
                }
                if (formFlag.carrySensorRight != testDataInfo.CarrySensorRight)
                {
                    formFlag.carrySensorRight = testDataInfo.CarrySensorRight;
                    ReflectToObject(btnCarrySensorRight, formFlag.carrySensorRight == true ? "ON" : "OFF");
                }
                ReflectToObject(XstepCode, testDataInfo.Xstep_EnCode.ToString());
                ReflectToObject(YstepCode, testDataInfo.Ystep_EnCode.ToString());
                ReflectToObject(SFCode,testDataInfo.SF_EnCode.ToString());
                ReflectToObject(SFhallValue, testDataInfo.SF_HallValue.ToString());
                ReflectToObject(IOVolt, ((testDataInfo.IO_VOLT*1.0)/10).ToString());
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
    }
}



