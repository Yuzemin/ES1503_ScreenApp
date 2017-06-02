using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class PointF
    {
        private Single x;
        private Single y;
        public Single X
        {
            get {
                return x;
            }
            set {
                x = value;
            }
        }
        public Single Y
        {
            get {
                return y;
            }
            set {
                y = value;
            }
        }
        public static PointF Empty
        {
            get {
                return new PointF(0, 0);
            }
        }
        public PointF(Single x, Single y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
