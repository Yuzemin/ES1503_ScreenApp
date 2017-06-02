using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineCTL;
using Microsoft.Win32;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class Menu : Form
    {
        private MainForm MainF;
        private MainFormManager MF_Manager;
        private ProcessBar progressForm;
        private UpdataFileManager updataProcess = new UpdataFileManager();
        public MenuFormManager Menu_Manger = new MenuFormManager();

        public Menu(MainForm MF)
        {
            InitializeComponent();

            MainF = MF;
            MF_Manager = MF.mainFormManager;
            ib_SetPos.SetMap(Properties.Resources.imgSetPos1, Properties.Resources.imgSetPos2);
            ib_Test.SetMap(Properties.Resources.imgTest1, Properties.Resources.imgTest2);
            ib_SetParam.SetMap(Properties.Resources.imgSetParam1, Properties.Resources.imgSetParam2);
            ibUpSrc.SetMap(Properties.Resources.imgUpSrc1, Properties.Resources.imgUpSrc2);
            ibUpEco.SetMap(Properties.Resources.imgUpEco1, Properties.Resources.imgUpEco2);
            ibUpBoot.SetMap(Properties.Resources.imgUpbtl1, Properties.Resources.imgUpbtl2);
            ibCopyCur.SetMap(Properties.Resources.imgCopyCur1, Properties.Resources.imgCopyCur2);
            ibCopyAll.SetMap(Properties.Resources.imgCopyAll1, Properties.Resources.imgCopyAll2);
            ibGetXml.SetMap(Properties.Resources.imgGetXml1, Properties.Resources.imgGetXml2);
            ibReturn.SetMap(Properties.Resources.imgReturn1, Properties.Resources.imgReturn2);
            ibInfo.SetMap(Properties.Resources.SysInfo1, Properties.Resources.SysInfo2);
            ibActive.SetMap(Properties.Resources.imgAct1, Properties.Resources.imgAct2);
        }

        private void ibSetPos_Click(object sender, EventArgs e)
        {
            BaseDataForm baseDataForm = new BaseDataForm();

            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.BaseFormMode;
            baseDataForm.ShowDialog();
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MenuForm;
        }

        private void ibTest_Click(object sender, EventArgs e)
        {
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.TestFormMode;

            TestForm testForm = new TestForm();
            testForm.ShowDialog();

            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MenuForm;
        }

        private void ExeFileUpdata()
        {
            this.Enabled = false;
            progressForm = new ProcessBar(1);
            progressForm.UpDataExeFile();
            UpDataHint MsgBox = new UpDataHint();
            MsgBox.ShowDialog();
        }

        private void ShowHintMsg()
        {
            UpDataHint MsgBox = new UpDataHint();
            MsgBox.ShowDialog();
        }


        private void WaitForUnLockMsgAndUpdata()
        {
            while (MenuFormManager.LockResult == 0xff) ;

            ShowHintMsg();
        }

        private void EcoFileUpdata()
        {
            this.Enabled = false;
            progressForm = new ProcessBar(1);
            progressForm.UpDataEcoFile();

            if (MenuFormManager.IsActed == 1)
            {
                Thread T = new Thread(WaitForUnLockMsgAndUpdata);
                T.Start();
            }
            else
                ShowHintMsg();
        }


        private void ibSrcUpdata_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckExeUpData())
            {
                ExeFileUpdata();
            }
        }

        private void ibEcoUpdata_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckEcoUpData())
            {
                EcoFileUpdata();
            }
        }

        private void ibBootLoadUpdata_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckBootLoad())
            {
                this.Enabled = false;
                progressForm = new ProcessBar(1);
                progressForm.UpDataBootLoader();
                this.Enabled = true;
            }
        }

        private void ibCopyCurStyle_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckCopyCur(MainF.bFileID.Text))
            {
                this.Enabled = false;
                progressForm = new ProcessBar(1);
                progressForm.CopyCurXml(MainF.bFileID.Text);
                this.Enabled = true;
            }
        }

        private void ibCopyAllStyle_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckCopyAll())
            {
                this.Enabled = false;
                progressForm = new ProcessBar(updataProcess.Total_Num);
                progressForm.CopyAllXml();
                this.Enabled = true;
            }
        }

        private void ibGetStyle_Click(object sender, EventArgs e)
        {
            if (updataProcess.CheckGetXml())
            {
                this.Enabled = false;
                progressForm = new ProcessBar(updataProcess.Total_Num);
                progressForm.GetAllXml();
                MF_Manager.UpdataShouldDatas(MainF.bFileID.Text);
                MF_Manager.LoadShouldPadImage();
                MainF.lblTotalNeedleNumber.Text = MF_Manager.TotalNumber.ToString();
                MainF.picShapeImage.Image = MF_Manager.GetShapeImage();
                this.Enabled = true;
            }
        }

        private void ibActive_Click(object sender, EventArgs e)
        {
            Thread T = new Thread(WaitForUnLockMsg);

            SetUnLockPassWord();
            T.Start();
        }

        private void SetUnLockPassWord()
        {
            Calculator myCal = new Calculator();
            myCal.InitStrNum = "";
            myCal.IsSercet = false;
            myCal.MaxValue = UInt32.MaxValue;
            myCal.MinValue = 0;
            myCal.ShowDialog();

            uint EncWord = Convert.ToUInt32(myCal.LastNumber);
            MenuFormManager.SetUnLockPW(EncWord);
        }

        private void WaitForUnLockMsg_f()
        {
            if (MenuFormManager.LockResult == 1)
            {
                MessageBoxEX.Show("程序已注册", MessageBoxButtonType.OK);
                MenuFormManager.IsActed = 1;
                ibActive.Visible = false;
            }
            else
                MessageBoxEX.Show("请输入正确激活码", MessageBoxButtonType.OK);
        }

        private void WaitForUnLockMsg()
        {
            while (MenuFormManager.LockResult == 0xff) ;

            this.Invoke(new MessageBoxShowReCall(WaitForUnLockMsg_f), null);
        }

        private void ibSetParam_Click(object sender, EventArgs e)
        {
            string[] SWP = new string[] { "5800", "2010", "1278" };

            for (uint i = 0; i < 3; i++)
            {
                Calculator myCal = new Calculator();
                myCal.InitStrNum = "";
                myCal.IsSercet = true;
                myCal.MaxValue = double.MaxValue;
                myCal.MinValue = 0;
                myCal.ShowDialog();

                string KeyBoard_Val = myCal.LastNumber.ToString();
                myCal.Dispose();

                if (i == 0 && KeyBoard_Val == "1597")
                {
                    FlowDrawForm flowDrawForm = new FlowDrawForm();

                    SerialDataManager.Feedback -= new FeedbackEventHandle(MainF.SerialDataManager_Feedback);
                    flowDrawForm.ShowDialog();
                    SerialDataManager.Feedback += new FeedbackEventHandle(MainF.SerialDataManager_Feedback);
                    ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MenuForm;
                    return;
                }
                else if (KeyBoard_Val != SWP[i])
                    return;
            }
            Process aaa = new Process();
            aaa.StartInfo.FileName = "explorer.exe";
            aaa.Start();
            Process.GetCurrentProcess().Kill();
        }

        private void ibReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ibInfo_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();
            infoForm.ShowDialog();
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

        private void Menu_Load(object sender, EventArgs e)
        {
            if (MenuFormManager.IsActed == 1)
                ibActive.Visible = false;
            else
                ibActive.Visible = true;
        }
    }
}