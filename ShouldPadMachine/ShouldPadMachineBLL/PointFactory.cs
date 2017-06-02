using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class PointFactory
    {
        private List<Point[]> sectionPointList;//段中的点
        public PointFactory()
        {
            sectionPointList = new List<Point[]>();
        }
        public Point[] LoadShapePoints(Point[] points,double enlarge)
        {
            List<Point> shapePointList = new List<Point>();
            List<Point[]> sectionPointList = new List<Point[]>();//段中的点
            List<Point> linePointList = new List<Point>();
            List<Point[]> sectionAllPointList = new List<Point[]>();//一段中所有点的坐标
            //对花型进行分段
            if (points.Length < 3)
                sectionPointList.Add(points);
            else
            {
                linePointList.Add(points[0]);
                linePointList.Add(points[1]);
                for (int i = 0; i < points.Length; i ++)
                {
                    if (CheckLinePoint(points[i], points[i + 1], points[i + 2]))
                        linePointList.Add(points[i + 2]);
                    else
                    {
                        sectionPointList.Add(linePointList.ToArray());
                        linePointList.Clear();
                        linePointList.Add(points[i + 1]);
                        linePointList.Add(points[i + 2]);
                    }
                    if ((i + 2) == (points.Length - 1))
                    {
                        sectionPointList.Add(linePointList.ToArray());
                        linePointList.Clear();
                        break;
                    }
                }
            }
            for (int i = 0; i < sectionPointList.Count; i++)//获取段上所有点
            {
                linePointList.Clear();
                if (sectionPointList[i].Length > 5)
                { 
                    
                }
                for (int j = 1; j < sectionPointList[i].Length; j++)
                    linePointList.AddRange(GetLinePoints(sectionPointList[i][j - 1], sectionPointList[i][j]));

                sectionAllPointList.Add(linePointList.ToArray());
            }
            double[] gauges;
            if (sectionAllPointList.Count <= 1)
                return shapePointList.ToArray();
            for (int i = 0; i < sectionAllPointList.Count; i++)//取出点的间距，将enlarge作用于它得出新的间距
            {
                gauges = new double[sectionPointList[i].Length - 1];
                for (int j = 1; j < sectionPointList[i].Length; j++)
                {
                    gauges[j - 1] = GetLineDistance(sectionPointList[i][j - 1], sectionPointList[i][j]) * enlarge;
                }
                sectionPointList[i] = GetEnlargePoints(sectionAllPointList[i],gauges,enlarge>=1?false:true); 
            }
            for (int i = 0; i < sectionPointList.Count; i++)
            {
                if(i != 0)
                    shapePointList.RemoveAt(shapePointList.Count - 1);
                shapePointList.AddRange(sectionPointList[i]);
            }
            return shapePointList.ToArray();
        }
        private double GetLineDistance(Point point1, Point point2)
        {
            double distance = 0;
            distance = (point2.X - point1.X) *(point2.X - point1.X);
            distance += (point2.Y - point1.Y) * (point2.Y - point1.Y);
            distance = Math.Round(Math.Sqrt(distance),1);
            return distance;
        }
        private Point[] GetEnlargePoints(Point[] points, double[] gauges, bool lessenFlag)
        {
            List<Point> enlargePointList = new List<Point>();
            Point point;
            double distance = 0;
            double preDistance = 0;
            int gaugeIndex = 0;
            double maxGauges;
            int smallNeedleIndex;
            Point[] smallNeedlePoints = null;
            int pointLength = points.Length;
            int gaugeLength = gauges.Length;
            if (gauges.Length > 5 && lessenFlag)
            {
                maxGauges = gauges[0];
                smallNeedleIndex = gauges.Length;
                for (int i = 0; i < gauges.Length; i++)
                {
                    if (gauges[i] > maxGauges)
                        maxGauges = gauges[i];
                }
                for (int i = 0; i < 5; i++)   //寻找后五针中是否有小针，通过smallNeedleIndex记录小针的下标索引
                {
                    if (gauges[gauges.Length - 1 - i] <= maxGauges / 2)
                    {
                        smallNeedleIndex = gauges.Length - i-1;
                        break;
                    }
                }
                if (smallNeedleIndex < gauges.Length)
                {
                    gaugeLength = smallNeedleIndex;
                    point = points[points.Length - 1];
                    gaugeIndex = gauges.Length - 1;
                    for (int i = points.Length - 2; i >= 0; i--)
                    {
                        distance = GetLineDistance(points[i], point);
                        if (distance >= gauges[gaugeIndex])
                        {
                            enlargePointList.Add(points[i]);
                            point = points[i];
                            if (smallNeedleIndex == gaugeIndex)
                            {
                                pointLength = i;
                                break;
                            }
                            gaugeIndex--;
                        }
                    }
                    if (enlargePointList.Count > 0)
                    {
                        smallNeedlePoints = new Point[enlargePointList.Count];
                        for (int i = enlargePointList.Count - 1; i >= 0; i--)
                            smallNeedlePoints[enlargePointList.Count - 1 -i] = enlargePointList[i];
                    }
                    enlargePointList.Clear();
                }
            }
            point = points[0];
            enlargePointList.Add(point);
            gaugeIndex = 0;
            for (int i = 1; i < pointLength; i++)
            {
                distance = GetLineDistance(points[i], point);
                if (distance >= gauges[gaugeIndex])
                {
                    enlargePointList.Add(points[i]);
                    point = points[i];
                    gaugeIndex++;
                    if (gaugeIndex == gaugeLength)
                        gaugeIndex = gaugeLength - 1;
                }
            }
            
            if (enlargePointList[enlargePointList.Count - 1] != points[pointLength - 1])
                enlargePointList.Add(points[pointLength - 1]);
            if (enlargePointList.Count > 2)
            {
                int length = enlargePointList.Count;
                preDistance = GetLineDistance(enlargePointList[length - 3], enlargePointList[length - 2]);
                distance = GetLineDistance(enlargePointList[length - 2], enlargePointList[length - 1]);
                if (distance * 2 < preDistance)
                    enlargePointList.RemoveAt(length - 2);
            }
            if (smallNeedlePoints != null)
                enlargePointList.AddRange(smallNeedlePoints);
            return enlargePointList.ToArray();
        }
        private Point[] GetLinePoints(Point point1, Point point2)
        {
            List<Point> shapePointList = new List<Point>();
            if (point1.X == point2.X)
            {
                if (point1.Y > point2.Y)
                {
                    for (int i = point1.Y; i >= point2.Y;i-- )
                        shapePointList.Add(new Point(point1.X, i));
                }
                else
                {
                    for (int i = point1.Y; i <= point2.Y; i++)
                        shapePointList.Add(new Point(point1.X, i));
                }
            }
            else if (point1.Y == point2.Y)
            {
                if (point1.X > point2.X)
                {
                    for (int i = point1.X; i >= point2.X; i--)
                        shapePointList.Add(new Point(i, point1.Y));
                }
                else
                {
                    for (int i = point1.X; i <= point2.X; i++)
                        shapePointList.Add(new Point(i, point1.Y));
                }
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
                    if (point1.X < point2.X)
                    {
                        for (int i = point1.X; i <= point2.X; i++)
                        {
                            value = (int)Math.Round((k * i + b), 0);
                            shapePointList.Add(new Point(i, value));
                        }
                    }
                    else
                    {
                        for (int i = point1.X; i >= point2.X; i--)
                        {
                            value = (int)Math.Round((k * i + b), 0);
                            shapePointList.Add(new Point(i, value));
                        }
                    }
                }
                else
                {
                    if (point1.Y<point2.Y)
                    {
                        for (int i = point1.Y; i <= point2.Y; i++)
                        {
                            value = (int)Math.Round((i - b) / k, 0);
                            shapePointList.Add(new Point(value, i));
                        }
                    }
                    else
                    {
                        for (int i = point1.Y; i >= point2.Y; i--)
                        {
                            value = (int)Math.Round((i - b) / k, 0);
                            shapePointList.Add(new Point(value, i));
                        }
                    }
                }
            }
            return shapePointList.ToArray();
        }
        private bool CheckLinePoint(Point point1,Point point2,Point point3)
        {
            bool linePointFlag = false;//是否属于同一段 
            double length1, length2;
            double minAngle = 0.785;
            length1 = (point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y);
            length1 = Math.Round(Math.Sqrt(length1), 2);
            length2 = (point3.X - point2.X) * (point3.X - point2.X) + (point3.Y - point2.Y) * (point3.Y - point2.Y);
            length2 = Math.Round(Math.Sqrt(length2),2);
            double vectorProduct = 0;//向量积
            vectorProduct = (point2.X - point1.X) * (point3.X - point2.X) + (point2.Y - point1.Y) * (point3.Y - point2.Y);
            if (length1 == 0 || length2 == 0)
                linePointFlag = true;
            else
            {
                double cos = Math.Round(vectorProduct / (length1 * length2), 2);
                cos = Math.Acos(cos);
                if (cos < minAngle)
                    linePointFlag = true;
                else
                    linePointFlag = false;
            }
            return linePointFlag;
        }
    }
}
