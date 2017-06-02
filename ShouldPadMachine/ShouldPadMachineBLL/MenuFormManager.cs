using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineUI;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class MenuFormManager
    {
        static public bool SendUnLockFlag = false;
        static public bool GetNewMsgFlag = false;
        public static bool IsShowLockMsg = false;
        public static bool showPF_En = true;

        //加密数据的设置与获取
        static private byte[] encNum = new byte[4];
        static public byte[] EncNum 
        {
            get { return encNum; }
            set { encNum = value; }
        }

        static public uint ShowEncNum()
        {
            uint Src = 0;
            for (int i = 0; i < 4; i++)
            {
                Src <<= 8;
                Src += EncNum[i];                
            }
            return Src;
        }

        //解锁码的设置与获取
        static private byte[] unLockNum = new byte[4];
        static public byte[] UnLockNum
        {
            get { return unLockNum; }
            set { unLockNum = value; }
        }

        static public void SetUnLockPW(uint PW)
        {
            for (int i = 3; i >= 0; i--) 
            {
                UnLockNum[i] = (byte)(PW & 0x00ff);
                PW >>= 8;
            }
            lockResult = 0xff;
            SendUnLockFlag = true;
        }

        //激活状态的设置与获取
        static public byte IsActed { get; set; }

        //锁定状态的设置与获取
        static public byte IsLocked { get; set; }

        //解锁结果
        static private byte lockResult;
        static public byte LockResult
        {
            get { return lockResult;}
            set 
            { 
                lockResult = value;
                if (lockResult == 1)
                {
                    GetNewMsgFlag = true;
                    IsLocked = 0;
                }
            }
        }

        static MenuFormManager()
        {
            IsActed = 0xff;//初始状态
            IsLocked = 0xff;
            lockResult = 0xff;
        }
    }
}
