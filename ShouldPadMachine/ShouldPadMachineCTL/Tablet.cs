using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist;


namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class Tablet : UserControl
    {
        private StringAlignment lineAlignment = StringAlignment.Center;
        private StringAlignment alignment = StringAlignment.Center;
        private string content = "";
        private int val_Max = 0;
        private int val_Min = 0;
        private bool enrange = false;
 
        public Tablet()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(233, 233, 233);
        }

        //数值范围使能
        public bool Enrange 
        {
            get { return this.enrange; }
            set 
            { 
                this.enrange = value;
                if (this.enrange)
                    this.Content = this.content; 
            }
        }

        public int Val_Max
        {
            set 
            {
                if (value < val_Min)
                    val_Max = val_Min;
                else
                    val_Max = value;
                if (this.enrange == true && (Convert.ToInt32(content) > val_Max))
                    this.Content = Convert.ToString(val_Max);
            }

            get { return val_Max; }         
        }

        public int Val_Min
        {
            set
            {
                if (value > val_Max)
                    val_Min = val_Max;
                else
                    val_Min = value;
                if (this.enrange == true && (Convert.ToInt32(content) < val_Min))
                    this.Content = Convert.ToString(val_Min);
            }

            get { return val_Min; }
        }

        private void CheckRange()
        {
            if (val_Max < val_Min)
                val_Max = val_Min;
            if (this.enrange == true)
            {
                if(Convert.ToInt32(content) < val_Min)
                    this.Content = Convert.ToString(val_Min);
                else if(Convert.ToInt32(content) > val_Max)
                    this.Content = Convert.ToString(val_Max);
            }
        }

        public void SetValRange(int Min, int Max)
        {
            this.val_Max = Max;
            this.val_Min = Min;
            CheckRange();
        }

        //小数点使能
        public bool Endecimal { get; set; }

        //负数使能
        public bool Enminus { get; set; }


        //水平方向对其
        public StringAlignment LineAlignment 
        {
            get { return lineAlignment; }
            set { lineAlignment = value; this.Invalidate(); }
        }
        //垂直方向对齐
        public StringAlignment Alignment 
        {
            get { return alignment; }
            set { alignment = value; this.Invalidate(); }
        }

        //文本内容        
        public String Content
        {
            get { return content; }
            set 
            {
                if (this.Enrange == false)
                    content = value;
                else
                {
                    int Tmp = Convert.ToInt32(value);

                    if (Tmp > this.val_Max)
                        Tmp = this.val_Max;
                    else if (Tmp < this.val_Min)
                        Tmp = this.val_Min;

                    this.content = Convert.ToString(Tmp);
       
                }  
                this.Invalidate(); 
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using(StringFormat StrFormat = new StringFormat())
            using (SolidBrush drawBrush = new SolidBrush(this.ForeColor))
            {
                RectangleF rec = new RectangleF(0, 0, this.Width, this.Height);
                StrFormat.Alignment = this.alignment;
                StrFormat.LineAlignment = this.lineAlignment;

                g.DrawString(this.content, this.Font, drawBrush, rec, StrFormat);
            }            
        }

    }
}
