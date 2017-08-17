using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineBLL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class WarnForm : Form
    {
        public static event FormHideEventHandle FormHide;
        private bool haveInitForm;
        private WarnType warnType;
        private Timer warnTimer;
        private PictureBox warnPicBox;
        private ImgBtn ibWarnSure;

        public bool HaveWarnMsg { get; set; }

        public WarnForm()
        {
            InitializeComponent();
            warnType = WarnType.Null;
            haveInitForm = false;
            HaveWarnMsg = false;
        }
        public WarnType WarnType
        {
            set
            {
                if (this.warnType != value)
                {
                    this.warnType = value;
                    haveInitForm = false;
                }
            }
        }
        private void OnFormHide()
        {
            HaveWarnMsg = false;
            if (FormHide != null)
                FormHide();
        }
        void WarnSureButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            OnFormHide();
        }

        void WarnTime_Click(object sender, EventArgs e)
        {
            if (warnType == WarnType.WorkedNumberOverflowWarn)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.WorkedNumberOverflowWarn == false)
                {
                    this.Hide();
                    OnFormHide();
                }
            }
            else if (warnType == WarnType.TotalWorkedNumberOverflowWarn)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.TotalWorkedNumberOverflowWarn == false)
                {
                    this.Hide();
                    OnFormHide();
                }
            }
            else if (warnType == WarnType.CrdWarn)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.CrdWarn == false)
                {
                    this.Hide();
                    OnFormHide();
                }
            }
            else if (warnType == WarnType.LineBreakWarn)
            {
                if (LowerMachineStatueData.LowerMachineStatueDateEx.LineBreakWarn == false)
                {
                    this.Hide();
                    OnFormHide();
                }
            }
        }

        private void WarnForm_Load(object sender, EventArgs e)
        {
            InitWarnForm();
        }

        private void WarnForm_Activated(object sender, EventArgs e)
        {
            InitWarnForm();
        }
        private void InitWarnForm()
        {
            if (haveInitForm == false)
            {
                haveInitForm = true;
                if (warnPicBox == null)
                {
                    warnPicBox = new PictureBox();
                    this.Controls.Add(warnPicBox);
                }
                if (ibWarnSure != null)
                    ibWarnSure.Visible = false;
                if ((warnType != WarnType.CommunicationError) && (warnType != WarnType.ModifiedValueWarn))
                {
                    this.Size = new Size(316, 188);
                    warnPicBox.Dock = DockStyle.Fill;
                    warnPicBox.SizeMode = PictureBoxSizeMode.Normal;
                    warnPicBox.Location = new Point(0, 0);
                    warnTimer = new Timer();
                    warnTimer.Interval = 800;
                    warnTimer.Tick += new EventHandler(WarnTime_Click);
                    warnTimer.Enabled = false;
                }
                else
                {
                    this.Size = new Size(316, 188);
                    warnPicBox.Dock = DockStyle.Fill;
                    warnPicBox.SizeMode = PictureBoxSizeMode.Normal;
                    warnPicBox.Location = new Point(0, 0);
                    if (ibWarnSure == null)
                    {
                        ibWarnSure = new ImgBtn();
                        ibWarnSure.SetMap(Properties.Resources.ButtonOK_OFF, Properties.Resources.ButtonOK_ON);
                        ibWarnSure.Enabled = true;
                        ibWarnSure.Location = new Point(110, 121);
                        ibWarnSure.Size = new Size(97, 42);
                        ibWarnSure.Click += new EventHandler(WarnSureButton_Click);
                        ibWarnSure.MouseDown += new MouseEventHandler(ImgBtn_MouseDown);
                        ibWarnSure.MouseUp += new MouseEventHandler(ImgBtn_MouseUp);
                        this.Controls.Add(ibWarnSure);
                    }
                    ibWarnSure.BringToFront();
                    ibWarnSure.Visible = true;
                }

                Bitmap ErrMsg;
                ErrMsg = (Bitmap)Properties.Resources.ResourceManager.GetObject(warnType.ToString());
                warnPicBox.Image = ErrMsg;

                switch (warnType)
                {
                    case WarnType.ModifiedValueWarn:
                    case WarnType.CommunicationError:
                        break;
                    case WarnType.ModeSwitchWarn:
                        warnTimer.Enabled = false;
                        break;
                    default:
                        warnTimer.Enabled = true;
                        break;
                }
                
            }
            if (warnTimer != null)
                warnTimer.Enabled = true;
        }

        private void WarnForm_Closing(object sender, CancelEventArgs e)
        {
        }

        public void ImgBtn_MouseDown(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickDown();
        }

        public void ImgBtn_MouseUp(object sender, MouseEventArgs e)
        {
            ImgBtn imgBtn = sender as ImgBtn;

            imgBtn.btnClickUp();
        }
    }
}