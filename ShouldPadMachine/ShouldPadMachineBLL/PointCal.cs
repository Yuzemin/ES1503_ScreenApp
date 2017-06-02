using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineUI;
using System.Drawing;



namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class Ell_Fun
    {
        //1.待证明放回的值是一个地址 还是值 2.调用X_Line修改里面的内容 会对传入的list产生改变吗?
        //X_Off：椭圆中心X偏移量 Y_Off：Y偏移量  Ell_X：椭圆X半轴长 Ell_Y：Y半轴长 X_Line：取点坐标
        public List<PointF> GetEllPointWithX(Single X_Off, Single Y_Off, Single Ell_X, Single Ell_Y, List<Single> X_Line)
        {
            UInt16 usIndex = 0;
            Single Param_Y = 0;
            List<PointF> Line = new List<PointF>();

            for (usIndex = 0; usIndex < X_Line.Count; usIndex++)
            {
                Param_Y = Ell_Y * (Single)Math.Sqrt(1 - Math.Pow(X_Line[usIndex] - X_Off, 2) / Math.Pow(Ell_X, 2)) + Y_Off;
                Line.Add(new PointF(X_Line[usIndex], Param_Y));
            }
            return Line;
        }

    }

    class PointCal
    {
        //                  纵向间距，   半个长度，  总宽度，   总长度    ,弧度长度    
        protected Single yDirectGauge, halfLength, padWidth, padLength, radianLevel,JagVal,xDirGauge;
        protected Single RowGap, Shape_offset;
        protected Int32 HalfRowNum,HalfColNum;  
        protected List<PointF> Shape_Point = new List<PointF>(); //用于存储计算后获得的半个花型坐标点
        
        public PointCal(List<Tablet> ParamList)
        {
            //总长度
            padLength = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.ShouldPadLength - 1].Content);
            //总宽度
            padWidth = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.ShouldPadWidth - 1].Content);
            //半个长度
            halfLength = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.ShouldPadHalfLength - 1].Content);

           
            //半个花型行数
            HalfColNum = Convert.ToInt32(ParamList[(int)ShouldPadDataEnum.RowNum - 1].Content);
            //半花型个列数
            HalfRowNum = Convert.ToInt32(ParamList[(int)ShouldPadDataEnum.XDirectGauge - 1].Content);

            //横向间距
            xDirGauge = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.GapX - 1].Content);
            //纵向间距
            yDirectGauge = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.YDirectGauge - 1].Content);

            //振动幅度
            JagVal = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.JagVal - 1].Content);
            //弧度程度
            radianLevel = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.RadianLevel - 1].Content);
            
            //列间距
            RowGap = halfLength / (HalfRowNum - 1);
            //中间偏移量
            Shape_offset = padLength / 2 - halfLength;
            
            MappingSize.MappingSizeEx.LowerMachineSize = new SizeF(padLength + radianLevel * 2, padWidth);
        }

        protected List<PointF> GetDeepCopy(ref List<PointF> Point_List)
        {
            List<PointF> New_Copy = new List<PointF>();

            for (int i = 0; i < Point_List.Count; i++)
                New_Copy.Add(new PointF(Point_List[i].X,Point_List[i].Y));

            return New_Copy;
        }

        protected PointF GetMiddlePoint(PointF point1, PointF point2)
        {
            Single middX = (point2.X - point1.X) / 2;
            Single middY = (point2.Y - point1.Y) / 2;
            return new PointF(point1.X + middX, point1.Y + middY);
        }

        public List<PointF> GetHalfPoint()
        {
            List<PointF> Half_Point = GetLeftPoint();

            foreach (PointF Elem in Half_Point)
            {
                Elem.Y *= -1;
            }

            return Half_Point;
        }

        public virtual List<PointF> GetLeftPoint()
        {
            return null;
        }

        public virtual List<PointF> GetRightPoint()
        {
            return null;
        }

        public virtual List<PointF> GetAllPoint()
        {
            return null;
        }

        protected void GetSimpleLines(ref List<PointF>[] PointLines)
        {
            uint Line_Num = 0;
            uint Point_Num = 0;
            Single Param_X = 0;
            Single Param_Y = 0;
            Single Param_Length = 0;

            Line_Num = (uint)PointLines.Count();
            for (int i = 0; i < Line_Num;i++)
            {
                Point_Num = (uint)(PointLines[i].Count() - 1);
                for (int j = 0; j < Point_Num; j++)
                {
                    Param_X = (Single)Math.Pow((PointLines[i][j].X - PointLines[i][j+1].X),2);
                    Param_Y = (Single)Math.Pow((PointLines[i][j].Y - PointLines[i][j + 1].Y), 2);
                    Param_Length = Param_X + Param_Y;
                    if (Param_Length <= 4)
                    {
                        if (j == (Point_Num - 1))
                            PointLines[i].RemoveAt(j);
                        else
                            PointLines[i].RemoveAt(j+1);
                    }
                }
            }
        }
    }

    //标准花型的坐标获取
    class StandardShape: PointCal
    {
        public StandardShape(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            ShapePointsCalInit();
        }

        private void ShapePointsCalInit()
        {
            try
            {
                uint Index = 0;
                List<Single> standLine = new List<float>();
                List<Single> midLine = new List<float>();
                List<Single> Tmp_Line = null;
                Single Tmp_X = 0, Tmp_Y = 0, Tmp_a = 0, Tmp_b = 0;
                List<PointF>[] endpoint = new List<PointF>[base.HalfRowNum];
                List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];
                bool Dirct = false;

                for (int i = 0; i < base.HalfRowNum; i++)
                {
                    ShapeLinePoint[i] = new List<PointF>();
                    endpoint[i] = new List<PointF>();
                }

                Tmp_b = base.padWidth / 2; //短半轴
                Tmp_a = base.halfLength + base.RowGap;  //长半轴

                //获取外椭圆和各个列的上下交点
                for (int i = 0; i < base.HalfRowNum; i++)
                {
                    Tmp_X =  i * base.RowGap;
                    Tmp_Y = Tmp_b * (Single)Math.Sqrt(1 - Math.Pow(Tmp_X, 2) / Math.Pow(Tmp_a, 2));
                    endpoint[i].Add(new PointF(Tmp_X + base.Shape_offset, Tmp_Y));
                    endpoint[i].Add(new PointF(Tmp_X + base.Shape_offset, -Tmp_Y));
                }

                //计算标准列的标准分段
                Index = (uint)(base.padWidth / base.yDirectGauge);
                Tmp_Y = base.padWidth / 2; //标准列起点Y坐标值

                if (Index != 0)
                {
                    for (int i = 0; i <= Index; i++)
                        standLine.Add(Tmp_Y - i * base.yDirectGauge);

                    if ((base.padWidth % base.yDirectGauge) != 0)
                        standLine.Add(-Tmp_Y);
                }

                //计算标准列中间段
                for (int i = 1; i < standLine.Count; i++)
                    midLine.Add((standLine[i] + standLine[i - 1]) / 2); 
                midLine.Reverse(); //逆序坐标

                //遍历每列 将标准列上的标准分段和中间分段 分别映射到奇偶列上 将坐标按照顺序存储到每一列对应的list中
                for (int i = 0; i < base.HalfRowNum; i++)
                {
                    Tmp_X = endpoint[i][0].X;//获得当前列的X坐标
                    Tmp_Y = endpoint[i][0].Y;

                    if (i % 2 == 0)
                    {
                        Tmp_Line = standLine;
                        Dirct = true;
                    }
                    else
                    {
                        Tmp_Line = midLine;
                        Dirct = false;
                    }

                    for (int j = 0; j < Tmp_Line.Count; j++)
                    {
                        if ((Tmp_Line[j] < Tmp_Y) && (Tmp_Line[j] > (-Tmp_Y)))
                            ShapeLinePoint[i].Add(new PointF(Tmp_X, Tmp_Line[j]));
                    }

                    if (Dirct)
                    {
                        ShapeLinePoint[i].Insert(0, new PointF(Tmp_X, Tmp_Y));
                        ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Tmp_X, -Tmp_Y));
                    }
                    else
                    {
                        ShapeLinePoint[i].Insert(0, new PointF(Tmp_X, -Tmp_Y));
                        ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Tmp_X, Tmp_Y));
                    }
                }

                //采用弧度算法
                foreach (List<PointF> Elem in ShapeLinePoint)
                {
                    if (Elem != null)
                        Shape_Point.AddRange(RadianAlgorithmer.GetRadianPoints(Elem, radianLevel));
                }

                //前后两段数据的改用弧线连接
/*                for (int i = 1; i < base.HalfRowNum; i++)
                {
                    Single Dif_T = base.xDirectGauge;
                    Single Dif_Offset = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].X;
                    Single Dif_S = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].Y;
                    Single Dif_A = (Single)(2 * (-Dif_S) / Math.Pow(Dif_T, 2));

                    for (int j = 0; j < ShapeLinePoint[i].Count; j++)
                    {
                        if (Dif_S * ShapeLinePoint[i][j].Y < 0)
                            break;
                        ShapeLinePoint[i][j].X = (Single)Math.Sqrt(2 * (ShapeLinePoint[i][j].Y - Dif_S) / Dif_A) + Dif_Offset;
                    }
                }

                foreach (List<PointF> Elem in ShapeLinePoint)
                    Shape_Point.AddRange(Elem); */
            }
            catch (NullReferenceException ex)
            {
                string message = ex.Message;
                System.Windows.Forms.MessageBox.Show(message);
            }
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0,0);
            PointF Point2 = new PointF(0,0);
            PointF Point3 = new PointF(0,0);

            Point1 = GetMiddlePoint(Point_Line[0], Point_Line[1]);
            Point2 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point3 = GetMiddlePoint(Point_Line[1], Point_Line[2]);

            Point_Line.Insert(0, Point2); //插入起始锁线点
            Point_Line.Insert(3, Point1);
            Point_Line.Insert(4, Point3);
            
            Point1 = GetMiddlePoint(Point_Line[Point_Line.Count - 2], Point_Line[Point_Line.Count - 1]);
            Point2 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point_Line.Insert(Point_Line.Count - 1, Point2);
            Point_Line.Insert(Point_Line.Count - 2, Point1);//末尾的锁线点
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);
            return Right_Point;
        }

        public override List<PointF>  GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            Left_Point.Reverse(); //逆序
            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            return Left_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制
                     
            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

    //多重椭圆花型的坐标计算
    class EllipseShape : PointCal
    {
        public EllipseShape(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            EllipseShapeInit();
        }

        private void EllipseShapeInit()
        {
            Single Ellipse_a, Ellipse_b;//椭圆长短轴
            List<PointF>[] Line_Point = new List<PointF>[base.HalfRowNum];
            List<Single> StandLine = new List<Single>();
            uint Index;
            Single Tmp_X, Tmp_Y,Tmp_Length;
            PointF Tra_Tmp = new PointF(0,0);

            Double test1,test2,test3;

            Ellipse_b = base.padWidth / 2;                  //椭圆Y轴

            for(int i=0;i<base.HalfRowNum;i++)
                Line_Point[i] = new List<PointF>();

            //计算标准列的标准分段
            Index = (uint)(base.padWidth / base.yDirectGauge);

            if (Index != 0)
            {
                for (int i = 0; i <= Index; i++)
                    StandLine.Add(Ellipse_b - i * base.yDirectGauge);

                if ((base.padWidth % base.yDirectGauge) != 0)
                    StandLine.Add(-Ellipse_b);
            }

            //标准列的坐标
            for (int i = 0; i < StandLine.Count; i++)
                Line_Point[0].Add(new PointF(base.Shape_offset, StandLine[i]));
            //外椭圆坐标
                //分段点映射
            for (int i = 1; i < base.HalfRowNum; i++) 
            {
                Ellipse_a = i * base.RowGap;

                for (int j = 0; j < StandLine.Count; j++)
                {
                    Tmp_Y = StandLine[j];
                    Tmp_X = Ellipse_a * (Single)Math.Sqrt(1 - Math.Pow(Tmp_Y, 2) / Math.Pow(Ellipse_b, 2));
                    Line_Point[i].Add(new PointF(Tmp_X + base.Shape_offset,Tmp_Y));
                }
            }
                //细分点插入
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                Ellipse_a = i * base.RowGap;
                for (int j = 0; j < (Line_Point[i].Count - 1); )
                {
                    Tmp_X = (Single)Math.Pow((Line_Point[i][j].X - Line_Point[i][j + 1].X), 2);
                    Tmp_Y = (Single)Math.Pow((Line_Point[i][j].Y - Line_Point[i][j + 1].Y), 2);
                    Tmp_Length = (Single)Math.Sqrt(Tmp_X + Tmp_Y); //两点间的点距离计算
                    if (Tmp_Length >= 25)
                    {
                        Tmp_Y = (Line_Point[i][j].Y + Line_Point[i][j + 1].Y) / 2;
                        test1 = Math.Pow(Tmp_Y, 2);
                        test2 = Math.Pow(Ellipse_b, 2);
                        test3 = test1 / test2;
                        Tmp_X = Ellipse_a * (Single)Math.Sqrt(1 - test3);
                        Line_Point[i].Insert(j + 1, new PointF(Tmp_X + base.Shape_offset, Tmp_Y));
                    }
                    else
                        j++;
                }
            }

            Tra_Tmp.X = Line_Point[0][0].X;
            Tra_Tmp.Y = Line_Point[0][0].Y;
            //奇数列逆序
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                if (i % 2 == 1)
                    Line_Point[i].Reverse();
                Line_Point[i].RemoveAt(0);
            }
            Line_Point[0].Insert(0, Tra_Tmp);

            //获得椭圆花型在X正半轴的坐标
            for (int i = 0; i < base.HalfRowNum; i++)
                Shape_Point.AddRange(Line_Point[i]);
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);
            PointF Point3 = new PointF(0, 0);

            Point1 = GetMiddlePoint(Point_Line[0], Point_Line[1]);
            Point2 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point3 = GetMiddlePoint(Point_Line[1], Point_Line[2]);

            Point_Line.Insert(0, Point2); //插入起始锁线点
            Point_Line.Insert(3, Point1);
            Point_Line.Insert(4, Point3);

            Point2 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point1 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point_Line.Insert(Point_Line.Count, Point2);
            Point_Line.Insert(Point_Line.Count, Point1);//末尾的锁线点
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            Left_Point.Reverse();

            return Left_Point;
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);            

            return Right_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

    //外带圆弧
    class EllipseOutSide : PointCal
    {
        public EllipseOutSide(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            EllipseOutSideInit();
        }

        private void EllipseOutSideInit()
        {
            uint Index = 0;
            List<Single> standLine = new List<Single>();
            List<Single> midLine = new List<Single>();
            List<Single> Tmp_Line = null;
            Single Tmp_X = 0, Tmp_Y = 0, Tmp_a = 0, Tmp_b = 0,Tmp_length;
            PointF[][] endpoint = new PointF[base.HalfRowNum][];
            List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];
            List<PointF> OutEllipse = new List<PointF>();
            bool Dirct = false;

            Tmp_b = base.padWidth / 2; //短半轴
            Tmp_a = base.halfLength;  //长半轴
            base.RowGap = base.halfLength / base.HalfRowNum; 

            for (int i = 0; i < base.HalfRowNum; i++)
                ShapeLinePoint[i] = new List<PointF>();

            //获取外椭圆和各个列的上下交点
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                Tmp_X = i * base.RowGap;
                Tmp_Y = Tmp_b * (Single)Math.Sqrt(1 - Math.Pow(Tmp_X, 2) / Math.Pow(Tmp_a, 2));
                endpoint[i] = new PointF[2];
                endpoint[i][0] = new PointF(Tmp_X + base.Shape_offset, Tmp_Y);
                endpoint[i][1] = new PointF(Tmp_X + base.Shape_offset, -Tmp_Y);
            }

            //计算标准列的标准分段 包括上下端点 为了便利 midLine的计算
            Index = (uint)(base.padWidth / base.yDirectGauge);
            Tmp_Y = base.padWidth / 2; //标准列起点Y坐标值

            if (Index != 0)
            {
                for (int i = 0; i <= Index; i++)
                    standLine.Add(Tmp_Y - i * base.yDirectGauge);

                if ((base.padWidth % base.yDirectGauge) != 0)
                    standLine.Add(-Tmp_Y);
            }

            //计算标准列中间段  
            for (int i = 1; i < standLine.Count; i++)
                midLine.Add((standLine[i] + standLine[i - 1]) / 2);

            //获得标准列的坐标
            for (int i = 0; i < standLine.Count; i++)
                ShapeLinePoint[0].Add(new PointF(base.Shape_offset, standLine[i]));
 
            //遍历每列 将标准列上的标准分段和中间分段 分别映射到奇偶列上 将坐标存储到每一列对应的list中
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                Tmp_X = endpoint[i][0].X;//获得当前列的X坐标
                Tmp_Y = endpoint[i][0].Y;

                if (i % 2 == 0)
                {
                    Tmp_Line = standLine;
                    Dirct = true;
                }
                else
                {
                    Tmp_Line = midLine;
                    Dirct = false;
                }

                for (int j = 0; j < Tmp_Line.Count; j++)
                {
                    if ((Tmp_Line[j] < Tmp_Y) && (Tmp_Line[j] > (-Tmp_Y)))
                        ShapeLinePoint[i].Add(new PointF(Tmp_X, Tmp_Line[j]));
                }

                ShapeLinePoint[i].Insert(0, new PointF(Tmp_X, Tmp_Y));
                ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Tmp_X, -Tmp_Y));

                if (Dirct)
                    ShapeLinePoint[i].Reverse();
            }
            //GetSimpleLines(ref ShapeLinePoint);

            OutEllipse.Add(new PointF(base.Shape_offset, -(base.padWidth / 2)));
            OutEllipse.Add(new PointF(base.padLength / 2, 0));
            OutEllipse.Add(new PointF(base.Shape_offset, base.padWidth / 2));
            for (int j = 0; j < (OutEllipse.Count - 1); )
            {
                Tmp_X = (Single)Math.Pow((OutEllipse[j].X - OutEllipse[j + 1].X), 2);
                Tmp_Y = (Single)Math.Pow((OutEllipse[j].Y - OutEllipse[j + 1].Y), 2);
                Tmp_length = (Single)Math.Sqrt(Tmp_X + Tmp_Y); //两点间的点距离计算
                if (Tmp_length >= 20)
                {
                    Tmp_Y = (OutEllipse[j].Y + OutEllipse[j + 1].Y) / 2;
                    Tmp_X = (base.halfLength) * (Single)Math.Sqrt(1 - Math.Pow(Tmp_Y, 2) / Math.Pow(base.padWidth / 2, 2));
                    OutEllipse.Insert(j + 1, new PointF(Tmp_X + base.Shape_offset, Tmp_Y));
                }
                else
                    j++;
            }

            //前后两段数据的改用弧线连接
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                Single Dif_T = base.RowGap;
                Single Dif_Offset = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].X;
                Single Dif_S = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].Y;
                
                if (i == 1)
                    Dif_S = ShapeLinePoint[i - 1][0].Y;

                Single Dif_A = (Single)(2 * (-Dif_S) / Math.Pow(Dif_T, 2));

                for (int j = 0; j < ShapeLinePoint[i].Count; j++)
                {
                    if (Dif_S * ShapeLinePoint[i][j].Y < 0)
                        break;
                    ShapeLinePoint[i][j].X = (Single)Math.Sqrt(2 * (ShapeLinePoint[i][j].Y - Dif_S) / Dif_A) + Dif_Offset;
                }
            }

            //弧度计算
            Shape_Point.AddRange(ShapeLinePoint[0]);
            Shape_Point.AddRange(OutEllipse);
            for (int i = 1; i < base.HalfRowNum; i++)
                Shape_Point.AddRange(ShapeLinePoint[i].ToArray());
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);
            PointF Point3 = new PointF(0, 0);

            Point1 = GetMiddlePoint(Point_Line[0], Point_Line[1]);
            Point2 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point3 = GetMiddlePoint(Point_Line[1], Point_Line[2]);

            Point_Line.Insert(0, Point2); //插入起始锁线点
            Point_Line.Insert(3, Point1);
            Point_Line.Insert(4, Point3);

            Point2 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point1 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point_Line.Insert(Point_Line.Count, Point2);
            Point_Line.Insert(Point_Line.Count, Point1);//末尾的锁线点
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            Left_Point.Reverse();

            return Left_Point;
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);

            return Right_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

    //内部锯齿
    class JagInside : PointCal
    {
        public JagInside(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            JagInsideInit();
        }

        private void JagInsideInit()
        {
            List<Single> standLine = new List<float>();
            List<Single> midLine = new List<float>();
            List<Single> Tmp_Line = null;
            Single Tmp_X = 0, Tmp_Y = 0, Tmp_a = 0, Tmp_b = 0, Tmp_length = 0,Jag_length = 0;
            List<PointF>[] endpoint = new List<PointF>[base.HalfRowNum];
            List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];
            List<PointF>[] JagLine = new List<PointF>[base.HalfRowNum];
            List<PointF> JagLeft = new List<PointF>();
            List<PointF> JagRight = new List<PointF>();
            bool Dirct = false;
            uint Index = 0;

            Jag_length = base.halfLength / (3 * base.HalfRowNum - 1) *2 ;
            if (Jag_length > base.JagVal) Jag_length = base.JagVal;
            base.RowGap = (base.halfLength - Jag_length) / (base.HalfRowNum - 1);

            //初始化
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                ShapeLinePoint[i] = new List<PointF>();
                endpoint[i] = new List<PointF>();
                JagLine[i] = new List<PointF>();
            }

            Tmp_b = base.padWidth / 2; //短半轴
            Tmp_a = base.halfLength;  //长半轴

            //获取外椭圆和各个列的上下交点
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                Tmp_X = i * base.RowGap;
                Tmp_Y = Tmp_b * (Single)Math.Sqrt(1 - Math.Pow(Tmp_X, 2) / Math.Pow(Tmp_a, 2));
                endpoint[i].Add(new PointF(Tmp_X + base.Shape_offset, Tmp_Y));
                endpoint[i].Add(new PointF(Tmp_X + base.Shape_offset, -Tmp_Y));
            }

            //计算标准列的标准分段
            Index = (uint)(base.padWidth / base.yDirectGauge);
            Tmp_Y = base.padWidth / 2; //标准列起点Y坐标值

            if (Index != 0)
            {
                for (int i = 0; i <= Index; i++)
                    standLine.Add(Tmp_Y - i * base.yDirectGauge);

                if ((base.padWidth % base.yDirectGauge) != 0)
                    standLine.Add(-Tmp_Y);
            }

            //计算标准列中间段
            //for (int i = 1; i < standLine.Count; i++)
            //    midLine.Add((standLine[i] + standLine[i - 1]) / 2);
            midLine.AddRange(standLine.ToArray());
            midLine.Reverse();

            //计算各列锯型坐标
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                Tmp_X = endpoint[i][0].X;//获得当前列的X坐标
                Tmp_Y = endpoint[i][0].Y;

                if (i % 2 == 0)
                {
                    Tmp_Line = standLine;
                    Dirct = true;
                }
                else
                {
                    Tmp_Line = midLine;
                    Dirct = false;
                }

                for (int j = 0; j < Tmp_Line.Count; j++)
                {
                    if ((Tmp_Line[j] < Tmp_Y) && (Tmp_Line[j] > (-Tmp_Y)))
                        ShapeLinePoint[i].Add(new PointF(Tmp_X, Tmp_Line[j]));
                }

                if (Dirct)
                {
                    ShapeLinePoint[i].Insert(0, new PointF(Tmp_X, Tmp_Y));
                    ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Tmp_X, -Tmp_Y));
                }
                else
                {
                    ShapeLinePoint[i].Insert(0, new PointF(Tmp_X, -Tmp_Y));
                    ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Tmp_X, Tmp_Y));
                }
            }

             
            Single Jag_X = 0;
            Tmp_a = base.halfLength;
            Tmp_b = base.padWidth / 2;
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                JagLine[i].Add(ShapeLinePoint[i][0]);
                Tmp_X = ShapeLinePoint[i][0].X + Jag_length;
          
                for (int j = 1; j < ShapeLinePoint[i].Count; j++)
                {
                    Tmp_Y = (ShapeLinePoint[i][j].Y + ShapeLinePoint[i][j-1].Y)/2;
                    Jag_X = (Single)(Tmp_a * Math.Sqrt(1 - Math.Pow(Tmp_Y, 2) / Math.Pow(Tmp_b, 2)));
                    Jag_X += base.Shape_offset;
                    if (Jag_X > Tmp_X) Jag_X = Tmp_X;
                    JagLine[i].Add(new PointF(Jag_X, Tmp_Y));
                    JagLine[i].Add(ShapeLinePoint[i][j]);
                }
            }

            //计算各列的连接点、
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                List<PointF> Tmp_List = new List<PointF>();

                Tmp_List.Add(new PointF(JagLine[i - 1][JagLine[i - 1].Count - 1].X, JagLine[i - 1][JagLine[i - 1].Count - 1].Y));
                Tmp_List.Add(new PointF(JagLine[i][0].X, JagLine[i][0].Y));

                for (int j = 0; j < Tmp_List.Count - 1; j++)
                {
                    Tmp_X = (Single)Math.Pow((Tmp_List[j].X - Tmp_List[j + 1].X), 2);
                    Tmp_Y = (Single)Math.Pow((Tmp_List[j].Y - Tmp_List[j + 1].Y), 2);
                    Tmp_length = (Single)Math.Sqrt(Tmp_X + Tmp_Y); //两点间的点距离计算
                    if (Tmp_length >= 25)
                    {
                        Tmp_Y = (Tmp_List[j].Y + Tmp_List[j + 1].Y) / 2;
                        Tmp_X = (Tmp_List[j].X + Tmp_List[j + 1].X) / 2;
                        Tmp_List.Insert(j + 1, new PointF(Tmp_X, Tmp_Y));
                    }
                    else
                        j++;
                }
                Tmp_List.RemoveAt(0);
                Tmp_List.RemoveAt(Tmp_List.Count - 1);
                JagLine[i - 1].AddRange(Tmp_List);
                Tmp_List.Clear();
            }

            foreach (List<PointF> Elem in JagLine)
                Shape_Point.AddRange(Elem);
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);

            Point1 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point2 = new PointF(Point_Line[2].X, Point_Line[2].Y);

             //插入起始锁线点
            Point_Line.Insert(0, Point1);
            Point_Line.Insert(0, Point2);

            Point1 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point2 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point_Line.Insert(Point_Line.Count, Point1);
            Point_Line.Insert(Point_Line.Count, Point2);//末尾的锁线点
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);
            return Right_Point;
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            Left_Point.Reverse(); //逆序
            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            return Left_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

    //内部锯齿外圆弧
    class JagWithEll : PointCal
    {
        public JagWithEll(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            JagWithEllInit();
        }

        private void JagWithEllInit()
        {
            try
            {
                uint Index = 0;
                Single Jag_Width = 0, Line_Gap = 0, Param_A = 0, Param_B = 0;
                Single Tmp_X = 0, Tmp_Y = 0, Line_X = 0, Line_Y = 0;
                List<Single> standLine = new List<float>();
                List<PointF> EllLine = new List<PointF>();
                List<PointF> Tmp_Line = new List<PointF>();
                List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];

                Param_A = base.halfLength;  //长半轴
                Param_B = base.padWidth / 2; //短半轴     
                

                //初始化
                for (int i = 0; i < base.HalfRowNum; i++)
                    ShapeLinePoint[i] = new List<PointF>();

                //计算锯齿宽度 和 列间隔
                Line_Gap = base.halfLength / base.HalfRowNum;
                if (Line_Gap <= base.JagVal)
                    Jag_Width = Line_Gap;
                else
                {
                    Jag_Width = base.JagVal;
                    Line_Gap = (base.halfLength - base.HalfRowNum * base.JagVal) / (base.HalfRowNum - 1);
                    Line_Gap += Jag_Width;
                }

                //计算标准列的Y轴坐标
                Index = (uint)(base.padWidth / base.yDirectGauge);
                for (int i = 0; i <= Index; i++)
                    standLine.Add(Param_B - i * base.yDirectGauge);

                
                //生成每列坐标
                for (int i = 0; i < standLine.Count; i++)
                    ShapeLinePoint[0].Add(new PointF(base.Shape_offset, standLine[i]));
                for (int i = 1; i < base.HalfRowNum; i++)
                {
                    Line_X = i * Line_Gap; //
                    Line_Y = Param_B * (Single)Math.Sqrt(1 - Math.Pow(Line_X, 2) / Math.Pow(Param_A, 2));
                    Line_X += base.Shape_offset;

                    //将该列的上下与椭圆的交点与标准列上的点找出
                    Tmp_Line.Add(new PointF(Line_X, Line_Y));
                    for (int j = 0; j < standLine.Count; j++)
                        if (standLine[j] < Line_Y && standLine[j] > -Line_Y)
                            Tmp_Line.Add(new PointF(Line_X, standLine[j]));
                    Tmp_Line.Add(new PointF(Line_X, -Line_Y));

                    //将Tmp_Line中的坐标存入当前列的列表中 并加入锯齿点坐标
                    ShapeLinePoint[i].Add(Tmp_Line[0]); //此处可能涉及到深度拷贝的问题
                    for (int j = 1; j < Tmp_Line.Count; j++)
                    {
                        Tmp_Y = (Tmp_Line[j].Y + Tmp_Line[j - 1].Y) / 2;
                        Tmp_X = (Single)(Param_A * Math.Sqrt(1 - Math.Pow(Tmp_Y, 2) / Math.Pow(Param_B, 2)));
                        Tmp_X += base.Shape_offset;
                        //对超出椭圆范围的点进行检测
                        if (Tmp_X >= (Line_X + Jag_Width))
                            Tmp_X = Line_X + Jag_Width;

                        ShapeLinePoint[i].Add(new PointF(Tmp_X, Tmp_Y));
                        ShapeLinePoint[i].Add(new PointF(Line_X, Tmp_Line[j].Y));
                    }
                    Tmp_Line.Clear();
                }

                //获得半个椭圆点
                float xSEgments = 0;
                int S_Count = 8;//8代表分段数量
                xSEgments = Param_A / S_Count;
                for (int i = 0; i <= S_Count; i++)
                {
                    Line_X = i * xSEgments; //
                    Line_Y = (float)(Param_B * (Single)Math.Sqrt(1 - Math.Pow(Line_X, 2) / Math.Pow(Param_A, 2)));
                    Line_X += base.Shape_offset;

                    Tmp_Line.Add(new PointF(Line_X, Line_Y));
                }
                if ((Param_A % S_Count) != 0)
                    Tmp_Line.Add(new PointF(Param_A + base.Shape_offset,0));
                //优化椭圆线迹
                for (int i = 1; i < Tmp_Line.Count; i++)
                {
                    if (Tmp_Line[i - 1].Y - Tmp_Line[i].Y >= 15)
                    {
                        Line_Y = (Tmp_Line[i - 1].Y + Tmp_Line[i].Y) / 2;
                        Line_X = (Single)(Param_A * Math.Sqrt(1 - Math.Pow(Line_Y, 2) / Math.Pow(Param_B, 2)));
                        Tmp_Line.Insert(i, new PointF(Line_X + base.Shape_offset, Line_Y));
                        i--;
                    }
                }
                EllLine.AddRange(Tmp_Line.ToArray());

                Tmp_Line.Reverse();
                for (int i = 1; i < Tmp_Line.Count; i++)
                    EllLine.Add(new PointF(Tmp_Line[i].X, -Tmp_Line[i].Y));
                EllLine.Reverse();
                Tmp_Line.Clear();

                //连接各列坐标
                PointF stPoint = new PointF(0, 0);
 
                Shape_Point.AddRange(ShapeLinePoint[0]);
                Shape_Point.AddRange(EllLine);
                EllLine.Reverse();
                for (int i = 1; i < base.HalfRowNum; i++)
                {
                    if (i % 2 == 0)
                        ShapeLinePoint[i].Reverse();

                    stPoint = Shape_Point[Shape_Point.Count - 1];

                    if ((Math.Pow(stPoint.Y - ShapeLinePoint[i][0].Y, 2) + Math.Pow(Line_Gap, 2)) >= 230)
                    {
                        if (stPoint.Y >= ShapeLinePoint[i][0].Y)
                        {
                            for (int j = 0; j < EllLine.Count; j++)
                            {
                                if(EllLine[j].Y <= stPoint.Y && EllLine[j].Y >= ShapeLinePoint[i][0].Y)
                                    Shape_Point.Add(new PointF(EllLine[j].X, EllLine[j].Y));
                                if (EllLine[j].Y < ShapeLinePoint[i][0].Y)
                                    break;
                            }
                        }
                        else
                        {
                            for (int j = EllLine.Count - 1; j >= 0; j--)
                            {
                                if (EllLine[j].Y >= stPoint.Y && EllLine[j].Y <= ShapeLinePoint[i][0].Y)
                                    Shape_Point.Add(new PointF(EllLine[j].X, EllLine[j].Y));
                                if (EllLine[j].Y > ShapeLinePoint[i][0].Y)
                                    break;
                            }
                        }
                    }

                    Shape_Point.AddRange(ShapeLinePoint[i]);
                }

            }
            catch (Exception ex)
            {
                MessageBoxEX.Show(ex.StackTrace);
            }

        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);

            Point1 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point2 = new PointF(Point_Line[2].X, Point_Line[2].Y);

            //插入起始锁线点
            Point_Line.Insert(0, Point1);
            Point_Line.Insert(0, Point2);

            Point1 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point2 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point_Line.Insert(Point_Line.Count, Point1);
            Point_Line.Insert(Point_Line.Count, Point2);//末尾的锁线点
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);
            return Right_Point;
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            Left_Point.Reverse(); //逆序
            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            return Left_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            try
            {
                List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
                List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

                List<PointF> All_Point = new List<PointF>();

                GetConnectPoint(ref Half_Right);
                All_Point.AddRange(Half_Left);
                All_Point.AddRange(Half_Right);
                return All_Point;
            }
            catch (Exception ex)
            {
                MessageBoxEX.Show(ex.StackTrace);
                return null;
            }
        }
    }
       
    //外锯齿
    class JagOutSide : PointCal
    {
        public JagOutSide(List<Tablet> ParamList)
            : base(ParamList)
        {
            if (HalfRowNum < 2)
                HalfRowNum = 2;
            JagOutSideInit();
        }

        //根据椭圆的长短半轴A B，等分段数Num 角度偏移值Offset 对第一象限内的椭圆 逆时针方向进行描点
        private List<PointF> GetHalfEllipse(Single Param_A,Single Param_B,int Num,double Offset)
        {
            Single Param_E2, Param_R, Param_X, Param_Y;
            double degree, Angle;
            List<PointF> HalfEllipse = new List<PointF>();

            Param_E2 = (Single)(1 - Math.Pow(Param_B, 2) / Math.Pow(Param_A, 2));
            degree = 90 / Num;

            for (int i = 0; i < Num; i++)
            {
                Angle = Math.PI * (i * degree + Offset) / 180.0;
                Param_R = (Single)(Param_B / Math.Sqrt(1 - Param_E2 * Math.Pow(Math.Cos(Angle), 2)));
                Param_X = (Single)(Param_R * Math.Cos(Angle));
                Param_Y = (Single)(Param_R * Math.Sin(Angle));
                HalfEllipse.Add(new PointF(Param_X + base.Shape_offset, Param_Y));
            }
            HalfEllipse.Add(new PointF(base.Shape_offset, Param_B));
            return HalfEllipse;
        }

        //获得外围的锯齿边缘坐标
        private List<PointF> GetJagOutSidePoints()
        {
            List<PointF> Ellipse_Out, Ellipse_In;
            List<PointF> JagLine = new List<PointF>();
            List<PointF> HalfJagLine = new List<PointF>();
            Single Ellipse_A, Ellipse_B,Ell_L,Ell_Angle,Ell_Size;
            int Count_Num;

            Ell_Size = base.JagVal;
            //锯齿内椭圆
            Ellipse_A = (Single)Math.Abs(base.halfLength - Ell_Size);
            Ellipse_B = (Single)Math.Abs(base.padWidth / 2 - Ell_Size);
            Ell_L = (float)(Math.PI * (3 * (Ellipse_A + Ellipse_B) / 2 - Math.Sqrt(Ellipse_A * Ellipse_B))) / 4;
            Count_Num = (int)(Ell_L / Ell_Size);
            Ell_Angle = ((float)90.0) / Count_Num;
            Ellipse_In = GetHalfEllipse(Ellipse_A, Ellipse_B, Count_Num, 0);

            //锯齿外椭圆
            Ellipse_A = (Single)Math.Abs(base.halfLength);
            Ellipse_B = (Single)Math.Abs(base.padWidth / 2);
            Ellipse_Out = GetHalfEllipse(Ellipse_A, Ellipse_B, Count_Num, Ell_Angle / 2);
            Ellipse_Out.RemoveAt(Count_Num);

            for (int i = 0; i < Count_Num; i++)
            {
                JagLine.Add(Ellipse_In[i]);
                JagLine.Add(Ellipse_Out[i]);
            }
            JagLine.Add(Ellipse_In[Count_Num]);

            Count_Num = JagLine.Count();
            for (int i = 1; i < Count_Num; i++)
                HalfJagLine.Add(new PointF(JagLine[i].X, -JagLine[i].Y));

            JagLine.Reverse();
            JagLine.AddRange(HalfJagLine);
            JagLine.Reverse();

            return JagLine;
        }

        //获得内部线迹坐标
        private List<PointF>[] GetLinePoints()
        {
            List<Single> standLine = new List<Single>();
            List<Single> midLine = new List<Single>();
            List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];
            List<PointF> Endpoint = new List<PointF>();
            List<Single> Tmp_Line = null;
            Single Ellipse_A, Ellipse_B;
            Single Param_X = 0, Param_Y = 0,Param_Ell = 0;
            uint Count_Num;
            bool Dirct;

            Param_Ell = base.JagVal + 10;
            Ellipse_B = (Single)Math.Abs(base.padWidth / 2 - Param_Ell); //短半轴
            Ellipse_A = (Single)Math.Abs(base.halfLength - Param_Ell);  //长半轴
            base.RowGap = Ellipse_A / base.HalfRowNum;

            //初始化
            for (int i = 0; i < base.HalfRowNum; i++)
                ShapeLinePoint[i] = new List<PointF>();

            //获取各个列与边缘的的上下交点
            for (int i = 0; i < base.HalfRowNum; i++)
            {
                Param_X = i * base.RowGap;
                Param_Y = Ellipse_B * (Single)Math.Sqrt(1 - Math.Pow(Param_X, 2) / Math.Pow(Ellipse_A, 2));
                Endpoint.Add(new PointF(Param_X + base.Shape_offset, Param_Y));
            }

            //计算标准列的标准分段 包括上下端点 为了便利 midLine的计算
            Count_Num = (uint)(Ellipse_B * 2 / base.yDirectGauge);
            if (Count_Num != 0)
            {
                for (int i = 0; i <= Count_Num; i++)
                    standLine.Add(Ellipse_B - i * base.yDirectGauge);

                if ((Ellipse_B % base.yDirectGauge) != 0)
                    standLine.Add(-Ellipse_B);
            }
            
            //计算标准列中间段  
            for (int i = 1; i < standLine.Count; i++)
                midLine.Add((standLine[i] + standLine[i - 1]) / 2);

            //获得标准列的坐标
            for (int i = 0; i < standLine.Count; i++)
                ShapeLinePoint[0].Add(new PointF(base.Shape_offset, standLine[i]));

            //遍历每列 将标准列上的标准分段和中间分段 分别映射到奇偶列上 将坐标存储到每一列对应的list中
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                Param_X = Endpoint[i].X;//获得当前列的X坐标
                Param_Y = Endpoint[i].Y;

                if (i % 2 == 0)
                {
                    Tmp_Line = standLine;
                    Dirct = true;
                }
                else
                {
                    Tmp_Line = midLine;
                    Dirct = false;
                }

                for (int j = 0; j < Tmp_Line.Count; j++)
                {
                    if ((Tmp_Line[j] < Param_Y) && (Tmp_Line[j] > (-Param_Y)))
                        ShapeLinePoint[i].Add(new PointF(Param_X, Tmp_Line[j]));
                }
 
                ShapeLinePoint[i].Insert(0, new PointF(Param_X, Param_Y));
                ShapeLinePoint[i].Insert(ShapeLinePoint[i].Count, new PointF(Param_X, -Param_Y));

                if (Dirct)
                    ShapeLinePoint[i].Reverse();
            }
 

            //前后两段数据的改用弧线连接 匀加速S-T 曲线
            for (int i = 1; i < base.HalfRowNum; i++)
            {
                Single Dif_T = base.RowGap;
                Single Dif_Offset = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].X;
                Single Dif_S = ShapeLinePoint[i - 1][ShapeLinePoint[i - 1].Count - 1].Y;

                if (i == 1)
                    Dif_S = ShapeLinePoint[i - 1][0].Y;

                Single Dif_A = (Single)(2 * (-Dif_S) / Math.Pow(Dif_T, 2));
                for (int j = 0; j < ShapeLinePoint[i].Count; j++)
                {
                    if (Dif_S * ShapeLinePoint[i][j].Y < 0)
                        break;
                    ShapeLinePoint[i][j].X = (Single)Math.Sqrt(2 * (ShapeLinePoint[i][j].Y - Dif_S) / Dif_A) + Dif_Offset;
                }
            }

            return ShapeLinePoint;
        }

        private void JagOutSideInit()
        {
            List<PointF>[] ShapeLinePoint = new List<PointF>[base.HalfRowNum];
            List<PointF> LinePoints_Out = new List<PointF>();

            LinePoints_Out  = GetJagOutSidePoints();
            ShapeLinePoint = GetLinePoints();

            LinePoints_Out.Add(new PointF(ShapeLinePoint[0][0].X, ShapeLinePoint[0][0].Y));

            Shape_Point.AddRange(ShapeLinePoint[0]);
            Shape_Point.AddRange(LinePoints_Out);
            for (int i = 1; i < base.HalfRowNum; i++)
                Shape_Point.AddRange(ShapeLinePoint[i]);

            if(Shape_Point.Count > 3)
                AddLockPoint(ref Shape_Point);
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);
            PointF Point3 = new PointF(0, 0);

            Point1 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point_Line.Insert(0, Point1); //插入起始锁线点

            Point1 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point2 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);           
            Point_Line.Insert(Point_Line.Count, Point2);
            Point_Line.Insert(Point_Line.Count, Point1);//末尾的锁线点
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            Left_Point.Reverse();

            return Left_Point;
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            return Right_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

    class MulitEllShape : PointCal
    {
        public MulitEllShape(List<Tablet> ParamList)
            : base(ParamList)
        {
            MulitEllShapeInit();
        }

        private void MulitEllShapeInit()
        {
            UInt16 usIndex = 0, usNum = 0;
            int RowNum = base.HalfColNum;
            float Point_XDis =  base.xDirGauge;
            Ell_Fun Ell_Function = new Ell_Fun();
            List<Single> StaLine = new List<Single>();
            List<PointF> Mid_Line = new List<PointF>();            
            
            Single X_Off, Y_Off, Ell_X, Ell_Y;
            Single X_Offect = 4, Y_Offect = 4, Ell_Offect = 8;            
            Single Ell_Desc = ((base.padWidth / 2 - Y_Offect) - RowNum * Ell_Offect) / (RowNum + 1);

            List<PointF>[] Line_Point = new List<PointF>[RowNum * 2 + 2];
            List<PointF>[] MLine_Point = new List<PointF>[RowNum * 2 + 2];
            UInt16 Point_Num = (UInt16)((base.halfLength / Point_XDis) + 1);

            for (usIndex = 0; usIndex < Line_Point.Count(); usIndex++)
            {
                Line_Point[usIndex] = new List<PointF>();
                MLine_Point[usIndex] = new List<PointF>();
            }

            //获得标准列的X坐标
            for (usIndex = 0; usIndex < Point_Num; usIndex++)
                StaLine.Add(base.Shape_offset + usIndex * Point_XDis + X_Offect);
            if (StaLine[StaLine.Count - 1] >= (base.halfLength + base.Shape_offset))
                StaLine[StaLine.Count - 1] = base.halfLength + base.Shape_offset;
            else
                StaLine.Add(base.halfLength + base.Shape_offset);

            //获得第一象限点坐标
            for (usIndex = 0; usIndex < StaLine.Count; usIndex++)
                Line_Point[0].Add(new PointF(StaLine[usIndex], Y_Offect));
            if (RowNum > 0)
            {
                for (usIndex = 0; usIndex < RowNum; usIndex++)
                {
                    X_Off = base.Shape_offset + X_Offect;
                    Y_Off = Y_Offect;
                    Ell_X = base.halfLength - X_Offect;
                    Ell_Y = (Ell_Desc + Ell_Offect) * usIndex + Ell_Desc;
                    Line_Point[usIndex * 2 + 1].AddRange(Ell_Function.GetEllPointWithX(X_Off, Y_Off, Ell_X, Ell_Y, StaLine));
                    Ell_Y += Ell_Offect;
                    Line_Point[usIndex * 2 + 2].AddRange(Ell_Function.GetEllPointWithX(X_Off, Y_Off, Ell_X, Ell_Y, StaLine));
                }
            }
            Line_Point[Line_Point.Count() - 1].AddRange(Ell_Function.GetEllPointWithX(base.Shape_offset, Y_Offect, base.halfLength, base.padWidth / 2 - Y_Offect, StaLine));

            //获得顺序调整后的象限1的坐标
            for (usIndex = 1; usIndex < Line_Point.Count(); usIndex++)
            {
                if (usIndex % 2 == 1)
                {
                    Line_Point[usIndex].RemoveAt(Line_Point[usIndex].Count - 1);
                    Line_Point[usIndex].Reverse();
                }
            }          

            //获得第四象限坐标
            for (usIndex = 0; usIndex < Line_Point.Count(); usIndex++)
            {
                MLine_Point[usIndex] = GetDeepCopy(ref Line_Point[Line_Point.Count() - usIndex - 1]);
                MLine_Point[usIndex].Reverse();
            }
            for (usIndex = 0; usIndex < Line_Point.Count(); usIndex++)
            {
                for (UInt16 i = 0; i < MLine_Point[usIndex].Count; i++)
                    MLine_Point[usIndex][i].Y *= -1;
            }

            //获得中间线坐标
            usNum = (UInt16)((base.padWidth / base.yDirectGauge) + 1);
            for (usIndex = 0; usIndex < usNum; usIndex++)
                Mid_Line.Add(new PointF(base.Shape_offset, base.padWidth / 2 - (base.yDirectGauge * usIndex)));
            if (Mid_Line[Mid_Line.Count - 1].Y > (-1 * (base.padWidth / 2)))
                Mid_Line.Add(new PointF(base.Shape_offset, -1 * (base.padWidth / 2)));

            //获得总体坐标
            base.Shape_Point.AddRange(Mid_Line);
            usNum = (UInt16)(Line_Point.Count());
            for (usIndex = 0; usIndex < usNum; usIndex++)
                base.Shape_Point.AddRange(MLine_Point[usIndex]);
            for (usIndex = 0; usIndex < usNum; usIndex++)
                base.Shape_Point.AddRange(Line_Point[usIndex]);
        }

        private void AddLockPoint(ref List<PointF> Point_Line)
        {
            PointF Point1 = new PointF(0, 0);
            PointF Point2 = new PointF(0, 0);
            PointF Point3 = new PointF(0, 0);

            Point1 = GetMiddlePoint(Point_Line[0], Point_Line[1]);
            Point2 = new PointF(Point_Line[1].X, Point_Line[1].Y);
            Point3 = GetMiddlePoint(Point_Line[1], Point_Line[2]);

            Point_Line.Insert(0, Point2); //插入起始锁线点
            Point_Line.Insert(3, Point1);
            Point_Line.Insert(4, Point3);

            Point2 = new PointF(Point_Line[Point_Line.Count - 2].X, Point_Line[Point_Line.Count - 2].Y);
            Point1 = new PointF(Point_Line[Point_Line.Count - 1].X, Point_Line[Point_Line.Count - 1].Y);
            Point_Line.Insert(Point_Line.Count, Point2);
            Point_Line.Insert(Point_Line.Count, Point1);//末尾的锁线点
        }

        public override List<PointF> GetLeftPoint()
        {
            List<PointF> Left_Point = new List<PointF>(); //列表复制
            Left_Point = GetDeepCopy(ref Shape_Point);

            if (Left_Point.Count > 3)
                AddLockPoint(ref Left_Point);

            for (int i = 0; i < Left_Point.Count; i++) //X坐标取反
                Left_Point[i].X *= -1;

            Left_Point.Reverse();

            return Left_Point;
        }

        public override List<PointF> GetRightPoint()
        {
            List<PointF> Right_Point = new List<PointF>();
            Right_Point = GetDeepCopy(ref Shape_Point);//列表复制

            if (Right_Point.Count > 3)
                AddLockPoint(ref Right_Point);

            return Right_Point;
        }

        private void GetConnectPoint(ref List<PointF> Point_Line)
        {
            float Tmp_Y = Point_Line[0].Y;
            Point_Line.Insert(0, new PointF((float)0, Tmp_Y));
        }

        public override List<PointF> GetAllPoint()
        {
            List<PointF> Half_Left = new List<PointF>(this.GetLeftPoint()); //列表复制   
            List<PointF> Half_Right = new List<PointF>(this.GetRightPoint()); //列表复制

            List<PointF> All_Point = new List<PointF>();

            GetConnectPoint(ref Half_Right);
            All_Point.AddRange(Half_Left);
            All_Point.AddRange(Half_Right);
            return All_Point;
        }
    }

}
