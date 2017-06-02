using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineDWL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineHelper;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class DrawShapeDC
    {
        private ShapeDC shapeDC;
        private Coordinates coordinates;
        public Bitmap ShapeBitmap
        {
            get
            {
                return shapeDC.Bitmap;
            }
        }
        public DrawShapeDC(Size backGroundSize)
        {
            Bitmap bimap = new Bitmap(backGroundSize.Width, backGroundSize.Height);
            shapeDC = new ShapeDC(bimap);
            coordinates = new Coordinates(backGroundSize);
        }
        public void DrawRange(Point[] rangePoints)
        {
            Point[] copyPoints = new Point[rangePoints.Length];
            rangePoints.CopyTo(copyPoints, 0);
            for (int i = 0; i < copyPoints.Length; i++)
                copyPoints[i] = coordinates.ChangeToActual(copyPoints[i]);
            shapeDC.DrawRange(copyPoints, DefaultColor.DefaultColorEx.DefaultRangeColor);
        }
        public void DrawClothCramp(Rectangle rect,Point point)//画加布器
        {
            rect.Location = coordinates.ChangeToActual(rect.Location);
            if (rect.Location.Y < 0)
            {
                rect.Size = new Size(rect.Width, rect.Height + rect.Y);
                rect.Location = new Point(rect.Location.X, 0);
            }
            else if ((rect.Location.Y + rect.Height) > shapeDC.Bitmap.Height)
            {
                rect.Size = new Size(rect.Width,shapeDC.Bitmap.Height - rect.Location.Y);
            }
            shapeDC.DrawSingleRect(rect,DefaultColor.DefaultColorEx.DefaultShapeColor);
            point = coordinates.ChangeToActual(point);
            shapeDC.DrawSinglePoint(point, DefaultColor.DefaultColorEx.DefaultShapeColor);
        }
        public void DrawNormalShape(ShapePointInfo shapePointInfos)
        {
            Point[] copyPoints = new Point[shapePointInfos.ShapePoints.Length];
            shapePointInfos.ShapePoints.CopyTo(copyPoints, 0);
            for (int i = 0; i < copyPoints.Length; i++)
                copyPoints[i] = coordinates.ChangeToActual(copyPoints[i]);
            shapePointInfos.ShapePoints = copyPoints;
            shapeDC.DrawNormalShape(shapePointInfos);
        }

        public void DrawNormalShapeSection(Point[] sectionPoints, Point[] erasePoints, bool eraseEnable)
        {
            Point[] copyPoints = new Point[sectionPoints.Length];
            sectionPoints.CopyTo(copyPoints,0);
            for (int i = 0; i < copyPoints.Length; i++)
                copyPoints[i] = coordinates.ChangeToActual(copyPoints[i]);
            if (erasePoints != null)
            {
                for (int i = 0; i < erasePoints.Length; i++)
                    erasePoints[i] = coordinates.ChangeToActual(erasePoints[i]);
            }
            shapeDC.DrawNormalShapeSection(copyPoints, erasePoints, eraseEnable);

        }
        public Color[] DrawLocatShape(Point[] shapePoints, Color pointsColor)
        {
            Point[] copyPoints = new Point[shapePoints.Length];
            shapePoints.CopyTo(copyPoints,0);
            for(int i = 0;i<copyPoints.Length;i++)
                copyPoints[i] = coordinates.ChangeToActual(copyPoints[i]);
            return shapeDC.DrawLocatShape(copyPoints, pointsColor);
        }
        public void EraseLocatShape(Point[] shapePoints, Color[] pointsColor)
        {
            if (pointsColor != null)
            { 
                Point[] copyPoints = new Point[shapePoints.Length];
                shapePoints.CopyTo(copyPoints, 0);
                for (int i = 0; i < copyPoints.Length; i++)
                    copyPoints[i] = coordinates.ChangeToActual(copyPoints[i]);
                shapeDC.EraseLocatShape(copyPoints, pointsColor);
            }
        }
        public void DrawString(String locatInfo,Point bottom)
        {
            shapeDC.DrawString(locatInfo, DefaultColor.DefaultColorEx.DefaultStringColor, bottom);
        }
        public void EraseString()
        {
            shapeDC.EraseString();
        }
        public void ClearBitmap()
        {
            if (shapeDC != null)
                shapeDC.ClearBitmap();
        }
    }
}
