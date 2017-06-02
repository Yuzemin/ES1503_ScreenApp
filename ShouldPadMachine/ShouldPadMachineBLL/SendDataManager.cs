using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineHelper;
using ShouldPadMachine.ShouldPadMachineFactory;
using ShouldPadMachine.ShouldPadMachineUI;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class SendDataManager
    {
        //根据各个标志位获得通讯命令标志位 (存在高位响应优先级过低的问题
        public ushort GetSendCmdFlag()
        {
            ushort cmdFlag = 0;

            if (ScreenStatueData.ScreenStatueDataEX.InterfaceMode == InterfaceMode.TestFormMode)
                cmdFlag = 0x0004;
            else
            {
                if (ScreenStatueData.ScreenStatueDataEX.InterfaceMode == InterfaceMode.MainFormMode)
                {
                    if (SerialDataManager.FirstMachine)//第一次开机，强制发机器参数
                    {
                        cmdFlag |= 0x0010;
                        cmdFlag |= 0x0100;//0x29命令
                        SerialDataManager.FirstMachine = false;
                    }
                }                
                
                if (ScreenStatueData.ScreenStatueDataEX.SendDesignFlag || ShouldPadModel.GetDataBaseModel().HaveDataChanged)
                    cmdFlag |= 0x0001;   //0x21
                if (BaseDateModel.GetDataBaseModel().HaveDataChanged || FlowDataModel.GetDataBaseModel().HaveDataChanged || ScreenStatueData.ScreenStatueDataEX.NormalSpeedChanged)
                    cmdFlag |= 0x0010;   //0x25
                if (SerialDataManager.FlowFlag)//0x27
                    cmdFlag |= 0x40;
                if (SerialDataManager.ScreenButton)//0x28
                    cmdFlag |= 0x80;
                if (MenuFormManager.SendUnLockFlag)//0x2A
                    cmdFlag |= 0x0200;
                if (MenuFormManager.GetNewMsgFlag)//0x29
                    cmdFlag |= 0x0100;

                cmdFlag |= ScreenStatueData.ScreenStatueDataEX.GetSendCmdFlag();
            }
            return cmdFlag;
        }

        //根据命令 获得对应的通讯数据
        public byte[] GetSerialSendData(byte comd)    //要点1
        {
            SendDataType sendDataType = (SendDataType)(comd);
            byte[] serialDatas = null;
            ISendData getSendDatas = null;
            DataInfoSet dataInfoSet = null;
            String[] dataBaseValues = null;
            switch (sendDataType)
            {               
                case SendDataType.NormalSerialData://0x20
                    serialDatas = GetNormalDatas();//
                    break;
                case SendDataType.DesignParam://0x21指令
                    serialDatas = GetDesignParam();
                    break;
                case SendDataType.TestSerialData://0x23
                    serialDatas = GetTestDatas();
                    break;
                case SendDataType.ClearComdSerailData://0x24
                    serialDatas = GetClearWorkNumberDatas();
                    break;
                case SendDataType.MachineSerialData://0x25
                    getSendDatas = new MachineInfoSendData();
                    dataInfoSet = MouldDataFactory.CreateDataInfo(DataTypeName.BaseDataTable);
                    dataBaseValues = BaseDateModel.GetDataBaseModel().DataBaseValues;
                    break;
                case SendDataType.ShouldPadPointsData://0x27
                    serialDatas = GetShouldPadPoints();
                    break;
                case SendDataType.SingleStepSerialData://0x28
                    serialDatas = GetSingleStepDatas();
                    break;     
                case SendDataType.LockStaSerialData://0X29
                    serialDatas = GetLockStaSerialDatas();
                    break;
                case SendDataType.UnLockSerialData://0x2a
                    serialDatas = GetUnLockSerialData();
                    break;
            }
            if (getSendDatas != null)
                serialDatas = getSendDatas.GetSendDatas(dataBaseValues, dataInfoSet);
            return serialDatas;
        }

        private byte[] GetUnLockSerialData()
        {
            byte[] serialDatas = new byte[4];

            for (int i = 0; i < 4; i++)
                serialDatas[i] = MenuFormManager.UnLockNum[i];
                
            return serialDatas;
        }

        private byte[] GetLockStaSerialDatas()
        {
            byte[] serialDatas = new byte[1];
            serialDatas[0] = 0x3E;//无意义的数据 随便写的
            return serialDatas;
        }

        private byte[] GetSingleStepDatas()
        {
            byte[] serialDatas = new byte[1];
          
            serialDatas[0] = (byte)ScreenStatueData.ScreenStatueDataEX.ScreenButton;
            return serialDatas;
        }

        private byte[] GetDesignParam()//花型参数
        {
            byte[] serialDatas = new byte[10];
            ushort dataBaseValue = 0;

            //工作模式
            serialDatas[0] =  Convert.ToByte(((int)ScreenStatueData.ScreenStatueDataEX.ScreenWorkedStatue) & 0xFF);
            serialDatas[1] = Convert.ToByte((((int)ScreenStatueData.ScreenStatueDataEX.ScreenWorkedStatue) >> 8) & 0xFF);

            //花型总针数
            serialDatas[2] = Convert.ToByte(MainFormManager.PatternTotalNeedle & 0xFF);
            serialDatas[3] = Convert.ToByte((MainFormManager.PatternTotalNeedle>>8) & 0xFF);

            //普通缝纫速度
            dataBaseValue = Convert.ToUInt16(ShouldPadModel.GetDataBaseModel()[(int)ShouldPadDataEnum.NormalSpeed]);
            serialDatas[4] = Convert.ToByte(dataBaseValue & 0xFF);
            serialDatas[5] = Convert.ToByte((dataBaseValue >> 8) & 0xFF);            

            //剪线距离
            dataBaseValue = Convert.ToUInt16(ShouldPadModel.GetDataBaseModel()[(int)ShouldPadDataEnum.CutLineDistance]);
            serialDatas[6] = Convert.ToByte(dataBaseValue & 0xFF);
            serialDatas[7] = Convert.ToByte((dataBaseValue >> 8) & 0xFF);

            //花型底线缝纫件数限制
            dataBaseValue = Convert.ToUInt16(ShouldPadModel.GetDataBaseModel()[(int)ShouldPadDataEnum.ClothNumberLimit]);
            serialDatas[8] = Convert.ToByte(dataBaseValue & 0xFF);
            serialDatas[9] = Convert.ToByte((dataBaseValue >> 8) & 0xFF);

            return serialDatas;
        }

        private byte[] GetShouldPadPoints()
        {
            return LowerShouldPointCollect.LowerShouldPointCollectEx.GetSerialDatas();
        }

        private byte[] GetNormalDatas()//获取0x20指令数据
        {
            byte[] serialDatas = new byte[2];
            UInt16 data = 0;
            if (ScreenStatueData.ScreenStatueDataEX.InterfaceMode != InterfaceMode.MainFormMode)
                data |= 0x01;
            if (ScreenStatueData.ScreenStatueDataEX.ParrentChanged)
                data |= 0x02;
            if (ScreenStatueData.ScreenStatueDataEX.InterfaceMode == InterfaceMode.BaseFormMode)
                data |= 0x04;
            if (ScreenStatueData.ScreenStatueDataEX.AutoEnable)
                data |= 0x08;
          
            
            serialDatas[0] = (byte)(data & 0xFF);////编辑状态下的运行保护（进入编辑状态时该位置1 退出清零）
            serialDatas[1] = (byte)((data >> 8) & 0xFF);
            return serialDatas;
        }

        private byte[] GetTestDatas()
        {
            //ToDo:输出口状态 (测试界面)

            byte[] serialDatas = new byte[1];
            serialDatas[0] = (byte)ScreenStatueData.ScreenStatueDataEX.MachineTestData;
            return serialDatas;
        }

        private byte[] GetVerifyDatas()
        {
            return null;
        }

        private byte[] GetClearWorkNumberDatas()
        {
            byte[] clearDatas = new byte[] { 1 };
            clearDatas[0] = ScreenStatueData.ScreenStatueDataEX.ClearNumberID;
            return clearDatas;
        }
        protected byte[] GetByteData(UInt16 baseData)
        {
            byte[] byteDatas = new byte[2];
            byteDatas[0] = Convert.ToByte(baseData & 0xFF);
            byteDatas[1] = Convert.ToByte((baseData >> 8) & 0xFF);
            return byteDatas;
        }
    }
}
