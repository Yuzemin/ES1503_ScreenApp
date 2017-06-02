using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineBLL
{

    public class RadianAlgorithmer//弧度算法类
    {
        public static PointF[] GetRadianPoints(List<PointF> linePoints, float radianValue)
        {
          
            List<PointF> quNullPoints = new List<PointF>();
            for (int i = 0; i < linePoints.Count; i++) //拷贝
            {
                if (linePoints[i] != null)
                    quNullPoints.Add(linePoints[i]);   
 
            }
            PointF[] radianLinePoints = new PointF[quNullPoints.Count];
            quNullPoints.CopyTo(radianLinePoints, 0);  //再拷贝
            if (radianLinePoints.Length > 2)
            {
                int length = radianLinePoints.Length;
                double diffY = radianLinePoints[length - 1].Y - radianLinePoints[0].Y; //获得该行 收尾坐标Y的差值
                double diffX = radianLinePoints[length - 1].X - radianLinePoints[0].X; //获得该行 收尾坐标X的差值
                if (radianValue > 0)
                {
                    double totalDist /*= Math.Round(Math.Sqrt((diffX * diffX) + (diffY * diffY)), 0)*/;
                    double distance = Math.Abs(radianLinePoints[1].Y - radianLinePoints[0].Y);
                    double value = 0;
                    if (diffX != 0)
                        length -= 1;  //收尾X的差值!=0 则将长度-1？？？  为什么
                    totalDist =Math.Abs(radianLinePoints[length - 1].Y - radianLinePoints[0].Y); //获得此行坐标Y轴上的 收尾的距离
                    for (int i = 1; i < length; i++)
                    {
                        value = Math.Abs(radianLinePoints[i].Y - radianLinePoints[0].Y);
                        value = Math.Abs(totalDist / 2 - Math.Abs(value - totalDist / 2));
                        value = value * Math.PI / totalDist;
                        value = Math.Sin(value) * radianValue;
                        radianLinePoints[i].X += (float)value;
                    }
                }
                else
                {
                    if (diffX != 0)
                    {
                        int index;
                        int diffIndex = 4;
                        if (radianLinePoints.Length > 3)
                            diffIndex = 4;
                        else
                            diffIndex = 3;
                        index = radianLinePoints.Length -  diffIndex;
                        diffIndex--;
                        double totalDist = Math.Abs(radianLinePoints[index].Y - radianLinePoints[index + diffIndex].Y);
                        double value = 0;
                        for (int i = index; i < radianLinePoints.Length; i++)
                        {
                            value = Math.Abs(radianLinePoints[i].Y - radianLinePoints[index + diffIndex].Y);
                            value = value * Math.PI / (2*totalDist);
                            value = Math.Sin(value) * diffX;
                            radianLinePoints[i].X = (float)(radianLinePoints[index + diffIndex].X - value);
                        }
                    }
                }
            }
            return radianLinePoints;
        }
    }
}
