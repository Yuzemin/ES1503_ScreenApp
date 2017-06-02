namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class HitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HitForm));
            this.imgBackgrand = new System.Windows.Forms.PictureBox();
            this.imgEnter = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.HitMsg = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // imgBackgrand
            // 
            this.imgBackgrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBackgrand.Image = ((System.Drawing.Image)(resources.GetObject("imgBackgrand.Image")));
            this.imgBackgrand.Location = new System.Drawing.Point(0, 0);
            this.imgBackgrand.Name = "imgBackgrand";
            this.imgBackgrand.Size = new System.Drawing.Size(316, 188);
            // 
            // imgEnter
            // 
            this.imgEnter.BackColor = System.Drawing.Color.Transparent;
            this.imgEnter.Location = new System.Drawing.Point(109, 123);
            this.imgEnter.Name = "imgEnter";
            this.imgEnter.Size = new System.Drawing.Size(97, 42);
            this.imgEnter.TabIndex = 1;
            this.imgEnter.Click += new System.EventHandler(this.imgBtn1_Click);
            this.imgEnter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.imgEnter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // HitMsg
            // 
            this.HitMsg.Image = ((System.Drawing.Image)(resources.GetObject("HitMsg.Image")));
            this.HitMsg.Location = new System.Drawing.Point(24, 25);
            this.HitMsg.Name = "HitMsg";
            this.HitMsg.Size = new System.Drawing.Size(267, 68);
            // 
            // HitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(316, 188);
            this.ControlBox = false;
            this.Controls.Add(this.HitMsg);
            this.Controls.Add(this.imgEnter);
            this.Controls.Add(this.imgBackgrand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HitForm";
            this.Text = "HitForm";
            this.Load += new System.EventHandler(this.HitForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBackgrand;
        private ShouldPadMachine.ShouldPadMachineCTL.ImgBtn imgEnter;
        private System.Windows.Forms.PictureBox HitMsg;
    }
}