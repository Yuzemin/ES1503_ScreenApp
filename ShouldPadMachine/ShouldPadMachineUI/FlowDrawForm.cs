using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineHelper;
using ShouldPadMachine.ShouldPadMachineFactory;


namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class FlowDrawForm : Form
    {
        private FlowDrawManager flowDrawManager = new FlowDrawManager();

        public static bool modelChange = false;
        private string[] dataChoiced = new string[4];
        private List<Tablet> TabList = new List<Tablet>();
        private List<DataButton> DstList = new List<DataButton>();

        //传递给下位机的数据 包括xy的起始角度 和 xy的跟随范围
        public FlowDrawForm()
        {
            InitializeComponent();
            ibEditCheck1.SetMap(Properties.Resources.BtnEdit1, Properties.Resources.BtnEdit2);
            ibEditCheck.SetMap(Properties.Resources.BtnEdit1, Properties.Resources.BtnEdit2);
            ibReturn.SetMap(Properties.Resources.BtnRtn1, Properties.Resources.BtnRtn2);
            ibReturn1.SetMap(Properties.Resources.BtnRtn1, Properties.Resources.BtnRtn2);
            PageDn.SetMap(Properties.Resources.BtnPageDn1, Properties.Resources.BtnPageDn2);
            PageUp.SetMap(Properties.Resources.BtnPageUp1, Properties.Resources.BtnPageUp2);
            test1.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test2.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test3.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test4.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test5.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test6.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test7.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test8.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test9.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test10.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test11.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test12.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test13.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test14.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test15.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test16.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test17.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test18.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test19.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
            test20.SetMap(Properties.Resources.btnTest1, Properties.Resources.btnTest2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.FlowDrawForm;
            FlowDataModel.GetDataBaseModel().HaveDataChanged = true;
            FlowDataDAO setDataDAO = new FlowDataDAO();

            MachineInfoSendData.choicedSendFlow = true;
            SerialDataManager.Feedback += new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            LoadPatternDataButton();

            int Count = (int)SetDataEnum.Null;
            for (int i = 0; i < Count; i++)
                TabList[i].Content = setDataDAO.GetDataBaseValue((SetDataEnum)i).ToString();

            DisPlay_DstErrData();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MainFormMode;

            MachineInfoSendData.choicedSendFlow = false;
            FlowDataModel.GetDataBaseModel().HaveDataChanged = true;
            ibEditCheck.IsCheck = false;
            ibEditCheck1.IsCheck = false;
            SerialDataManager.Feedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            this.Close();
        }

        private void DisPlay_DstErrData()
        {
            LowerMachineStatueData LMachStaData = LowerMachineStatueData.LowerMachineStatueDateEx;

            xDstErr1.Text = LMachStaData.XBgnDstErr.GetValue(0).ToString() + "," + LMachStaData.XEndDstErr.GetValue(0).ToString();
            xDstErr2.Text = LMachStaData.XBgnDstErr.GetValue(1).ToString() + "," + LMachStaData.XEndDstErr.GetValue(1).ToString();
            xDstErr3.Text = LMachStaData.XBgnDstErr.GetValue(2).ToString() + "," + LMachStaData.XEndDstErr.GetValue(2).ToString();
            xDstErr4.Text = LMachStaData.XBgnDstErr.GetValue(3).ToString() + "," + LMachStaData.XEndDstErr.GetValue(3).ToString();
            xDstErr5.Text = LMachStaData.XBgnDstErr.GetValue(4).ToString() + "," + LMachStaData.XEndDstErr.GetValue(4).ToString();
            xDstErr6.Text = LMachStaData.XBgnDstErr.GetValue(5).ToString() + "," + LMachStaData.XEndDstErr.GetValue(5).ToString();
            xDstErr7.Text = LMachStaData.XBgnDstErr.GetValue(6).ToString() + "," + LMachStaData.XEndDstErr.GetValue(6).ToString();
            xDstErr8.Text = LMachStaData.XBgnDstErr.GetValue(7).ToString() + "," + LMachStaData.XEndDstErr.GetValue(7).ToString();
            xDstErr9.Text = LMachStaData.XBgnDstErr.GetValue(8).ToString() + "," + LMachStaData.XEndDstErr.GetValue(8).ToString();
            xDstErr10.Text = LMachStaData.XBgnDstErr.GetValue(9).ToString() + "," + LMachStaData.XEndDstErr.GetValue(9).ToString();
            xDstErr11.Text = LMachStaData.XBgnDstErr.GetValue(10).ToString() + "," + LMachStaData.XEndDstErr.GetValue(10).ToString();
            xDstErr12.Text = LMachStaData.XBgnDstErr.GetValue(11).ToString() + "," + LMachStaData.XEndDstErr.GetValue(11).ToString();
            xDstErr13.Text = LMachStaData.XBgnDstErr.GetValue(12).ToString() + "," + LMachStaData.XEndDstErr.GetValue(12).ToString();
            xDstErr14.Text = LMachStaData.XBgnDstErr.GetValue(13).ToString() + "," + LMachStaData.XEndDstErr.GetValue(13).ToString();
            xDstErr15.Text = LMachStaData.XBgnDstErr.GetValue(14).ToString() + "," + LMachStaData.XEndDstErr.GetValue(14).ToString();
            xDstErr16.Text = LMachStaData.XBgnDstErr.GetValue(15).ToString() + "," + LMachStaData.XEndDstErr.GetValue(15).ToString();
            xDstErr17.Text = LMachStaData.XBgnDstErr.GetValue(16).ToString() + "," + LMachStaData.XEndDstErr.GetValue(16).ToString();
            xDstErr18.Text = LMachStaData.XBgnDstErr.GetValue(17).ToString() + "," + LMachStaData.XEndDstErr.GetValue(17).ToString();
            xDstErr19.Text = LMachStaData.XBgnDstErr.GetValue(18).ToString() + "," + LMachStaData.XEndDstErr.GetValue(18).ToString();
            xDstErr20.Text = LMachStaData.XBgnDstErr.GetValue(19).ToString() + "," + LMachStaData.XEndDstErr.GetValue(19).ToString();

            yDstErr1.Text = LMachStaData.YBgnDstErr.GetValue(0).ToString() + "," + LMachStaData.YEndDstErr.GetValue(0).ToString();
            yDstErr2.Text = LMachStaData.YBgnDstErr.GetValue(1).ToString() + "," + LMachStaData.YEndDstErr.GetValue(1).ToString();
            yDstErr3.Text = LMachStaData.YBgnDstErr.GetValue(2).ToString() + "," + LMachStaData.YEndDstErr.GetValue(2).ToString();
            yDstErr4.Text = LMachStaData.YBgnDstErr.GetValue(3).ToString() + "," + LMachStaData.YEndDstErr.GetValue(3).ToString();
            yDstErr5.Text = LMachStaData.YBgnDstErr.GetValue(4).ToString() + "," + LMachStaData.YEndDstErr.GetValue(4).ToString();
            yDstErr6.Text = LMachStaData.YBgnDstErr.GetValue(5).ToString() + "," + LMachStaData.YEndDstErr.GetValue(5).ToString();
            yDstErr7.Text = LMachStaData.YBgnDstErr.GetValue(6).ToString() + "," + LMachStaData.YEndDstErr.GetValue(6).ToString();
            yDstErr8.Text = LMachStaData.YBgnDstErr.GetValue(7).ToString() + "," + LMachStaData.YEndDstErr.GetValue(7).ToString();
            yDstErr9.Text = LMachStaData.YBgnDstErr.GetValue(8).ToString() + "," + LMachStaData.YEndDstErr.GetValue(8).ToString();
            yDstErr10.Text = LMachStaData.YBgnDstErr.GetValue(9).ToString() + "," + LMachStaData.YEndDstErr.GetValue(9).ToString();
            yDstErr11.Text = LMachStaData.YBgnDstErr.GetValue(10).ToString() + "," + LMachStaData.YEndDstErr.GetValue(10).ToString();
            yDstErr12.Text = LMachStaData.YBgnDstErr.GetValue(11).ToString() + "," + LMachStaData.YEndDstErr.GetValue(11).ToString();
            yDstErr13.Text = LMachStaData.YBgnDstErr.GetValue(12).ToString() + "," + LMachStaData.YEndDstErr.GetValue(12).ToString();
            yDstErr14.Text = LMachStaData.YBgnDstErr.GetValue(13).ToString() + "," + LMachStaData.YEndDstErr.GetValue(13).ToString();
            yDstErr15.Text = LMachStaData.YBgnDstErr.GetValue(14).ToString() + "," + LMachStaData.YEndDstErr.GetValue(14).ToString();
            yDstErr16.Text = LMachStaData.YBgnDstErr.GetValue(15).ToString() + "," + LMachStaData.YEndDstErr.GetValue(15).ToString();
            yDstErr17.Text = LMachStaData.YBgnDstErr.GetValue(16).ToString() + "," + LMachStaData.YEndDstErr.GetValue(16).ToString();
            yDstErr18.Text = LMachStaData.YBgnDstErr.GetValue(17).ToString() + "," + LMachStaData.YEndDstErr.GetValue(17).ToString();
            yDstErr19.Text = LMachStaData.YBgnDstErr.GetValue(18).ToString() + "," + LMachStaData.YEndDstErr.GetValue(18).ToString();
            yDstErr20.Text = LMachStaData.YBgnDstErr.GetValue(19).ToString() + "," + LMachStaData.YEndDstErr.GetValue(19).ToString();
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

        void SerialDataManager_Feedback (ShouldPadMachine.ShouldPadMachineModel.UartComdEventArgs lowerDataInfo)
        {
            if (lowerDataInfo.LowerDataType == LowerDataType.TestReptDataType) 
            {
                int index = 0;
                LowerMachineStatueData LMachStaData = LowerMachineStatueData.LowerMachineStatueDateEx;
                TestReportInfo TestRptInfo = lowerDataInfo.LowerDataInfo as TestReportInfo;

                if(TestRptInfo.RptID > 0)
                {
                    LMachStaData.XBgnDstErr.SetValue(TestRptInfo.XBgnDstErr, TestRptInfo.RptID - 1);
                    LMachStaData.XEndDstErr.SetValue(TestRptInfo.XEndDstErr, TestRptInfo.RptID - 1);
                    LMachStaData.YBgnDstErr.SetValue(TestRptInfo.YBgnDstErr, TestRptInfo.RptID - 1);
                    LMachStaData.YEndDstErr.SetValue(TestRptInfo.YEndDstErr, TestRptInfo.RptID - 1);

                    index = TestRptInfo.RptID - 1;

                    foreach (DataButton Sel in DstList)
                    {
                        int TagIdx = int.Parse(Sel.Tag.ToString());
                        int idx = TagIdx / 10;
                        int row = TagIdx % 10;
                        if (idx == index)
                        {
                            switch (row)
                            {
                                case 0:
                                    ReflectToObject(Sel, TestRptInfo.XBgnDstErr.ToString() + "," + TestRptInfo.XEndDstErr.ToString());
                                    break;
                                case 1:
                                    ReflectToObject(Sel, TestRptInfo.YBgnDstErr.ToString() + "," + TestRptInfo.YEndDstErr.ToString());
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }      
            }
            else if (lowerDataInfo.LowerDataType == LowerDataType.MachineBasicDataType)
            {
                MachineBasicDataInfo machineBasicDataInfo = lowerDataInfo.LowerDataInfo as MachineBasicDataInfo;
                // 收到跟随表测试数据报告
                if (machineBasicDataInfo.TestReport != 0)
                {
                    // 请求测试跟随数据 请求0x26
                    SerialDataManager.TestReportRep = true;
                }
            }
        }                            

        private void TestBtn_Click(object sender, EventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;
            ScreenStatueData.ScreenStatueDataEX.TestIndex = Convert.ToUInt16(imgBtn.Tag);
        }

        private void ButtonData_Click(object sender, EventArgs e)
        {
            if (flowDrawManager.ModeChange)
            {
                if (sender is Tablet)
                {
                    Tablet Tab = sender as Tablet;
                    Calculator myCal = null;

                    Tab.Focus();

                    myCal = new Calculator(800, 480, 0, 0);
                    myCal.InitStrNum = Tab.Content;
                    myCal.PointButtonEnable = false;
                    myCal.MinusButtonEnable = false;
                    myCal.IsSercet = false;
                    myCal.MaxValue = (double)999;
                    myCal.MinValue = 0;
                    myCal.ShowDialog();
                    Tab.Content = myCal.LastNumber.ToString();
                    FlowDataDAO dataBaseDAO = new FlowDataDAO();
                    dataBaseDAO.SetDataBaseValue((SetDataEnum)Convert.ToInt16(Tab.Tag), Convert.ToInt32(Tab.Content));
                }
            }
        }

        //按键列表
        private void LoadPatternDataButton()
        {
            TabletComparerByTag TagComparer = new TabletComparerByTag();

            foreach (Control ctl in this.Controls)
            {
                if (ctl is Tablet)
                {
                    Tablet Tab = ctl as Tablet;
                    if (Tab.Tag != null)
                        TabList.Add(Tab);
                }
                else if (ctl is DataButton)
                {
                    DataButton Btn = ctl as DataButton;
                    DstList.Add(Btn);    
                }
            }
            TabList.Sort(TagComparer);
        }

        private void ibSwitch_Click(object sender, EventArgs e)
        {
            this.ibEditCheck.SwitchClick();
            this.ibEditCheck1.SwitchClick();
            flowDrawManager.ModeChange = this.ibEditCheck.IsCheck;
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

        private void Tab_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Tablet)
            {
                Tablet Tab = sender as Tablet;
                int Index = int.Parse(Tab.Tag.ToString());
                int Row = Index % 10;

                foreach (Tablet Sel in TabList)
                {
                    if (Sel.BackColor != Color.FromArgb(233, 233, 233))
                    {
                        Sel.BackColor = Color.FromArgb(233, 233, 233);
                        Sel.Invalidate();
                    }
                }

                TabList[Index].BackColor = Color.MediumSeaGreen;
            }
        }

        private void PageDn_Click(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(0, 480);
        }

        private void PageUp_Click(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(0, 0);
        }
    }
}