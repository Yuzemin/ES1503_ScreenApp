using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineFactory
{
    class MouldDataFactory
    {
        public static DataBaseDAO CreateDataBaseDAO(DataTypeName dataTypeName)
        {
            DataBaseDAO dataBaseDAO = null;
            switch (dataTypeName)
            {
                case DataTypeName.ShouldPadDataTable:
                    dataBaseDAO = new ShouldPadDAO();
                    break;
                case DataTypeName.InOutDataTable:
                    dataBaseDAO = new InOutDataDAO();
                    break;
                case DataTypeName.BaseDataTable:
                    dataBaseDAO = new MachineBaseDataDAO();
                    break;
                case DataTypeName.FlowDataTable:
                    dataBaseDAO = new FlowDataDAO();
                    break;
                default:
                    break;
            }
            return dataBaseDAO;
        }
        public static DataInfoSet CreateDataInfo(DataTypeName dataTypeName)
        {
            DataInfoSet dataInfoSet = null;
            switch (dataTypeName)
            { 
                case DataTypeName.BaseDataTable:
                    dataInfoSet = new MachineBaseDataInfoSet();
                    break;
                case DataTypeName.CascadeDataTable:
                    break;
                case DataTypeName.ShouldPadDataTable:
                    dataInfoSet = new ShouldPadDataInfoSet();
                    break;
                case DataTypeName.InOutDataTable:
                    break;
                default:
                    break;
            }
            return dataInfoSet;
        }
    }
}
