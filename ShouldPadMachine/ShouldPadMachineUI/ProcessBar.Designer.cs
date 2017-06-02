namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class ProcessBar
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
            this.FileBar = new System.Windows.Forms.ProgressBar();
            this.PB_Msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileBar
            // 
            this.FileBar.Location = new System.Drawing.Point(27, 91);
            this.FileBar.Name = "FileBar";
            this.FileBar.Size = new System.Drawing.Size(274, 43);
            // 
            // PB_Msg
            // 
            this.PB_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.PB_Msg.Location = new System.Drawing.Point(27, 56);
            this.PB_Msg.Name = "PB_Msg";
            this.PB_Msg.Size = new System.Drawing.Size(274, 22);
            this.PB_Msg.Text = "文件名";
            // 
            // ProcessBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(330, 180);
            this.ControlBox = false;
            this.Controls.Add(this.PB_Msg);
            this.Controls.Add(this.FileBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessBar";
            this.Text = "ProcessBar";
            this.Load += new System.EventHandler(this.ProcessBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar FileBar;
        public System.Windows.Forms.Label PB_Msg;
    }
}