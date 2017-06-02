namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class MachineWarnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineWarnForm));
            this.lblWarn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWarnID = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWarn
            // 
            this.lblWarn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblWarn.Location = new System.Drawing.Point(112, 60);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(271, 53);
            this.lblWarn.Text = "220V电压过高";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblWarnID
            // 
            this.lblWarnID.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblWarnID.Location = new System.Drawing.Point(112, 21);
            this.lblWarnID.Name = "lblWarnID";
            this.lblWarnID.Size = new System.Drawing.Size(152, 30);
            this.lblWarnID.Text = "W1:";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(123)))), ((int)(((byte)(217)))));
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.btnOK.Location = new System.Drawing.Point(121, 128);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(143, 46);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // MachineWarnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(123)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(383, 189);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblWarnID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWarn);
            this.Location = new System.Drawing.Point(415, 266);
            this.Name = "MachineWarnForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MachineWarnForm_Load);
            this.Activated += new System.EventHandler(this.MachineWarnForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblWarnID;
        private System.Windows.Forms.Button btnOK;
    }
}