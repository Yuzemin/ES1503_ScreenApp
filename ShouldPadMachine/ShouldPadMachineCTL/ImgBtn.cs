using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class ImgBtn : UserControl
    {
        Bitmap mapOn = new Bitmap(120,45);
        Bitmap mapOff = new Bitmap(120, 45);
        bool isCheck = false;

        public ImgBtn()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        public void SetMap (Bitmap bitMapOff,Bitmap bitMapOn)
        {
            mapOn = bitMapOn;
            mapOff = bitMapOff;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (isCheck)
                g.DrawImage(mapOn, 0, 0);
            else
                g.DrawImage(mapOff, 0, 0);
        }

        public void btnClickUp()
        {
            isCheck = false;
            this.Invalidate();
        }

        public void btnClickDown()
        {
            isCheck = true;
            this.Invalidate();
        }


    }
}
