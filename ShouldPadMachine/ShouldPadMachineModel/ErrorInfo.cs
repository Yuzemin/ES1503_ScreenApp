using System;

using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineModel
{
    public class ErrorInfo
    {
        private int errorID;
        private int[] errorData;
        public ErrorInfo(int id, int[] datas)
        {
            errorData = datas;
            errorID = id;
        }
        public ErrorInfo(byte id, Int16[] datas)
        {
            errorID = id;
            errorData = new int[datas.Length];
            for (int i = 0; i < errorData.Length; i++)
            {
                errorData[i] = Convert.ToInt32(datas[i]);
            }
        }
        public int ErrorID
        {
            set
            {
                errorID = value;
            }
            get
            {
                return errorID;
            }
        }
        public int[] ErrorData
        {
            set
            {
                errorData = value;
            }
            get
            {
                return errorData;
            }
        }
        public int GetDataCount()
        {
            return errorData.Length;
        }
    }
}
