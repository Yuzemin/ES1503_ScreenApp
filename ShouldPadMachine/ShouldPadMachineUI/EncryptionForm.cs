using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class EncryptionForm : Form
    {
        public EncryptionForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height + 40) / 2);
        }
        private String initStrNum = String.Empty;//最初数据
        private double lastNumber;//最终数据
        private bool minusButtonEnable = false;
        private bool pointButtonEnable = false;
        private double maxValue;
        private double minValue;
        private bool isFirstClick;
        private bool isSercet = false;
        private bool haveTwodecimal = false;//有两位小数点
        #region 属性
        public bool IsSercet
        {
            get { return isSercet; }
            set { isSercet = value; }
        }
        public bool HaveTwoDecimal
        {
            get
            {
                return haveTwodecimal;
            }
            set
            {
                haveTwodecimal = value;
            }
        }
        public double MaxValue
        {
            get { return maxValue; }
            set { maxValue = Convert.ToDouble(value); }
        }
        public double MinValue
        {
            get { return minValue; }
            set { minValue = Convert.ToDouble(value); }
        }

        public bool PointButtonEnable
        {
            set { pointButtonEnable = value; }
        }

        public bool MinusButtonEnable
        {
            set { minusButtonEnable = value; }
        }
        public double LastNumber
        {
            get { return lastNumber; }
        }
        public String InitStrNum
        {
            get { return initStrNum; }
            set { initStrNum = value; }
        }
        #endregion

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                isFirstClick = false;
                txtShowData.Text = ((Button)sender).Text;
                return;
            }
            if (txtShowData.Text.IndexOf(".") != -1)
            {
                if (haveTwodecimal == false && txtShowData.Text.IndexOf(".") + 1 < txtShowData.Text.Length)
                    return;
                if (haveTwodecimal == true && txtShowData.Text.IndexOf(".") + 2 < txtShowData.Text.Length)
                    return;
            }
            if (txtShowData.Text != "0" || isSercet == true)
                txtShowData.Text += ((Button)sender).Text;
            else
                txtShowData.Text = ((Button)sender).Text;
        }

        private void OtherNumber_Click(object sender, EventArgs e)
        {
            String strText = ((Button)sender).Text;
            isFirstClick = false;
            switch (strText)
            {
                case "－":
                    if (txtShowData.Text[0] == '-')
                        txtShowData.Text = txtShowData.Text.Substring(1, txtShowData.Text.Length - 1);
                    else if (txtShowData.Text != "0")
                        txtShowData.Text = "-" + txtShowData.Text;
                    break;
                case "ENT":
                    if (txtShowData.Text != "")
                        lastNumber = Convert.ToDouble((txtShowData.Text));
                    else
                        lastNumber = 0;
                    if (lastNumber > maxValue) lastNumber = maxValue;
                    else if (lastNumber < minValue) lastNumber = minValue;
                    this.Close();
                    break;
                case "CLR":
                    if (txtShowData.PasswordChar == '*')
                        txtShowData.Text = "";
                    else
                        txtShowData.Text = "0";
                    break;
                case ".":
                    if (txtShowData.Text.IndexOf(".") == -1)
                        txtShowData.Text += ".";
                    break;
                default:
                    break;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.btnMinus.Enabled = minusButtonEnable;
            this.btnPoint.Enabled = pointButtonEnable;
            if (isSercet == true)
                txtShowData.PasswordChar = '*';
            else
                txtShowData.PasswordChar = Convert.ToChar(0);
            if (initStrNum != null)
                txtShowData.Text = initStrNum;
            else
                txtShowData.Text = "0";
            isFirstClick = true;
            btnNumber0.Focus();
            this.ClientSize = new Size(422, 335);
        }

        private void Calculator_Paint(object sender, PaintEventArgs e)
        {
            Rectangle frameRect = new Rectangle(2, 2, this.ClientSize.Width - 4, this.ClientSize.Height - 4);
            Color frameColor = Color.Silver;
            Pen framePen = new Pen(frameColor, 2);
            e.Graphics.DrawRectangle(framePen, frameRect);
            framePen.Dispose();
        }

        public new void Dispose()
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.Dispose();
            }
            base.Dispose();
        }

    }
}