using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    public class ClothClamp
    {
        private Point locatPoint;//位置坐标
        private Rectangle rect;//加布夹的矩形模型
        private bool direction;//加布夹方向，true为上面的加布夹
        private int minValueX;
        private int maxValueX;
        private int valueY;
        public Rectangle ClothClampRect
        {
            get {
                return rect;
            }
        }
        public Point ClothClampPoint
        {
            get {
                return locatPoint;
            }
        }
        public ClothClamp(Point point, int rangeX, int rangeY)
        {
            int indent = 5;
            int height = 30;
            if (point.Y < 0)
                direction = false;
            else
                direction = true;
            locatPoint = point;
            if (point.X == 0)
                height /= 2;
            if (direction)
            {
                valueY = point.Y - rangeY;
                rect = new Rectangle(point.X - indent, point.Y + height - indent, 2 * indent, height);
            }
            else
            {
                valueY = point.Y + rangeY;
                rect = new Rectangle(point.X - indent,point.Y + indent,2 * indent,height);
            }
            minValueX = point.X - rangeX;
            maxValueX = point.X + rangeX;
        }
        public Point[] RangeLinePoints()
        {
            Point[] rangePoints = new Point[4];
            int indent = 25;//
            if (direction)
            {
                rangePoints[0] = new Point(minValueX, valueY + indent);
                rangePoints[1] = new Point(minValueX, valueY);
                rangePoints[2] = new Point(maxValueX, valueY);
                rangePoints[3] = new Point(maxValueX, valueY + indent);
            }
            else
            {
                rangePoints[0] = new Point(minValueX,valueY - indent);
                rangePoints[1] = new Point(minValueX,valueY);
                rangePoints[2] = new Point(maxValueX,valueY);
                rangePoints[3] = new Point(maxValueX,valueY - indent);
            }
            return rangePoints;
        }
        public bool Contains(Point point1, Point point2)
        {
            bool contains = false;
            int diffY = point2.Y - point1.Y;
            int diffX = point2.X - point1.X;
            List<Point> linePointList = new List<Point>();
            if (diffX == 0)
            {
                int minY = 0, maxY = 0;
                if (point1.Y > point2.Y)
                {
                    maxY = point1.Y;
                    minY = point2.Y;
                }
                else
                {
                    minY = point1.Y;
                    maxY = point2.Y;
                }
                for (int i = minY; i <= maxY; i++)
                    linePointList.Add(new Point(point1.X, i));
            }
            else
            {
                double k = (double)diffY / (double)diffX;
                double b = point1.Y - k * point1.X;
                int pointY = 0;
                int minX = 0, maxX = 0;
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
                {
                    pointY = Convert.ToInt32(Math.Round(k * i + b, 0));
                    linePointList.Add(new Point(i, pointY));
                }
            }
            for (int i = 0; i < linePointList.Count; i++)
            {
                if (Contains(linePointList[i]) == true)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        public bool Contains(Point point)
        {
            bool contains = false;
            if (direction)
            {
                if (point.Y >= valueY)
                    contains = true;
            }
            else
            {
                if (point.Y <= valueY)
                    contains = true;
            }
            if (contains)
            {
                if (point.X >= minValueX && point.X <= maxValueX)
                    contains = true;
                else
                    contains = false;
            }
            return contains;
        }
    }
}
