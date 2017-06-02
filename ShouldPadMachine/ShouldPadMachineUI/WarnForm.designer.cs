namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class WarnForm
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
            this.SuspendLayout();
            // 
            // WarnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(316, 188);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(240, 110);
            this.Name = "WarnForm";
            this.Text = "WarnForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.WarnForm_Load);
            this.Activated += new System.EventHandler(this.WarnForm_Activated);
            this.ResumeLayout(false);

        }

        #endregion







    }
}