namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class UpDataHint
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
            this.HintPic = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // HintPic
            // 
            this.HintPic.Location = new System.Drawing.Point(0, 0);
            this.HintPic.Name = "HintPic";
            this.HintPic.Size = new System.Drawing.Size(316, 188);
            // 
            // UpDataHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(316, 188);
            this.ControlBox = false;
            this.Controls.Add(this.HintPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpDataHint";
            this.Text = "UpDataHint";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox HintPic;
    }
}