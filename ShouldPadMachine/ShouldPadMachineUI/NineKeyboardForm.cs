using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class NineKeyboardForm : Form
    {
        public NineKeyboardForm()
        {
            InitializeComponent();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height + 40) / 2);
        }

        private String initStrNum = String.Empty;//最初数据
        private string lastNumber;//最终数据
        private bool minusButtonEnable = false;
        private bool pointButtonEnable = false;
        private double maxValue;
        private double minValue;
        private bool isSercet = false;
        private bool haveTwodecimal = false;//有两位小数点
        private ShowNumForm showNumForm;
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
        public string LastNumber
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
            //弹出一个小选择框
            if (showNumForm != null)
                showNumForm.Close();

            showNumForm = new ShowNumForm();

            if (((PictureBox)sender).Tag.ToString().Split(',').Length == 4)
            {

                showNumForm.StrBut1 = ((PictureBox)sender).Tag.ToString().Split(',')[0].ToString();
                showNumForm.StrBut2 = ((PictureBox)sender).Tag.ToString().Split(',')[1].ToString();
                showNumForm.StrBut3 = ((PictureBox)sender).Tag.ToString().Split(',')[2].ToString();
                showNumForm.StrBut4 = ((PictureBox)sender).Tag.ToString().Split(',')[3].ToString();
            }
            else
            {
                showNumForm.StrBut1 = ((PictureBox)sender).Tag.ToString().Split(',')[0].ToString();
                showNumForm.StrBut2 = ((PictureBox)sender).Tag.ToString().Split(',')[1].ToString();
                showNumForm.StrBut3 = ((PictureBox)sender).Tag.ToString().Split(',')[2].ToString();
            }
            showNumForm.Location = new Point(100, 100);
            showNumForm.Show();
        }

        private void OtherNumber_Click(object sender, EventArgs e)
        {
            String strText = ((PictureBox)sender).Tag.ToString();

            if (showNumForm != null)
                showNumForm.Close();

            switch (strText)
            {
                case "0":
                    txtShowData1.Text += strText;
                    break;
                case "－":
                    txtShowData1.Text += strText;
                    break;
                case "ENT":
                    if (txtShowData1.Text != "")
                        lastNumber = txtShowData1.Text;
                    else
                        lastNumber = initStrNum;

                    ShowNumForm.AclFeedback -= new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.NoticeCALFeedbackEventHandle(ACL_Feedback);
                    this.Close();
                    break;
                case "CLR":
                    if (txtShowData1.PasswordChar == '*')
                        txtShowData1.Text = "";
                    else
                        txtShowData1.Text = "";
                    break;
                case ".":
                    txtShowData1.Text += strText;
                    break;
                default:
                    break;
            }
        }

        private void NineKeyboardForm_Load(object sender, EventArgs e)
        {
            this.txtShowData1.Text = initStrNum;
            ShowNumForm.AclFeedback += new ShouldPadMachine.ShouldPadMachineAssist.DelegateEx.NoticeCALFeedbackEventHandle(ACL_Feedback);
        }

        private void NineKeyboardForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle frameRect = new Rectangle(2, 2, this.ClientSize.Width - 4, this.ClientSize.Height - 4);
            Color frameColor = Color.Silver;
            Pen framePen = new Pen(frameColor, 2);
            e.Graphics.DrawRectangle(framePen, frameRect);
            framePen.Dispose();
        }

        void ACL_Feedback(string e)
        {
            if (!this.txtShowData1.IsDisposed)
                this.txtShowData1.Text += e;
            else
            {
                this.txtShowData1 = new System.Windows.Forms.TextBox();
                this.txtShowData1.Text += e;
            }

        }



      
    }
}