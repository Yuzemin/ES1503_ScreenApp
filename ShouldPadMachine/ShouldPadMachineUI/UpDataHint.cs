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
    public partial class UpDataHint : Form
    {
        public UpDataHint()
        {
            InitializeComponent();
            this.Size = new Size(316, 188); 
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height - 40) / 2);
            HintPic.Size = new Size(316, 188);
            HintPic.Dock = DockStyle.Fill;
            HintPic.SizeMode = PictureBoxSizeMode.Normal;
            HintPic.Image = Properties.Resources.UpdataSuccess;
        }
    }
}