using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace ShouldPadMachine.ShouldPadMachineDWL
{
    public class Coordinates
    {
        private Point centerPoint = Point.Empty;
        public Coordinates()
        {
        }
        public Coordinates(int width, int height)
            : this()
        {
            centerPoint = new Point(width / 2, height / 2);
        }
        public Coordinates(Size size)
            : this(size.Width, size.Height)
        {
        }
        public Coordinates(Point point)//由中心点构造坐标类
        {
            centerPoint = point;
        }
        public Point ChangeToVirutal(int x, int y)
        {
            Point retPoint = Point.Empty;
            retPoint.Y = centerPoint.Y - y;
            retPoint.X = x - centerPoint.X;
            return retPoint;
        }
        public Point ChangeToVirutal(Point point)//转换成虚拟坐标
        {
            return ChangeToVirutal(point.X, point.Y);
        }
        public Point ChangeToActual(int x, int y)
        {
            Point retPoint = new Point();
            retPoint.X = x + centerPoint.X;
            retPoint.Y = centerPoint.Y - y;
            return retPoint;
        }
        public Point GetCenterPoint()
        {
            return this.centerPoint;
        }
        public Point ChangeToActual(Point point)//转换成实际的坐标，即计算机坐标
        {
            return ChangeToActual(point.X, point.Y);
        }
        public void Dispose()
        {
            centerPoint = Point.Empty;
        }
    }
}
