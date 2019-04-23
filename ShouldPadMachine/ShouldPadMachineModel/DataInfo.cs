using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class DataInfo // 数据信息类
    {
        private double maxValue;
        private double minValue;
        private bool minusEnable;
        private bool pointEnable;
        private double editUnit;
        private UnitType unitType;

        public double EditUnit
        {
            get {
                return editUnit;
            }
            set {
                editUnit = value;
            }
        }
        public UnitType UnitType
        {
            get {
                return unitType;
            }
            set {
                unitType = value;
            }
        }
        public double MaxValue
        {
            get
            {
                return maxValue;
            }
            set {
                maxValue = value;
            }
        }
        public double MinValue
        {
            get
            {
                return minValue;
            }
        }
        public bool MinusEnable
        {
            get
            {
                return minusEnable;
            }
        }
        public bool PointEnable
        {
            get
            {
                return pointEnable;
            }
        }
        public UInt16 SerialDataMaxValue
        {
            get
            {
                double addValue;
                double serialDataMaxValue = maxValue;
                if (maxValue > Math.Abs(minValue))
                    addValue = maxValue;
                else
                    addValue = Math.Abs(minValue);
                if (minusEnable == true)
                    serialDataMaxValue += addValue;
                if (pointEnable == true)
                    serialDataMaxValue *= 10;
                return Convert.ToUInt16(serialDataMaxValue);
            }
        }
        public DataInfo(double minValue, double maxValue, bool minusEnable, bool pointEnable, UnitType unitType)
            : this(minValue, maxValue, minusEnable, pointEnable)
        {
            this.unitType = unitType;
        }
        public DataInfo(double minValue, double maxValue, bool minusEnable, bool pointEnable)
        {
            this.maxValue = maxValue;
            this.minusEnable = minusEnable;
            this.minValue = minValue;
            this.pointEnable = pointEnable;
            this.unitType = UnitType.Null;
        }
        public DataInfo()
        {
            maxValue = double.MaxValue;
            minValue = double.MinValue;
            minusEnable = false;
            pointEnable = false;
            unitType = UnitType.Null;
            editUnit = 1;
        }
    }
    public abstract class DataInfoSet
    {
        protected abstract DataInfo[] DataInfos
        {
            get;
            set;
        }
        protected DataInfo this[int index]
        {
            get
            {
                if (DataInfos != null && index < DataInfos.Length)
                    return DataInfos[index];
                else
                    return null;
            }
        }
        public DataInfo this[String enumName]
        {
            get
            {
                int index = GetEnumIndexByName(enumName);
                return this[index];
            }
        }
        protected abstract int GetEnumIndexByName(String enumName);
    }
    public class ShouldPadDataInfoSet : DataInfoSet
    {
        private DataInfo[] dataInfoSet;
        protected override DataInfo[] DataInfos
        {
            get
            {
                return dataInfoSet;
            }
            set
            {
                dataInfoSet = value;
            }
        }
        public ShouldPadDataInfoSet()
        {
            dataInfoSet = new DataInfo[] { 
            null,
            new DataInfo(50,400,false,false),   //左夹布夹间隙
            new DataInfo(50,400,false,false),   //主夹布夹间隙
            new DataInfo(50,400,false,false),   //右夹布夹间隙
            new DataInfo(100,600,false,false),    //花形长度
            new DataInfo(100,300,false,false),    //花形宽度
            new DataInfo(50,300,false,false),    //花形半长度
            new DataInfo(0,100,false,false),    //半个花型行数
            new DataInfo(2,100,false,false),    //半个花型列数
            new DataInfo(1,35,false,false),    //X轴方向间距
            new DataInfo(1,35,false,false),    //Y轴方向间距
            new DataInfo(5,35,false,false),    //锯齿振幅
            new DataInfo(0,30,false,false),     //弧度程度
            new DataInfo(100,2000,false,false),  //普通速度
            new DataInfo(0,350,false,false),    //剪线距离
            new DataInfo(1,100,false,false),    //底线件数            
            };
        }
        protected override int GetEnumIndexByName(string enumName)
        {
            ShouldPadDataEnum mouldDataEnum = (ShouldPadDataEnum)Enum.Parse(typeof(ShouldPadDataEnum), enumName, true);
            return Convert.ToInt32(mouldDataEnum);
        }
    }
    public class MachineBaseDataInfoSet : DataInfoSet
    {
        private DataInfo[] dataInfoSet;
        protected override DataInfo[] DataInfos
        {
            get
            {
                return dataInfoSet;
            }
            set
            {
                dataInfoSet = value;
            }
        }
        protected override int GetEnumIndexByName(string enumName)
        {
            MachineBaseDataEnum machineBaseDataEnum = (MachineBaseDataEnum)Enum.Parse(typeof(MachineBaseDataEnum), enumName, true);
            return Convert.ToInt32(machineBaseDataEnum);

        }
        public MachineBaseDataInfoSet()
        {
            dataInfoSet = new DataInfo[]{
            new DataInfo(1,100,false,false),         //ID号
            new DataInfo(100,2800,false,false),      //电机速度
            new DataInfo(-400,400,true,false),       //X零位修正
            new DataInfo(-400,400,true,false),       //Y零位修正
            new DataInfo(-150,150,true,false),       //上针位编码器修正值
            new DataInfo(1,65525,false,false),       //总件数限制
            new DataInfo(1,999,false,false),         //低峰件数限制
            new DataInfo(1,350,false,false) ,        //剪线距离
            new DataInfo(100,1000,false,false),      //角度
            new DataInfo(10,500,false,false),        //跟随距离范围
            };
        }
    }
}