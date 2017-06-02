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
    public partial class ShowNumForm : Form
    {
        public static NoticeCALFeedbackEventHandle AclFeedback;
        //public string NumberString;
        public ShowNumForm()
        {
            InitializeComponent();
        }
        //public ShowNumForm(string numberstring)
        //{

        //    this.NumberString = numberstring;
        //    InitializeComponent();
        //}
        public void OnFeedBack(string uartComdEventArgs)
        {
            if (AclFeedback != null)
                AclFeedback(uartComdEventArgs);
        }


        public string StrBut1
        {
            set { this.button1.Text = value; }
        }


        public string StrBut2
        {
            set { this.button2.Text = value; }
        }


        public string StrBut3
        {
            get { return this.button3.Text; }
            set { this.button3.Text = value; }
        }
        public string StrBut4
        {
            get { return this.button4.Text; }
            set { this.button4.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OnFeedBack(((Button)sender).Text);
            //NumberString += ((Button)sender).Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ShowNumForm_Load(object sender, EventArgs e)
        {
            if (StrBut3 == "")
                this.button3.Visible = false;
            else
                this.button3.Visible = true;
            if (StrBut4 == "")
                this.button4.Visible = false;
            else
                this.button4.Visible = true;


        }

      

    }
}