using ShouldPadMachine.ShouldPadMachineCTL;
namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picBackGround = new System.Windows.Forms.PictureBox();
            this.lblTotalNeedleNumber = new System.Windows.Forms.Label();
            this.lblWorkNeedleNumber = new System.Windows.Forms.Label();
            this.picShapeImage = new System.Windows.Forms.PictureBox();
            this.swAuto = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.VerString = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.swSingleStep = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.btnMoveNext = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMovePrevious = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibEdit = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibMenu = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnNormalSpeed = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.bFileID = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.lblBottomWorkedNumber = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.lblWorkedNumber = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.lblTotalNum = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.lblLimitWorkedNumber = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.lblMagnWorkedNumber = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.SuspendLayout();
            // 
            // picBackGround
            // 
            this.picBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackGround.Image = ((System.Drawing.Image)(resources.GetObject("picBackGround.Image")));
            this.picBackGround.Location = new System.Drawing.Point(0, 0);
            this.picBackGround.Name = "picBackGround";
            this.picBackGround.Size = new System.Drawing.Size(800, 480);
            // 
            // lblTotalNeedleNumber
            // 
            this.lblTotalNeedleNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblTotalNeedleNumber.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalNeedleNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalNeedleNumber.Location = new System.Drawing.Point(25, 19);
            this.lblTotalNeedleNumber.Name = "lblTotalNeedleNumber";
            this.lblTotalNeedleNumber.Size = new System.Drawing.Size(53, 30);
            this.lblTotalNeedleNumber.Text = "0";
            this.lblTotalNeedleNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblWorkNeedleNumber
            // 
            this.lblWorkNeedleNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblWorkNeedleNumber.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblWorkNeedleNumber.ForeColor = System.Drawing.Color.Black;
            this.lblWorkNeedleNumber.Location = new System.Drawing.Point(92, 19);
            this.lblWorkNeedleNumber.Name = "lblWorkNeedleNumber";
            this.lblWorkNeedleNumber.Size = new System.Drawing.Size(54, 30);
            this.lblWorkNeedleNumber.Text = "0";
            this.lblWorkNeedleNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picShapeImage
            // 
            this.picShapeImage.BackColor = System.Drawing.Color.Silver;
            this.picShapeImage.Location = new System.Drawing.Point(25, 90);
            this.picShapeImage.Name = "picShapeImage";
            this.picShapeImage.Size = new System.Drawing.Size(568, 370);
            // 
            // swAuto
            // 
            this.swAuto.BackColor = System.Drawing.Color.Transparent;
            this.swAuto.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.swAuto.IsCheck = false;
            this.swAuto.Location = new System.Drawing.Point(631, 241);
            this.swAuto.Name = "swAuto";
            this.swAuto.Size = new System.Drawing.Size(120, 45);
            this.swAuto.TabIndex = 81;
            this.swAuto.Click += new System.EventHandler(this.swAuto_Click);
            // 
            // VerString
            // 
            this.VerString.Alignment = System.Drawing.StringAlignment.Far;
            this.VerString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.VerString.Content = "V0.0.0.0";
            this.VerString.Endecimal = false;
            this.VerString.Enminus = false;
            this.VerString.Enrange = false;
            this.VerString.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular);
            this.VerString.ForeColor = System.Drawing.Color.Green;
            this.VerString.LineAlignment = System.Drawing.StringAlignment.Center;
            this.VerString.Location = new System.Drawing.Point(686, 450);
            this.VerString.Name = "VerString";
            this.VerString.Size = new System.Drawing.Size(83, 27);
            this.VerString.TabIndex = 69;
            this.VerString.Val_Max = 0;
            this.VerString.Val_Min = 0;
            // 
            // swSingleStep
            // 
            this.swSingleStep.BackColor = System.Drawing.Color.Transparent;
            this.swSingleStep.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.swSingleStep.IsCheck = false;
            this.swSingleStep.Location = new System.Drawing.Point(631, 313);
            this.swSingleStep.Name = "swSingleStep";
            this.swSingleStep.Size = new System.Drawing.Size(120, 45);
            this.swSingleStep.TabIndex = 57;
            this.swSingleStep.Click += new System.EventHandler(this.SingleStep_Click);
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveNext.Location = new System.Drawing.Point(699, 382);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(52, 64);
            this.btnMoveNext.TabIndex = 49;
            this.btnMoveNext.Visible = false;
            this.btnMoveNext.Click += new System.EventHandler(this.Direction_Click);
            this.btnMoveNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.btnMoveNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnMovePrevious.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMovePrevious.Location = new System.Drawing.Point(629, 382);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.Size = new System.Drawing.Size(52, 64);
            this.btnMovePrevious.TabIndex = 37;
            this.btnMovePrevious.Visible = false;
            this.btnMovePrevious.Click += new System.EventHandler(this.Direction_Click);
            this.btnMovePrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.btnMovePrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibEdit
            // 
            this.ibEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibEdit.Location = new System.Drawing.Point(631, 98);
            this.ibEdit.Name = "ibEdit";
            this.ibEdit.Size = new System.Drawing.Size(120, 45);
            this.ibEdit.TabIndex = 25;
            this.ibEdit.Click += new System.EventHandler(this.lbEdit_Click);
            this.ibEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibMenu
            // 
            this.ibMenu.BackColor = System.Drawing.Color.Transparent;
            this.ibMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibMenu.Location = new System.Drawing.Point(631, 170);
            this.ibMenu.Name = "ibMenu";
            this.ibMenu.Size = new System.Drawing.Size(120, 45);
            this.ibMenu.TabIndex = 13;
            this.ibMenu.Click += new System.EventHandler(this.MenuBtn_Click);
            this.ibMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // btnNormalSpeed
            // 
            this.btnNormalSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.btnNormalSpeed.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.btnNormalSpeed.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.btnNormalSpeed.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.ShouldPadDataTable;
            this.btnNormalSpeed.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnNormalSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNormalSpeed.FrameColor = System.Drawing.Color.Empty;
            this.btnNormalSpeed.HasClick = false;
            this.btnNormalSpeed.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.btnNormalSpeed.Location = new System.Drawing.Point(714, 19);
            this.btnNormalSpeed.Name = "btnNormalSpeed";
            this.btnNormalSpeed.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.btnNormalSpeed.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.NormalSpeed;
            this.btnNormalSpeed.Size = new System.Drawing.Size(83, 30);
            this.btnNormalSpeed.Tag = "unTouch";
            this.btnNormalSpeed.Text = "0";
            this.btnNormalSpeed.Click += new System.EventHandler(this.DataButton2_Click);
            // 
            // bFileID
            // 
            this.bFileID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.bFileID.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.ID;
            this.bFileID.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.bFileID.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.BaseDataTable;
            this.bFileID.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.bFileID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bFileID.FrameColor = System.Drawing.Color.Empty;
            this.bFileID.HasClick = false;
            this.bFileID.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.bFileID.Location = new System.Drawing.Point(534, 14);
            this.bFileID.Name = "bFileID";
            this.bFileID.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.bFileID.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.bFileID.Size = new System.Drawing.Size(115, 41);
            this.bFileID.Tag = "unTouch";
            this.bFileID.Text = "0";
            this.bFileID.Click += new System.EventHandler(this.FileName_Click);
            // 
            // lblBottomWorkedNumber
            // 
            this.lblBottomWorkedNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblBottomWorkedNumber.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.lblBottomWorkedNumber.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.lblBottomWorkedNumber.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.lblBottomWorkedNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblBottomWorkedNumber.ForeColor = System.Drawing.Color.Black;
            this.lblBottomWorkedNumber.FrameColor = System.Drawing.Color.Empty;
            this.lblBottomWorkedNumber.HasClick = false;
            this.lblBottomWorkedNumber.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.lblBottomWorkedNumber.Location = new System.Drawing.Point(439, 19);
            this.lblBottomWorkedNumber.Name = "lblBottomWorkedNumber";
            this.lblBottomWorkedNumber.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.lblBottomWorkedNumber.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.lblBottomWorkedNumber.Size = new System.Drawing.Size(46, 30);
            this.lblBottomWorkedNumber.Tag = "2";
            this.lblBottomWorkedNumber.Text = "0";
            this.lblBottomWorkedNumber.Click += new System.EventHandler(this.ClearWorkedNumber_Click);
            // 
            // lblWorkedNumber
            // 
            this.lblWorkedNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblWorkedNumber.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.lblWorkedNumber.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.lblWorkedNumber.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.lblWorkedNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblWorkedNumber.ForeColor = System.Drawing.Color.Black;
            this.lblWorkedNumber.FrameColor = System.Drawing.Color.Empty;
            this.lblWorkedNumber.HasClick = false;
            this.lblWorkedNumber.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.lblWorkedNumber.Location = new System.Drawing.Point(276, 19);
            this.lblWorkedNumber.Name = "lblWorkedNumber";
            this.lblWorkedNumber.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.lblWorkedNumber.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.lblWorkedNumber.Size = new System.Drawing.Size(72, 30);
            this.lblWorkedNumber.Tag = "1";
            this.lblWorkedNumber.Text = "0";
            this.lblWorkedNumber.Click += new System.EventHandler(this.ClearWorkedNumber_Click);
            // 
            // lblTotalNum
            // 
            this.lblTotalNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblTotalNum.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.TotalClothNumberLimit;
            this.lblTotalNum.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.lblTotalNum.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.BaseDataTable;
            this.lblTotalNum.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalNum.FrameColor = System.Drawing.Color.Empty;
            this.lblTotalNum.HasClick = false;
            this.lblTotalNum.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.lblTotalNum.Location = new System.Drawing.Point(196, 19);
            this.lblTotalNum.Name = "lblTotalNum";
            this.lblTotalNum.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.lblTotalNum.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.lblTotalNum.Size = new System.Drawing.Size(72, 30);
            this.lblTotalNum.Text = "0";
            this.lblTotalNum.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // lblLimitWorkedNumber
            // 
            this.lblLimitWorkedNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(63)))));
            this.lblLimitWorkedNumber.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.lblLimitWorkedNumber.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.lblLimitWorkedNumber.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.ShouldPadDataTable;
            this.lblLimitWorkedNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblLimitWorkedNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLimitWorkedNumber.FrameColor = System.Drawing.Color.Empty;
            this.lblLimitWorkedNumber.HasClick = false;
            this.lblLimitWorkedNumber.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.lblLimitWorkedNumber.Location = new System.Drawing.Point(388, 19);
            this.lblLimitWorkedNumber.Name = "lblLimitWorkedNumber";
            this.lblLimitWorkedNumber.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.lblLimitWorkedNumber.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.ClothNumberLimit;
            this.lblLimitWorkedNumber.Size = new System.Drawing.Size(46, 30);
            this.lblLimitWorkedNumber.Text = "0";
            this.lblLimitWorkedNumber.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // lblMagnWorkedNumber
            // 
            this.lblMagnWorkedNumber.BackColor = System.Drawing.Color.Silver;
            this.lblMagnWorkedNumber.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.lblMagnWorkedNumber.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.lblMagnWorkedNumber.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.lblMagnWorkedNumber.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            this.lblMagnWorkedNumber.ForeColor = System.Drawing.Color.Black;
            this.lblMagnWorkedNumber.FrameColor = System.Drawing.Color.Empty;
            this.lblMagnWorkedNumber.HasClick = false;
            this.lblMagnWorkedNumber.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.lblMagnWorkedNumber.Location = new System.Drawing.Point(26, 91);
            this.lblMagnWorkedNumber.Name = "lblMagnWorkedNumber";
            this.lblMagnWorkedNumber.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.lblMagnWorkedNumber.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.lblMagnWorkedNumber.Size = new System.Drawing.Size(97, 43);
            this.lblMagnWorkedNumber.Tag = "1";
            this.lblMagnWorkedNumber.Text = "0000";
            this.lblMagnWorkedNumber.Click += new System.EventHandler(this.ClearWorkedNumber_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.swAuto);
            this.Controls.Add(this.VerString);
            this.Controls.Add(this.swSingleStep);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.btnMovePrevious);
            this.Controls.Add(this.ibEdit);
            this.Controls.Add(this.ibMenu);
            this.Controls.Add(this.btnNormalSpeed);
            this.Controls.Add(this.bFileID);
            this.Controls.Add(this.lblWorkNeedleNumber);
            this.Controls.Add(this.lblTotalNeedleNumber);
            this.Controls.Add(this.lblBottomWorkedNumber);
            this.Controls.Add(this.lblWorkedNumber);
            this.Controls.Add(this.lblTotalNum);
            this.Controls.Add(this.lblLimitWorkedNumber);
            this.Controls.Add(this.lblMagnWorkedNumber);
            this.Controls.Add(this.picShapeImage);
            this.Controls.Add(this.picBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackGround;
        public ShouldPadMachine.ShouldPadMachineCTL.DataButton bFileID;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton lblBottomWorkedNumber;
        public System.Windows.Forms.Label lblTotalNeedleNumber;
        private System.Windows.Forms.Label lblWorkNeedleNumber;
        public System.Windows.Forms.PictureBox picShapeImage;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton btnNormalSpeed;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton lblLimitWorkedNumber;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton lblWorkedNumber;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton lblTotalNum;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton lblMagnWorkedNumber;
        private ImgBtn ibMenu;
        private ImgBtn ibEdit;
        private ImgBtn btnMovePrevious;
        private ImgBtn btnMoveNext;
        private ImgSwitch swSingleStep;
        private Tablet VerString;
        private ImgSwitch swAuto;

    }
}

