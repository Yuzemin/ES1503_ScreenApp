using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineBLL;


namespace ShouldPadMachine.ShouldPadMachineUI
{
    public partial class MessageBoxEX : Form
    {
        private int maxWidth = 360;
        private String messageText;
        private int edgeWidth = 5;
        private int edgeHeight = 5;
        private MessageBoxButtonType messageBoxButtons;
        private Rectangle textRect;
        private DialogResultEx dialogResult;
        private Color backColor = Color.FromArgb(107, 97, 158);
        private int indent = 2;
        public new DialogResultEx DialogResult
        {
            get {
                return dialogResult;
            }
        }
        private MessageBoxButtonType MessageBoxButtons
        {
            set {
                messageBoxButtons = value;
            }
        }
        private String MessageText
        {
            set {
                messageText = value;
            }
        }
        public MessageBoxEX()
        {
            InitializeComponent();
        }
        public static DialogResultEx Show(String messageText, MessageBoxButtonType messageBoxButtons)
        {
            MessageBoxEX messageBoxEx = new MessageBoxEX();
            messageBoxEx.MessageBoxButtons = messageBoxButtons;
            messageBoxEx.MessageText =messageText;
            messageBoxEx.ShowDialog();
            return messageBoxEx.DialogResult;
        }
        public static DialogResultEx Show(String messageText)
        {
            return Show(messageText, MessageBoxButtonType.OK);
        }

        private void MessageBoxEX_Load(object sender, EventArgs e)
        {
            Graphics pe = this.CreateGraphics();
            SizeF size =  pe.MeasureString(messageText, this.Font);
            int textHeight = (int)size.Height;
            int textWidth = (int)size.Width;
            if (size.Width > maxWidth)
            {
                int number = ((int)size.Width / maxWidth) + 1;
                textHeight = number * textHeight;
                textWidth = maxWidth;
            }
            Button[] showButtons = GetShowButtons(messageBoxButtons);
            int buttonWidth = 0;
            for (int i = 0; i < showButtons.Length; i++)
                buttonWidth += edgeWidth + showButtons[i].Width;
            if (textWidth < buttonWidth)
                textWidth = buttonWidth;
            int buttonHeight = 0;
            if (messageBoxButtons != MessageBoxButtonType.None)
                buttonHeight = button1.Height;
            Rectangle validSize = new Rectangle(indent, indent, textWidth + 2 * edgeWidth, textHeight + 3 * edgeWidth + buttonHeight);//有效区域，文本和控件都应该存在于这个矩形区域中
            textRect = new Rectangle(validSize.X + edgeWidth, validSize.Y + edgeHeight, textWidth, textHeight);//文本矩形框
            if (messageBoxButtons != MessageBoxButtonType.None)
            {
                Rectangle containerSize = new Rectangle(validSize.X + edgeWidth, validSize.Y + textHeight + 3 * edgeWidth, textWidth, button1.Height);
                ChangeButtonLocation(containerSize, showButtons);
            }
            this.Size = new Size(validSize.Width +  indent + edgeWidth, validSize.Height + 2*indent + edgeHeight);
            this.Location = new Point((800 - this.Size.Width) / 2, (480 - this.Size.Height) / 2);
        }
        private Button[] ButtonsVisible(bool[] visiables)
        {
            Button[] buttons = new Button[] { button1,button2,button3};
            List<Button> showButtons = new List<Button>();
            for (int i = 0; i < visiables.Length; i++)
            {
                buttons[i].Visible = visiables[i];
                if (visiables[i])
                    showButtons.Add(buttons[i]);
            }
            return showButtons.ToArray();
        }
        private Button[] GetShowButtons(MessageBoxButtonType messageBoxButtonType)
        {
            bool[] visiables = null;
            switch (messageBoxButtonType)
            { 
                case MessageBoxButtonType.Repair:
                    visiables = new bool[] {true,false,false };
                    button1.Text = "Repair";
                    break;
                case MessageBoxButtonType.None:
                    visiables = new bool[] { false, false, false };
                    break;
                case MessageBoxButtonType.OK:
                    visiables = new bool[] {true,false,false };
                    button1.Text = "OK";
                    break;
                case MessageBoxButtonType.InputUpdata:
                    visiables = new bool[] { true, true, false };
                    button1.Text = "Updata";
                    button2.Text = "Input";
                    break;
                case MessageBoxButtonType.InPutGetUpdata:
                    visiables = new bool[] { true, false, false };
                    button1.Text = "Updata";
                    break;

                case MessageBoxButtonType.RetryCancel:
                    visiables = new bool[] { true, true, false };
                    button1.Text = "Retry";
                    button2.Text = "Cancel";
                    break;
                case MessageBoxButtonType.RetryGetCancel:
                    visiables = new bool[] { true, true, true };
                    button1.Text = "GetInfo";
                    button2.Text = "Retry";
                    button3.Text = "Cancel";
                    break;
                case MessageBoxButtonType.YesCancel:
                    visiables = new bool[] { true, true, false};
                    button1.Text = "Yes";
                    button2.Text = "Cancel";
                    break;
                case MessageBoxButtonType.InPutDeleteUpdata:
                    visiables = new bool[] { true, true, false };
                    button1.Text = "Updata";
                    button2.Text = "Input";
                    break;
                default:
                    break;
            }
            if (visiables != null)
                return ButtonsVisible(visiables);
            else
                return null;

        }
        private void ChangeButtonLocation(Rectangle containRect, Button[] buttons)
        {
            if (buttons != null && buttons.Length > 0)
            {
                int space = 0;//按钮之间的间隔
                int spaceNumber = 0;//按钮间隔个数
                spaceNumber = buttons.Length - 1;
                int width = buttons[0].Width;
                if (spaceNumber > 0)
                {
                    space = (containRect.Width - width * buttons.Length) / spaceNumber;
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (i > 0)
                            buttons[i].Location = new Point(buttons[i - 1].Location.X + buttons[i - 1].Width + space, containRect.Y);
                        else
                            buttons[i].Location = new Point(containRect.X, containRect.Y);
                    }
                }
                else
                {
                    space = containRect.X + (containRect.Width - width) / 2;
                    buttons[0].Location = new Point(space, containRect.Y);
                }
            }
        }
        private void MessageBoxEX_Paint(object sender, PaintEventArgs e)
        {
            Graphics pe = e.Graphics;
            Font textFont = this.Font;
            SolidBrush textBrush = new SolidBrush(this.ForeColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            pe.FillRectangle(new SolidBrush(backColor), new Rectangle(indent, indent, this.Size.Width - 2 * indent, this.Size.Height - 2 * indent));
            pe.DrawString(messageText, textFont, textBrush, textRect, stringFormat);
            textFont.Dispose();
            textBrush.Dispose();
            stringFormat.Dispose();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            String text = (sender as Button).Text;
            switch (text)
            { 
                case "OK":
                    dialogResult = DialogResultEx.OK;
                    break;
                case"NO":
                    dialogResult = DialogResultEx.No;
                    break;
                case "Yes":
                    dialogResult = DialogResultEx.Yes;
                    break;
                case"Retry":
                    dialogResult = DialogResultEx.Retry;
                    break;
                case "Cancel":
                    dialogResult = DialogResultEx.Cancel;
                    break;
                case "GetInfo":
                    dialogResult = DialogResultEx.GetInfo;
                    break;
                case "Delete":
                    dialogResult = DialogResultEx.Delete;
                    break;
                case "Updata":
                    dialogResult = DialogResultEx.Updata;
                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}