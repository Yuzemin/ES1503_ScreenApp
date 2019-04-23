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

            xBgnDstErr1.Text = LMachStaData.XBgnDstErr.GetValue(0).ToString();
            xBgnDstErr2.Text = LMachStaData.XBgnDstErr.GetValue(1).ToString();
            xBgnDstErr3.Text = LMachStaData.XBgnDstErr.GetValue(2).ToString();
            xBgnDstErr4.Text = LMachStaData.XBgnDstErr.GetValue(3).ToString();
            xBgnDstErr5.Text = LMachStaData.XBgnDstErr.GetValue(4).ToString();
            xBgnDstErr6.Text = LMachStaData.XBgnDstErr.GetValue(5).ToString();
            xBgnDstErr7.Text = LMachStaData.XBgnDstErr.GetValue(6).ToString();
            xBgnDstErr8.Text = LMachStaData.XBgnDstErr.GetValue(7).ToString();
            xBgnDstErr9.Text = LMachStaData.XBgnDstErr.GetValue(8).ToString();
            xBgnDstErr10.Text = LMachStaData.XBgnDstErr.GetValue(9).ToString();
            xBgnDstErr11.Text = LMachStaData.XBgnDstErr.GetValue(10).ToString();
            xBgnDstErr12.Text = LMachStaData.XBgnDstErr.GetValue(11).ToString();
            xBgnDstErr13.Text = LMachStaData.XBgnDstErr.GetValue(12).ToString();
            xBgnDstErr14.Text = LMachStaData.XBgnDstErr.GetValue(13).ToString();
            xBgnDstErr15.Text = LMachStaData.XBgnDstErr.GetValue(14).ToString();
            xBgnDstErr16.Text = LMachStaData.XBgnDstErr.GetValue(15).ToString();
            xBgnDstErr17.Text = LMachStaData.XBgnDstErr.GetValue(16).ToString();
            xBgnDstErr18.Text = LMachStaData.XBgnDstErr.GetValue(17).ToString();
            xBgnDstErr19.Text = LMachStaData.XBgnDstErr.GetValue(18).ToString();
            xBgnDstErr20.Text = LMachStaData.XBgnDstErr.GetValue(19).ToString();

            xEndDstErr1.Text = LMachStaData.XEndDstErr.GetValue(0).ToString();
            xEndDstErr2.Text = LMachStaData.XEndDstErr.GetValue(1).ToString();
            xEndDstErr3.Text = LMachStaData.XEndDstErr.GetValue(2).ToString();
            xEndDstErr4.Text = LMachStaData.XEndDstErr.GetValue(3).ToString();
            xEndDstErr5.Text = LMachStaData.XEndDstErr.GetValue(4).ToString();
            xEndDstErr6.Text = LMachStaData.XEndDstErr.GetValue(5).ToString();
            xEndDstErr7.Text = LMachStaData.XEndDstErr.GetValue(6).ToString();
            xEndDstErr8.Text = LMachStaData.XEndDstErr.GetValue(7).ToString();
            xEndDstErr9.Text = LMachStaData.XEndDstErr.GetValue(8).ToString();
            xEndDstErr10.Text = LMachStaData.XEndDstErr.GetValue(9).ToString();
            xEndDstErr11.Text = LMachStaData.XEndDstErr.GetValue(10).ToString();
            xEndDstErr12.Text = LMachStaData.XEndDstErr.GetValue(11).ToString();
            xEndDstErr13.Text = LMachStaData.XEndDstErr.GetValue(12).ToString();
            xEndDstErr14.Text = LMachStaData.XEndDstErr.GetValue(13).ToString();
            xEndDstErr15.Text = LMachStaData.XEndDstErr.GetValue(14).ToString();
            xEndDstErr16.Text = LMachStaData.XEndDstErr.GetValue(15).ToString();
            xEndDstErr17.Text = LMachStaData.XEndDstErr.GetValue(16).ToString();
            xEndDstErr18.Text = LMachStaData.XEndDstErr.GetValue(17).ToString();
            xEndDstErr19.Text = LMachStaData.XEndDstErr.GetValue(18).ToString();
            xEndDstErr20.Text = LMachStaData.XEndDstErr.GetValue(19).ToString();

            yBgnDstErr1.Text = LMachStaData.YBgnDstErr.GetValue(0).ToString();
            yBgnDstErr2.Text = LMachStaData.YBgnDstErr.GetValue(1).ToString();
            yBgnDstErr3.Text = LMachStaData.YBgnDstErr.GetValue(2).ToString();
            yBgnDstErr4.Text = LMachStaData.YBgnDstErr.GetValue(3).ToString();
            yBgnDstErr5.Text = LMachStaData.YBgnDstErr.GetValue(4).ToString();
            yBgnDstErr6.Text = LMachStaData.YBgnDstErr.GetValue(5).ToString();
            yBgnDstErr7.Text = LMachStaData.YBgnDstErr.GetValue(6).ToString();
            yBgnDstErr8.Text = LMachStaData.YBgnDstErr.GetValue(7).ToString();
            yBgnDstErr9.Text = LMachStaData.YBgnDstErr.GetValue(8).ToString();
            yBgnDstErr10.Text = LMachStaData.YBgnDstErr.GetValue(9).ToString();
            yBgnDstErr11.Text = LMachStaData.YBgnDstErr.GetValue(10).ToString();
            yBgnDstErr12.Text = LMachStaData.YBgnDstErr.GetValue(11).ToString();
            yBgnDstErr13.Text = LMachStaData.YBgnDstErr.GetValue(12).ToString();
            yBgnDstErr14.Text = LMachStaData.YBgnDstErr.GetValue(13).ToString();
            yBgnDstErr15.Text = LMachStaData.YBgnDstErr.GetValue(14).ToString();
            yBgnDstErr16.Text = LMachStaData.YBgnDstErr.GetValue(15).ToString();
            yBgnDstErr17.Text = LMachStaData.YBgnDstErr.GetValue(16).ToString();
            yBgnDstErr18.Text = LMachStaData.YBgnDstErr.GetValue(17).ToString();
            yBgnDstErr19.Text = LMachStaData.YBgnDstErr.GetValue(18).ToString();
            yBgnDstErr20.Text = LMachStaData.YBgnDstErr.GetValue(19).ToString();

            yEndDstErr1.Text = LMachStaData.YEndDstErr.GetValue(0).ToString();
            yEndDstErr2.Text = LMachStaData.YEndDstErr.GetValue(1).ToString();
            yEndDstErr3.Text = LMachStaData.YEndDstErr.GetValue(2).ToString();
            yEndDstErr4.Text = LMachStaData.YEndDstErr.GetValue(3).ToString();
            yEndDstErr5.Text = LMachStaData.YEndDstErr.GetValue(4).ToString();
            yEndDstErr6.Text = LMachStaData.YEndDstErr.GetValue(5).ToString();
            yEndDstErr7.Text = LMachStaData.YEndDstErr.GetValue(6).ToString();
            yEndDstErr8.Text = LMachStaData.YEndDstErr.GetValue(7).ToString();
            yEndDstErr9.Text = LMachStaData.YEndDstErr.GetValue(8).ToString();
            yEndDstErr10.Text = LMachStaData.YEndDstErr.GetValue(9).ToString();
            yEndDstErr11.Text = LMachStaData.YEndDstErr.GetValue(10).ToString();
            yEndDstErr12.Text = LMachStaData.YEndDstErr.GetValue(11).ToString();
            yEndDstErr13.Text = LMachStaData.YEndDstErr.GetValue(12).ToString();
            yEndDstErr14.Text = LMachStaData.YEndDstErr.GetValue(13).ToString();
            yEndDstErr15.Text = LMachStaData.YEndDstErr.GetValue(14).ToString();
            yEndDstErr16.Text = LMachStaData.YEndDstErr.GetValue(15).ToString();
            yEndDstErr17.Text = LMachStaData.YEndDstErr.GetValue(16).ToString();
            yEndDstErr18.Text = LMachStaData.YEndDstErr.GetValue(17).ToString();
            yEndDstErr19.Text = LMachStaData.YEndDstErr.GetValue(18).ToString();
            yEndDstErr20.Text = LMachStaData.YEndDstErr.GetValue(19).ToString();
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
                                    ReflectToObject(Sel, TestRptInfo.XBgnDstErr.ToString());
                                    break;
                                case 1:
                                    ReflectToObject(Sel, TestRptInfo.XEndDstErr.ToString());
                                    break;
                                case 2:
                                    ReflectToObject(Sel, TestRptInfo.YBgnDstErr.ToString());
                                    break;
                                case 3:
                                    ReflectToObject(Sel, TestRptInfo.YEndDstErr.ToString());
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