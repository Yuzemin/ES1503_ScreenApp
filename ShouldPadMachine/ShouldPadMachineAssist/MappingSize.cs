using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class MappingSize
    {
        private Size screenSize;
        private SizeF lowerMachineSize;
        private Point centerPoint;
        private static MappingSize mappingSize;
        public static MappingSize MappingSizeEx
        {
            get {
                if (mappingSize == null)
                    mappingSize = new MappingSize();
                return mappingSize;
            }
        }
        public Size ScreenSize
        {
            set {
                screenSize = value;
                centerPoint = new Point(screenSize.Width/2,screenSize.Height/2);
            }
            get {
                return screenSize;
            }
        }
        public SizeF LowerMachineSize
        {
            set {
                lowerMachineSize = new SizeF(value.Width * 1.1F,value.Height * 1.1F);
            }
        }
        public double MappingRatio//映射比例
        {
            get {
                double radioX = 1;
                double radioY = 1   ;
                if (lowerMachineSize != SizeF.Empty)
                {
                    radioX = (double)screenSize.Width / (double)lowerMachineSize.Width;
                    radioY = (double)screenSize.Height / (double)lowerMachineSize.Height;
                    radioX = Math.Round(radioX, 2);
                    radioY = Math.Round(radioY, 2);
                }
                double mappingRatio = radioX < radioY ? radioX : radioY;
                return mappingRatio;
            }
        }
        private MappingSize()
        { 
            
        }
    }
}
