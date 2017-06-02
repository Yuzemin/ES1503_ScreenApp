using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineHelper;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineDWL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class ShapeOperManager
    {
        private List<Point[]> shapePointCollect;
        private DrawShapeDC drawShapeDC;
        private Point[] shapePoints;
        private Point plusPoint;
        private CircleDotLine movePlus;
        private CircleDot locatPlus;
        private bool movePlusVisable;
        private bool locatPlusVisable;
        private int moveSelectPointIndex;
        private int selectPointIndex;
        private int oldSelectPointIndex;
        private Size backGroundSize;
        private ClothClamp[] clothClamps;
        private bool haveIrregularPoint;
        private MoveType moveType;
        private int plusShapeSize;
        private ValueRange[] pointValueRanges;

        public bool HaveIttegularPoint
        {
            get {
                return haveIrregularPoint;
            }
        }
        public int SelectPointIndex
        {
            get {
                return selectPointIndex;
            }
            set {
                if (selectPointIndex != value && moveType== MoveType.MoveShapeSelectPoint)
                {
                    if (value != -1 && selectPointIndex != -1)
                    {
                        if (shapePoints != null && value != shapePoints.Length && selectPointIndex != shapePoints.Length)
                        {
                            if (selectPointIndex != shapePoints.Length)
                                oldSelectPointIndex = selectPointIndex;
                        }
                    }
                    selectPointIndex = value;
                }
            }
        }
        public MoveType MoveType
        {
            set
            {
                if (moveType != value)
                {
                    if (moveType == MoveType.MoveShape)
                    {
                        SetShapePoints(shapePoints,false);
                    }
                    moveType = value;
                    if (moveType == MoveType.MoveShapeUnSelectPoint && shapePoints != null && selectPointIndex <shapePoints.Length)
                    {
                        movePlusVisable = true;
                        locatPlusVisable = false;
                        plusPoint = shapePoints[selectPointIndex];
                        if (locatPlus != null)
                            drawShapeDC.EraseLocatShape(locatPlus.GetLocatShapePoints(),locatPlus.GetPointColors());
                        DrawShapeSection(true);

                    }
                    else if (moveType == MoveType.MoveShapeSelectPoint)
                    {
                        movePlusVisable = false;
                        locatPlusVisable = true;
                        if (movePlus != null)
                            drawShapeDC.EraseLocatShape(movePlus.GetLocatShapePoints(), movePlus.GetPointColors());
                        DrawShapeSection(false);
                    }
                    else if (moveType == MoveType.MoveShape)
                    {
                        movePlusVisable = false;
                        locatPlusVisable = false;
                        plusPoint = Point.Empty;
                        SetShapePoints(shapePoints, DefaultColor.DefaultColorEx.DefaultPlueColor);
                    }
                    else
                    {
                        movePlusVisable = false;
                        locatPlusVisable = false;
                        if (movePlus != null)
                            drawShapeDC.EraseLocatShape(movePlus.GetLocatShapePoints(), movePlus.GetPointColors());
                        if (locatPlus != null)
                            drawShapeDC.EraseLocatShape(locatPlus.GetLocatShapePoints(), locatPlus.GetPointColors());
                        drawShapeDC.EraseString();

                    }
                }
            }
        }
        private void DrawShapeSection(bool eraseShapeSection)
        {
            List<Point> erasePointList = new List<Point>();
            Point[] selectPoints = null;
            int selectIndex = 0;
            if (eraseShapeSection)
            {
                selectIndex = selectPointIndex;
                moveSelectPointIndex = selectPointIndex;
            }
            else
                selectIndex = moveSelectPointIndex;
            if (shapePoints != null && shapePoints.Length > 1)
            {
                if (selectIndex == 0)
                {
                    erasePointList.Add(shapePoints[selectIndex]);
                    erasePointList.Add(shapePoints[selectIndex + 1]);
                }
                else if (selectIndex == shapePoints.Length - 1)
                {
                    erasePointList.Add(shapePoints[selectIndex]);
                    erasePointList.Add(shapePoints[selectIndex - 1]);
                }
                else
                {
                    erasePointList.Add(shapePoints[selectIndex - 1]);
                    erasePointList.Add(shapePoints[selectIndex]);
                    erasePointList.Add(shapePoints[selectIndex + 1]);
                }
                selectPoints = new Point[1];
                selectPoints[0] = shapePoints[selectIndex];
                drawShapeDC.DrawNormalShapeSection(erasePointList.ToArray(), selectPoints, eraseShapeSection);
            }
        }
        public int ShapePointLength
        {
            get {
                int length = 0;
                if (shapePoints != null)
                    length = shapePoints.Length;
                return length;
            }
        }
        public ShapeOperManager(Size size)
        {
            moveType = MoveType.Null;
            plusShapeSize = 3;
            drawShapeDC = new DrawShapeDC(size);
            this.backGroundSize = size;
        }
        private void LoadPointValueRange()
        {
            int maxX, minX;
            int maxY, minY;
            if (shapePoints != null)
            {
                maxX = shapePoints[0].X;
                minX = maxX;
                minY = shapePoints[0].Y;
                maxY = minY;
                for (int i = 0; i < shapePoints.Length; i++)
                {
                    if (shapePoints[i].X > maxX)
                        maxX = shapePoints[i].X;
                    if (shapePoints[i].X < minX)
                        minX = shapePoints[i].X;
                    if (shapePoints[i].Y > maxY)
                        maxY = shapePoints[i].Y;
                    if (shapePoints[i].Y < minY)
                        minY = shapePoints[i].Y;
                }
                pointValueRanges = new ValueRange[2];
                pointValueRanges[0] = new ValueRange(minX, maxX);
                pointValueRanges[1] = new ValueRange(minY, maxY);
            }
        }
        public void MovePlus(DirectionType directionType)
        {
            switch (directionType)
            { 
                case DirectionType.MoveDown:
                    plusPoint.Y -= 1;
                    break;
                case DirectionType.MoveLeft:
                    plusPoint.X -= 1;
                    break;
                case DirectionType.MoveLeftDown:
                    plusPoint.X -= 1;
                    plusPoint.Y -= 1;
                    break;
                case DirectionType.MoveLeftUp:
                    plusPoint.X -= 1;
                    plusPoint.Y += 1;
                    break;
                case DirectionType.MoveRight:
                    plusPoint.X += 1;
                    break;
                case DirectionType.MoveRightDown:
                    plusPoint.X += 1;
                    plusPoint.Y -= 1;
                    break;
                case DirectionType.MoveRightUp:
                    plusPoint.X += 1;
                    plusPoint.Y += 1;
                    break;
                case DirectionType.MoveUp:
                    plusPoint.Y += 1;
                    break;
                case DirectionType.MovePrevious:
                    SelectPointIndex--;
                    break;
                case DirectionType.MoveNext:
                    SelectPointIndex++;
                    break;
            }
            int maxX = ((backGroundSize.Width-4) - plusShapeSize) / 2;
            int minX = maxX * -1;
            int maxY = ((backGroundSize.Height-4) - plusShapeSize) / 2;
            int minY = maxY * -1;
            if (moveType != MoveType.MoveShape)
            {
                if (directionType == DirectionType.MoveNext || directionType == DirectionType.MovePrevious)
                {
                    MoveType = MoveType.MoveShapeSelectPoint;
                    if (shapePoints != null)
                    {
                        if (selectPointIndex < 0)
                            SelectPointIndex = 0;
                        if (selectPointIndex >= shapePoints.Length)
                            SelectPointIndex = shapePoints.Length - 1;
                    }
                }
                else
                {
                    if (plusPoint.X > maxX)
                        plusPoint.X = maxX;
                    if (plusPoint.Y > maxY)
                        plusPoint.Y = maxY;
                    if (plusPoint.X < minX)
                        plusPoint.X = minX;
                    if (plusPoint.Y < minY)
                        plusPoint.Y = minY;
                    MoveType = MoveType.MoveShapeUnSelectPoint;
                    movePlusVisable = true;
                }
            }
            else
            {
                if (pointValueRanges != null)
                {
                    if (plusPoint.X + pointValueRanges[0].MaxValue > maxX)
                        plusPoint.X -= 1;
                    if (plusPoint.X + pointValueRanges[0].MinValue < minX)
                        plusPoint.X += 1;
                    if (plusPoint.Y + pointValueRanges[1].MaxValue > maxY)
                        plusPoint.Y -= 1;
                    if (plusPoint.Y + pointValueRanges[1].MinValue < minY)
                        plusPoint.Y += 1;
                }
            }
        }
        public void DeleteShapePoint()
        {
            if (shapePoints != null)
            {
                if (selectPointIndex < shapePoints.Length && selectPointIndex >= 0 && shapePoints.Length > 2)
                {
                    List<Point> shapePointList = new List<Point>();
                    shapePointList.AddRange(shapePoints);
                    shapePointList.RemoveAt(selectPointIndex);
                    SetShapePoints(shapePointList.ToArray());
                    MoveType = MoveType.MoveShapeSelectPoint;
                }
            }
        }
        public void MirrorShapePoint(int dir)
        {
            List<Point> mirrorPointList = new List<Point>();
            List<Point> shapePointList = new List<Point>();
            Point left_Con, right_Con, Connect;

            if (shapePoints[0].X < 0)
            {
                for (int i = 0; i < shapePoints.Length; i++)
                {
                    if (shapePoints[i].X >= 0) // 只获得左半花型
                        break;
                    shapePointList.Add(shapePoints[i]);

                    if (dir == 0)
                        mirrorPointList.Add(new Point(shapePoints[i].X * -1, shapePoints[i].Y));
                    else
                        mirrorPointList.Add(new Point(shapePoints[i].X * -1, shapePoints[i].Y * -1));
                }
                mirrorPointList.Reverse();
                left_Con = shapePointList[shapePointList.Count - 1];
                right_Con = mirrorPointList[0];
                Connect = new Point((left_Con.X + right_Con.X) / 2, (left_Con.Y + right_Con.Y) / 2);
                shapePointList.Add(Connect);
                shapePointList.AddRange(mirrorPointList);
            }
            else //表明图像只有在X轴正方向的点或者没有点
            {
                for (int i = shapePoints.Length - 1; i >= 0; i--)
                {
                    if (dir == 0)
                        mirrorPointList.Add(new Point(shapePoints[i].X * -1, shapePoints[i].Y));
                    else
                        mirrorPointList.Add(new Point(shapePoints[i].X * -1, shapePoints[i].Y * -1));
                }

                left_Con = mirrorPointList[mirrorPointList.Count - 1];
                right_Con = shapePoints[0];
                Connect = new Point((left_Con.X + right_Con.X) / 2, (left_Con.Y + right_Con.Y) / 2);
                shapePointList.AddRange(mirrorPointList.ToArray());
                shapePointList.Add(Connect);
                shapePointList.AddRange(shapePoints);
            }

            SetShapePoints(shapePointList.ToArray());
            MoveType = MoveType.MoveShapeSelectPoint;
        }
        public void AppendShapePoint()
        {
            int newX, newY;
            if (shapePoints != null)
            {
                int maxX = ((backGroundSize.Width - 4) - plusShapeSize) / 2;
                int maxY = ((backGroundSize.Height - 4) - plusShapeSize) / 2;

                if (selectPointIndex >= 0 && selectPointIndex < shapePoints.Length)
                {
                    Point[] copyPoints = new Point[shapePoints.Length + 1];
                    for (int i = 0,j=0; i < shapePoints.Length; i++,j++)
                    {
                        if (j == selectPointIndex + 1)
                        {
                            newX = shapePoints[i].X + 6;
                            newY = shapePoints[i].Y + 6;
                            copyPoints[j].X = (newX > maxX) ? maxX : newX;
                            copyPoints[j].Y = (newY > maxY) ? maxY : newY;
                        }
                        else
                            copyPoints[j] = shapePoints[i];
                        if (j == selectPointIndex)
                            i--;
                    }
                    SetShapePoints(copyPoints, true);
                    SelectPointIndex++;
                    moveType = MoveType.Null;
                    MoveType = MoveType.MoveShapeUnSelectPoint;
                }
            }
        }
        public void MoveShapePoint()
        {
            if (moveType == MoveType.MoveShapeUnSelectPoint)
            {
                MoveType = MoveType.MoveShapeSelectPoint;
                if (shapePoints != null)
                {
                    if (selectPointIndex < shapePoints.Length && selectPointIndex >= 0)
                    {
                        if (shapePoints[selectPointIndex] != plusPoint)
                        {
                            shapePoints[selectPointIndex] = plusPoint;
                            SetShapePoints(shapePoints,true);
                        }
                    }
                }
            }
            if (moveType == MoveType.MoveShape)
            {
                MoveType = MoveType.MoveShapeSelectPoint;
                SetShapePoints(shapePoints);
            }
            
        }
        public void RevokeShapesOPer()
        {
            if (moveType == MoveType.MoveShapeUnSelectPoint)
                MoveType = MoveType.MoveShapeSelectPoint;
            else
            {
                if (shapePointCollect.Count > 1)
                {
                    shapePointCollect.RemoveAt(shapePointCollect.Count - 1);
                    SetShapePoints(shapePointCollect[shapePointCollect.Count - 1], false);
                }
            }
        }
        private void SetShapePoints(Point[] shapePoints)
        {
            SetShapePoints(shapePoints, true);
        }
        private void SetShapePoints(Point[] shapePoints, bool newShapes)
        {
            this.shapePoints = new Point[shapePoints.Length];
            shapePoints.CopyTo(this.shapePoints, 0);
            if (newShapes)
            {
                if (shapePointCollect == null)
                    shapePointCollect = new List<Point[]>();
                shapePointCollect.Add(shapePoints);
            }
            ClearBitmap();
            int[] irregularPointIndexs = GetIrregularPointIndexs();
            if (irregularPointIndexs == null || irregularPointIndexs.Length == 0)
                haveIrregularPoint = false;
            else
                haveIrregularPoint = true;
            drawShapeDC.DrawNormalShape(new ShapePointInfo(shapePoints, GetIrregularPointIndexs(), GetWarnPointIndexs()));
            if (selectPointIndex >= shapePoints.Length)
                SelectPointIndex = shapePoints.Length - 1;
            if (oldSelectPointIndex >= shapePoints.Length)
            {
                if (selectPointIndex > 0)
                    oldSelectPointIndex = selectPointIndex - 1;
                else
                    oldSelectPointIndex = selectPointIndex;
            }
        }

        private void SetShapePoints(Point[] shapePoints, Color shapeColor)
        { 
            this.shapePoints = new Point[shapePoints.Length];
            shapePoints.CopyTo(this.shapePoints,0);
            ClearBitmap();
            drawShapeDC.DrawNormalShape(new ShapePointInfo(shapePoints, null, null,shapeColor));
        }

        private void ClearBitmap()
        {
            if (locatPlus != null)
                drawShapeDC.EraseLocatShape(locatPlus.GetLocatShapePoints(), locatPlus.GetPointColors());
            if (movePlus != null)
                drawShapeDC.EraseLocatShape(movePlus.GetLocatShapePoints(), movePlus.GetPointColors());
            drawShapeDC.ClearBitmap();
            if (clothClamps != null)
            {
                for (int i = 0; i < clothClamps.Length; i++)
                {
                    drawShapeDC.DrawRange(clothClamps[i].RangeLinePoints());
                    drawShapeDC.DrawClothCramp(clothClamps[i].ClothClampRect, clothClamps[i].ClothClampPoint);
                }
            }
        }
        private int[] GetWarnPointIndexs()
        {
            List<int> warnPointIndexList = new List<int>();
            if (shapePoints != null)
            {
                for (int i = 1; i < shapePoints.Length; i++)
                {
                    if (clothClamps != null)
                    {
                        for (int j = 0; j < clothClamps.Length; j++)
                        {
                            if (clothClamps[j].Contains(shapePoints[i - 1], shapePoints[i]))
                                warnPointIndexList.Add(i);
                        }
                    }
                }
            }
            return warnPointIndexList.ToArray();
        }
        private int[] GetIrregularPointIndexs()
        {
            List<int> irregularPointIndexList = new List<int>();
            if (shapePoints != null)
            {
                for (int i = 0; i < shapePoints.Length; i++)
                {
                    if (clothClamps != null)
                    {
                        for (int j = 0; j < clothClamps.Length; j++)
                        {
                            if (clothClamps[j].Contains(shapePoints[i]))
                                irregularPointIndexList.Add(i);
                        }
                    }
                }
            }
            return irregularPointIndexList.ToArray();
        }
        public void  SetShouldPadShapeInfo(ShouldPadShapeInfo shouldPadShapeInfo)
        {
            if (shouldPadShapeInfo != null)
            {
                if(shapePointCollect != null)
                    shapePointCollect.Clear();
                clothClamps = shouldPadShapeInfo.ClothClamps;
                SetShapePoints(shouldPadShapeInfo.ShapePoints);
                SelectPointIndex = 0;
                moveSelectPointIndex = 0;
            }
        }
        public ShouldPadShapeInfo GetShouldPadShapeInfo()
        {
            return new ShouldPadShapeInfo(shapePoints, clothClamps);
        }
        public Bitmap GetShapeBitmap()
        {
            if (shapePoints != null && shapePoints.Length != 0)
            {
                if (movePlusVisable)
                {
                    Color[] plusColors;
                    movePlusVisable = false;
                    if (movePlus == null)
                        movePlus = new CircleDotLine(DefaultColor.DefaultColorEx.DefaultMovePlusColor, plusShapeSize);
                    else
                        drawShapeDC.EraseLocatShape(movePlus.GetLocatShapePoints(), movePlus.GetPointColors());
                    Nullable<Point> point1 = null;
                    Nullable<Point> point2 = null;
                    if (shapePoints.Length > 1)
                    {
                        if (selectPointIndex == 0)
                        {
                            point1 = null;
                            point2 = shapePoints[selectPointIndex + 1];
                        }
                        else if (selectPointIndex == shapePoints.Length - 1)
                        {
                            point1 = shapePoints[selectPointIndex - 1];
                            point2 = null;
                        }
                        else
                        {
                            point1 = shapePoints[selectPointIndex - 1];
                            point2 = shapePoints[selectPointIndex + 1];
                        }
                    }
                    movePlus.SetPointIn(plusPoint, point1, point2);
                    plusColors = drawShapeDC.DrawLocatShape(movePlus.GetLocatShapePoints(), movePlus.ShapeColor);
                    movePlus.SetPointColor(plusColors);
                    ShowPointInfo();
                }
                if (locatPlusVisable)
                {
                    if (locatPlus != null)
                        drawShapeDC.EraseLocatShape(locatPlus.GetLocatShapePoints(), locatPlus.GetPointColors());
                    else
                        locatPlus = new CircleDot(DefaultColor.DefaultColorEx.DefaultPlueColor, plusShapeSize);
                    locatPlus.SetPointIn(shapePoints[selectPointIndex]);
                    Color[] plusColors = drawShapeDC.DrawLocatShape(locatPlus.GetLocatShapePoints(), locatPlus.ShapeColor);
                    locatPlus.SetPointColor(plusColors);
                    ShowPointInfo();
                }
                if (moveType == MoveType.MoveShape)
                {
                    if (plusPoint != Point.Empty)
                    {
                        for (int i = 0; i < shapePoints.Length; i++)
                        {
                            shapePoints[i].X += plusPoint.X;
                            shapePoints[i].Y += plusPoint.Y;
                        }
                        plusPoint = Point.Empty;
                        SetShapePoints(shapePoints, DefaultColor.DefaultColorEx.DefaultPlueColor);
                        LoadPointValueRange();
                    }
                } 
            }
            return drawShapeDC.ShapeBitmap;
        }
        private void ShowPointInfo()
        {
            String pointLocatInfo = String.Empty;
            if (shapePoints != null)
            {
                if (selectPointIndex >= 0 && selectPointIndex < shapePoints.Length)
                {
                    Point currentPoint = shapePoints[selectPointIndex];
                    Point oldPoint = shapePoints[oldSelectPointIndex];
                    double ration = MappingSize.MappingSizeEx.MappingRatio;
                    double pointX, pointY,distance;
                    if (moveType == MoveType.MoveShapeSelectPoint)
                    {
                        distance = (oldPoint.X - currentPoint.X) * (oldPoint.X - currentPoint.X);
                        distance += (oldPoint.Y - currentPoint.Y) * (oldPoint.Y - currentPoint.Y);
                        distance = Math.Round(Math.Sqrt(distance) / ration, 0);
                        pointX = Math.Round(currentPoint.X / ration, 0);
                        pointY = Math.Round(currentPoint.Y / ration, 0);
                        //pointLocatInfo = String.Format("X:{0},Y:{1},D{2}", currentPoint.X, currentPoint.Y, distance);
                        pointLocatInfo = String.Format("X:{0},Y:{1} D:{2} ", pointX, pointY,distance);
                    }
                    else
                    {
                        distance = (plusPoint.X - currentPoint.X) * (plusPoint.X - currentPoint.X);
                        distance += (plusPoint.Y - currentPoint.Y) * (plusPoint.Y - currentPoint.Y);
                        distance = Math.Round(Math.Sqrt(distance) / ration, 0);
                        pointX = Math.Round(currentPoint.X / ration, 0);
                        pointY = Math.Round(currentPoint.Y / ration, 0);
                        //diffPointX = Math.Round((plusPoint.X - currentPoint.X) / ration,0);
                        //diffPointY = Math.Round((plusPoint.Y - currentPoint.Y) / ration,0);
                        pointLocatInfo = String.Format("X:{0}, Y:{1} D:{2}", pointX, pointY, distance);
                    }
                }
            }
            drawShapeDC.DrawString(pointLocatInfo, new Point(backGroundSize.Width,backGroundSize.Height));
            if (clothClamps != null)
            {
                for (int i = 0; i < clothClamps.Length; i++)
                {
                    drawShapeDC.DrawRange(clothClamps[i].RangeLinePoints());
                    drawShapeDC.DrawClothCramp(clothClamps[i].ClothClampRect, clothClamps[i].ClothClampPoint);
                }
            }
        }
    }
}
