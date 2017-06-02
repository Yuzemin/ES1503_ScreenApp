using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class TabletComparerByTag : IComparer<Tablet>
    {
        public int Compare(Tablet x, Tablet y)
        {
            int ParamX,ParamY;

            ParamX = int.Parse(x.Tag.ToString());
            ParamY = int.Parse(y.Tag.ToString());

            if (ParamX < ParamY)
                return -1;
            else if (ParamX > ParamY)
                return 1;
            else
                return 0;
        }
    }
}
