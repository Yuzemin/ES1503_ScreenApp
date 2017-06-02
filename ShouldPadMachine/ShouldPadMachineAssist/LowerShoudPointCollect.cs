using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class LowerShouldPointCollect
    {
        private static LowerShouldPointCollect lowerShouldPointCollect;
         private int groupIndex;//发送第几组
        private Point[] shapePoints;
        public const int maxPackNum = 50; //每个包最多坐标点数
 

        public byte ReceiveGroupIndex
        {
            set {
                if (groupIndex == value)
                    groupIndex++;
            }
        }
        private LowerShouldPointCollect()
        {
            groupIndex = 0;
        }
        public void SetShouldPadPoints(Point[] shapePoints)
        {
            this.shapePoints = shapePoints;
            groupIndex = 0;
        }
        protected byte[] GetByteData(UInt16 baseData)
        {
            byte[] byteDatas = new byte[2];
            byteDatas[0] = Convert.ToByte(baseData & 0xFF);
            byteDatas[1] = Convert.ToByte((baseData >> 8) & 0xFF);
            return byteDatas;
        }

        public byte[] GetSerialDatas()
        {
            //坐标包序 坐标点数  坐标
            int packIndex = ScreenStatueData.patternIndex;//包序号（20里面请求的包序）
            List<byte> serialDataList = new List<byte>();
            serialDataList.AddRange(GetByteData((ushort)packIndex));//包序号
            List<Point> smallPack = new List<Point>();

            if (shapePoints != null && shapePoints.Length != 0)
            {
                int packTotal = (int)Math.Ceiling(shapePoints.Length / maxPackNum);//总包次
                int thisPackNum = 0;//当前包坐标个数
                for (int i = (packIndex - 1) * maxPackNum; i < (packIndex) * maxPackNum; i++)
                {
                    if (i >= shapePoints.Length)//最后一个包序
                    {
                        thisPackNum = i - (packIndex - 1) * 50;
                        break;
                    }
                    else
                    {
                        smallPack.Add(shapePoints[i]);
                        if (i == 49 + (packIndex - 1) * 50)
                            thisPackNum = 50;
                    }
                }
                serialDataList.AddRange(GetByteData((ushort)thisPackNum));//包坐标点数


                for (int i = 0; i < smallPack.Count; i++)
                {
                    serialDataList.AddRange(GetByteData((ushort)(smallPack[i].X)));
                    serialDataList.AddRange(GetByteData((ushort)(smallPack[i].Y)));
                }

            }
            return serialDataList.ToArray();
        }
        public static LowerShouldPointCollect LowerShouldPointCollectEx
        {
            get {
                if (lowerShouldPointCollect == null)
                    lowerShouldPointCollect = new LowerShouldPointCollect();
                return lowerShouldPointCollect;
            }
        }
    }
}
