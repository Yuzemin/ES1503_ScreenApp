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
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineDAL;
 

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class MainForm : Form
    {
        private WarnForm warnForm = new WarnForm();
        private MachineWarnForm machineWarnForm;
        private MainFormFlagData flagData;
        public MainFormManager mainFormManager = new MainFormManager();
        private EditForm editForm;
        private NineKeyboardForm Ninecalculator;
        private Menu MenuForm;
        private byte ClockSta = 0;
        private bool showPromptForm = false;       
        

        public MainForm()
        {
            InitializeComponent();
            ibMenu.SetMap(Properties.Resources.imgMenu1, Properties.Resources.imgMenu2);
            ibEdit.SetMap(Properties.Resources.imgEdit1, Properties.Resources.imgEdit2);
            btnMovePrevious.SetMap(Properties.Resources.imgPre1, Properties.Resources.imgPre2);
            btnMoveNext.SetMap(Properties.Resources.imgNext1, Properties.Resources.imgNext2);
            swSingleStep.SetMap(Properties.Resources.imgNor, Properties.Resources.imgSingle);
            swAuto.SetMap(Properties.Resources.imgAuto1, Properties.Resources.imgAuto2);
            VerString.Content = "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "MainProgram";
            SerialDataManager.Feedback += new FeedbackEventHandle(SerialDataManager_Feedback);
            WarnForm.FormHide += new FormHideEventHandle(WarnForm_FormHide);
            MachineWarnForm.FormHide += new FormHideEventHandle(WarnForm_FormHide);
            ErrorMessage.OccurError += new OccurErrorEventHandle(ErrorMessage_OccurError);
            
            mainFormManager.InitSystemData();
            mainFormManager.LoadSizeRadio(picShapeImage.Size);
            DefaultColor.DefaultColorEx.DefaultBackGroundColor = picShapeImage.BackColor;
            mainFormManager.LoadShouldPadImage();
            picShapeImage.Image = mainFormManager.GetShapeImage();
            lblTotalNeedleNumber.Text = mainFormManager.TotalNumber.ToString();

            MachineBaseDataDAO baseDataDAO = new MachineBaseDataDAO();
            if (baseDataDAO.IsParamsInvalid())
            {
				warnForm.HaveWarnMsg = true;
                warnForm.WarnType = WarnType.ModifiedValueWarn;
				warnForm.Show();
            }
        }

        private void CheckMachineInfoData()
        {
            LowerMachineStatueData.LowerMachineStatueDateEx.MachineCanWork = true;
            if (!mainFormManager.CheckMachineInfoData())
            {
                LowerMachineStatueData.LowerMachineStatueDateEx.MachineCanWork = false;
                ShowPromptForm();
            }
        }

        void ErrorMessage_OccurError(ErrorMessage errorMessage)
        {
            lock (this)
            {
                ShowErrorMessage(errorMessage);
            }
        }

        private void ShowErrorMessage(ErrorMessage errorMessage)
        {
            if (this.InvokeRequired)
            {
                object[] obs = new object[] { errorMessage };
                this.Invoke(new ShowErrorMessageDelegate(ShowErrorMessage), obs);
                return;
            }
            MessageBoxButtonType messageBoxButtonType = MessageBoxButtonType.OK;
            if (errorMessage.PromptOccurPlace == PromptOccurPlace.XmlWriteError || errorMessage.PromptOccurPlace == PromptOccurPlace.XmlReadError)
                messageBoxButtonType = MessageBoxButtonType.Repair;
            switch (errorMessage.PromptMessageType)
            {
                case PromptMessageType.ShouldUpdataFile:
                    messageBoxButtonType = MessageBoxButtonType.YesCancel;
                    break;
                case PromptMessageType.PromptMessageType:
                    messageBoxButtonType = MessageBoxButtonType.OK;
                    break;
                case PromptMessageType.UnKnown:
                    messageBoxButtonType = MessageBoxButtonType.OK;
                    break;
            }
            if (errorMessage.PromptMessageType != PromptMessageType.PromptMessageType)
            {
                mainFormManager.CloseSerialPort();
            }
            DialogResultEx diaglogResult = MessageBoxEX.Show(MessageString.GetMessageString(errorMessage.PromptOccurPlace, errorMessage.PromptMessageType, errorMessage.ErrorInfo), messageBoxButtonType);
            if (errorMessage.PromptOccurPlace == PromptOccurPlace.XmlReadError || errorMessage.PromptOccurPlace == PromptOccurPlace.XmlWriteError)
            {
                RepairMachineManager repairMachineManager = new RepairMachineManager();
                if (errorMessage.PromptOccurPlace == PromptOccurPlace.XmlWriteError)
                {
                    repairMachineManager.RepairSaveMachineDatas(errorMessage.ErrorInfo.ToString());
                    MessageBoxEX.Show("Repair success!", MessageBoxButtonType.OK);
                }
                else
                {
                    repairMachineManager.RepairCopyMachineDatas(errorMessage.ErrorInfo.ToString());
                    MessageBoxEX.Show("Repair success!pleas restart the machine", MessageBoxButtonType.None);
                }
            }
        }

        public void SerialDataManager_Feedback(UartComdEventArgs e)
        {
            
            LowerMachineStatueData lowerMachineStatueData = LowerMachineStatueData.LowerMachineStatueDateEx;
            int Read_ProductNum = 0;

            if (flagData == null)
                flagData = new MainFormFlagData();
            if (e.LowerDataType == LowerDataType.MachineBasicDataType)
            {
                MachineBasicDataInfo machineBasicDataInfo = e.LowerDataInfo as MachineBasicDataInfo;

                lowerMachineStatueData.WorkedStatue = machineBasicDataInfo.WorkedStatue;            //缝纫模块工作状态
                lowerMachineStatueData.SendClothStatue = machineBasicDataInfo.SendClothStatue;      //运布模块状态  1在等待阶段
                lowerMachineStatueData.SingleStepStatue = machineBasicDataInfo.SingleStepStatue;    //单步模块状态  1在就绪阶段


                if (lowerMachineStatueData.WorkedStatue == WorkedStatue.WaitToStartStatue)
                    ScreenStatueData.ScreenStatueDataEX.ScreenButtonEnable = true;
                if (flagData.ClickSewingButton != machineBasicDataInfo.ClickSewingButton)
                {
                    if (machineBasicDataInfo.ClickSewingButton)
                        lowerMachineStatueData.ClickSewingButtonWarn = true;
                    showPromptForm = true;
                    flagData.ClickSewingButton = machineBasicDataInfo.ClickSewingButton;
                }
                if (flagData.WorkedNumber != machineBasicDataInfo.WorkedNumber || flagData.SyncWorkedNumber == false)
                {
                    lowerMachineStatueData.WorkedNumber = machineBasicDataInfo.WorkedNumber;
                    flagData.WorkedNumber = machineBasicDataInfo.WorkedNumber;
                    //ReflectToObject(lblWorkedNumber, machineBasicDataInfo.WorkedNumber.ToString());
                    //ReflectToObject(lblMagnWorkedNumber, machineBasicDataInfo.WorkedNumber.ToString()); 

                    MachineBaseDataDAO baseDataDAO = new MachineBaseDataDAO();
                    Read_ProductNum = baseDataDAO.GetDataBaseValue(MachineBaseDataEnum.ProductCount);
                    if (flagData.SyncWorkedNumber == true && machineBasicDataInfo.WorkedNumber != 0)
                    {
                        Read_ProductNum++;
                        baseDataDAO.SetDataBaseValue(MachineBaseDataEnum.ProductCount, Read_ProductNum);
                    }
                    flagData.SyncWorkedNumber = true;
                    ReflectToObject(lblWorkedNumber, Read_ProductNum.ToString());
                    ReflectToObject(lblMagnWorkedNumber, Read_ProductNum.ToString());    
                }
                if (flagData.BootomWorkedNumber != machineBasicDataInfo.BootomWorkedNumber)
                {
                    flagData.BootomWorkedNumber = machineBasicDataInfo.BootomWorkedNumber;
                    ReflectToObject(lblBottomWorkedNumber, flagData.BootomWorkedNumber.ToString());
                }
                if (flagData.WorkNeedleNumber != machineBasicDataInfo.WorkNeedleNumber)
                {
                    flagData.WorkNeedleNumber = machineBasicDataInfo.WorkNeedleNumber;
                    ReflectToObject(lblWorkNeedleNumber, (machineBasicDataInfo.WorkNeedleNumber).ToString());
                }
                if (flagData.TestData != 0)
                {
                    flagData.TestData = 0;
                }
                ////////////////////////////////////////////////////////////////////////////

                if (flagData.ModeSwitchWarn != machineBasicDataInfo.ModeSwitchWarn)
                {
                    flagData.ModeSwitchWarn = machineBasicDataInfo.ModeSwitchWarn;
                    lowerMachineStatueData.ModeSwitchWarn = flagData.ModeSwitchWarn;
                    if (lowerMachineStatueData.ModeSwitchWarn)
                        showPromptForm = true;
                }
                if (flagData.TotalWorkedNumberOverflowWarn != machineBasicDataInfo.TotalWorkedNumberOverflowWarn)
                {
                    flagData.TotalWorkedNumberOverflowWarn = machineBasicDataInfo.TotalWorkedNumberOverflowWarn;
                    lowerMachineStatueData.TotalWorkedNumberOverflowWarn = flagData.TotalWorkedNumberOverflowWarn;
                    if (lowerMachineStatueData.TotalWorkedNumberOverflowWarn)
                        showPromptForm = true;
                }
                if (flagData.WorkedNumberOverflowWarn != machineBasicDataInfo.WorkedNumberOverflowWarn)
                {
                    flagData.WorkedNumberOverflowWarn = machineBasicDataInfo.WorkedNumberOverflowWarn;
                    lowerMachineStatueData.WorkedNumberOverflowWarn = flagData.WorkedNumberOverflowWarn;
                    if (lowerMachineStatueData.WorkedNumberOverflowWarn)
                        showPromptForm = true;
                }
                if (flagData.LineBreakWarn != machineBasicDataInfo.LineBreakWarn)
                {
                    flagData.LineBreakWarn = machineBasicDataInfo.LineBreakWarn;
                    lowerMachineStatueData.LineBreakWarn = flagData.LineBreakWarn;
                    if (lowerMachineStatueData.LineBreakWarn)
                        showPromptForm = true;
                }
                if (flagData.CrdWarn != machineBasicDataInfo.CrdWarn)
                {
                    flagData.CrdWarn = machineBasicDataInfo.CrdWarn;
                    lowerMachineStatueData.CrdWarn = flagData.CrdWarn;
                    if (lowerMachineStatueData.CrdWarn)
                        showPromptForm = true;
                } 

                /*****************************************************************/
                if (flagData.SFLVoltWarn != machineBasicDataInfo.SFLVoltWarn)
                {
                    flagData.SFLVoltWarn = machineBasicDataInfo.SFLVoltWarn;
                    lowerMachineStatueData.SFLVoltWarn = flagData.SFLVoltWarn;
                    if(lowerMachineStatueData.SFLVoltWarn)
                        showPromptForm = true;
                }
                if (flagData.STLVoltWarn != machineBasicDataInfo.STLVoltWarn)
                {
                    flagData.STLVoltWarn = machineBasicDataInfo.STLVoltWarn;
                    lowerMachineStatueData.STLVoltWarn = flagData.STLVoltWarn;
                    if (lowerMachineStatueData.STLVoltWarn)
                        showPromptForm = true;
                }
                if (flagData.IOLVoltWarn != machineBasicDataInfo.IOLVoltWarn)
                {
                    flagData.IOLVoltWarn = machineBasicDataInfo.IOLVoltWarn;
                    lowerMachineStatueData.IOLVoltWarn = flagData.IOLVoltWarn;
                    if (lowerMachineStatueData.IOLVoltWarn)
                        showPromptForm = true;
                }
                if (flagData.SF_QepErrWarn != machineBasicDataInfo.SF_QepErrWarn)
                {
                    flagData.SF_QepErrWarn = machineBasicDataInfo.SF_QepErrWarn;
                    lowerMachineStatueData.SF_QepErrWarn = flagData.SF_QepErrWarn;
                    if (lowerMachineStatueData.SF_QepErrWarn)
                        showPromptForm = true;
                }
                if (flagData.SF_NoMotorWarn != machineBasicDataInfo.SF_NoMotorWarn)
                {
                    flagData.SF_NoMotorWarn = machineBasicDataInfo.SF_NoMotorWarn;
                    lowerMachineStatueData.SF_NoMotorWarn = flagData.SF_NoMotorWarn;
                    if (lowerMachineStatueData.SF_NoMotorWarn)
                        showPromptForm = true;
                }
                if (flagData.SF_OCurWarn != machineBasicDataInfo.SF_OCurWarn)
                {
                    flagData.SF_OCurWarn = machineBasicDataInfo.SF_OCurWarn;
                    lowerMachineStatueData.SF_OCurWarn = flagData.SF_OCurWarn;
                    if (lowerMachineStatueData.SF_OCurWarn)
                        showPromptForm = true;
                }
                if (flagData.SF_OLoadWarn != machineBasicDataInfo.SF_OLoadWarn)
                {
                    flagData.SF_OLoadWarn = machineBasicDataInfo.SF_OLoadWarn;
                    lowerMachineStatueData.SF_OLoadWarn = flagData.SF_OLoadWarn;
                    if (lowerMachineStatueData.SF_OLoadWarn)
                        showPromptForm = true;
                }
                if (flagData.SF_NoEcdWarn != machineBasicDataInfo.SF_NoEcdWarn)
                {
                    flagData.SF_NoEcdWarn = machineBasicDataInfo.SF_NoEcdWarn;
                    lowerMachineStatueData.SF_NoEcdWarn = flagData.SF_NoEcdWarn;
                    if (lowerMachineStatueData.SF_NoEcdWarn)
                        showPromptForm = true;
                }
                if (flagData.X_QepErrWarn != machineBasicDataInfo.X_QepErrWarn)
                {
                    flagData.X_QepErrWarn = machineBasicDataInfo.X_QepErrWarn;
                    lowerMachineStatueData.X_QepErrWarn = flagData.X_QepErrWarn;
                    if (lowerMachineStatueData.X_QepErrWarn)
                        showPromptForm = true;
                }
                if (flagData.X_OLoadWarn != machineBasicDataInfo.X_OLoadWarn)
                {
                    flagData.X_OLoadWarn = machineBasicDataInfo.X_OLoadWarn;
                    lowerMachineStatueData.X_OLoadWarn = flagData.X_OLoadWarn;
                    if (lowerMachineStatueData.X_OLoadWarn)
                        showPromptForm = true;
                }
                if (flagData.X_OCurWarn != machineBasicDataInfo.X_OCurWarn)
                {
                    flagData.X_OCurWarn = machineBasicDataInfo.X_OCurWarn;
                    lowerMachineStatueData.X_OCurWarn = flagData.X_OCurWarn;
                    if (lowerMachineStatueData.X_OCurWarn)
                        showPromptForm = true;
                }
                if (flagData.X_NoMotorWarn != machineBasicDataInfo.X_NoMotorWarn)
                {
                    flagData.X_NoMotorWarn = machineBasicDataInfo.X_NoMotorWarn;
                    lowerMachineStatueData.X_NoMotorWarn = flagData.X_NoMotorWarn;
                    if (lowerMachineStatueData.X_NoMotorWarn)
                        showPromptForm = true;
                }
                if (flagData.Y_QepErrWarn != machineBasicDataInfo.Y_QepErrWarn)
                {
                    flagData.Y_QepErrWarn = machineBasicDataInfo.Y_QepErrWarn;
                    lowerMachineStatueData.Y_QepErrWarn = flagData.Y_QepErrWarn;
                    if (lowerMachineStatueData.Y_QepErrWarn)
                        showPromptForm = true;
                }
                if (flagData.Y_OLoadWarn != machineBasicDataInfo.Y_OLoadWarn)
                {
                    flagData.Y_OLoadWarn = machineBasicDataInfo.Y_OLoadWarn;
                    lowerMachineStatueData.Y_OLoadWarn = flagData.Y_OLoadWarn;
                    if (lowerMachineStatueData.Y_OLoadWarn)
                        showPromptForm = true;
                }
                if (flagData.Y_OCurWarn != machineBasicDataInfo.Y_OCurWarn)
                {
                    flagData.Y_OCurWarn = machineBasicDataInfo.Y_OCurWarn;
                    lowerMachineStatueData.Y_OCurWarn = flagData.Y_OCurWarn;
                    if (lowerMachineStatueData.Y_OCurWarn)
                        showPromptForm = true;
                }
                if (flagData.Y_NoMotorWarn != machineBasicDataInfo.Y_NoMotorWarn)
                {
                    flagData.Y_NoMotorWarn = machineBasicDataInfo.Y_NoMotorWarn;
                    lowerMachineStatueData.Y_NoMotorWarn = flagData.Y_NoMotorWarn;
                    if (lowerMachineStatueData.Y_NoMotorWarn)
                        showPromptForm = true;
                }

                if (flagData.SysTimeOutWarn != machineBasicDataInfo.SysTimeOutWarn)
                {
                    flagData.SysTimeOutWarn = machineBasicDataInfo.SysTimeOutWarn;
                    lowerMachineStatueData.SysTimeOutWarn = flagData.SysTimeOutWarn;
                    if (lowerMachineStatueData.SysTimeOutWarn)
                        showPromptForm = true;
                }                

                if (flagData.UpperSensorErr != machineBasicDataInfo.takeClothUpperSensorErr)
                {
                    flagData.UpperSensorErr = machineBasicDataInfo.takeClothUpperSensorErr;
                    lowerMachineStatueData.UpperSensorErr = flagData.UpperSensorErr;
                    if (lowerMachineStatueData.UpperSensorErr)
                        showPromptForm = true;
                }
                if (flagData.UpperSensorErrL != machineBasicDataInfo.takeClothUpperSensorErrL)
                {
                    flagData.UpperSensorErrL = machineBasicDataInfo.takeClothUpperSensorErrL;
                    lowerMachineStatueData.UpperSensorErrL = flagData.UpperSensorErrL;
                    if (lowerMachineStatueData.UpperSensorErrL)
                        showPromptForm = true;
                }
                if (flagData.MidSensorErr != machineBasicDataInfo.takeClothMidSensorErr)
                {
                    flagData.MidSensorErr = machineBasicDataInfo.takeClothMidSensorErr;
                    lowerMachineStatueData.MidSensorErr = flagData.MidSensorErr;
                    if (lowerMachineStatueData.MidSensorErr)
                        showPromptForm = true;
                }
                if (flagData.MidSensorErrL != machineBasicDataInfo.takeClothMidSensorErrL)
                {
                    flagData.MidSensorErrL = machineBasicDataInfo.takeClothMidSensorErrL;
                    lowerMachineStatueData.MidSensorErrL = flagData.MidSensorErrL;
                    if (lowerMachineStatueData.MidSensorErrL)
                        showPromptForm = true;
                }
                if (flagData.DownSensorErr != machineBasicDataInfo.takeClothDownSensorErr)
                {
                    flagData.DownSensorErr = machineBasicDataInfo.takeClothDownSensorErr;
                    lowerMachineStatueData.DownSensorErr = flagData.DownSensorErr;
                    if (lowerMachineStatueData.DownSensorErr)
                        showPromptForm = true;
                }
                if (flagData.DownSensorErrL != machineBasicDataInfo.takeClothDownSensorErrL)
                {
                    flagData.DownSensorErrL = machineBasicDataInfo.takeClothDownSensorErrL;
                    lowerMachineStatueData.DownSensorErrL = flagData.DownSensorErrL;
                    if (lowerMachineStatueData.DownSensorErrL)
                        showPromptForm = true;
                }
                if (flagData.LeftSensorErr != machineBasicDataInfo.takeClothLeftSensorErr)
                {
                    flagData.LeftSensorErr = machineBasicDataInfo.takeClothLeftSensorErr;
                    lowerMachineStatueData.LeftSensorErr = flagData.LeftSensorErr;
                    if (lowerMachineStatueData.LeftSensorErr)
                        showPromptForm = true;
                }
                if (flagData.LeftSensorErrL != machineBasicDataInfo.takeClothLeftSensorErrL)
                {
                    flagData.LeftSensorErrL = machineBasicDataInfo.takeClothLeftSensorErrL;
                    lowerMachineStatueData.LeftSensorErrL = flagData.LeftSensorErrL;
                    if (lowerMachineStatueData.LeftSensorErrL)
                        showPromptForm = true;
                }
                if (flagData.RightSensorErr != machineBasicDataInfo.takeClothRightSensorErr)
                {
                    flagData.RightSensorErr = machineBasicDataInfo.takeClothRightSensorErr;
                    lowerMachineStatueData.RightSensorErr = flagData.RightSensorErr;
                    if (lowerMachineStatueData.RightSensorErr)
                        showPromptForm = true;
                }
                if (flagData.RightSensorErrL != machineBasicDataInfo.takeClothRightSensorErrL)
                {
                    flagData.RightSensorErrL = machineBasicDataInfo.takeClothRightSensorErrL;
                    lowerMachineStatueData.RightSensorErrL = flagData.RightSensorErrL;
                    if (lowerMachineStatueData.RightSensorErrL)
                        showPromptForm = true;
                }
                if (flagData.XSensorErr != machineBasicDataInfo.xBackToZeroSensorErr)
                {
                    flagData.XSensorErr = machineBasicDataInfo.xBackToZeroSensorErr;
                    lowerMachineStatueData.XSensorErr = flagData.XSensorErr;
                    if (lowerMachineStatueData.XSensorErr)
                        showPromptForm = true;
                }
                if (flagData.YoSensorErr != machineBasicDataInfo.yBackToZeroSensorErr)
                {
                    flagData.YoSensorErr = machineBasicDataInfo.yBackToZeroSensorErr;
                    lowerMachineStatueData.YSensorErr = flagData.YoSensorErr;
                    if (lowerMachineStatueData.YSensorErr)
                        showPromptForm = true;
                }
                if (flagData.ServoSensorErr != machineBasicDataInfo.servoBackToZeroSensorErr)
                {
                    flagData.ServoSensorErr = machineBasicDataInfo.servoBackToZeroSensorErr;
                    lowerMachineStatueData.ServoSensorErr = flagData.ServoSensorErr;
                    if (lowerMachineStatueData.ServoSensorErr)
                        showPromptForm = true;
                }
                if (flagData.SysRePowerWarn != machineBasicDataInfo.SysRePowerWarn)
                {
                    flagData.SysRePowerWarn = machineBasicDataInfo.SysRePowerWarn;
                    lowerMachineStatueData.SysRePowerWarn = flagData.SysRePowerWarn;
                    if (lowerMachineStatueData.SysRePowerWarn)
                        showPromptForm = true;
                }



                if (flagData.Working != false)
                {
                    flagData.Working = false;
                    lowerMachineStatueData.Working = flagData.Working;
                }
                lowerMachineStatueData.SetWarnValue(0);
                if (lowerMachineStatueData.HaveWarnInfo)
                    showPromptForm = true;
                if (machineBasicDataInfo.ErrorOccur)//有错误发生
                    lowerMachineStatueData.ErrorValue = machineBasicDataInfo.ErrorValue;


                if (machineBasicDataInfo.StReqstData)//请求花型数据
                {
                    //ToDo:强制发21花型参数
                    ScreenStatueData.ScreenStatueDataEX.SendDesignFlag = true;
                }
                if (machineBasicDataInfo.ReciveGroupIndex != 0)//请求包序
                {
                    //ToDo:强制发27 坐标
                    ScreenStatueData.patternIndex = machineBasicDataInfo.ReciveGroupIndex;
                    SerialDataManager.FlowFlag = true;
                }

                if (ClockSta != MenuFormManager.IsLocked)
                {
                    ClockSta = MenuFormManager.IsLocked;
                    if (ClockSta == 1)
                    {
                        MenuFormManager.IsShowLockMsg = true;
                        MenuFormManager.showPF_En = false;
                        showPromptForm = true;

                        Thread T = new Thread(ShowHitForm);
                        T.Start();
                    }                    
                }
            }
            else if (e.LowerDataType == LowerDataType.ErrorDataType)
            {
                ErrorDataInfo errorDataInfo = e.LowerDataInfo as ErrorDataInfo;
                lowerMachineStatueData.ErrorInfo = errorDataInfo.GetErrorInfo();
                showPromptForm = true;
            }
            else if (e.LowerDataType == LowerDataType.CommunicatError)
            {
                lowerMachineStatueData.CommunicationWarn = true;
                showPromptForm = true;
            }
            else if (e.LowerDataType == LowerDataType.VersionDataType)
            {
                VersionDataInfo versionDataInfo = e.LowerDataInfo as VersionDataInfo;

            }
            else if (e.LowerDataType == LowerDataType.ServoDataType)
            {
                ServoDataInfo servoDataInfo = e.LowerDataInfo as ServoDataInfo;
                if (flagData == null)
                    flagData = new MainFormFlagData();
                if (flagData.Working != servoDataInfo.Working)
                {
                    flagData.Working = servoDataInfo.Working;
                    lowerMachineStatueData.Working = flagData.Working;
                }
                if (flagData.CascadeOver != servoDataInfo.CascadeOver)
                {
                    flagData.CascadeOver = servoDataInfo.CascadeOver;
                    lowerMachineStatueData.CascadeOver = servoDataInfo.CascadeOver;
                }
            }
            else if (e.LowerDataType == LowerDataType.LowerSingleStepInfoType)
            {
                LowerSingleStepInfo lowerSingleStepInfo = e.LowerDataInfo as LowerSingleStepInfo;

                if (flagData.ReachesPositionWarn != lowerSingleStepInfo.ReachasPositionWarn)
                {
                    flagData.ReachesPositionWarn = lowerSingleStepInfo.ReachasPositionWarn;
                    lowerMachineStatueData.ReachesPositionWarn = lowerSingleStepInfo.ReachasPositionWarn;
                }
            }

            if (showPromptForm == true && MenuFormManager.showPF_En == true)
            {
                showPromptForm = false;
                ShowPromptForm();
            }
        }

        void WarnForm_FormHide()
        {
            ShowPromptForm();
            picShapeImage.Invalidate();
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
            else if (sender is Label)
            {
                Label label = sender as Label;
                label.Text = text;
            }
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            bool warn_Sig = false;

            if (ShowWarnForm("Setting")) //运行情况下不能按。
                return;

            if (MenuForm == null)
                MenuForm = new Menu(this);

            if (warnForm.HaveWarnMsg) { warnForm.Visible = false; warn_Sig = true; MenuFormManager.showPF_En = false; }
            InitCollingStepMode(false);

            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MenuForm;
            MenuForm.ShowDialog();
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MainFormMode;

            if (warn_Sig) { warnForm.Visible = true; warn_Sig = false; MenuFormManager.showPF_En = true; }
        }

        public void lbEdit_Click(object sender, EventArgs e)
        {
            bool warn_Sig = false;
            if (ShowWarnForm("Setting"))
                return;
            SerialDataManager.Feedback -= new FeedbackEventHandle(SerialDataManager_Feedback);

            if (warnForm.HaveWarnMsg) { warnForm.Visible = false; warn_Sig = true; MenuFormManager.showPF_En = false; }
            InitCollingStepMode(false);
            if (editForm == null)
                editForm = new EditForm();
  
            editForm.ShouldPadShapeInfo = mainFormManager.ShouldPadShapeInfo; //传入加布和点坐标
            InitCollingStepMode(false);
            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.EditFormMode;
            editForm.ShowDialog();

            ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MainFormMode;
            mainFormManager.SetShouldPadShapeInfo(editForm.ShouldPadShapeInfo, true);
            lblTotalNeedleNumber.Text = mainFormManager.TotalNumber.ToString();
            mainFormManager.LoadSizeRadio(MappingSize.MappingSizeEx.ScreenSize);
            mainFormManager.LoadShouldPadImage();
            SerialDataManager.Feedback += new FeedbackEventHandle(SerialDataManager_Feedback);
            picShapeImage.Image = mainFormManager.GetShapeImage();
            if (warn_Sig) { warnForm.Visible = true; warn_Sig = false; MenuFormManager.showPF_En = true; }
        }

        private void ShowHitForm_f()
        {
            HitForm hitForm = new HitForm();
            hitForm.ShowDialog();
        }

        private void ShowHitForm()
        {
            this.Invoke(new MessageBoxShowReCall(ShowHitForm_f), null);
        } 

        private void ShowPromptForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new NoValueEventHandle(ShowPromptForm));
                return;
            }
            LowerMachineStatueData lowerMachineStatueData = LowerMachineStatueData.LowerMachineStatueDateEx;
            
            if (lowerMachineStatueData.HaveWarnInfo)
            {
                if (machineWarnForm == null)
                    machineWarnForm = new MachineWarnForm();
                if (!machineWarnForm.Visible)
                {
                    lowerMachineStatueData.HaveWarnInfo = false;
                    int index = lowerMachineStatueData.WarnID;
                    MachineInfoManager machineInfoManager = new MachineInfoManager();
                    String language = machineInfoManager.GetMachineInfoValue(MachineInfoEnum.UseLanguage);
                    LanguageLibrary languageLibrary = new LanguageLibrary(language);
                    String[] warnStrings = languageLibrary.WarnStrings;
                    String warnString = String.Empty;
                    if (index > warnStrings.Length || index == 0)
                        warnString = warnStrings[0];
                    else
                        warnString = warnStrings[index - 1];
                    machineWarnForm.SetWarnText(warnString, index.ToString());
                    machineWarnForm.Show();
                }
            }
            if (machineWarnForm == null || !machineWarnForm.Visible)
            {
                if (lowerMachineStatueData.ErrorInfo != null)
                    lowerMachineStatueData.ErrorInfo = null;

                if (warnForm.HaveWarnMsg == false)
                {
                    WarnType warnType = WarnType.Null;
                    if (lowerMachineStatueData.CommunicationWarn)
                    {
                        lowerMachineStatueData.CommunicationWarn = false;
                        if (ScreenStatueData.ScreenStatueDataEX.InterfaceMode != InterfaceMode.MainFormMode)
                            warnType = WarnType.Null;
                        else
                            warnType = WarnType.CommunicationError;                        
                    }
                    else if (lowerMachineStatueData.ModeSwitchWarn)
                        warnType = WarnType.ModeSwitchWarn;
                    else if (lowerMachineStatueData.LineBreakWarn)
                        warnType = WarnType.LineBreakWarn;
                    else if (lowerMachineStatueData.WorkedNumberOverflowWarn)
                        warnType = WarnType.WorkedNumberOverflowWarn;
                    else if (lowerMachineStatueData.TotalWorkedNumberOverflowWarn)
                        warnType = WarnType.TotalWorkedNumberOverflowWarn;
                    else if (lowerMachineStatueData.CrdWarn)
                        warnType = WarnType.CrdWarn;

                    /************************************************************************/
                    else if (lowerMachineStatueData.SFLVoltWarn)
                        warnType = WarnType.SFLVoltWarn;
                    else if (lowerMachineStatueData.STLVoltWarn)
                        warnType = WarnType.STLVoltWarn;
                    else if (lowerMachineStatueData.IOLVoltWarn)
                        warnType = WarnType.IOLVoltWarn;
                    else if (lowerMachineStatueData.SF_NoEcdWarn)
                        warnType = WarnType.SF_NoEcdWarn;
                    else if (lowerMachineStatueData.SF_NoMotorWarn)
                        warnType = WarnType.SF_NoMotorWarn;
                    else if (lowerMachineStatueData.SF_QepErrWarn)
                        warnType = WarnType.SF_QepErrWarn;
                    else if (lowerMachineStatueData.SF_OLoadWarn)
                        warnType = WarnType.SF_OLoadWarn;
                    else if (lowerMachineStatueData.SF_OCurWarn)
                        warnType = WarnType.SF_OCurWarn;

                    else if (lowerMachineStatueData.X_NoMotorWarn)
                        warnType = WarnType.X_NoMotorWarn;
                    else if (lowerMachineStatueData.X_QepErrWarn)
                        warnType = WarnType.X_QepErrWarn;
                    else if (lowerMachineStatueData.X_OLoadWarn)
                        warnType = WarnType.X_OLoadWarn;
                    else if (lowerMachineStatueData.X_OCurWarn)
                        warnType = WarnType.X_OCurWarn;

                    else if (lowerMachineStatueData.Y_NoMotorWarn)
                        warnType = WarnType.Y_NoMotorWarn;
                    else if (lowerMachineStatueData.Y_QepErrWarn)
                        warnType = WarnType.Y_QepErrWarn;
                    else if (lowerMachineStatueData.Y_OLoadWarn)
                        warnType = WarnType.Y_OLoadWarn;
                    else if (lowerMachineStatueData.Y_OCurWarn)
                        warnType = WarnType.Y_OCurWarn;
                    

                    else if (lowerMachineStatueData.SysTimeOutWarn)
                        warnType = WarnType.SysTimeOutWarn;

                    else if (lowerMachineStatueData.UpperSensorErr)
                        warnType = WarnType.UpperSensorErr;
                    else if (lowerMachineStatueData.MidSensorErr)
                        warnType = WarnType.MidSensorErr;
                    else if (lowerMachineStatueData.DownSensorErr)
                        warnType = WarnType.DownSensorErr;
                    else if (lowerMachineStatueData.LeftSensorErr)
                        warnType = WarnType.LeftSensorErr;
                    else if (lowerMachineStatueData.RightSensorErr)
                        warnType = WarnType.RightSensorErr;

                    else if (lowerMachineStatueData.UpperSensorErrL)
                        warnType = WarnType.UpperSensorErrL;
                    else if (lowerMachineStatueData.MidSensorErrL)
                        warnType = WarnType.MidSensorErrL;
                    else if (lowerMachineStatueData.DownSensorErrL)
                        warnType = WarnType.DownSensorErrL;
                    else if (lowerMachineStatueData.LeftSensorErrL)
                        warnType = WarnType.LeftSensorErrL;
                    else if (lowerMachineStatueData.RightSensorErrL)
                        warnType = WarnType.RightSensorErrL;

                    else if (lowerMachineStatueData.XSensorErr)
                        warnType = WarnType.XSensorErr;
                    else if (lowerMachineStatueData.YSensorErr)
                        warnType = WarnType.YSensorErr;
                    else if (lowerMachineStatueData.ServoSensorErr)
                        warnType = WarnType.ServoSensorErr;
                    else if (lowerMachineStatueData.SysRePowerWarn)
                        warnType = WarnType.SysRePowerErr;

                    if (warnType != WarnType.Null)
                    {
                        warnForm.HaveWarnMsg = true;
                        warnForm.WarnType = warnType;
                        warnForm.Show();
                    } 
                }
            }

        }

        private void FileName_Click(object sender, EventArgs e)
        {
            DataButton TmpdataButton = sender as DataButton;
            String buttonInfo = String.Empty;
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();

            buttonInfo = TmpdataButton.Tag.ToString();
            if (ShowWarnForm(buttonInfo))
                return; 

            EncryptionForm encryptionForm = new EncryptionForm();

            encryptionForm.InitStrNum = "0";
            encryptionForm.MaxValue = 999999;
            encryptionForm.MinValue=0;
            encryptionForm.PointButtonEnable = false;
            encryptionForm.MinusButtonEnable = false;
            encryptionForm.ShowDialog();
            string EncryStr = encryptionForm.LastNumber.ToString();
            encryptionForm.Dispose();

            if (EncryStr == "4321")
            {
                DataButton dataButton = sender as DataButton;
                DataInfo dataInfo = dataButton.ButtonDataInfo;
                if (dataInfo == null)
                    dataInfo = new DataInfo();
                Ninecalculator = new NineKeyboardForm();
                Ninecalculator.InitStrNum = dataButton.Text;
                Ninecalculator.ShowDialog();

                string NineStr = Ninecalculator.LastNumber;
                Ninecalculator.Dispose();

                dataButton.HasClick = true;
                if (NineStr != dataButton.Text)
                {                    
                    if (dataButton.BaseDataElement == MachineBaseDataEnum.ID)
                    {
                        if (NineStr == "BaseData" || NineStr == "FlowXml" || NineStr == "InOutData")
                            return;
                        dataButton.Text = NineStr;
                        InitCollingStepMode(false);
                        ScreenStatueData.ScreenStatueDataEX.NormalSpeedChanged = true;

                        mainFormManager.UpdataShouldDatas(NineStr);

                        lblLimitWorkedNumber.Text = shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.ClothNumberLimit).ToString();
                        lblLimitWorkedNumber.HasClick = true;

                        mainFormManager.LoadShouldPadImage();             //载入花型点图像
                        lblTotalNeedleNumber.Text = mainFormManager.TotalNumber.ToString();
                        picShapeImage.Image = mainFormManager.GetShapeImage();
                        btnNormalSpeed.FreshEnable = true;
                    }
                    else
                        dataButton.Text = Ninecalculator.LastNumber;
                }                
            }            
        }

        private void DataButton2_Click(object sender, EventArgs e)
        {
            DataButton TmpdataButton = sender as DataButton;
            String buttonInfo = String.Empty;
            buttonInfo = TmpdataButton.Tag.ToString();
            if (ShowWarnForm(buttonInfo))
                return;

            EncryptionForm encryptionForm = new EncryptionForm();

            encryptionForm.InitStrNum = "0";
            encryptionForm.MaxValue = 999999;
            encryptionForm.MinValue=0;
            encryptionForm.PointButtonEnable = false;
            encryptionForm.MinusButtonEnable = false;
            encryptionForm.ShowDialog();
            if (encryptionForm.LastNumber.ToString() == "4321")
            {

                DataButton dataButton = sender as DataButton;
                DataInfo dataInfo = dataButton.ButtonDataInfo;
                if (dataInfo == null)
                    dataInfo = new DataInfo();
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
                    if (dataButton.ShouldPadDataEnum == ShouldPadDataEnum.NormalSpeed)
                    {
                        dataButton.Text = calculator.LastNumber.ToString();
                       // NormalSpeed = int.Parse(calculator.LastNumber.ToString());
                    }
                    else
                        dataButton.Text = calculator.LastNumber.ToString();

                    if (dataButton.BaseDataElement == MachineBaseDataEnum.ID)
                    {
                        InitCollingStepMode(false);
                        mainFormManager.UpdataShouldDatas(calculator.LastNumber.ToString());
                        mainFormManager.LoadShouldPadImage();
                        lblTotalNeedleNumber.Text = mainFormManager.TotalNumber.ToString();
                        picShapeImage.Image = mainFormManager.GetShapeImage();
                    }
                }
                calculator.Dispose();
            }
            encryptionForm.Dispose();
        }

        private void DataButton_Click(object sender, EventArgs e)
        {
            DataButton dataButton = sender as DataButton;
            DataInfo dataInfo = dataButton.ButtonDataInfo;
            if (dataInfo == null)
                dataInfo = new DataInfo();
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
                if (dataButton.BaseDataElement == MachineBaseDataEnum.ID)
                {
                    InitCollingStepMode(false);
                    mainFormManager.UpdataShouldDatas(calculator.LastNumber.ToString());
                    mainFormManager.LoadShouldPadImage();
                    lblTotalNeedleNumber.Text = mainFormManager.TotalNumber.ToString();
                    picShapeImage.Image = mainFormManager.GetShapeImage();
                }
            }
            calculator.Dispose();
        }

        private bool ShowWarnForm(String relateData)
        {
            bool flag = false;
            if (ScreenStatueData.ScreenStatueDataEX.ScreenButtonEnable == false)
                flag = true;
            if (relateData.IndexOf("unTouch") != -1) //花型文件ID 按钮 在运布模块在预备状态 缝纫装置不在工作状态才能按下
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.WorkedStatue == WorkedStatue.WorkingStatue || LowerMachineStatueData.LowerMachineStatueDateEx.SendClothStatue == 2)
                    flag = true;
            }
            if (relateData.IndexOf("Setting") != -1)//花型编辑 菜单按钮 在运布模块在预备状态 缝纫装置不在工作状态才能按下  且不在单步缝纫界面下
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.WorkedStatue == WorkedStatue.WorkingStatue || LowerMachineStatueData.LowerMachineStatueDateEx.SendClothStatue == 2 || ScreenStatueData.ScreenStatueDataEX.InterfaceMode == InterfaceMode.SingleStepMode)
                    flag = true;
            }
            if (relateData.IndexOf("SingleStepSwitch") != -1)  //单步模式按钮 仅在缝纫和运布模块都在预备状态下才能按下
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.WorkedStatue != WorkedStatue.WaitToStartStatue || LowerMachineStatueData.LowerMachineStatueDateEx.SendClothStatue != 1)
                    flag = true;
            }

            if (relateData.IndexOf("SingleStepButton") != -1)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.SingleStepStatue == false) //单步模块处在等待按键信号状态
                    flag = true;
            }

            return flag;
        }

        private void swAuto_Click(object sender, EventArgs e)
        {
            ImgSwitch swBtn = sender as ImgSwitch;

            swBtn.SwitchClick();
            ScreenStatueData.ScreenStatueDataEX.AutoEnable = swBtn.IsCheck;
        }

        private void InitCollingStepMode(bool flag)
        {
            swSingleStep.IsCheck = flag;
            mainFormManager.SingleStepSwitch(flag);
            btnMovePrevious.Visible = flag;
            btnMoveNext.Visible = flag;
            picShapeImage.Image = mainFormManager.GetShapeImage();
            swSingleStep.Invalidate();
        }

        private void SingleStep_Click(object sender, EventArgs e)
        {
            ImgSwitch imageButton = sender as ImgSwitch;

            if (imageButton.IsCheck == false)
            {
                if (ShowWarnForm("SingleStepSwitch"))
                    return;
                InitCollingStepMode(true);
            }
            else
                InitCollingStepMode(false);            
        }

        private void Direction_Click(object sender, EventArgs e)
        {
            ImgBtn imageButton = sender as ImgBtn;
  
            if (ShowWarnForm("SingleStepButton"))
                return;

            String directName = imageButton.Name;
            directName = directName.Remove(0, 3);
            if (directName == "MovePrevious")
            {
                //强制发28 屏幕按键
                SerialDataManager.ScreenButton = true;

                ScreenStatueData.ScreenStatueDataEX.BackwardNeedle = true;
            }
            else 
            {
                SerialDataManager.ScreenButton = true;
                ScreenStatueData.ScreenStatueDataEX.ForwardNeedle = true;
            }

            mainFormManager.MoveDitection(directName);
            lblWorkNeedleNumber.Text = mainFormManager.SelectPointIndex.ToString(); //显示针数
            picShapeImage.Image = mainFormManager.GetShapeImage();                  //获取新的位图 根据SelectPointIndex
        }

        private void ClearWorkedNumber_Click(object sender, EventArgs e)
        {
            DialogResultEx dialogResultEx = MessageBoxEX.Show("确定要件数清零？",MessageBoxButtonType.YesCancel);
            if (dialogResultEx == DialogResultEx.Yes)
            {
                ScreenStatueData.ScreenStatueDataEX.ClearWorkNumber = true;
                DataButton dataButton = sender as DataButton;
                object tag = dataButton.Tag;
                if (tag != null)
                    ScreenStatueData.ScreenStatueDataEX.ClearNumberID = Convert.ToByte(tag.ToString());
                dataButton.Text = "0";

                MachineBaseDataDAO baseDataDAO = new MachineBaseDataDAO();
                if (baseDataDAO.GetDataBaseValue(MachineBaseDataEnum.ProductCount) != 0)       //清零屏上保存的已生产件数
                    baseDataDAO.SetDataBaseValue(MachineBaseDataEnum.ProductCount, 0);  
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