using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineHelper;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineDWL
{
    /// <summary>
    /// 画图的类，接受的点的坐标均为计算机屏幕坐标,Y轴向下增长
    /// </summary>
    class ShapeDC
    {
        private Bitmap bitmap;
        private Rectangle textRect;
        public Bitmap Bitmap
        {
            get {
                return bitmap;
            }
        }
        public ShapeDC(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            ClearBitmap();
        }
        public void DrawRange(Point[] rangePoints, Color rangeColor)
        {
            Pen rangePen = new Pen(rangeColor);
            Graphics pe = Graphics.FromImage(bitmap);
            rangePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = 1; i < rangePoints.Length; i++)
            {
                pe.DrawLine(rangePen, rangePoints[i - 1].X, rangePoints[i - 1].Y, rangePoints[i].X, rangePoints[i].Y);
            }
            pe.Dispose();
        }
        public void DrawNormalShapeSection(Point[] shapePoints, Point[] earsePoints,bool eraseEnable)
        {
            DefaultColor defaultColor = DefaultColor.DefaultColorEx;
            Pen drawPen = new Pen(defaultColor.DefaultBackGroundColor);
            Color pointColor = defaultColor.DefaultBackGroundColor;
            drawPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (!eraseEnable)
            {
                drawPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                pointColor = defaultColor.DefaultShapeColor;
                drawPen.Color = defaultColor.DefaultShapeColor;
            }
            Graphics pe = Graphics.FromImage(bitmap);
            for (int i = 1; i < shapePoints.Length; i++)
                pe.DrawLine(drawPen, shapePoints[i - 1].X, shapePoints[i - 1].Y, shapePoints[i].X, shapePoints[i].Y);
            if (earsePoints != null)
            {
                for (int i = 0; i < earsePoints.Length; i++)
                {
                    DrawSinglePoint(pe, earsePoints[i], pointColor);
                    if(eraseEnable)
                        DrawDottSinglePoint(pe, earsePoints[i], defaultColor.DefaultShapeColor);
                }
            }
            pe.Dispose();
        }
        //public void EraseNormalShapeSection(Point[] shapePoints,Point[] earsePoints)
        //{
        //    DefaultColor defaultColor = DefaultColor.DefaultColorEx;
        //    Pen drawPen = new Pen(defaultColor.DefaultBackGroundColor);
        //    Color pointColor = defaultColor.DefaultBackGroundColor;
        //    Graphics pe = Graphics.FromImage(bitmap);
        //    for (int i = 1; i < shapePoints.Length; i++)
        //        pe.DrawLine(drawPen, shapePoints[i - 1].X, shapePoints[i - 1].Y, shapePoints[i].X, shapePoints[i].Y);
        //    if (earsePoints != null)
        //    {
        //        for (int i = 0; i < earsePoints.Length; i++)
        //            DrawSinglePoint(pe, earsePoints[i], pointColor);
        //    }
        //    pe.Dispose();
        //}
        public void DrawNormalShape(ShapePointInfo shapePointInfos)
        {
            Point[] shapePoints = shapePointInfos.ShapePoints;
            DefaultColor defaultColor = DefaultColor.DefaultColorEx;
            int[] errorPointIndexs = shapePointInfos.ErrorPointIndexs;
            int[] warnPointIndexs = shapePointInfos.WarnPointIndex;
            Pen drawPen = new Pen(defaultColor.DefaultShapeColor);
            Graphics pe = Graphics.FromImage(bitmap);
            Color pointColor = defaultColor.DefaultShapeColor;
            for (int i = 1; i < shapePoints.Length; i++)
            {
                pointColor = shapePointInfos.ShapeColor;
                drawPen.Color = defaultColor.DefaultShapeColor;
                if (warnPointIndexs != null)
                {
                    if (Array.IndexOf(warnPointIndexs, i) != -1)
                        drawPen.Color = defaultColor.DefalultWarnColor;
                }
                if (errorPointIndexs != null)
                {
                    if (Array.IndexOf(errorPointIndexs, i) != -1)
                    {
                        drawPen.Color = defaultColor.DefaultIrregularColor;
                        pointColor = defaultColor.DefaultIrregularColor;
                    }
                    else if (Array.IndexOf(errorPointIndexs, i - 1) != -1)
                        drawPen.Color = defaultColor.DefaultIrregularColor;
                }
                pe.DrawLine(drawPen, shapePoints[i - 1].X, shapePoints[i - 1].Y, shapePoints[i].X, shapePoints[i].Y);
                if (i == 1)
                {
                    if (errorPointIndexs != null)
                    {
                        if (Array.IndexOf(errorPointIndexs, i - 1) != -1)
                            pointColor = defaultColor.DefaultIrregularColor;
                    }
                    DrawSinglePoint(pe,shapePoints[0], pointColor);
                }
                DrawSinglePoint(pe,shapePoints[i], pointColor);
            }
            pe.Dispose();
        }
        private void DrawSinglePoint(Graphics pe,Point shapePoint, Color pointColor)
        {
            SolidBrush pointBrush = new SolidBrush(pointColor);
            Rectangle pointRect = new Rectangle();
            Size pointSize = DefaultValue.DefaultValueEx.DefaultPointSize;
            pointRect.X = shapePoint.X - pointSize.Width / 2;
            pointRect.Y = shapePoint.Y - pointSize.Height / 2;
            pointRect.Size = pointSize;
            pe.FillEllipse(pointBrush, pointRect);
            pe.Dispose();
        }
        private void DrawDottSinglePoint(Graphics pe, Point shapePoint, Color pointColor)
        {
            Pen drawPen = new Pen(pointColor);
            Rectangle pointRect = new Rectangle();
            Size pointSize = DefaultValue.DefaultValueEx.DefaultPointSize;
            pointRect.X = shapePoint.X - pointSize.Width / 2;
            pointRect.Y = shapePoint.Y - pointSize.Height / 2;
            pointRect.Size = pointSize;
            pe.DrawEllipse(drawPen, pointRect);
            pe.Dispose();
        }
        public void DrawSinglePoint(Point shapePoint,Color pointColor)
        {
            Graphics pe = Graphics.FromImage(bitmap);
            SolidBrush pointBrush = new SolidBrush(pointColor);
            Rectangle pointRect = new Rectangle();
            Size pointSize = DefaultValue.DefaultValueEx.DefaultPointSize;
            pointRect.X = shapePoint.X - pointSize.Width / 2;
            pointRect.Y = shapePoint.Y - pointSize.Height / 2;
            pointRect.Size = pointSize;
            pe.FillEllipse(pointBrush, pointRect);
            pe.Dispose();
        }
        public void DrawSingleRect(Rectangle rect, Color color)
        {
            Graphics pe = Graphics.FromImage(bitmap);
            Pen drawPen = new Pen(color);
            pe.DrawRectangle(drawPen, rect);
            pe.FillRectangle(new SolidBrush(Color.White),rect);
            pe.Dispose();
        }
        public Color[] DrawLocatShape(Point[] shapePoints, Color pointsColor)//画坐标系列图形，返回覆盖掉的颜色坐标
        {
            Color[] colors = GetPointsColor(shapePoints);
            for (int i = 0; i < shapePoints.Length; i++)
                SetPointColor(shapePoints[i], pointsColor);
            return colors;
        }
        public void EraseLocatShape(Point[] shapePoints, Color[] pointsColor)
        {
            if (pointsColor != null)
            { 
                Point[] copyPoints = new Point[shapePoints.Length];
                shapePoints.CopyTo(copyPoints, 0);
                for (int i = 0; i < copyPoints.Length; i++)
                    SetPointColor(copyPoints[i], pointsColor[i]);
            }
        }
        /// <summary>
        /// info:要显示的数据
        /// color:所用的颜色
        /// 字体矩形的最低点
        /// </summary>
        /// <param name="info"></param>
        /// <param name="color"></param>
        /// <param name="bottom"></param>
        public void DrawString(String info,Color color,Point bottom)
        {
            DefaultColor defaultColor = DefaultColor.DefaultColorEx;
            Graphics pe = Graphics.FromImage(bitmap);
            SolidBrush infoBrush = new SolidBrush(color);
            Font infoFont = new Font(FontFamily.GenericSerif, 10, FontStyle.Regular);
            SizeF infoSizeF = pe.MeasureString(info, infoFont);
            Rectangle rect = new Rectangle(bottom.X - (int)infoSizeF.Width - 5,bottom.Y - (int)infoSizeF.Height - 5,(int)infoSizeF.Width + 10,(int)infoSizeF.Height + 10);
            if(textRect != null && textRect != Rectangle.Empty)
                pe.FillRectangle(new SolidBrush(defaultColor.DefaultBackGroundColor), textRect);
            textRect = rect;
            pe.DrawString(info, infoFont, infoBrush, rect);
            pe.Dispose();
        }
        public void EraseString()
        {
            DefaultColor defaultColor = DefaultColor.DefaultColorEx;
            Graphics pe = Graphics.FromImage(bitmap);
            if (textRect != null && textRect != Rectangle.Empty)
                pe.FillRectangle(new SolidBrush(defaultColor.DefaultBackGroundColor), textRect);
        }
        private void SetPointColor(Point point, Color color)
        {
            bitmap.SetPixel(point.X, point.Y, color);
        }
        private Color[] GetPointsColor(Point[] points)
        { 
            Color[] colors = new Color[points.Length];
            for (int i = 0; i < colors.Length; i++)
                colors[i] = bitmap.GetPixel(points[i].X,points[i].Y);
            return colors;
        }
        public void ClearBitmap()
        {
            DefaultColor defaultColor = DefaultColor.DefaultColorEx;
            Graphics pe = Graphics.FromImage(bitmap);
            pe.Clear(defaultColor.DefaultBackGroundColor);
            pe.Dispose();
        }
        public void Dispose()
        {
            if (bitmap != null)
                bitmap.Dispose();
            bitmap = null;
        }
    }
}
