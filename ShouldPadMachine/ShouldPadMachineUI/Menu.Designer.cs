using ShouldPadMachine.ShouldPadMachineCTL;
namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.Menu_BG_Image = new System.Windows.Forms.PictureBox();
            this.ib_SetParam = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ib_Test = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ib_SetPos = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibUpSrc = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibUpEco = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibUpBoot = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibCopyCur = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibCopyAll = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibGetXml = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibReturn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibInfo = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibActive = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.SuspendLayout();
            // 
            // Menu_BG_Image
            // 
            this.Menu_BG_Image.Image = ((System.Drawing.Image)(resources.GetObject("Menu_BG_Image.Image")));
            this.Menu_BG_Image.Location = new System.Drawing.Point(0, 0);
            this.Menu_BG_Image.Name = "Menu_BG_Image";
            this.Menu_BG_Image.Size = new System.Drawing.Size(800, 480);
            // 
            // ib_SetParam
            // 
            this.ib_SetParam.BackColor = System.Drawing.Color.Transparent;
            this.ib_SetParam.Location = new System.Drawing.Point(505, 168);
            this.ib_SetParam.Name = "ib_SetParam";
            this.ib_SetParam.Size = new System.Drawing.Size(120, 45);
            this.ib_SetParam.TabIndex = 31;
            this.ib_SetParam.Click += new System.EventHandler(this.ibSetParam_Click);
            this.ib_SetParam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ib_SetParam.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ib_Test
            // 
            this.ib_Test.BackColor = System.Drawing.Color.Transparent;
            this.ib_Test.Location = new System.Drawing.Point(344, 168);
            this.ib_Test.Name = "ib_Test";
            this.ib_Test.Size = new System.Drawing.Size(120, 45);
            this.ib_Test.TabIndex = 30;
            this.ib_Test.Click += new System.EventHandler(this.ibTest_Click);
            this.ib_Test.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ib_Test.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ib_SetPos
            // 
            this.ib_SetPos.BackColor = System.Drawing.Color.Transparent;
            this.ib_SetPos.Location = new System.Drawing.Point(173, 168);
            this.ib_SetPos.Name = "ib_SetPos";
            this.ib_SetPos.Size = new System.Drawing.Size(120, 45);
            this.ib_SetPos.TabIndex = 28;
            this.ib_SetPos.Click += new System.EventHandler(this.ibSetPos_Click);
            this.ib_SetPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ib_SetPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibUpSrc
            // 
            this.ibUpSrc.BackColor = System.Drawing.Color.Transparent;
            this.ibUpSrc.Location = new System.Drawing.Point(173, 246);
            this.ibUpSrc.Name = "ibUpSrc";
            this.ibUpSrc.Size = new System.Drawing.Size(120, 45);
            this.ibUpSrc.TabIndex = 39;
            this.ibUpSrc.Click += new System.EventHandler(this.ibSrcUpdata_Click);
            this.ibUpSrc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibUpSrc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibUpEco
            // 
            this.ibUpEco.BackColor = System.Drawing.Color.Transparent;
            this.ibUpEco.Location = new System.Drawing.Point(344, 246);
            this.ibUpEco.Name = "ibUpEco";
            this.ibUpEco.Size = new System.Drawing.Size(120, 45);
            this.ibUpEco.TabIndex = 41;
            this.ibUpEco.Click += new System.EventHandler(this.ibEcoUpdata_Click);
            this.ibUpEco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibUpEco.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibUpBoot
            // 
            this.ibUpBoot.BackColor = System.Drawing.Color.Transparent;
            this.ibUpBoot.Location = new System.Drawing.Point(505, 246);
            this.ibUpBoot.Name = "ibUpBoot";
            this.ibUpBoot.Size = new System.Drawing.Size(120, 45);
            this.ibUpBoot.TabIndex = 43;
            this.ibUpBoot.Click += new System.EventHandler(this.ibBootLoadUpdata_Click);
            this.ibUpBoot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibUpBoot.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibCopyCur
            // 
            this.ibCopyCur.BackColor = System.Drawing.Color.Transparent;
            this.ibCopyCur.Location = new System.Drawing.Point(173, 88);
            this.ibCopyCur.Name = "ibCopyCur";
            this.ibCopyCur.Size = new System.Drawing.Size(120, 45);
            this.ibCopyCur.TabIndex = 45;
            this.ibCopyCur.Click += new System.EventHandler(this.ibCopyCurStyle_Click);
            this.ibCopyCur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibCopyCur.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibCopyAll
            // 
            this.ibCopyAll.BackColor = System.Drawing.Color.Transparent;
            this.ibCopyAll.Location = new System.Drawing.Point(344, 88);
            this.ibCopyAll.Name = "ibCopyAll";
            this.ibCopyAll.Size = new System.Drawing.Size(120, 45);
            this.ibCopyAll.TabIndex = 46;
            this.ibCopyAll.Click += new System.EventHandler(this.ibCopyAllStyle_Click);
            this.ibCopyAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibCopyAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibGetXml
            // 
            this.ibGetXml.BackColor = System.Drawing.Color.Transparent;
            this.ibGetXml.Location = new System.Drawing.Point(505, 88);
            this.ibGetXml.Name = "ibGetXml";
            this.ibGetXml.Size = new System.Drawing.Size(120, 45);
            this.ibGetXml.TabIndex = 47;
            this.ibGetXml.Click += new System.EventHandler(this.ibGetStyle_Click);
            this.ibGetXml.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibGetXml.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibReturn
            // 
            this.ibReturn.BackColor = System.Drawing.Color.Transparent;
            this.ibReturn.Location = new System.Drawing.Point(505, 350);
            this.ibReturn.Name = "ibReturn";
            this.ibReturn.Size = new System.Drawing.Size(120, 45);
            this.ibReturn.TabIndex = 48;
            this.ibReturn.Click += new System.EventHandler(this.ibReturn_Click);
            this.ibReturn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibReturn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibInfo
            // 
            this.ibInfo.BackColor = System.Drawing.Color.Transparent;
            this.ibInfo.Location = new System.Drawing.Point(344, 350);
            this.ibInfo.Name = "ibInfo";
            this.ibInfo.Size = new System.Drawing.Size(120, 45);
            this.ibInfo.TabIndex = 50;
            this.ibInfo.Click += new System.EventHandler(this.ibInfo_Click);
            this.ibInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibActive
            // 
            this.ibActive.BackColor = System.Drawing.Color.Transparent;
            this.ibActive.Location = new System.Drawing.Point(173, 350);
            this.ibActive.Name = "ibActive";
            this.ibActive.Size = new System.Drawing.Size(120, 45);
            this.ibActive.TabIndex = 52;
            this.ibActive.Click += new System.EventHandler(this.ibActive_Click);
            this.ibActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibActive.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.ibActive);
            this.Controls.Add(this.ibInfo);
            this.Controls.Add(this.ibReturn);
            this.Controls.Add(this.ibGetXml);
            this.Controls.Add(this.ibCopyAll);
            this.Controls.Add(this.ibCopyCur);
            this.Controls.Add(this.ibUpBoot);
            this.Controls.Add(this.ibUpEco);
            this.Controls.Add(this.ibUpSrc);
            this.Controls.Add(this.ib_SetParam);
            this.Controls.Add(this.ib_Test);
            this.Controls.Add(this.ib_SetPos);
            this.Controls.Add(this.Menu_BG_Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Menu_BG_Image;
        private ImgBtn ib_SetPos;
        private ImgBtn ib_Test;
        private ImgBtn ib_SetParam;
        private ImgBtn ibUpSrc;
        private ImgBtn ibUpEco;
        private ImgBtn ibUpBoot;
        private ImgBtn ibCopyCur;
        private ImgBtn ibCopyAll;
        private ImgBtn ibGetXml;
        private ImgBtn ibReturn;
        private ImgBtn ibInfo;
        private ImgBtn ibActive;
    }
}