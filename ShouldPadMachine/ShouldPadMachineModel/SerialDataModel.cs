using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class SerialDataModel
    {
        private SerialDataType serialDataType;
        private byte[] serialDatas;
        private byte comd;
        public SerialDataType SerialDataType
        {
            get
            {
                return serialDataType;
            }
            set
            {
                serialDataType = value;
            }
        }
        public String SerialDatas
        {
            get
            {
                String serialValues = String.Empty;
                for (int i = 0; i < serialDatas.Length; i++)
                {
                    serialValues += serialDatas[i].ToString("X") + ",";
                }
                return serialValues.TrimEnd(',');
            }
        }
        public byte Comd
        {
            get
            {
                return comd;
            }
            set
            {
                comd = value;
            }
        }
        public SerialDataModel(SerialDataType serialDataType, byte comd, byte[] serialDatas)
        {
            this.serialDataType = serialDataType;
            this.comd = comd;
            if (serialDatas == null)
                serialDatas = new byte[0];
            this.serialDatas = serialDatas;
        }
    }
    public class SerialDataModelCollect
    {
        private List<SerialDataModel> serialDataModelList;
        private int modelIndex;
        private int maxIndex;

        public SerialDataModelCollect()
        {
            maxIndex = 50;
            modelIndex = 0;
            serialDataModelList = new List<SerialDataModel>();
        }
        public int Length
        {
            get
            {
                return serialDataModelList.Count;
            }
        }
        public void Add(SerialDataModel serialDataModel)
        {
            if (modelIndex < maxIndex)
            {
                serialDataModelList.Add(serialDataModel);
                modelIndex++;
            }
            else
            {
                int i = 0;
                for (i = 0; i < serialDataModelList.Count - 1; i++)
                {
                    serialDataModelList[i] = serialDataModelList[i + 1];
                }
                serialDataModelList[i] = serialDataModel;
            }
        }
        public SerialDataModel this[int index]
        {
            get
            {
                if (index < serialDataModelList.Count)
                    return serialDataModelList[index];
                else
                    return null;
            }
        }
    }
}
