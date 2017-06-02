using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class DefaultValue
    {
        private Size defaultBackSize;
        private Size defaultPointSize;
        private static DefaultValue defaultValue;
        private Single clothClampSpace;
        private Single invalidPointXDist;
        private Single invalidPointYDist;
        public Point CenterPoint
        {
            get {
                return new Point(defaultBackSize.Width / 2,defaultBackSize.Height/2);
            }
        }
        public Size DefaultBackSize
        {
            get {
                return defaultBackSize;
            }
            set {
                defaultBackSize = value;
            }
        }
        public Single InvalidPointXDist
        {
            get {
                return invalidPointXDist;
            }
        }
        public Single InvalidPointYDist
        {
            get {
                return invalidPointYDist;
            }
        }
        public Single ClothClampSpace
        {
            get {
                return clothClampSpace;
            }
        }
        public Size DefaultPointSize
        {
            get {
                return defaultPointSize;
            }
        }
        public static DefaultValue DefaultValueEx
        {
            get {
                if (defaultValue == null)
                    defaultValue = new DefaultValue();
                return defaultValue;
            }
        }
        private DefaultValue()
        {
            defaultBackSize = new Size(568, 370);
            defaultPointSize = new Size(4, 4);
            clothClampSpace = 70F;   //夹布器 X方向间距
            invalidPointXDist = 10F;
            invalidPointYDist = 10F;
        }
    }
}
