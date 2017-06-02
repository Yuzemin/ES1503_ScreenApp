using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class HitForm : Form
    {
        public HitForm()
        {
            InitializeComponent();

            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            imgBackgrand.Location = new Point((this.Size.Width - imgBackgrand.Size.Width) / 2, 90);

            imgEnter.SetMap(Properties.Resources.ButtonOK_OFF, Properties.Resources.ButtonOK_ON);
        }

        private void HitForm_Load(object sender, EventArgs e)
        {
            if (MenuFormManager.IsActed == 0)
                HitMsg.Image = Properties.Resources.warn_due;
            else
                HitMsg.Image = Properties.Resources.warn_Upgrade;            
        }

        private void imgBtn1_Click(object sender, EventArgs e)
        {
            MenuFormManager.IsShowLockMsg = false;
            MenuFormManager.showPF_En = true;
            this.Close();
        }

        private void ImgBtn_MouseDown(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickDown();
        }

        private void ImgBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickUp();
        }
    }
}