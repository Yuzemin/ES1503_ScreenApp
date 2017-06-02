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
    public partial class ImgSwitch : UserControl
    {
        Bitmap mapOn = new Bitmap(120, 45);
        Bitmap mapOff = new Bitmap(120, 45);
        private bool isCheck = false;
 
        public bool IsCheck 
        {
            get{return isCheck;}
            set{isCheck = value;this.Invalidate();}
        }

        public ImgSwitch()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        public void SetMap(Bitmap bitMapOn, Bitmap bitMapOff)
        {
            mapOn = bitMapOn;
            mapOff = bitMapOff;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (IsCheck)
            {
                //this.Size = new Size(mapOff.Size.Width, mapOff.Size.Height);
                g.DrawImage(mapOff, 0, 0);
            }
            else
            {
                //this.Size = new Size(mapOn.Size.Width, mapOn.Size.Height);
                g.DrawImage(mapOn, 0, 0);
            }
        }

        public void SwitchClick()
        {
            IsCheck = !IsCheck;
            this.Invalidate();
        }
    }
}
