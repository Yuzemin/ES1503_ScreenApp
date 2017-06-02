using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineDWL
{
    public abstract class LocatShape:IDisposable
    {
        protected bool haveNewPoints;
        protected int shapeSize = 0;
        protected Point[] shapePoints;//位置图形的所有点的坐标
        protected Color[] pointColors;//位置图形覆盖的所有点的颜色
        protected Point oldLocatPoint;
        protected Point locatPoint;//位置图形的中心点
        private Color shapeColor;//位置图形的颜色
        public Point LocatPoint
        {
            get {
                return locatPoint;
            }
        }
        public Color ShapeColor
        {
            get {
                return shapeColor;
            }
        }
        public LocatShape(Color shapeColor)
        {
            this.shapeColor = shapeColor;
        }
        protected abstract Point[] GetShapePoints();
        public void SetPointColor(Color[] colors)
        {
            pointColors = colors;
        }
        public Color[] GetPointColors()
        {
            Color[] colors = pointColors;
            pointColors = null;
            return colors;
        }
        public Point[] GetLocatShapePoints()
        {
            if (haveNewPoints)
            {
                haveNewPoints = false;
                shapePoints = GetShapePoints();
            }
            return shapePoints;
        }
        public void Dispose()
        {
            shapePoints = null;
            pointColors = null;
            oldLocatPoint = Point.Empty;
        }
        public virtual void SetPointIn(Point point)
        {
            haveNewPoints = true;
            locatPoint = point;
        }
        ~LocatShape()
        {
            Dispose();
        }
    }
    public class CircleDot : LocatShape
    {
        private List<Point> pointList;
        public CircleDot()
            : this(Color.Black)
        { }
        public CircleDot(Color color)
            : base(color)
        {
            shapeSize = 4;
        }
        public CircleDot(Color color, int shapeSize)
            : base(color)
        {
            this.shapeSize = shapeSize;
        }
        protected Point[] GetShapePoints(Point[] shapePoints)
        {
            if (oldLocatPoint != locatPoint || locatPoint == Point.Empty)
            {
                if (shapePoints != null)
                {
                    for (int i = 0; i < shapePoints.Length; i++)
                    {
                        shapePoints[i].X += locatPoint.X - oldLocatPoint.X;
                        shapePoints[i].Y += locatPoint.Y - oldLocatPoint.Y;
                    }
                }
                else
                {
                    FillBoundary(locatPoint.X, locatPoint.Y);
                    if (pointList != null)
                        shapePoints = pointList.ToArray();
                }
                oldLocatPoint = locatPoint;
            }
            return shapePoints;
        }
        protected override Point[] GetShapePoints()
        {
            return GetShapePoints(shapePoints);
        }
        private bool EfficientPoint(int x, int y)
        {
            bool efficientPoint = true;
            if (pointList != null)
            {
                for (int i = 0; i < pointList.Count; i++)
                {
                    if (pointList[i].X == x && pointList[i].Y == y)
                        efficientPoint = false;
                }
            }
            if (efficientPoint)
            {
                double x2 = (x - locatPoint.X) * (x - locatPoint.X);
                double y2 = (y - locatPoint.Y) * (y - locatPoint.Y);
                int direct = (int)Math.Round(Math.Sqrt(x2 + y2));
                if (direct > shapeSize)
                    efficientPoint = false;
            }
            return efficientPoint;
        }
        private void FillBoundary(int x, int y)//种子填充法
        {
            if (EfficientPoint(x,y))
            {
                if (pointList == null)
                    pointList = new List<Point>();
                pointList.Add(new Point(x, y));
                FillBoundary(x - 1, y);
                FillBoundary(x, y - 1);
                FillBoundary(x + 1, y);
                FillBoundary(x, y + 1);
            }
        }
    }
    public class CircleDotLine : CircleDot
    {
        private Nullable<Point> firstPoint;
        private Nullable<Point> secondPoint;
        private Point[] circleDotPoints;
        public CircleDotLine()
            : this(Color.Black)
        { }
        public CircleDotLine(Color color)
            : base(color,4)
        {
        }
        public CircleDotLine(Color color, int shapeSize)
            : base(color,shapeSize)
        {
        }
        public void SetPointIn(Point point, Nullable<Point> firstPoint, Nullable<Point> secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            base.SetPointIn(point);
        }

        protected override Point[] GetShapePoints()
        {
            List<Point> shapePointList = new List<Point>();
            if (firstPoint!= null)
                shapePointList.AddRange(GetLinePoints(firstPoint.Value,locatPoint));
            if (secondPoint != null)
                shapePointList.AddRange(GetLinePoints(secondPoint.Value, locatPoint));
            circleDotPoints = base.GetShapePoints(circleDotPoints);
            shapePointList.AddRange(circleDotPoints);
            return shapePointList.ToArray();
        }
        private Point[] GetLinePoints(Point point1, Point point2)
        {
            List<Point> shapePointList = new List<Point>();
            if (point1.X == point2.X)
            {
                int minY = point1.Y;
                int maxY = point1.Y;
                if (point1.Y > point2.Y)
                {
                    maxY = point1.Y;
                    minY = point2.Y;
                }
                else
                {
                    maxY = point2.Y;
                    minY = point1.Y;
                }
                for (int i = minY; i <= maxY; i++)
                    shapePointList.Add(new Point(point1.X,i));
            }
            else if (point1.Y == point2.Y)
            {
                int minX = point1.X;
                int maxX = point1.X;
                if (point1.X > point2.X)
                {
                    maxX = point1.X;
                    minX = point2.X;
                }
                else
                {
                    maxX = point2.X;
                    minX = point1.X;
                }
                for (int i = minX; i <= maxX; i++)
                    shapePointList.Add(new Point(i,point1.Y));
            }
            else
            {
                int diffY = point1.Y - point2.Y;
                int diffX = point1.X - point2.X;
                double k = (double)diffY / (double)diffX;
                double b = point2.Y - k * point2.X;
                int maxX = point1.X;
                int minX = point1.X;
                int maxY = point1.Y;
                int minY = point1.Y;
                int value = 0;
                if (Math.Abs(k) <= 1)
                {
                    if (point2.X > point1.X)
                    {
                        maxX = point2.X;
                        minX = point1.X;
                    }
                    else
                    {
                        maxX = point1.X;
                        minX = point2.X;
                    }
                    for (int i = minX; i <= maxX; i++)
                    {
                        value = (int)Math.Round((k * i + b), 0);
                        shapePointList.Add(new Point(i, value));
                    }
                }
                else
                {
                    if (point2.Y > point1.Y)
                    {
                        maxY = point2.Y;
                        minY = point1.Y;
                    }
                    else
                    {
                        maxY = point1.Y;
                        minY = point2.Y;
                    }
                    for (int i = minY; i <= maxY; i++)
                    {
                        value = (int)Math.Round((i - b)/k,0);
                        shapePointList.Add(new Point(value,i));
                    }
                }
            }
            return shapePointList.ToArray();
        }
    }

}
