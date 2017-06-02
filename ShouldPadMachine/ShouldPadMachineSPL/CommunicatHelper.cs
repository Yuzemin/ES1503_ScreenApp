using System;

using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineSPL
{
    internal class CommunicatHelper
    {
        private List<byte> receiveDatas;
        public CommunicatHelper()
        {
            receiveDatas = new List<byte>();
        }
        public void WriteByteToBuffer(Byte data)
        {
            receiveDatas.Add(data);
        }
        public byte[] GetRecieveData()
        {
            byte[] serialPoartDatas = null;
            if (receiveDatas != null && receiveDatas.Count > 4)
            {
                serialPoartDatas = new byte[receiveDatas.Count - 5];
                for (int i = 0; i < serialPoartDatas.Length; i++)
                    serialPoartDatas[i] = receiveDatas[i + 3];
            }
            return serialPoartDatas;
        }
        public void ClearRecieveData()
        {
            receiveDatas.Clear();
        }
        public int GetCheckDataLength()//从校验中获得数据
        {
            int length = 0;
            if (receiveDatas.Count > 2)
                length = receiveDatas[1] + (receiveDatas[2] << 8);
            return length;
        }
        public bool CrcCheckOut()//Crc校验
        {
            int crcValue = 0xFFFF;
            for (int i = 0; i < receiveDatas.Count - 2; i++)
            {
                crcValue ^= receiveDatas[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((crcValue & 0x01) != 0)
                        crcValue = (crcValue >> 1) ^ 0xa001;
                    else
                        crcValue = crcValue >> 1;
                }
            }
            byte crcByte1, crcByte2;
            crcByte1 = Convert.ToByte(crcValue & 0xFF);
            crcByte2 = Convert.ToByte((crcValue >> 8) & 0xFF);
            int length = receiveDatas.Count;
            if (length < 2)
                return false;
            else
            {
                if (crcByte1 == receiveDatas[length - 2] && crcByte2 == receiveDatas[length - 1])
                    return true;
                else
                    return false;
            }
        }
        public int GetDataLength()
        {
            if (receiveDatas == null)
                return 0;
            else
                return receiveDatas.Count;
        }
        public byte GetComd()
        {
            byte cmd = 0;
            if (receiveDatas.Count > 0)
                cmd = receiveDatas[0];
            return cmd;
        }
    }
}
