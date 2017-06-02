using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineHelper
{
    public class ShapePointInfo
    {
        private Point[] shapePoints;
        private int[] errorPointIndexs;
        private int[] warnPointIndex;
        private Color shapeColor;
        public Color ShapeColor
        {
            get {
                return shapeColor;
            }
        }
        public Point[] ShapePoints
        {
            get
            {
                return shapePoints;
            }
            set {
                shapePoints = value;
            }
        }
        public int[] ErrorPointIndexs
        {
            get {
                return errorPointIndexs;
            }
        }
        public int[] WarnPointIndex
        {
            get {
                return warnPointIndex;
            }
        }
        public ShapePointInfo(Point[] shapePoints, int[] errorPointIndexs, int[] warnPointIndex)
        {
            this.shapePoints = shapePoints;
            this.errorPointIndexs = errorPointIndexs;
            this.warnPointIndex = warnPointIndex;
            shapeColor = DefaultColor.DefaultColorEx.DefaultShapeColor;
        }
        public ShapePointInfo(Point[] shapePoints,int[] errorPointIndexs,int[] warnPointIndex,Color pointColor)
        {
            this.shapePoints = shapePoints;
            this.errorPointIndexs = errorPointIndexs;
            this.warnPointIndex = warnPointIndex;
            this.shapeColor = pointColor;
        }
    }
}
