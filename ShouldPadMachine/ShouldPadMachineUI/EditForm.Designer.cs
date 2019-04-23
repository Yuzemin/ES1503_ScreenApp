using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.picShapeImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlJag = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlGapX = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlRow = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlCurve = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlClampM = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlClampR = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlClampL = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlCol = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlGapY = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlPadHalf = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlPad_Width = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.tlPadLength = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.ShapeType = new ShouldPadMachine.ShouldPadMachineCTL.Tablet();
            this.ibBackOut = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibReturn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibPointEdit = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibDrawRight = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibDrawAll = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibDrawLift = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibRightBtn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.ibLeftBtn = new ShouldPadMachine.ShouldPadMachineCTL.ImgBtn();
            this.SuspendLayout();
            // 
            // picShapeImage
            // 
            this.picShapeImage.BackColor = System.Drawing.Color.Silver;
            this.picShapeImage.Location = new System.Drawing.Point(21, 38);
            this.picShapeImage.Name = "picShapeImage";
            this.picShapeImage.Size = new System.Drawing.Size(568, 370);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 480);
            // 
            // tlJag
            // 
            this.tlJag.Alignment = System.Drawing.StringAlignment.Center;
            this.tlJag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlJag.Content = "5";
            this.tlJag.Endecimal = false;
            this.tlJag.Enminus = false;
            this.tlJag.Enrange = true;
            this.tlJag.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlJag.ForeColor = System.Drawing.Color.Black;
            this.tlJag.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlJag.Location = new System.Drawing.Point(607, 345);
            this.tlJag.Name = "tlJag";
            this.tlJag.Size = new System.Drawing.Size(76, 36);
            this.tlJag.TabIndex = 218;
            this.tlJag.Tag = "11";
            this.tlJag.Val_Max = 30;
            this.tlJag.Val_Min = 5;
            this.tlJag.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlGapX
            // 
            this.tlGapX.Alignment = System.Drawing.StringAlignment.Center;
            this.tlGapX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlGapX.Content = "5";
            this.tlGapX.Endecimal = false;
            this.tlGapX.Enminus = false;
            this.tlGapX.Enrange = true;
            this.tlGapX.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlGapX.ForeColor = System.Drawing.Color.Black;
            this.tlGapX.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlGapX.Location = new System.Drawing.Point(607, 286);
            this.tlGapX.Name = "tlGapX";
            this.tlGapX.Size = new System.Drawing.Size(76, 36);
            this.tlGapX.TabIndex = 217;
            this.tlGapX.Tag = "9";
            this.tlGapX.Val_Max = 30;
            this.tlGapX.Val_Min = 5;
            this.tlGapX.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlRow
            // 
            this.tlRow.Alignment = System.Drawing.StringAlignment.Center;
            this.tlRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlRow.Content = "0";
            this.tlRow.Endecimal = false;
            this.tlRow.Enminus = false;
            this.tlRow.Enrange = true;
            this.tlRow.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlRow.ForeColor = System.Drawing.Color.Black;
            this.tlRow.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlRow.Location = new System.Drawing.Point(607, 227);
            this.tlRow.Name = "tlRow";
            this.tlRow.Size = new System.Drawing.Size(76, 36);
            this.tlRow.TabIndex = 216;
            this.tlRow.Tag = "7";
            this.tlRow.Val_Max = 5;
            this.tlRow.Val_Min = 0;
            this.tlRow.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlCurve
            // 
            this.tlCurve.Alignment = System.Drawing.StringAlignment.Center;
            this.tlCurve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlCurve.Content = "0";
            this.tlCurve.Endecimal = false;
            this.tlCurve.Enminus = false;
            this.tlCurve.Enrange = true;
            this.tlCurve.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlCurve.ForeColor = System.Drawing.Color.Black;
            this.tlCurve.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlCurve.Location = new System.Drawing.Point(703, 345);
            this.tlCurve.Name = "tlCurve";
            this.tlCurve.Size = new System.Drawing.Size(76, 36);
            this.tlCurve.TabIndex = 201;
            this.tlCurve.Tag = "12";
            this.tlCurve.Val_Max = 30;
            this.tlCurve.Val_Min = 0;
            this.tlCurve.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlClampM
            // 
            this.tlClampM.Alignment = System.Drawing.StringAlignment.Center;
            this.tlClampM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlClampM.Content = "50";
            this.tlClampM.Endecimal = false;
            this.tlClampM.Enminus = false;
            this.tlClampM.Enrange = true;
            this.tlClampM.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlClampM.ForeColor = System.Drawing.Color.Black;
            this.tlClampM.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlClampM.Location = new System.Drawing.Point(607, 108);
            this.tlClampM.Name = "tlClampM";
            this.tlClampM.Size = new System.Drawing.Size(76, 36);
            this.tlClampM.TabIndex = 200;
            this.tlClampM.Tag = "2";
            this.tlClampM.Val_Max = 300;
            this.tlClampM.Val_Min = 50;
            this.tlClampM.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlClampR
            // 
            this.tlClampR.Alignment = System.Drawing.StringAlignment.Center;
            this.tlClampR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlClampR.Content = "50";
            this.tlClampR.Endecimal = false;
            this.tlClampR.Enminus = false;
            this.tlClampR.Enrange = true;
            this.tlClampR.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlClampR.ForeColor = System.Drawing.Color.Black;
            this.tlClampR.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlClampR.Location = new System.Drawing.Point(607, 168);
            this.tlClampR.Name = "tlClampR";
            this.tlClampR.Size = new System.Drawing.Size(76, 36);
            this.tlClampR.TabIndex = 199;
            this.tlClampR.Tag = "3";
            this.tlClampR.Val_Max = 300;
            this.tlClampR.Val_Min = 50;
            this.tlClampR.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlClampL
            // 
            this.tlClampL.Alignment = System.Drawing.StringAlignment.Center;
            this.tlClampL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlClampL.Content = "50";
            this.tlClampL.Endecimal = false;
            this.tlClampL.Enminus = false;
            this.tlClampL.Enrange = true;
            this.tlClampL.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlClampL.ForeColor = System.Drawing.Color.Black;
            this.tlClampL.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlClampL.Location = new System.Drawing.Point(607, 49);
            this.tlClampL.Name = "tlClampL";
            this.tlClampL.Size = new System.Drawing.Size(76, 36);
            this.tlClampL.TabIndex = 198;
            this.tlClampL.Tag = "1";
            this.tlClampL.Val_Max = 300;
            this.tlClampL.Val_Min = 50;
            this.tlClampL.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlCol
            // 
            this.tlCol.Alignment = System.Drawing.StringAlignment.Center;
            this.tlCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlCol.Content = "2";
            this.tlCol.Endecimal = false;
            this.tlCol.Enminus = false;
            this.tlCol.Enrange = true;
            this.tlCol.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlCol.ForeColor = System.Drawing.Color.Black;
            this.tlCol.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlCol.Location = new System.Drawing.Point(703, 227);
            this.tlCol.Name = "tlCol";
            this.tlCol.Size = new System.Drawing.Size(76, 36);
            this.tlCol.TabIndex = 197;
            this.tlCol.Tag = "8";
            this.tlCol.Val_Max = 20;
            this.tlCol.Val_Min = 2;
            this.tlCol.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlGapY
            // 
            this.tlGapY.Alignment = System.Drawing.StringAlignment.Center;
            this.tlGapY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlGapY.Content = "5";
            this.tlGapY.Endecimal = false;
            this.tlGapY.Enminus = false;
            this.tlGapY.Enrange = true;
            this.tlGapY.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlGapY.ForeColor = System.Drawing.Color.Black;
            this.tlGapY.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlGapY.Location = new System.Drawing.Point(703, 286);
            this.tlGapY.Name = "tlGapY";
            this.tlGapY.Size = new System.Drawing.Size(76, 36);
            this.tlGapY.TabIndex = 196;
            this.tlGapY.Tag = "10";
            this.tlGapY.Val_Max = 30;
            this.tlGapY.Val_Min = 5;
            this.tlGapY.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlPadHalf
            // 
            this.tlPadHalf.Alignment = System.Drawing.StringAlignment.Center;
            this.tlPadHalf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlPadHalf.Content = "20";
            this.tlPadHalf.Endecimal = false;
            this.tlPadHalf.Enminus = false;
            this.tlPadHalf.Enrange = true;
            this.tlPadHalf.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlPadHalf.ForeColor = System.Drawing.Color.Black;
            this.tlPadHalf.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlPadHalf.Location = new System.Drawing.Point(703, 167);
            this.tlPadHalf.Name = "tlPadHalf";
            this.tlPadHalf.Size = new System.Drawing.Size(76, 36);
            this.tlPadHalf.TabIndex = 195;
            this.tlPadHalf.Tag = "6";
            this.tlPadHalf.Val_Max = 175;
            this.tlPadHalf.Val_Min = 20;
            this.tlPadHalf.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlPad_Width
            // 
            this.tlPad_Width.Alignment = System.Drawing.StringAlignment.Center;
            this.tlPad_Width.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlPad_Width.Content = "50";
            this.tlPad_Width.Endecimal = false;
            this.tlPad_Width.Enminus = false;
            this.tlPad_Width.Enrange = true;
            this.tlPad_Width.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlPad_Width.ForeColor = System.Drawing.Color.Black;
            this.tlPad_Width.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlPad_Width.Location = new System.Drawing.Point(703, 108);
            this.tlPad_Width.Name = "tlPad_Width";
            this.tlPad_Width.Size = new System.Drawing.Size(76, 36);
            this.tlPad_Width.TabIndex = 194;
            this.tlPad_Width.Tag = "5";
            this.tlPad_Width.Val_Max = 300;
            this.tlPad_Width.Val_Min = 50;
            this.tlPad_Width.Click += new System.EventHandler(this.Param_Click);
            // 
            // tlPadLength
            // 
            this.tlPadLength.Alignment = System.Drawing.StringAlignment.Center;
            this.tlPadLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.tlPadLength.Content = "50";
            this.tlPadLength.Endecimal = false;
            this.tlPadLength.Enminus = false;
            this.tlPadLength.Enrange = true;
            this.tlPadLength.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.tlPadLength.ForeColor = System.Drawing.Color.Black;
            this.tlPadLength.LineAlignment = System.Drawing.StringAlignment.Center;
            this.tlPadLength.Location = new System.Drawing.Point(703, 49);
            this.tlPadLength.Name = "tlPadLength";
            this.tlPadLength.Size = new System.Drawing.Size(76, 36);
            this.tlPadLength.TabIndex = 193;
            this.tlPadLength.Tag = "4";
            this.tlPadLength.Val_Max = 350;
            this.tlPadLength.Val_Min = 50;
            this.tlPadLength.Click += new System.EventHandler(this.Param_Click);
            // 
            // ShapeType
            // 
            this.ShapeType.Alignment = System.Drawing.StringAlignment.Center;
            this.ShapeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.ShapeType.Content = "";
            this.ShapeType.Endecimal = false;
            this.ShapeType.Enminus = false;
            this.ShapeType.Enrange = false;
            this.ShapeType.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular);
            this.ShapeType.LineAlignment = System.Drawing.StringAlignment.Center;
            this.ShapeType.Location = new System.Drawing.Point(652, 417);
            this.ShapeType.Name = "ShapeType";
            this.ShapeType.Size = new System.Drawing.Size(82, 43);
            this.ShapeType.TabIndex = 153;
            this.ShapeType.Val_Max = 0;
            this.ShapeType.Val_Min = 0;
            // 
            // ibBackOut
            // 
            this.ibBackOut.BackColor = System.Drawing.Color.Transparent;
            this.ibBackOut.Location = new System.Drawing.Point(502, 416);
            this.ibBackOut.Name = "ibBackOut";
            this.ibBackOut.Size = new System.Drawing.Size(80, 45);
            this.ibBackOut.TabIndex = 120;
            this.ibBackOut.Click += new System.EventHandler(this.Revoke_Click);
            this.ibBackOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibBackOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibReturn
            // 
            this.ibReturn.BackColor = System.Drawing.Color.Transparent;
            this.ibReturn.Location = new System.Drawing.Point(408, 416);
            this.ibReturn.Name = "ibReturn";
            this.ibReturn.Size = new System.Drawing.Size(80, 45);
            this.ibReturn.TabIndex = 119;
            this.ibReturn.Click += new System.EventHandler(this.Return_Click);
            this.ibReturn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibReturn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibPointEdit
            // 
            this.ibPointEdit.BackColor = System.Drawing.Color.Transparent;
            this.ibPointEdit.Location = new System.Drawing.Point(313, 416);
            this.ibPointEdit.Name = "ibPointEdit";
            this.ibPointEdit.Size = new System.Drawing.Size(80, 45);
            this.ibPointEdit.TabIndex = 118;
            this.ibPointEdit.Click += new System.EventHandler(this.ShapeFixed_Click);
            this.ibPointEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibPointEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibDrawRight
            // 
            this.ibDrawRight.BackColor = System.Drawing.Color.Transparent;
            this.ibDrawRight.Location = new System.Drawing.Point(219, 416);
            this.ibDrawRight.Name = "ibDrawRight";
            this.ibDrawRight.Size = new System.Drawing.Size(80, 45);
            this.ibDrawRight.TabIndex = 117;
            this.ibDrawRight.Click += new System.EventHandler(this.RightDrawBitmap_Click);
            this.ibDrawRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibDrawRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibDrawAll
            // 
            this.ibDrawAll.BackColor = System.Drawing.Color.Transparent;
            this.ibDrawAll.Location = new System.Drawing.Point(124, 416);
            this.ibDrawAll.Name = "ibDrawAll";
            this.ibDrawAll.Size = new System.Drawing.Size(80, 45);
            this.ibDrawAll.TabIndex = 116;
            this.ibDrawAll.Click += new System.EventHandler(this.DrawBitmap_Click);
            this.ibDrawAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibDrawAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibDrawLift
            // 
            this.ibDrawLift.BackColor = System.Drawing.Color.Transparent;
            this.ibDrawLift.Location = new System.Drawing.Point(30, 416);
            this.ibDrawLift.Name = "ibDrawLift";
            this.ibDrawLift.Size = new System.Drawing.Size(80, 45);
            this.ibDrawLift.TabIndex = 112;
            this.ibDrawLift.Click += new System.EventHandler(this.LeftDrawBitmap_Click);
            this.ibDrawLift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibDrawLift.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibRightBtn
            // 
            this.ibRightBtn.BackColor = System.Drawing.Color.Transparent;
            this.ibRightBtn.Location = new System.Drawing.Point(741, 415);
            this.ibRightBtn.Name = "ibRightBtn";
            this.ibRightBtn.Size = new System.Drawing.Size(45, 45);
            this.ibRightBtn.TabIndex = 73;
            this.ibRightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            this.ibRightBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibRightBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // ibLeftBtn
            // 
            this.ibLeftBtn.BackColor = System.Drawing.Color.Transparent;
            this.ibLeftBtn.Location = new System.Drawing.Point(602, 415);
            this.ibLeftBtn.Name = "ibLeftBtn";
            this.ibLeftBtn.Size = new System.Drawing.Size(45, 45);
            this.ibLeftBtn.TabIndex = 72;
            this.ibLeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            this.ibLeftBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseDown);
            this.ibLeftBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImgBtn_MouseUp);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.tlJag);
            this.Controls.Add(this.tlGapX);
            this.Controls.Add(this.tlRow);
            this.Controls.Add(this.tlCurve);
            this.Controls.Add(this.tlClampM);
            this.Controls.Add(this.tlClampR);
            this.Controls.Add(this.tlClampL);
            this.Controls.Add(this.tlCol);
            this.Controls.Add(this.tlGapY);
            this.Controls.Add(this.tlPadHalf);
            this.Controls.Add(this.tlPad_Width);
            this.Controls.Add(this.tlPadLength);
            this.Controls.Add(this.ShapeType);
            this.Controls.Add(this.ibBackOut);
            this.Controls.Add(this.ibReturn);
            this.Controls.Add(this.ibPointEdit);
            this.Controls.Add(this.ibDrawRight);
            this.Controls.Add(this.ibDrawAll);
            this.Controls.Add(this.ibDrawLift);
            this.Controls.Add(this.ibRightBtn);
            this.Controls.Add(this.ibLeftBtn);
            this.Controls.Add(this.picShapeImage);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picShapeImage;
        private ImgBtn ibLeftBtn;
        private ImgBtn ibRightBtn;
        private ImgBtn ibDrawLift;
        private ImgBtn ibDrawAll;
        private ImgBtn ibDrawRight;
        private ImgBtn ibPointEdit;
        private ImgBtn ibReturn;
        private ImgBtn ibBackOut;
        private Tablet ShapeType;
        private Tablet tlPadLength;
        private Tablet tlPad_Width;
        private Tablet tlPadHalf;
        private Tablet tlGapY;
        private Tablet tlCol;
        private Tablet tlClampL;
        private Tablet tlClampR;
        private Tablet tlClampM;
        private Tablet tlCurve;
        private Tablet tlRow;
        private Tablet tlGapX;
        private Tablet tlJag;
        
    }
}