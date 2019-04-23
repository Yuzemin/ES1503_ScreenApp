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
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineDAL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class EditForm : Form
    {
        private WarnForm warnForm;
        private EditFormManager EditManager =new EditFormManager();
        private ModifyShapeForm modifyShapeForm;
        private EditFormFlagData flagData;
        private int ShapeType_Index = 0;
        private string[] TypeEnum = { "标准", "圆弧", "外圆弧", "内锯齿", "外锯齿" ,"横向","齿带弧"};
        private List<Tablet> VisibleList = new List<Tablet>();

        public ShouldPadShapeInfo ShouldPadShapeInfo
        {
            set {
                if (value != null)
                {
                    if (EditManager == null)
                        EditManager = new EditFormManager();
                    picShapeImage.Image =  EditManager.SetShouldPadPoints(value);
                }
            }
            get {
                return EditManager.ShouldPadShapeInfo;
            }
        }

        public EditForm()
        {
            InitializeComponent();
            ibLeftBtn.SetMap(Properties.Resources.imgLift1, Properties.Resources.imgLift2);
            ibRightBtn.SetMap(Properties.Resources.imgRight1, Properties.Resources.imgRight2);
            ibBackOut.SetMap(Properties.Resources.imgRepeal1, Properties.Resources.imgRepeal2);
            ibDrawAll.SetMap(Properties.Resources.imgDrawAll1, Properties.Resources.imgDrawAll2);
            ibDrawLift.SetMap(Properties.Resources.imgHalfLift1, Properties.Resources.imgHalfLift2);
            ibDrawRight.SetMap(Properties.Resources.imgHalfRight1, Properties.Resources.imgHalfRight2);
            ibPointEdit.SetMap(Properties.Resources.imgPointCh1, Properties.Resources.imgPointCh2);
            ibReturn.SetMap(Properties.Resources.imgExit1, Properties.Resources.imgExit2);
            
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Tablet)
                {
                    Tablet Param = ctl as Tablet;
                    if (Param.Tag != null)
                        EditManager.ParamList.Add(Param);
                }
            }
            TabletComparerByTag TagComparer = new TabletComparerByTag();
            EditManager.ParamList.Sort(TagComparer);
            VisibleList.Add(tlCol);
            VisibleList.Add(tlRow);
            VisibleList.Add(tlCurve);
            VisibleList.Add(tlJag);
            VisibleList.Add(tlGapX);
        }

        private void InitParamButtons()
        {
            //读Xml数据
            ShouldPadDAO PadDAO = new ShouldPadDAO();
            foreach (Tablet Tab in EditManager.ParamList)
            {
                if (Tab.Tag.ToString() == "6")
                {
                    Tab.Val_Max = Convert.ToInt32(tlPadLength.Content) / 2;
                }
                Tab.Content = PadDAO.GetDataBaseValue(int.Parse(Tab.Tag.ToString()));
            }
            tlPadHalf.SetValRange(20, Convert.ToInt32(tlPadLength.Content) / 2);
            PadDAO.SetDataBaseValue((ShouldPadDataEnum)Convert.ToInt16(tlPadHalf.Tag), tlPadHalf.Content);
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (flagData == null)
                flagData = new EditFormFlagData();
            InitParamButtons();
            EditManager.AddEditOperParams();
            
            LowerMachineStatueData.LowerMachineStatueDateEx.EditStatue = true;            
            SerialDataManager.Feedback += new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);

            ShapeType_Index = 0;
            ShapeType.Content = TypeEnum[ShapeType_Index];
            shapeType_SelectedCh();            
        }

        private void shapeType_SelectedCh()
        {
            foreach (Tablet Tab in VisibleList)
            {
                Tab.Enabled = false;
                Tab.ForeColor = Color.DarkGray;
            }

            switch (TypeEnum[ShapeType_Index])
            {
                case "标准":
                    tlCol.Enabled = true;
                    tlCurve.Enabled = true;
                    break;
                case "圆弧":
                case "外圆弧":
                    tlCol.Enabled = true;
                    break;
                case "内锯齿":
                case "外锯齿":
                case "齿带弧":
                    tlCol.Enabled = true;
                    tlJag.Enabled = true;
                    break;
                case "横向":
                    tlRow.Enabled = true;
                    tlGapX.Enabled = true;
                    break;
                default:
                    break;
            }

            foreach (Tablet Tab in VisibleList)
            {
                Tab.Invalidate();
                if (Tab.Enabled == true)
                    Tab.ForeColor = Color.Black;
            }
        }

        void SerialDataManager_Feedback(UartComdEventArgs lowerDataInfo)
        {
            if (lowerDataInfo.LowerDataType == LowerDataType.MachineBasicDataType)
            {
                MachineBasicDataInfo machineBasicDataInfo = lowerDataInfo.LowerDataInfo as MachineBasicDataInfo;
                if (flagData == null)
                    flagData = new EditFormFlagData();
                if (flagData.ClickSewingButton != machineBasicDataInfo.ClickSewingButton)
                {
                    flagData.ClickSewingButton = machineBasicDataInfo.ClickSewingButton;
                    if (flagData.ClickSewingButton)
                        ShowPromptForm();
                }
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            if (EditManager.EditShouldPadInfoList.Count > 1)
            {
                DialogResultEx dialogResultEx = MessageBoxEX.Show("图形已经被修改，是否进行保存！", MessageBoxButtonType.YesCancel);

                if (dialogResultEx == DialogResultEx.Yes)
                {
                    if (EditManager.HaveIrregularPoint)
                        MessageBoxEX.Show("图中存在无效点，请重新编辑！");
                    else if (EditManager.GetShapePointLength > 300)
                        MessageBoxEX.Show("花型针数超过300针，请重新编辑！");
                    else
                    {
                        EditManager.Edit_SaveAllParam();
                        EditManager.ShouldPadShapeInfo = EditManager.EditShouldPadInfoList[EditManager.EditShouldPadInfoList.Count - 1].ShouldPadShapeInfo;
                        LowerMachineStatueData.LowerMachineStatueDateEx.EditStatue = false;
                        SerialDataManager.Feedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
                        this.Close();
                    }
                }
                else
                {
                    EditManager.ShouldPadShapeInfo = EditManager.EditShouldPadInfoList[0].ShouldPadShapeInfo;                    
                    LowerMachineStatueData.LowerMachineStatueDateEx.EditStatue = false;
                    SerialDataManager.Feedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.FeedbackEventHandle(SerialDataManager_Feedback);
                    this.Close();
                }
            }
            else
            {
                this.Close();
                LowerMachineStatueData.LowerMachineStatueDateEx.EditStatue = false;
            }
        }

        private void ShapeFixed_Click(object sender, EventArgs e)
        {
            if (EditManager.ShouldPadShapeInfo == null || EditManager.ShouldPadShapeInfo.ShapePoints == null)
                MessageBoxEX.Show("该界面没有图形，无法打开修正模式！");
            else
            {
                if (modifyShapeForm == null)
                    modifyShapeForm = new ModifyShapeForm();
                modifyShapeForm.ShouldPadShapeInfo = EditManager.ShouldPadShapeInfo;
                ScreenStatueData.ScreenStatueDataEX.InterfaceMode = ShouldPadMachine.ShouldPadMachineAssist.Enum.InterfaceMode.ModifyFormMode;

                modifyShapeForm.ShowDialog();

                ScreenStatueData.ScreenStatueDataEX.InterfaceMode = ShouldPadMachine.ShouldPadMachineAssist.Enum.InterfaceMode.EditFormMode;
                if (modifyShapeForm.DialogResult == DialogResult.Yes)
                    picShapeImage.Image =  EditManager.SetShouldPadPoints(modifyShapeForm.ShouldPadShapeInfo.ShapePoints);
            }
        }

        private void Param_Click(object sender, EventArgs e)
        {
            Tablet tlParam = sender as Tablet;

            Calculator calculator = new Calculator();
            calculator.InitStrNum = tlParam.Content;
            calculator.PointButtonEnable = tlParam.Endecimal;
            calculator.MinusButtonEnable = tlParam.Enminus;
            calculator.MaxValue = Convert.ToDouble(tlParam.Val_Max);
            calculator.MinValue = Convert.ToDouble(tlParam.Val_Min);
            calculator.ShowDialog();
            double CalVal = calculator.LastNumber;

            //MessageBox.Show("键盘输入值为：" + CalVal.ToString() + "\r\n" + "此按键最大值：" + tlParam.Val_Max.ToString() + "\r\n" + "此按键最小值：" + tlParam.Val_Min.ToString());
            if (tlParam.Name == "tlPadLength")
            {
                tlParam.Content = CalVal.ToString();

                tlPadHalf.SetValRange(20, Convert.ToInt32(tlPadLength.Content) / 2);
            }
            else
            {
                tlParam.Content = CalVal.ToString();
                if (tlParam.Name == "tlClampL" || tlParam.Name == "tlClampM" || tlParam.Name == "tlClampR")
                {
                    picShapeImage.Image = EditManager.RecountClampCloth();
                    //ShouldPadDAO dataBaseDAO = new ShouldPadDAO();
                    //dataBaseDAO.SetDataBaseValue((ShouldPadDataEnum)Convert.ToInt16(tlParam.Tag), tlParam.Content);
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

        private void Revoke_Click(object sender, EventArgs e)
        {
            picShapeImage.Image = EditManager.RevokeOper();
        }

        private void LeftDrawBitmap_Click(object sender, EventArgs e)
        {
            picShapeImage.Image = EditManager.LeftDrawShouldPadShape(ShapeType_Index);
        }

        private void RightDrawBitmap_Click(object sender, EventArgs e)
        {
            picShapeImage.Image = EditManager.RightDrawShouldPadShape(ShapeType_Index);
        }

        private void DrawBitmap_Click(object sender, EventArgs e)
        {
            picShapeImage.Image = EditManager.DrawShouldPadShape(ShapeType_Index);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            this.ShapeType_Index--;

            if (this.ShapeType_Index < 0)
                this.ShapeType_Index = TypeEnum.Count() - 1;

            ShapeType.Content = TypeEnum[this.ShapeType_Index];
            shapeType_SelectedCh();
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            this.ShapeType_Index++;

            if (this.ShapeType_Index >= TypeEnum.Count())
                this.ShapeType_Index = 0;

            ShapeType.Content = TypeEnum[this.ShapeType_Index];
            shapeType_SelectedCh();
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