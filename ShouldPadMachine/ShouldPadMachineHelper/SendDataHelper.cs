using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineCTL;

namespace ShouldPadMachine.ShouldPadMachineHelper
{
    public abstract class ISendData
    {
        public abstract byte[] GetSendDatas(String[] dataBaseValues, DataInfoSet dataInfoSet);
        //GetByteData() 将16位数据 转化为2个8位数据
        protected byte[] GetByteData(UInt16 baseData)
        {
            byte[] byteDatas = new byte[2];
            byteDatas[0] = Convert.ToByte(baseData & 0xFF);
            byteDatas[1] = Convert.ToByte((baseData >> 8) & 0xFF);
            return byteDatas;
        }
    }
    public class MouldInfoSendData : ISendData//模具信息发送数据
    {
        public override byte[] GetSendDatas(String[] dataBaseValues, DataInfoSet dataInfoSet)
        {
            return new byte[] { 0 };
        }
    }
    public class MachineInfoSendData : ISendData//机器信息发送数据
    {
        public static bool choicedSendFlow = false;

        public override byte[] GetSendDatas(String[] dataBaseValues, DataInfoSet dataInfoSet)
        {
            List<byte> sendDataList = new List<byte>();
            String[] flowModelDataBases = new String[40];

            //扇区表数据
            FlowDataModel.GetDataBaseModel().DataBaseValues.CopyTo(flowModelDataBases, 0);
            for (int j = 0; j < 10; j++)
            {
                sendDataList.AddRange(GetByteData(Convert.ToUInt16(flowModelDataBases[j])));
                sendDataList.AddRange(GetByteData(Convert.ToUInt16(flowModelDataBases[j + 10])));
                sendDataList.AddRange(GetByteData(Convert.ToUInt16(flowModelDataBases[j + 20])));
                sendDataList.AddRange(GetByteData(Convert.ToUInt16(flowModelDataBases[j + 30])));
            }

            //放布位置XY修正值
            sendDataList.AddRange(GetByteData(Convert.ToUInt16(dataBaseValues[(int)MachineBaseDataEnum.XZeroModify])));
            sendDataList.AddRange(GetByteData(Convert.ToUInt16(dataBaseValues[(int)MachineBaseDataEnum.YZeroModify])));

            //目标生产件数
            sendDataList.AddRange(GetByteData(Convert.ToUInt16(dataBaseValues[(int)MachineBaseDataEnum.TotalClothNumberLimit])));            
            sendDataList.AddRange(GetByteData(Convert.ToUInt16(dataBaseValues[(int)MachineBaseDataEnum.UpNeedleCodeValue])));  

            return sendDataList.ToArray();
        }
    }
}
