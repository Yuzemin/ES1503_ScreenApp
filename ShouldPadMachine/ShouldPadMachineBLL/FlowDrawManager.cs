using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class FlowDrawManager
    {
        private bool modeChange;
        private BaseDataFormFlagData flagData;


        public BaseDataFormFlagData FlagData
        {
            get { return flagData; }
            set { flagData = value; }
        }

        public bool ModeChange
        {
            get { return modeChange; }
            set { modeChange = value; }
        }
    }
}
