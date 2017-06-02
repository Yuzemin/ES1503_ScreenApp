using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineBLL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class ModifyShapeForm : Form
    {
        private ShapeOperManager shapeOperManager;
        private TimeClock timeClock;
        private DialogResult dialogResult;
        private WarnForm warnForm;
        private ModifyFormFlagData flagData;
        private DirectionType directionType;
        public new DialogResult DialogResult
        {
            get {
                return dialogResult;
            }
        }
        public ModifyShapeForm()
        {
            InitializeComponent();

            ibMirror.SetMap(Properties.Resources.imgMirror1, Properties.Resources.imgMirror2);
            ibMirror1.SetMap(Properties.Resources.imgMir1, Properties.Resources.imgMir2);

            ibReturn.SetMap(Properties.Resources.imgExit1, Properties.Resources.imgExit2);
            ibAddPoint.SetMap(Properties.Resources.imgAddPoit1, Properties.Resources.imgAddPoit2);
            ibDelPoint.SetMap(Properties.Resources.imgDelPoint1, Properties.Resources.imgDelPoint2);
            ibSelAll.SetMap(Properties.Resources.imgSelAll1, Properties.Resources.imgSelAll2);            
            ibBreakOut.SetMap(Properties.Resources.imgRepeal1, Properties.Resources.imgRepeal2);
            btnMovePrevious.SetMap(Properties.Resources.imgLift1, Properties.Resources.imgLift2);
            btnMoveNext.SetMap(Properties.Resources.imgRight1,Properties.Resources.imgRight2);
            btnMoveLeftUp.SetMap(Properties.Resources.img7d1,Properties.Resources.img7d2);
            btnMoveUp.SetMap(Properties.Resources.img8d1,Properties.Resources.img8d2);
            btnMoveRightUp.SetMap(Properties.Resources.img9d1,Properties.Resources.img9d2);
            btnMoveLeft.SetMap(Properties.Resources.img4d1,Properties.Resources.img4d2);
            ibEnter.SetMap(Properties.Resources.img5d1,Properties.Resources.img5d2);
            btnMoveRight.SetMap(Properties.Resources.img6d1,Properties.Resources.img6d2);
            btnMoveLeftDown.SetMap(Properties.Resources.img1d1,Properties.Resources.img1d2);
            btnMoveDown.SetMap(Properties.Resources.img2d1,Properties.Resources.img2d2);
            btnMoveRightDown.SetMap(Properties.Resources.img3d1,Properties.Resources.img3d2);
        }
        public ShouldPadShapeInfo ShouldPadShapeInfo
        {
            set {
                if (shapeOperManager == null)
                    shapeOperManager = new ShapeOperManager(DefaultValue.DefaultValueEx.DefaultBackSize);
                shapeOperManager.SetShouldPadShapeInfo(value);
            }
            get {
                return shapeOperManager.GetShouldPadShapeInfo();
            }
        }
        private void ModifyShapeForm_Load(object sender, EventArgs e)
        {
            ibSelAll.IsCheck = false;
            shapeOperManager.MoveType = ShouldPadMachine.ShouldPadMachineAssist.Enum.MoveType.MoveShapeSelectPoint;
            SerialDataManager.Feedback +=new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
            ShowNeedleInfo();
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
        }
        private void ShowNeedleInfo()
        {
            lblNeedleNumber.Text = (shapeOperManager.SelectPointIndex+1).ToString().PadLeft(3, '0');
            lblTotalNeedleNumber.Text = shapeOperManager.ShapePointLength.ToString().PadLeft(3, '0');
        }
        private void Direction_MouseDown(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickDown();
            String directName = imgBtn.Name;
            directName = directName.Remove(0, 3);
            directionType = (DirectionType)Enum.Parse(typeof(DirectionType), directName, true);
            if (timeClock == null)
                timeClock = new TimeClock(timMain.Interval,1);
            timeClock.PressButtonEnable = true;
            timMain.Enabled = true;
            shapeOperManager.MovePlus(directionType);
            ShowNeedleInfo();
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
        }

        private void Direction_MouseUp(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickUp();
            if (timeClock != null)
            {
                if (timeClock.ShouldGetBitmapAgain)
                {
                    picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
                    ShowNeedleInfo();
                }
                timeClock.PressButtonEnable = false;
            }
            timMain.Enabled = false;
        }

        private void MakeSure_Click(object sender, EventArgs e)
        {
            shapeOperManager.MoveShapePoint();
            ibSelAll.IsCheck = false;
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
            ShowNeedleInfo();
        }

        private void MainTime_Tick(object sender, EventArgs e)
        {
            if (timeClock != null)
            {
                timeClock.Timer_Tick();
                if (timeClock.MovePlusEnable)
                {
                    shapeOperManager.MovePlus(directionType);
                    //MessageBox.Show("移动坐标");
                }
                if (timeClock.GetBitmapEnable)
                {
                    picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
                    //MessageBox.Show("获取图片");
                }
            }
        }

        private void PointOperMode_Click(object sender, EventArgs e)
        {
            ImgBtn imageButton = sender as ImgBtn;
            switch (imageButton.Name)
            {
                case "ibAddPoint":
                    shapeOperManager.AppendShapePoint();
                    break;
                case "ibDelPoint":
                    shapeOperManager.DeleteShapePoint();
                    break;
                case "ibMirror":
                    shapeOperManager.MirrorShapePoint(0);
                    break;
                case "ibMirror1":
                    shapeOperManager.MirrorShapePoint(1);
                    break;
                default:
                    break;
            }
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
            ShowNeedleInfo();
        }

        private void Revoke_Click(object sender, EventArgs e)
        {
            shapeOperManager.RevokeShapesOPer();
            ShowNeedleInfo();
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
        }

        private void Return_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Yes;
            this.Close();
        }
        void SerialDataManager_Feedback(UartComdEventArgs lowerDataInfo)
        {
            if (lowerDataInfo.LowerDataType == LowerDataType.MachineBasicDataType)
            {
                MachineBasicDataInfo machineBasicDataInfo = lowerDataInfo.LowerDataInfo as MachineBasicDataInfo;
                if (flagData == null)
                    flagData = new ModifyFormFlagData();
                if (flagData.ClickSewingButton != machineBasicDataInfo.ClickSewingButton)
                {
                    flagData.ClickSewingButton = machineBasicDataInfo.ClickSewingButton;
                    if (flagData.ClickSewingButton)
                        ShowPromptForm();
                }
            }
        }
        private void ShowPromptForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NoValueEventHandle(ShowPromptForm));
                return;
            }
            if (warnForm == null)
                warnForm = new WarnForm();
        }

        private void MoveTypeChange_Click(object sender, EventArgs e)
        {
            ImgSwitch imBtn = sender as ImgSwitch;

            imBtn.SwitchClick();
            if (imBtn.IsCheck)
                shapeOperManager.MoveType = MoveType.MoveShape;
            else
                shapeOperManager.MoveType = MoveType.MoveShapeSelectPoint;
   
            picDrawBackGround.Image = shapeOperManager.GetShapeBitmap();
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