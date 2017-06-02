using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class ValueRange
    {
        private int maxValue;
        private int minValue;
        public int MaxValue
        {
            get {
                return maxValue;
            }
        }
        public int MinValue
        {
            get {
                return minValue;
            }
        }
        public ValueRange(int minValue,int maxValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }
    }
}
