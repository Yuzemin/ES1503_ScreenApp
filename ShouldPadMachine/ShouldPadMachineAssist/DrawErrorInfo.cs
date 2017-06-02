using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    /// <summary>
    /// 画错误数据类
    /// </summary>
    public class DrawErrorInfo:IDisposable
    {
        private Bitmap errorBitmap;
        private ErrorInfo[] errorInfos;
        private ShouldPadMachine.ShouldPadMachineModel.Region[] regions;
        private Rectangle rect;
        private Color backColor;
        public DrawErrorInfo(Rectangle rect,Color backColor)
        {
            this.backColor = backColor;
            this.rect = rect;
        }
        public void SetErrorInfos(ErrorInfo[] errorInfos)
        {
            this.errorInfos = errorInfos;
            regions = new ShouldPadMachine.ShouldPadMachineModel.Region[errorInfos.Length];
            int wide = 30;
            int wideCount = 0;
            int mould = 0;//求模
            int result = 0;//求商
            for (int i = 0; i < errorInfos.Length; i++)
            {
                mould = errorInfos[i].GetDataCount() % 5;
                result = errorInfos[i].GetDataCount() / 5;
                regions[i].StartY = rect.Y + wideCount * wide;
                if (mould != 0)
                    wideCount += result + 1;
                else
                    wideCount += result;
                if (wideCount == 0)
                    wideCount=1;
                regions[i].EndY = rect.Y + wideCount * wide;
            }
            int height;
            int width;
            if (wideCount * wide < rect.Height)
            {
                width = rect.Width + 21;
                height = rect.Height;
            }
            else
            {
                width = rect.Width-5;
                height = wideCount * wide;
            }
            errorBitmap = new Bitmap(width, height);
        }
        private void DrawErrorInfos(Graphics pe)
        {
            pe.Clear(backColor);
            String[] strErrorDatas;
            String strErrorID;
            Font fontErrorID = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Font fontErrorData = new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            StringFormat stringFormat = new StringFormat();
            Rectangle rectErrorID;
            Rectangle[] rectErrorDatas;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            StringFormat stringFormat1 = new StringFormat();
            stringFormat1.Alignment = StringAlignment.Near;
            stringFormat1.LineAlignment = StringAlignment.Center;
            Point pointLine1 = new Point();
            Point pointLine2 = new Point();
            pointLine1.X = rect.X;
            pointLine2.X = rect.X + errorBitmap.Width;
            Pen drawPen = new Pen(Color.Black);
            String strData = String.Empty;
            for (int i = 0; i < regions.Length; i++)
            {
                pointLine1.Y = regions[i].StartY;
                pointLine2.Y = pointLine1.Y;
                pe.DrawLine(drawPen, pointLine1.X, pointLine1.Y, pointLine2.X, pointLine2.Y);
                pointLine1.Y = regions[i].EndY;
                pointLine2.Y = pointLine1.Y;
                pe.DrawLine(drawPen, pointLine1.X, pointLine1.Y, pointLine2.X, pointLine2.Y);
                strErrorID = "E" + errorInfos[i].ErrorID.ToString() + "：";
                int dataStringLength = 0;
                dataStringLength = errorInfos[i].GetDataCount() / 5;
                if (errorInfos[i].GetDataCount() % 5 == 0)
                    dataStringLength--;
                strErrorDatas = new string[dataStringLength + 1];
                for (int j = 0; j < errorInfos[i].ErrorData.Length; j++)
                {
                    strData = errorInfos[i].ErrorData[j].ToString();
                    strData = strData.PadLeft(6,' ');
                    strErrorDatas[j / 5] += strData + " ";
                }
                pointLine1.Y = regions[i].StartY;
                pointLine2.Y = pointLine1.Y;
                rectErrorID = new Rectangle(pointLine1.X, pointLine1.Y, rect.Width / 6, regions[i].EndY - regions[i].StartY);
                pe.DrawString(strErrorID, fontErrorID, solidBrush, rectErrorID, stringFormat);
                rectErrorDatas = new Rectangle[strErrorDatas.Length];
                int gain = regions[i].EndY - regions[i].StartY;
                if(rectErrorDatas.Length !=0)
                    gain = gain / rectErrorDatas.Length;//将高度平分
                for (int j = 0; j < rectErrorDatas.Length; j++)//获得平分后的矩形
                {
                    rectErrorDatas[j] = new Rectangle(rectErrorID.X + rectErrorID.Width * 3 / 2, rectErrorID.Y + j * gain, rect.Width - rectErrorID.Width, rectErrorID.Height / rectErrorDatas.Length);
                }
                for (int j = 0; j < rectErrorDatas.Length; j++)
                {
                    pe.DrawString(strErrorDatas[j], fontErrorData, solidBrush, rectErrorDatas[j], stringFormat1);
                }
            }
        }
        public void Dispose()
        {
            errorInfos = null;
            regions = null;
        }
        public Bitmap GetBitmap()
        {
            DrawErrorInfos(Graphics.FromImage(errorBitmap));
            return errorBitmap;
        }
    }
}
