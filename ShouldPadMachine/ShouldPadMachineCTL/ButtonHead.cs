using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class ButtonHead : Control
    {
        public ButtonHead()
        {
            InitializeComponent();
        }

        #region 属性

        /// <summary>
        /// 列头名 
        /// </summary>
        private string headName;

        public string HeadName
        {
            get { return headName; }
            set { headName = value; }
        }

        /// <summary>
        /// 双击标志
        /// </summary>

        #endregion
        protected virtual Rectangle GetTextRect()
        {
            return new Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top,
                                                        this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
        }

 



        protected override void OnPaint(PaintEventArgs pe)
        {
            StringFormat fontAlignMent = new StringFormat();
            //String strText = this.Text;
            Rectangle textRect = GetTextRect();//获得图形矩形
            Font textFont = new System.Drawing.Font(this.Font.Name, this.Font.Size, this.Font.Style);
            SolidBrush fontBrush = new System.Drawing.SolidBrush(this.ForeColor);
            fontAlignMent.Alignment = StringAlignment.Center;//设置字体显示时候的对齐方式
            fontAlignMent.LineAlignment = StringAlignment.Center;
            String text = this.HeadName;
            Pen pen = new Pen(Color.White);

            pe.Graphics.DrawRectangle(pen, textRect);
            pe.Graphics.DrawString(text, textFont, fontBrush, textRect, fontAlignMent);
          
            fontBrush.Dispose();
            fontAlignMent.Dispose();
            textFont.Dispose();
            fontBrush.Dispose();
            base.OnPaint(pe);
            base.OnPaint(pe);
        }
    }
}
