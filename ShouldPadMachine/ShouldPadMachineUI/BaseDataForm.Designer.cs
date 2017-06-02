using ShouldPadMachine.ShouldPadMachineCTL;
namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class BaseDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDataForm));
            this.picBackGround = new System.Windows.Forms.PictureBox();
            this.ibSysReset = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibReturn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.zModify = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.dataButton5 = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.btnUpShowNeedleCodeNumber = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.yModify = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.xModify = new ShouldPadMachine.ShouldPadMachineCTL.DataButton();
            this.swUnlockParam = new ShouldPadMachine.ShouldPadMachineCTL.ImgSwitch();
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
            // ibSysReset
            // 
            this.ibSysReset.BackColor = System.Drawing.Color.Transparent;
            this.ibSysReset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibSysReset.Location = new System.Drawing.Point(494, 241);
            this.ibSysReset.Name = "ibSysReset";
            this.ibSysReset.Size = new System.Drawing.Size(100, 45);
            this.ibSysReset.TabIndex = 25;
            this.ibSysReset.Click += new System.EventHandler(this.ibSysReset_Click);
            this.ibSysReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibSysReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibReturn
            // 
            this.ibReturn.BackColor = System.Drawing.Color.Transparent;
            this.ibReturn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.ibReturn.Location = new System.Drawing.Point(494, 350);
            this.ibReturn.Name = "ibReturn";
            this.ibReturn.Size = new System.Drawing.Size(100, 45);
            this.ibReturn.TabIndex = 18;
            this.ibReturn.Click += new System.EventHandler(this.Return_Click);
            this.ibReturn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibReturn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // zModify
            // 
            this.zModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.zModify.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.UpNeedleCodeValue;
            this.zModify.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.zModify.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.BaseDataTable;
            this.zModify.Enabled = false;
            this.zModify.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.zModify.ForeColor = System.Drawing.Color.DarkGray;
            this.zModify.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.zModify.HasClick = false;
            this.zModify.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.zModify.Location = new System.Drawing.Point(206, 242);
            this.zModify.Name = "zModify";
            this.zModify.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.zModify.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.zModify.Size = new System.Drawing.Size(98, 43);
            this.zModify.Text = "0";
            this.zModify.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // dataButton5
            // 
            this.dataButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.dataButton5.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.dataButton5.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.dataButton5.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.ShouldPadDataTable;
            this.dataButton5.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.dataButton5.ForeColor = System.Drawing.Color.Black;
            this.dataButton5.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.dataButton5.HasClick = false;
            this.dataButton5.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.dataButton5.Location = new System.Drawing.Point(495, 129);
            this.dataButton5.Name = "dataButton5";
            this.dataButton5.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.dataButton5.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.CutLineDistance;
            this.dataButton5.Size = new System.Drawing.Size(98, 43);
            this.dataButton5.Text = "0";
            this.dataButton5.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // btnUpShowNeedleCodeNumber
            // 
            this.btnUpShowNeedleCodeNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnUpShowNeedleCodeNumber.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.Null;
            this.btnUpShowNeedleCodeNumber.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.btnUpShowNeedleCodeNumber.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.Null;
            this.btnUpShowNeedleCodeNumber.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnUpShowNeedleCodeNumber.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnUpShowNeedleCodeNumber.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.btnUpShowNeedleCodeNumber.HasClick = false;
            this.btnUpShowNeedleCodeNumber.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.btnUpShowNeedleCodeNumber.Location = new System.Drawing.Point(351, 242);
            this.btnUpShowNeedleCodeNumber.Name = "btnUpShowNeedleCodeNumber";
            this.btnUpShowNeedleCodeNumber.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.btnUpShowNeedleCodeNumber.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.btnUpShowNeedleCodeNumber.Size = new System.Drawing.Size(98, 43);
            this.btnUpShowNeedleCodeNumber.Text = "0";
            // 
            // yModify
            // 
            this.yModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.yModify.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.YZeroModify;
            this.yModify.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.yModify.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.BaseDataTable;
            this.yModify.Enabled = false;
            this.yModify.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.yModify.ForeColor = System.Drawing.Color.DarkGray;
            this.yModify.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.yModify.HasClick = false;
            this.yModify.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.yModify.Location = new System.Drawing.Point(351, 129);
            this.yModify.Name = "yModify";
            this.yModify.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.yModify.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.yModify.Size = new System.Drawing.Size(98, 43);
            this.yModify.Text = "0";
            this.yModify.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // xModify
            // 
            this.xModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.xModify.BaseDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.MachineBaseDataEnum.XZeroModify;
            this.xModify.CascadeDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.CascadeDataEnum.Null;
            this.xModify.DataTypeName = ShouldPadMachine.ShouldPadMachineAssist.Enum.DataTypeName.BaseDataTable;
            this.xModify.Enabled = false;
            this.xModify.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.xModify.ForeColor = System.Drawing.Color.DarkGray;
            this.xModify.FrameColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.xModify.HasClick = false;
            this.xModify.InOutDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.InOutDataEnum.Null;
            this.xModify.Location = new System.Drawing.Point(206, 129);
            this.xModify.Name = "xModify";
            this.xModify.SetDataElement = ShouldPadMachine.ShouldPadMachineAssist.Enum.SetDataEnum.Null;
            this.xModify.ShouldPadDataEnum = ShouldPadMachine.ShouldPadMachineAssist.Enum.ShouldPadDataEnum.Null;
            this.xModify.Size = new System.Drawing.Size(98, 43);
            this.xModify.Text = "0";
            this.xModify.Click += new System.EventHandler(this.DataButton_Click);
            // 
            // swUnlockParam
            // 
            this.swUnlockParam.BackColor = System.Drawing.Color.Transparent;
            this.swUnlockParam.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular);
            this.swUnlockParam.IsCheck = false;
            this.swUnlockParam.Location = new System.Drawing.Point(205, 350);
            this.swUnlockParam.Name = "swUnlockParam";
            this.swUnlockParam.Size = new System.Drawing.Size(100, 45);
            this.swUnlockParam.TabIndex = 82;
            this.swUnlockParam.Click += new System.EventHandler(this.swUnlock_Click);
            // 
            // BaseDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.swUnlockParam);
            this.Controls.Add(this.ibSysReset);
            this.Controls.Add(this.ibReturn);
            this.Controls.Add(this.zModify);
            this.Controls.Add(this.dataButton5);
            this.Controls.Add(this.btnUpShowNeedleCodeNumber);
            this.Controls.Add(this.yModify);
            this.Controls.Add(this.xModify);
            this.Controls.Add(this.picBackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseDataForm";
            this.Text = "BaseDataForm";
            this.Load += new System.EventHandler(this.BaseDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackGround;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton xModify;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton yModify;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton btnUpShowNeedleCodeNumber;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton dataButton5;
        private ShouldPadMachine.ShouldPadMachineCTL.DataButton zModify;
        private ImgBtn ibReturn;
        private ImgBtn ibSysReset;
        private ImgSwitch swUnlockParam;
    }
}