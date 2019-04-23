using ShouldPadMachine.ShouldPadMachineCTL;
namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class ModifyShapeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyShapeForm));
            this.timMain = new System.Windows.Forms.Timer();
            this.picDrawBackGround = new System.Windows.Forms.PictureBox();
            this.picModiyBackGround = new System.Windows.Forms.PictureBox();
            this.ibxMirror = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.lblNeedleNumber = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.lblTotalNeedleNumber = new ShouldPadMachine.ShouldPadMachineCTL.ImageButton();
            this.ibEnter = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveDown = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveRightDown = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveRight = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveRightUp = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveUp = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveLeftDown = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveLeft = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMoveLeftUp = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibMirror = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibDelPoint = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibAddPoint = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibSelAll = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.btnMoveNext = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.btnMovePrevious = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibBreakOut = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibReturn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibMirrorCopy = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
            this.SuspendLayout();
            // 
            // timMain
            // 
            this.timMain.Interval = 5;
            this.timMain.Tick += new System.EventHandler(this.MainTime_Tick);
            // 
            // picDrawBackGround
            // 
            this.picDrawBackGround.BackColor = System.Drawing.Color.Gray;
            this.picDrawBackGround.Location = new System.Drawing.Point(21, 38);
            this.picDrawBackGround.Name = "picDrawBackGround";
            this.picDrawBackGround.Size = new System.Drawing.Size(568, 370);
            // 
            // picModiyBackGround
            // 
            this.picModiyBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picModiyBackGround.Image = ((System.Drawing.Image)(resources.GetObject("picModiyBackGround.Image")));
            this.picModiyBackGround.Location = new System.Drawing.Point(0, 0);
            this.picModiyBackGround.Name = "picModiyBackGround";
            this.picModiyBackGround.Size = new System.Drawing.Size(800, 480);
            // 
            // ibxMirror
            // 
            this.ibxMirror.BackColor = System.Drawing.Color.Transparent;
            this.ibxMirror.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibxMirror.Location = new System.Drawing.Point(266, 417);
            this.ibxMirror.Name = "ibxMirror";
            this.ibxMirror.Size = new System.Drawing.Size(80, 45);
            this.ibxMirror.TabIndex = 35;
            this.ibxMirror.Click += new System.EventHandler(this.PointOperMode_Click);
            this.ibxMirror.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibxMirror.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // lblNeedleNumber
            // 
            this.lblNeedleNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblNeedleNumber.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.lblNeedleNumber.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.lblNeedleNumber.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblNeedleNumber.FrameNoramlColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblNeedleNumber.FramePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblNeedleNumber.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.lblNeedleNumber.Location = new System.Drawing.Point(692, 417);
            this.lblNeedleNumber.Name = "lblNeedleNumber";
            this.lblNeedleNumber.Size = new System.Drawing.Size(40, 43);
            this.lblNeedleNumber.TabIndex = 5;
            this.lblNeedleNumber.Text = "000";
            // 
            // lblTotalNeedleNumber
            // 
            this.lblTotalNeedleNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblTotalNeedleNumber.ButtonStatus = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonStatus.Normal;
            this.lblTotalNeedleNumber.ButtonType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ButtonType.ClickButton;
            this.lblTotalNeedleNumber.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblTotalNeedleNumber.FrameNoramlColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblTotalNeedleNumber.FramePressColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.lblTotalNeedleNumber.ImageType = ShouldPadMachine.ShouldPadMachineAssist.Enum.ImageType.Null;
            this.lblTotalNeedleNumber.Location = new System.Drawing.Point(650, 417);
            this.lblTotalNeedleNumber.Name = "lblTotalNeedleNumber";
            this.lblTotalNeedleNumber.Size = new System.Drawing.Size(40, 43);
            this.lblTotalNeedleNumber.TabIndex = 5;
            this.lblTotalNeedleNumber.Text = "000";
            // 
            // ibEnter
            // 
            this.ibEnter.BackColor = System.Drawing.Color.Transparent;
            this.ibEnter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibEnter.Location = new System.Drawing.Point(663, 261);
            this.ibEnter.Name = "ibEnter";
            this.ibEnter.Size = new System.Drawing.Size(57, 60);
            this.ibEnter.TabIndex = 29;
            this.ibEnter.Click += new System.EventHandler(this.MakeSure_Click);
            this.ibEnter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibEnter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveDown.Location = new System.Drawing.Point(663, 323);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(57, 52);
            this.btnMoveDown.TabIndex = 28;
            this.btnMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveRightDown
            // 
            this.btnMoveRightDown.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveRightDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveRightDown.Location = new System.Drawing.Point(722, 323);
            this.btnMoveRightDown.Name = "btnMoveRightDown";
            this.btnMoveRightDown.Size = new System.Drawing.Size(55, 52);
            this.btnMoveRightDown.TabIndex = 27;
            this.btnMoveRightDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveRightDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveRight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveRight.Location = new System.Drawing.Point(722, 261);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(55, 60);
            this.btnMoveRight.TabIndex = 26;
            this.btnMoveRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveRightUp
            // 
            this.btnMoveRightUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveRightUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveRightUp.Location = new System.Drawing.Point(722, 207);
            this.btnMoveRightUp.Name = "btnMoveRightUp";
            this.btnMoveRightUp.Size = new System.Drawing.Size(55, 52);
            this.btnMoveRightUp.TabIndex = 25;
            this.btnMoveRightUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveRightUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveUp.Location = new System.Drawing.Point(663, 207);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(57, 52);
            this.btnMoveUp.TabIndex = 24;
            this.btnMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveLeftDown
            // 
            this.btnMoveLeftDown.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveLeftDown.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveLeftDown.Location = new System.Drawing.Point(609, 323);
            this.btnMoveLeftDown.Name = "btnMoveLeftDown";
            this.btnMoveLeftDown.Size = new System.Drawing.Size(52, 52);
            this.btnMoveLeftDown.TabIndex = 23;
            this.btnMoveLeftDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveLeftDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveLeft.Location = new System.Drawing.Point(609, 261);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(52, 60);
            this.btnMoveLeft.TabIndex = 22;
            this.btnMoveLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMoveLeftUp
            // 
            this.btnMoveLeftUp.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveLeftUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveLeftUp.Location = new System.Drawing.Point(609, 207);
            this.btnMoveLeftUp.Name = "btnMoveLeftUp";
            this.btnMoveLeftUp.Size = new System.Drawing.Size(52, 52);
            this.btnMoveLeftUp.TabIndex = 21;
            this.btnMoveLeftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveLeftUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // ibMirror
            // 
            this.ibMirror.BackColor = System.Drawing.Color.Transparent;
            this.ibMirror.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibMirror.Location = new System.Drawing.Point(155, 417);
            this.ibMirror.Name = "ibMirror";
            this.ibMirror.Size = new System.Drawing.Size(80, 45);
            this.ibMirror.TabIndex = 20;
            this.ibMirror.Click += new System.EventHandler(this.PointOperMode_Click);
            this.ibMirror.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibMirror.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibDelPoint
            // 
            this.ibDelPoint.BackColor = System.Drawing.Color.Transparent;
            this.ibDelPoint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibDelPoint.Location = new System.Drawing.Point(699, 49);
            this.ibDelPoint.Name = "ibDelPoint";
            this.ibDelPoint.Size = new System.Drawing.Size(80, 45);
            this.ibDelPoint.TabIndex = 19;
            this.ibDelPoint.Click += new System.EventHandler(this.PointOperMode_Click);
            this.ibDelPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibDelPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibAddPoint
            // 
            this.ibAddPoint.BackColor = System.Drawing.Color.Transparent;
            this.ibAddPoint.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibAddPoint.Location = new System.Drawing.Point(606, 49);
            this.ibAddPoint.Name = "ibAddPoint";
            this.ibAddPoint.Size = new System.Drawing.Size(80, 45);
            this.ibAddPoint.TabIndex = 18;
            this.ibAddPoint.Click += new System.EventHandler(this.PointOperMode_Click);
            this.ibAddPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibAddPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibSelAll
            // 
            this.ibSelAll.BackColor = System.Drawing.Color.Transparent;
            this.ibSelAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibSelAll.IsCheck = false;
            this.ibSelAll.Location = new System.Drawing.Point(606, 120);
            this.ibSelAll.Name = "ibSelAll";
            this.ibSelAll.Size = new System.Drawing.Size(80, 45);
            this.ibSelAll.TabIndex = 17;
            this.ibSelAll.Click += new System.EventHandler(this.MoveTypeChange_Click);
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveNext.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMoveNext.Location = new System.Drawing.Point(738, 416);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(45, 45);
            this.btnMoveNext.TabIndex = 14;
            this.btnMoveNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMoveNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnMovePrevious.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.btnMovePrevious.Location = new System.Drawing.Point(599, 416);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.Size = new System.Drawing.Size(45, 45);
            this.btnMovePrevious.TabIndex = 13;
            this.btnMovePrevious.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseDown);
            this.btnMovePrevious.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Direction_MouseUp);
            // 
            // ibBreakOut
            // 
            this.ibBreakOut.BackColor = System.Drawing.Color.Transparent;
            this.ibBreakOut.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibBreakOut.Location = new System.Drawing.Point(488, 417);
            this.ibBreakOut.Name = "ibBreakOut";
            this.ibBreakOut.Size = new System.Drawing.Size(80, 45);
            this.ibBreakOut.TabIndex = 12;
            this.ibBreakOut.Click += new System.EventHandler(this.Revoke_Click);
            this.ibBreakOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibBreakOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibReturn
            // 
            this.ibReturn.BackColor = System.Drawing.Color.Transparent;
            this.ibReturn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibReturn.Location = new System.Drawing.Point(377, 417);
            this.ibReturn.Name = "ibReturn";
            this.ibReturn.Size = new System.Drawing.Size(80, 45);
            this.ibReturn.TabIndex = 8;
            this.ibReturn.Click += new System.EventHandler(this.Return_Click);
            this.ibReturn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibReturn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibMirrorCopy
            // 
            this.ibMirrorCopy.BackColor = System.Drawing.Color.Transparent;
            this.ibMirrorCopy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibMirrorCopy.IsCheck = false;
            this.ibMirrorCopy.Location = new System.Drawing.Point(699, 120);
            this.ibMirrorCopy.Name = "ibMirrorCopy";
            this.ibMirrorCopy.Size = new System.Drawing.Size(80, 45);
            this.ibMirrorCopy.TabIndex = 38;
            this.ibMirrorCopy.Click += new System.EventHandler(this.ibMirrorCopy_Click);
            // 
            // ModifyShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.ibMirrorCopy);
            this.Controls.Add(this.ibxMirror);
            this.Controls.Add(this.lblNeedleNumber);
            this.Controls.Add(this.lblTotalNeedleNumber);
            this.Controls.Add(this.ibEnter);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveRightDown);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveRightUp);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnMoveLeftDown);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveLeftUp);
            this.Controls.Add(this.ibMirror);
            this.Controls.Add(this.ibDelPoint);
            this.Controls.Add(this.ibAddPoint);
            this.Controls.Add(this.ibSelAll);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.btnMovePrevious);
            this.Controls.Add(this.ibBreakOut);
            this.Controls.Add(this.ibReturn);
            this.Controls.Add(this.picDrawBackGround);
            this.Controls.Add(this.picModiyBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModifyShapeForm";
            this.Text = "ModifyShapeManager";
            this.Load += new System.EventHandler(this.ModifyShapeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picModiyBackGround;
        private System.Windows.Forms.PictureBox picDrawBackGround;
        private System.Windows.Forms.Timer timMain;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton lblNeedleNumber;
        private ShouldPadMachine.ShouldPadMachineCTL.ImageButton lblTotalNeedleNumber;
        private ImgBtn ibReturn;
        private ImgBtn ibBreakOut;
        private ImgBtn btnMovePrevious;
        private ImgBtn btnMoveNext;
        private ImgSwitch ibSelAll;
        private ImgBtn ibAddPoint;
        private ImgBtn ibDelPoint;
        private ImgBtn ibMirror;
        private ImgBtn btnMoveLeftUp;
        private ImgBtn btnMoveLeft;
        private ImgBtn btnMoveLeftDown;
        private ImgBtn btnMoveUp;
        private ImgBtn btnMoveRightUp;
        private ImgBtn btnMoveRight;
        private ImgBtn btnMoveRightDown;
        private ImgBtn btnMoveDown;
        private ImgBtn ibEnter;
        private ImgBtn ibxMirror;
        private ImgSwitch ibMirrorCopy;
    }
}