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
        

        //传递给下位机的数据 包括xy的起始角度 和 xy的跟随范围
        public FlowDrawForm()
        {
            InitializeComponent();
            ibEditCheck.SetMap(Properties.Resources.imgEditLock1, Properties.Resources.imgEditLock2);
            ibReturn.SetMap(Properties.Resources.imgReturn1, Properties.Resources.imgReturn2);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.FlowDrawForm;            
            FlowDataModel.GetDataBaseModel().HaveDataChanged = true;
            FlowDataDAO setDataDAO = new FlowDataDAO();

            MachineInfoSendData.choicedSendFlow = true;
            //SerialDataManager.Feedback += new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            LoadPatternDataButton();

            int Count = (int)SetDataEnum.Null;
            for (int i = 0; i < Count; i++)
                TabList[i].Content = setDataDAO.GetDataBaseValue((SetDataEnum)i).ToString();
        }               

        private void Return_Click(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MainFormMode;

            MachineInfoSendData.choicedSendFlow = false;
            FlowDataModel.GetDataBaseModel().HaveDataChanged = true;
            ibEditCheck.IsCheck = false;
            this.Close();
        }

        //void SerialDataManager_Feedback(UartComdEventArgs lowerDataInfo)
        //{
        //    if (lowerDataInfo.LowerDataType == LowerDataType.MachineBasicDataType) { }
        //}                            

        private void ButtonData_Click(object sender, EventArgs e)
        {
            if (flowDrawManager.ModeChange)
            {
                if (sender is Tablet)
                {
                    Tablet Tab = sender as Tablet;

                    Calculator myCal = new Calculator();
                    myCal.InitStrNum = Tab.Content;
                    myCal.PointButtonEnable = false;
                    myCal.MinusButtonEnable = false;
                    myCal.IsSercet = false;
                    myCal.MaxValue = (double)1000;
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
                    if(Tab.Tag != null)
                        TabList.Add(Tab);
                }
            }
            TabList.Sort(TagComparer);
        }

        private void ibSwitch_Click(object sender, EventArgs e)
        {
            ImgSwitch imgBtn = sender as ImgSwitch;

            imgBtn.SwitchClick();
            flowDrawManager.ModeChange = imgBtn.IsCheck;
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
                
                TabList[Row].BackColor = Color.Silver;
                TabList[10 + Row].BackColor = Color.Silver;
                TabList[20 + Row].BackColor = Color.Silver;
                TabList[30 + Row].BackColor = Color.Silver;
                TabList[Index].BackColor = Color.MediumSeaGreen;
            }
        }


    }
}