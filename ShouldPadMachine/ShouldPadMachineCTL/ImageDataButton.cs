using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class ImageDataButton : DataButton
    {
        private ImageDataButtonInfo imageDataButtonInfo;
        public ImageDataButton()
        {
            InitializeComponent();
            imageDataButtonInfo = new ImageDataButtonInfo();
        }
        #region
        public int Indent
        {
            get {
                return imageDataButtonInfo.Indent;
            }
            set {
                imageDataButtonInfo.Indent = value;
            }
        }
        public int ImageWidth
        {
            get {
                return imageDataButtonInfo.ImageWidth;
            }
            set {
                imageDataButtonInfo.ImageWidth = value;
            }
        }
        public Color ColorPress
        {
            get {
                return imageDataButtonInfo.ColorPress;
            }
            set {
                imageDataButtonInfo.ColorPress = value;
            }
        }
        public Color ColorNormal
        {
            get {
                return imageDataButtonInfo.ColorNormal;
            }
            set {
                imageDataButtonInfo.ColorNormal = value;
            }
        }
        public ButtonStatus ButtonStatus
        {
            get
            {
                return imageDataButtonInfo.ButtonStatus;
            }
            set
            {
                if (imageDataButtonInfo.ButtonStatus != value)
                {
                    imageDataButtonInfo.ButtonStatus = value;
                    this.Refresh();
                }
            }
        }
        public ImageType ImageType
        {
            get
            {
                return imageDataButtonInfo.ImageType;
            }
            set
            {
                imageDataButtonInfo.ImageType = value;
                if (imageDataButtonInfo.ImageType != ImageType.Null)
                {
                    String imageName = imageDataButtonInfo.ImageType.ToString();
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
                            imageDataButtonInfo.ImageNormal = new Bitmap(normalImagePath);
                        if (File.Exists(pressImagePath))
                            imageDataButtonInfo.ImagePress = new Bitmap(pressImagePath);
                        this.Refresh();
                    }
                }
            }
        }
        #endregion
        private Image GetCurrentImage()
        {
            Image buttonImage = null;
            if (imageDataButtonInfo.ButtonStatus == ButtonStatus.Normal)
            {
                if (imageDataButtonInfo.ImageNormal != null)
                    buttonImage = imageDataButtonInfo.ImageNormal;
            }
            else
            {
                if (imageDataButtonInfo.ImagePress == null)
                {
                    if (imageDataButtonInfo.ImageNormal != null)
                        buttonImage = imageDataButtonInfo.ImageNormal;
                }
                else
                    buttonImage = imageDataButtonInfo.ImagePress;
            }
            return buttonImage;
        }
        private Color GetCurrentColor()
        {
            Color color = Color.Empty;
            if (imageDataButtonInfo.ButtonStatus == ButtonStatus.Normal)
                color = imageDataButtonInfo.ColorNormal;
            else
                color = imageDataButtonInfo.ColorPress;
            return color;
        }
        private Rectangle GetImageRectangle(Image currentImage)
        {
            Rectangle rectangle = Rectangle.Empty;
            if (currentImage != null)
                rectangle = new Rectangle(0, 0, currentImage.Width, currentImage.Height);
            return rectangle;
        }
        protected override void OnClick(EventArgs e)
        {
            String relateData = this.Name + this.Text;
            if (this.Tag != null)
                relateData += this.Tag.ToString();
            if (ButtonEnable.GetButtonEnable(relateData))
            {
                if (ButtonStatus == ButtonStatus.Normal)
                    ButtonStatus = ButtonStatus.Press;
                else
                    ButtonStatus = ButtonStatus.Normal;
            }
            base.OnClick(e);
        }
        protected override Rectangle GetTextRect()
        {
            Rectangle validRect = GetValidRect();
            Rectangle txtRect = new Rectangle(validRect.X + imageDataButtonInfo.ImageWidth,validRect.Y,validRect.Width - imageDataButtonInfo.ImageWidth,validRect.Height);
            return txtRect;
        }
        private Rectangle GetValidRect()
        {
            int indent = imageDataButtonInfo.Indent;
            Rectangle validRect = new Rectangle(indent, indent, this.ClientRectangle.Width - 2 * indent-1, this.ClientRectangle.Height - 2 * indent-1);
            return validRect;
        }
        private void DrawFrame(Graphics pe)
        {
            int indent = imageDataButtonInfo.Indent;
            if (indent > 0)
            {
                Rectangle frameRect = GetValidRect();
                Pen framePen = new Pen(BackColor, indent);
                pe.DrawRectangle(framePen, frameRect);
                framePen.Dispose();
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码

            // Calling the base class OnPaint
            Image currentImage = GetCurrentImage();
            Rectangle imageRect = GetImageRectangle(currentImage);
            Rectangle validRect = GetValidRect();
            if (currentImage != null)
            {
                Rectangle srcRect = new Rectangle(validRect.X,validRect.Y,imageDataButtonInfo.ImageWidth,validRect.Height);
                pe.Graphics.DrawImage(currentImage, srcRect, imageRect, GraphicsUnit.Pixel);
            }
            Rectangle txtRect = GetTextRect();
            Color color = GetCurrentColor();
            pe.Graphics.FillRectangle(new SolidBrush(color), txtRect);
            DrawFrame(pe.Graphics);
            base.OnPaint(pe);
        }
    }
}
