using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class ShouldPadShapeInfo
    {
        private Point[] shapePoints;
        private ClothClamp[] clothClamps;
        public ClothClamp[] ClothClamps
        {
            get {
                return clothClamps;
            }
        }
        public Point[] ShapePoints
        {
            get {
                return shapePoints;
            }
        }
        public ShouldPadShapeInfo(Point[] shapePoints, ClothClamp[] clothClamps)
        {
            this.shapePoints = shapePoints;
            this.clothClamps = clothClamps;
        }

    }
    public class EditShouldPadInfo
    {
        private double originalMappingRatio;
        private Single[] shapeParams;
        private ShouldPadShapeInfo shouldPadShapeInfo;
        public Single[] ShapeParams
        {
            get {
                return shapeParams;
            }
        }
        public ShouldPadShapeInfo ShouldPadShapeInfo
        {
            get {
                return shouldPadShapeInfo;
            }
        }
        public double OriginalMappingRatio
        {
            get {
                return originalMappingRatio;
            }
        }
        public EditShouldPadInfo(Single[] shapeParams, ShouldPadShapeInfo shouldPadShapeInfo, double originalMappingRatio)
        {
            this.originalMappingRatio = originalMappingRatio;
            this.shapeParams = shapeParams;
            this.shouldPadShapeInfo = shouldPadShapeInfo;
        }
        
    }
}
