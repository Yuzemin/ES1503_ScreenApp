using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class ImageButton : Control
    {
        private ImageButtonInfo imageButtonInfo;
        public event EventHandler ImageTypeChanged;
        #region 属性编辑
        public Color FrameNoramlColor
        {
            get
            {
                return imageButtonInfo.FrameNormalColor;
            }
            set
            {
                if (imageButtonInfo.FrameNormalColor != value)
                {
                    imageButtonInfo.FrameNormalColor = value;
                    this.Refresh();
                }
            }
        }
        public Color FramePressColor
        {
            get
            {
                return imageButtonInfo.FramePressColor;
            }
            set
            {
                if (imageButtonInfo.FramePressColor != value)
                {
                    imageButtonInfo.FramePressColor = value;
                    this.Refresh();
                }
            }
        }
        public ButtonStatus ButtonStatus
        {
            get
            {
                return imageButtonInfo.ButtonStatus;
            }
            set
            {
                if (imageButtonInfo.ButtonStatus != value)
                {
                    imageButtonInfo.ButtonStatus = value;
                    this.Refresh();
                }
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Refresh();
                }
            }
        }
        public ButtonType ButtonType
        {
            get
            {
                return imageButtonInfo.ButtonType;
            }
            set
            {
                imageButtonInfo.ButtonType = value;
            }
        }
        public ImageType ImageType
        {
            get
            {
                return imageButtonInfo.ImageType;
            }
            set
            {
                if (imageButtonInfo.ImageType != value)
                {
                    imageButtonInfo.ImageType = value;
                    ImageType imageType = imageButtonInfo.ImageType;
                    if (imageType != ImageType.Null)
                    {
                        String imageName = imageType.ToString();
                        String pressImagePath = String.Empty;
                        String normalImagePath = String.Empty;
                        String imagePath = String.Empty;
                        if (imageName.Length > 5)
                        {
                            imageName = imageName.Remove(imageName.Length - 5, 5);
                            imagePath = DefaultPath.DefaultPathEx.ImagePath;
                            normalImagePath = imagePath + "Normal" + imageName + ".jpg";
                            pressImagePath = imagePath + "Press" + imageName + ".jpg";
                            if (File.Exists(normalImagePath))
                                imageButtonInfo.ImageNormal = new Bitmap(normalImagePath);
                            if (File.Exists(pressImagePath))
                                imageButtonInfo.ImagePress = new Bitmap(pressImagePath);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        if (imageButtonInfo.ImageNormal != null)
                        {
                            imageButtonInfo.ImageNormal.Dispose();
                            imageButtonInfo.ImageNormal = null;
                        }
                        if (imageButtonInfo.ImagePress != null)
                        {
                            imageButtonInfo.ImagePress.Dispose();
                            imageButtonInfo.ImagePress = null;
                        }
                    }
                    OnImageTypeChanged(null);
                }


            }
        }
        #endregion
        public ImageButton()
        {
            InitializeComponent();
            imageButtonInfo = new ImageButtonInfo();
        }

        private Image GetCurrentImage()
        {
            Image buttonImage = null;
            if (imageButtonInfo.ButtonStatus == ButtonStatus.Normal)
            {
                if (imageButtonInfo.ImageNormal != null)
                    buttonImage = imageButtonInfo.ImageNormal;
            }
            else
            {
                if (imageButtonInfo.ImagePress == null)
                {
                    if (imageButtonInfo.ImageNormal != null)
                        buttonImage = imageButtonInfo.ImageNormal;
                }
                else
                    buttonImage = imageButtonInfo.ImagePress;
            }
            return buttonImage;
        }
        private Rectangle GetImageRectangle(Image currentImage)
        {
            Rectangle rectangle = Rectangle.Empty;
            if (currentImage != null)
                rectangle = new Rectangle(0, 0, currentImage.Width, currentImage.Height);
            return rectangle;
        }
        protected virtual void OnImageTypeChanged(EventArgs e)
        {
            if (ImageTypeChanged != null)
                ImageTypeChanged(this, e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (imageButtonInfo.ButtonType == ButtonType.PressButton)
            {
                String relateData = this.Name + this.Text;
                if (this.Tag != null)
                    relateData += this.Tag.ToString();
                if (ButtonEnable.GetButtonEnable(relateData))
                {
                    if (imageButtonInfo.ButtonStatus == ButtonStatus.Normal)
                        ButtonStatus = ButtonStatus.Press;
                    else
                        ButtonStatus = ButtonStatus.Normal;
                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (imageButtonInfo.ButtonType == ButtonType.PressButton)
            {
                String relateData = this.Name + this.Text;
                if (this.Tag != null)
                    relateData += this.Tag.ToString();
                if (ButtonEnable.GetButtonEnable(relateData))
                {
                    if (imageButtonInfo.ButtonStatus == ButtonStatus.Normal)
                        ButtonStatus = ButtonStatus.Press;
                    else
                        ButtonStatus = ButtonStatus.Normal;
                }
            }
            base.OnMouseUp(e);
        }
        protected override void OnClick(EventArgs e)
        {
            bool canChanged = true;
            if (imageButtonInfo.ButtonType == ButtonType.ClickButton)
            {
                String relateData = this.Name + this.Text;
                if (this.Tag != null)
                    relateData += this.Tag.ToString();
                if (ButtonEnable.GetButtonEnable(relateData))
                {
                    if (this.Tag != null)
                    {
                        String tag = this.Tag.ToString();
                        if (tag.LastIndexOf("NotChangeButton") != -1)
                            canChanged = false;
                    }
                    if (canChanged)
                    {
                        if (imageButtonInfo.ButtonStatus == ButtonStatus.Normal)
                            ButtonStatus = ButtonStatus.Press;
                        else
                            ButtonStatus = ButtonStatus.Normal;
                    }
                }
            }
            base.OnClick(e);
        }
        private void DrawString(Graphics pe)
        {
            if (this.Text == "")
                return;
            /********************************为控件绘制文本属性************************/
            StringFormat fontAlignMent = new StringFormat();
            String strText = this.Text;
            Color fontColor = Color.Empty;
            System.Drawing.Font textFont = new System.Drawing.Font(this.Font.Name, this.Font.Size, this.Font.Style);
            String tag = String.Empty;
            fontColor = this.ForeColor;
            System.Drawing.SolidBrush fontBrush = new System.Drawing.SolidBrush(fontColor);
            fontAlignMent.Alignment = StringAlignment.Center;//设置字体显示时候的对齐方式
            fontAlignMent.LineAlignment = StringAlignment.Center;
            System.Drawing.Rectangle boxRect = new System.Drawing.Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top,
                                                                                    this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
            pe.DrawString(this.Text, textFont, fontBrush, boxRect, fontAlignMent);
        }
        private void DrawFrame(Graphics pe)
        {
            if (imageButtonInfo.FrameNormalColor != Color.Empty)
            {
                int indent = 2;
                Rectangle[] frameRects = new Rectangle[4];
                Color frameColor = imageButtonInfo.FrameNormalColor;
                if (imageButtonInfo.ButtonStatus == ButtonStatus.Press && imageButtonInfo.FramePressColor != Color.Empty)
                    frameColor = imageButtonInfo.FramePressColor;
                frameRects[0] = new Rectangle(0, 0, this.Size.Width, indent);
                frameRects[1] = new Rectangle(this.Size.Width - indent, 0, indent, this.Size.Height);
                frameRects[2] = new Rectangle(0, 0, indent, this.Size.Height);
                frameRects[3] = new Rectangle(0, this.Size.Height - indent, this.Size.Width, indent);
                SolidBrush solidBrush = new SolidBrush(frameColor);
                for (int i = 0; i < frameRects.Length; i++)
                    pe.FillRectangle(solidBrush, frameRects[i]);
                solidBrush.Dispose();
                solidBrush = null;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // Calling the base class OnPaint
            Image currentImage = GetCurrentImage();
            Rectangle rectangle = GetImageRectangle(currentImage);
            if (rectangle != Rectangle.Empty)
                pe.Graphics.DrawImage(currentImage, this.ClientRectangle, rectangle, GraphicsUnit.Pixel);
            if (this.Text != String.Empty)
                DrawString(pe.Graphics);
            if (imageButtonInfo.FrameNormalColor != Color.Empty)
                DrawFrame(pe.Graphics);
            base.OnPaint(pe);
        }
    }
}
