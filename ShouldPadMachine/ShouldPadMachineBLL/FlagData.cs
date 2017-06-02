using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class MainFormFlagData
    {
        public bool ReachesPositionWarn { get; set; }
        public int TotalNeedleNumber { get; set; }
        public int WorkNeedleNumber { get; set; }
        public int TotalWorkedNumber { get; set; }
        public int WorkedNumber { get; set; }
        public bool Working { get; set; }
        public bool ClickSewingButton { get; set; }
        public bool CascadeOver { get; set; }
        public bool BreakLineWarn { get; set; }

        public bool CommunicationWarn { get; set; }
        public ushort TestData{set;get;}
        public ushort BootomWorkedNumber { get; set; }

        public bool ModeSwitchWarn { get; set; }
        public bool WorkedNumberOverflowWarn { get; set; }
        public bool TotalWorkedNumberOverflowWarn { get; set; }
        public bool LineBreakWarn { get; set; }
        public bool CrdWarn { get; set; }


        public bool SFLVoltWarn { get; set; }
        public bool STLVoltWarn { get; set; }
        public bool IOLVoltWarn { get; set; }
        public bool SF_QepErrWarn { get; set; }
        public bool SF_NoMotorWarn { get; set; }
        public bool SF_OCurWarn { get; set; }
        public bool SF_OLoadWarn { get; set; }
        public bool SF_NoEcdWarn { get; set; }
        public bool X_QepErrWarn { get; set; }
        public bool X_OLoadWarn { get; set; }
        public bool X_OCurWarn { get; set; }
        public bool X_NoMotorWarn { get; set; }
        public bool Y_QepErrWarn { get; set; }
        public bool Y_OLoadWarn { get; set; }
        public bool Y_OCurWarn { get; set; }
        public bool Y_NoMotorWarn { get; set; }
        public bool SysTimeOutWarn { get; set; }
        public bool SysRePowerWarn { get; set; } 
        public bool TakeClothUpperSensorWarn { get; set; }
        public bool TakeClothMidSensorWarn { get; set; }
        public bool TakeClothDownSensorWarn { get; set; }
        public bool TakeClothLeftSensorWarn { get; set; }
        public bool TakeClothRightSensorWarn { get; set; }
        public bool XBackToZeroSensorWarn { get; set; }
        public bool YBackToZeroSensorWarn { get; set; }
        public bool ServoBackToZeroSensorWarn { get; set; }
    }
    public class EditFormFlagData
    {
        public bool ClickSewingButton { get; set; }
        public bool PaintEditForm { get; set; }
    }
    public class BaseDataFormFlagData
    {
        public short UpNeedleCodeNumber { get; set; }
        public short ServoNewCodeValue { get; set; }
        public short ServoCodeValue { get; set; }        
        public short ServoCodeValue1 { get; set; }
    }
    public class ModifyFormFlagData
    {
        public bool ClickSewingButton { get; set; }
    }
    public class TestFormFlag
    {
        public bool ServoSensor { get; set; }
        public bool xSensor { get; set; }
        public bool ySensor { get; set; }
        public bool greenKey1 { get; set; }
        public bool redKey1 { get; set; }

        public bool greenKey2 { get; set; }
        public bool redKey2 { get; set; }
        public bool clampSensorLower { get; set; }
        public bool clampSensorMid { get; set; }
        public bool clampSensorUp { get; set; }
        public bool carrySensorLeft { get; set; }
        public bool carrySensorRight { get; set; }


      
    }
}
