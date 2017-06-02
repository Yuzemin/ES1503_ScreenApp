using ShouldPadMachine.ShouldPadMachineCTL;
namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class TestForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.BackImage = new System.Windows.Forms.PictureBox();
            this.IOVolt = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.SFhallValue = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.SFCode = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.YstepCode = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.XstepCode = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.btnCarrySensorRight = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnCarrySensorLeft = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnClampSensorUp = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnClampSensorMid = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnClampSensorLower = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnRedKey2 = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnSFSensor = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnGreenKey2 = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnGreenKey1 = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnRedKey1 = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnYSensor = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.btnXSensor = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.ibTestReturn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibCut = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.ibBlow = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.ibClamp = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.ibCarry = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.ibPressure = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.ibCatch = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.SuspendLayout();
            // 
            // BackImage
            // 
            this.BackImage.Image = ((System.Drawing.Image)(resources.GetObject("BackImage.Image")));
            this.BackImage.Location = new System.Drawing.Point(0, 0);
            this.BackImage.Name = "BackImage";
            this.BackImage.Size = new System.Drawing.Size(800, 480);
            // 
            // IOVolt
            // 
            this.IOVolt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.IOVolt.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.IOVolt.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.IOVolt.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.IOVolt.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.IOVolt.FrameColor = System.Drawing.Color.Empty;
            this.IOVolt.HasClick = false;
            this.IOVolt.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.IOVolt.Location = new System.Drawing.Point(542, 216);
            this.IOVolt.Name = "IOVolt";
            this.IOVolt.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.IOVolt.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.IOVolt.Size = new System.Drawing.Size(76, 38);
            this.IOVolt.Text = "0";
            // 
            // SFhallValue
            // 
            this.SFhallValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.SFhallValue.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.SFhallValue.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.SFhallValue.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.SFhallValue.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.SFhallValue.FrameColor = System.Drawing.Color.Empty;
            this.SFhallValue.HasClick = false;
            this.SFhallValue.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.SFhallValue.Location = new System.Drawing.Point(655, 142);
            this.SFhallValue.Name = "SFhallValue";
            this.SFhallValue.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.SFhallValue.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.SFhallValue.Size = new System.Drawing.Size(76, 38);
            this.SFhallValue.Text = "0";
            // 
            // SFCode
            // 
            this.SFCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.SFCode.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.SFCode.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.SFCode.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.SFCode.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.SFCode.FrameColor = System.Drawing.Color.Empty;
            this.SFCode.HasClick = false;
            this.SFCode.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.SFCode.Location = new System.Drawing.Point(542, 142);
            this.SFCode.Name = "SFCode";
            this.SFCode.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.SFCode.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.SFCode.Size = new System.Drawing.Size(76, 38);
            this.SFCode.Text = "0";
            // 
            // YstepCode
            // 
            this.YstepCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.YstepCode.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.YstepCode.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.YstepCode.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.YstepCode.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.YstepCode.FrameColor = System.Drawing.Color.Empty;
            this.YstepCode.HasClick = false;
            this.YstepCode.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.YstepCode.Location = new System.Drawing.Point(655, 68);
            this.YstepCode.Name = "YstepCode";
            this.YstepCode.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.YstepCode.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.YstepCode.Size = new System.Drawing.Size(76, 38);
            this.YstepCode.Text = "0";
            // 
            // XstepCode
            // 
            this.XstepCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.XstepCode.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.XstepCode.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.XstepCode.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.XstepCode.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.XstepCode.FrameColor = System.Drawing.Color.Empty;
            this.XstepCode.HasClick = false;
            this.XstepCode.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.XstepCode.Location = new System.Drawing.Point(542, 68);
            this.XstepCode.Name = "XstepCode";
            this.XstepCode.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.XstepCode.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.XstepCode.Size = new System.Drawing.Size(76, 38);
            this.XstepCode.Text = "0";
            // 
            // btnCarrySensorRight
            // 
            this.btnCarrySensorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnCarrySensorRight.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnCarrySensorRight.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnCarrySensorRight.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnCarrySensorRight.ForeColor = System.Drawing.Color.Black;
            this.btnCarrySensorRight.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnCarrySensorRight.FramePressColor = System.Drawing.Color.Empty;
            this.btnCarrySensorRight.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnCarrySensorRight.Location = new System.Drawing.Point(290, 216);
            this.btnCarrySensorRight.Name = "btnCarrySensorRight";
            this.btnCarrySensorRight.Size = new System.Drawing.Size(76, 38);
            this.btnCarrySensorRight.TabIndex = 14;
            this.btnCarrySensorRight.Text = "OFF";
            // 
            // btnCarrySensorLeft
            // 
            this.btnCarrySensorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnCarrySensorLeft.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnCarrySensorLeft.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnCarrySensorLeft.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnCarrySensorLeft.ForeColor = System.Drawing.Color.Black;
            this.btnCarrySensorLeft.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnCarrySensorLeft.FramePressColor = System.Drawing.Color.Empty;
            this.btnCarrySensorLeft.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnCarrySensorLeft.Location = new System.Drawing.Point(290, 142);
            this.btnCarrySensorLeft.Name = "btnCarrySensorLeft";
            this.btnCarrySensorLeft.Size = new System.Drawing.Size(76, 38);
            this.btnCarrySensorLeft.TabIndex = 13;
            this.btnCarrySensorLeft.Text = "OFF";
            // 
            // btnClampSensorUp
            // 
            this.btnClampSensorUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnClampSensorUp.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnClampSensorUp.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnClampSensorUp.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnClampSensorUp.ForeColor = System.Drawing.Color.Black;
            this.btnClampSensorUp.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnClampSensorUp.FramePressColor = System.Drawing.Color.Empty;
            this.btnClampSensorUp.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnClampSensorUp.Location = new System.Drawing.Point(401, 68);
            this.btnClampSensorUp.Name = "btnClampSensorUp";
            this.btnClampSensorUp.Size = new System.Drawing.Size(76, 38);
            this.btnClampSensorUp.TabIndex = 12;
            this.btnClampSensorUp.Text = "OFF";
            // 
            // btnClampSensorMid
            // 
            this.btnClampSensorMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnClampSensorMid.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnClampSensorMid.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnClampSensorMid.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnClampSensorMid.ForeColor = System.Drawing.Color.Black;
            this.btnClampSensorMid.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnClampSensorMid.FramePressColor = System.Drawing.Color.Empty;
            this.btnClampSensorMid.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnClampSensorMid.Location = new System.Drawing.Point(401, 142);
            this.btnClampSensorMid.Name = "btnClampSensorMid";
            this.btnClampSensorMid.Size = new System.Drawing.Size(76, 38);
            this.btnClampSensorMid.TabIndex = 11;
            this.btnClampSensorMid.Text = "OFF";
            // 
            // btnClampSensorLower
            // 
            this.btnClampSensorLower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnClampSensorLower.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnClampSensorLower.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnClampSensorLower.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnClampSensorLower.ForeColor = System.Drawing.Color.Black;
            this.btnClampSensorLower.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnClampSensorLower.FramePressColor = System.Drawing.Color.Empty;
            this.btnClampSensorLower.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnClampSensorLower.Location = new System.Drawing.Point(401, 216);
            this.btnClampSensorLower.Name = "btnClampSensorLower";
            this.btnClampSensorLower.Size = new System.Drawing.Size(76, 38);
            this.btnClampSensorLower.TabIndex = 10;
            this.btnClampSensorLower.Text = "OFF";
            // 
            // btnRedKey2
            // 
            this.btnRedKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnRedKey2.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnRedKey2.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnRedKey2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnRedKey2.ForeColor = System.Drawing.Color.Black;
            this.btnRedKey2.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnRedKey2.FramePressColor = System.Drawing.Color.Empty;
            this.btnRedKey2.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnRedKey2.Location = new System.Drawing.Point(180, 216);
            this.btnRedKey2.Name = "btnRedKey2";
            this.btnRedKey2.Size = new System.Drawing.Size(76, 38);
            this.btnRedKey2.TabIndex = 9;
            this.btnRedKey2.Text = "OFF";
            // 
            // btnSFSensor
            // 
            this.btnSFSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnSFSensor.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnSFSensor.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnSFSensor.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnSFSensor.ForeColor = System.Drawing.Color.Black;
            this.btnSFSensor.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnSFSensor.FramePressColor = System.Drawing.Color.Empty;
            this.btnSFSensor.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnSFSensor.Location = new System.Drawing.Point(290, 68);
            this.btnSFSensor.Name = "btnSFSensor";
            this.btnSFSensor.Size = new System.Drawing.Size(76, 38);
            this.btnSFSensor.TabIndex = 7;
            this.btnSFSensor.Text = "OFF";
            // 
            // btnGreenKey2
            // 
            this.btnGreenKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnGreenKey2.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnGreenKey2.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnGreenKey2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnGreenKey2.ForeColor = System.Drawing.Color.Black;
            this.btnGreenKey2.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnGreenKey2.FramePressColor = System.Drawing.Color.Empty;
            this.btnGreenKey2.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnGreenKey2.Location = new System.Drawing.Point(69, 216);
            this.btnGreenKey2.Name = "btnGreenKey2";
            this.btnGreenKey2.Size = new System.Drawing.Size(76, 38);
            this.btnGreenKey2.TabIndex = 2;
            this.btnGreenKey2.Text = "OFF";
            // 
            // btnGreenKey1
            // 
            this.btnGreenKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnGreenKey1.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnGreenKey1.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnGreenKey1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnGreenKey1.ForeColor = System.Drawing.Color.Black;
            this.btnGreenKey1.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnGreenKey1.FramePressColor = System.Drawing.Color.Empty;
            this.btnGreenKey1.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnGreenKey1.Location = new System.Drawing.Point(69, 142);
            this.btnGreenKey1.Name = "btnGreenKey1";
            this.btnGreenKey1.Size = new System.Drawing.Size(76, 38);
            this.btnGreenKey1.TabIndex = 2;
            this.btnGreenKey1.Text = "OFF";
            // 
            // btnRedKey1
            // 
            this.btnRedKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnRedKey1.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnRedKey1.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnRedKey1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnRedKey1.ForeColor = System.Drawing.Color.Black;
            this.btnRedKey1.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnRedKey1.FramePressColor = System.Drawing.Color.Empty;
            this.btnRedKey1.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnRedKey1.Location = new System.Drawing.Point(180, 142);
            this.btnRedKey1.Name = "btnRedKey1";
            this.btnRedKey1.Size = new System.Drawing.Size(76, 38);
            this.btnRedKey1.TabIndex = 2;
            this.btnRedKey1.Text = "OFF";
            // 
            // btnYSensor
            // 
            this.btnYSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnYSensor.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnYSensor.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnYSensor.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnYSensor.ForeColor = System.Drawing.Color.Black;
            this.btnYSensor.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnYSensor.FramePressColor = System.Drawing.Color.Empty;
            this.btnYSensor.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnYSensor.Location = new System.Drawing.Point(180, 68);
            this.btnYSensor.Name = "btnYSensor";
            this.btnYSensor.Size = new System.Drawing.Size(76, 38);
            this.btnYSensor.TabIndex = 2;
            this.btnYSensor.Text = "OFF";
            // 
            // btnXSensor
            // 
            this.btnXSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnXSensor.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.btnXSensor.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.btnXSensor.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.btnXSensor.ForeColor = System.Drawing.Color.Black;
            this.btnXSensor.FrameNoramlColor = System.Drawing.Color.Empty;
            this.btnXSensor.FramePressColor = System.Drawing.Color.Empty;
            this.btnXSensor.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.btnXSensor.Location = new System.Drawing.Point(69, 68);
            this.btnXSensor.Name = "btnXSensor";
            this.btnXSensor.Size = new System.Drawing.Size(76, 38);
            this.btnXSensor.TabIndex = 2;
            this.btnXSensor.Text = "OFF";
            // 
            // ibTestReturn
            // 
            this.ibTestReturn.BackColor = System.Drawing.Color.Black;
            this.ibTestReturn.Location = new System.Drawing.Point(612, 394);
            this.ibTestReturn.Name = "ibTestReturn";
            this.ibTestReturn.Size = new System.Drawing.Size(120, 45);
            this.ibTestReturn.TabIndex = 16;
            this.ibTestReturn.Click += new System.EventHandler(this.Return_Click);
            this.ibTestReturn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibTestReturn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibCut
            // 
            this.ibCut.BackColor = System.Drawing.Color.Transparent;
            this.ibCut.IsCheck = false;
            this.ibCut.Location = new System.Drawing.Point(68, 322);
            this.ibCut.Name = "ibCut";
            this.ibCut.Size = new System.Drawing.Size(120, 45);
            this.ibCut.TabIndex = 23;
            this.ibCut.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // ibBlow
            // 
            this.ibBlow.BackColor = System.Drawing.Color.Transparent;
            this.ibBlow.IsCheck = false;
            this.ibBlow.Location = new System.Drawing.Point(213, 322);
            this.ibBlow.Name = "ibBlow";
            this.ibBlow.Size = new System.Drawing.Size(120, 45);
            this.ibBlow.TabIndex = 24;
            this.ibBlow.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // ibClamp
            // 
            this.ibClamp.BackColor = System.Drawing.Color.Transparent;
            this.ibClamp.IsCheck = false;
            this.ibClamp.Location = new System.Drawing.Point(358, 322);
            this.ibClamp.Name = "ibClamp";
            this.ibClamp.Size = new System.Drawing.Size(120, 45);
            this.ibClamp.TabIndex = 25;
            this.ibClamp.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // ibCarry
            // 
            this.ibCarry.BackColor = System.Drawing.Color.Transparent;
            this.ibCarry.IsCheck = false;
            this.ibCarry.Location = new System.Drawing.Point(68, 394);
            this.ibCarry.Name = "ibCarry";
            this.ibCarry.Size = new System.Drawing.Size(120, 45);
            this.ibCarry.TabIndex = 26;
            this.ibCarry.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // ibPressure
            // 
            this.ibPressure.BackColor = System.Drawing.Color.Transparent;
            this.ibPressure.IsCheck = false;
            this.ibPressure.Location = new System.Drawing.Point(213, 394);
            this.ibPressure.Name = "ibPressure";
            this.ibPressure.Size = new System.Drawing.Size(120, 45);
            this.ibPressure.TabIndex = 27;
            this.ibPressure.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // ibCatch
            // 
            this.ibCatch.BackColor = System.Drawing.Color.Transparent;
            this.ibCatch.IsCheck = false;
            this.ibCatch.Location = new System.Drawing.Point(358, 394);
            this.ibCatch.Name = "ibCatch";
            this.ibCatch.Size = new System.Drawing.Size(120, 45);
            this.ibCatch.TabIndex = 28;
            this.ibCatch.Click += new System.EventHandler(this.MachineTestData_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.ibCatch);
            this.Controls.Add(this.ibPressure);
            this.Controls.Add(this.ibCarry);
            this.Controls.Add(this.ibClamp);
            this.Controls.Add(this.ibBlow);
            this.Controls.Add(this.ibCut);
            this.Controls.Add(this.ibTestReturn);
            this.Controls.Add(this.IOVolt);
            this.Controls.Add(this.SFhallValue);
            this.Controls.Add(this.SFCode);
            this.Controls.Add(this.YstepCode);
            this.Controls.Add(this.XstepCode);
            this.Controls.Add(this.btnCarrySensorRight);
            this.Controls.Add(this.btnCarrySensorLeft);
            this.Controls.Add(this.btnClampSensorUp);
            this.Controls.Add(this.btnClampSensorMid);
            this.Controls.Add(this.btnClampSensorLower);
            this.Controls.Add(this.btnRedKey2);
            this.Controls.Add(this.btnSFSensor);
            this.Controls.Add(this.btnGreenKey2);
            this.Controls.Add(this.btnGreenKey1);
            this.Controls.Add(this.btnRedKey1);
            this.Controls.Add(this.btnYSensor);
            this.Controls.Add(this.btnXSensor);
            this.Controls.Add(this.BackImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnXSensor;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnYSensor;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnGreenKey2;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnRedKey1;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnGreenKey1;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnSFSensor;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnRedKey2;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnClampSensorLower;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnClampSensorMid;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnClampSensorUp;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnCarrySensorLeft;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton btnCarrySensorRight;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton XstepCode;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton YstepCode;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton SFCode;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton SFhallValue;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton IOVolt;
        private System.Windows.Forms.PictureBox BackImage;
        private ImgBtn ibTestReturn;
        private ImgSwitch ibCut;
        private ImgSwitch ibBlow;
        private ImgSwitch ibClamp;
        private ImgSwitch ibCarry;
        private ImgSwitch ibPressure;
        private ImgSwitch ibCatch;
    }
}