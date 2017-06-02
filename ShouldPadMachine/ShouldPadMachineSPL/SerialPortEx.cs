using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.IO;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineUI;



namespace ShouldPadMachine.ShouldPadMachineSPL
{
    public class SerialPortEx
    {
        private SerialPort serialPort;
        private CommunicatHelper communicatHelper;
        public event DataArrivedEventHandle DataArrived;
        public void OpenSerialPort()
        {
            if (serialPort == null)
            {
                serialPort = new SerialPort();
                serialPort.BaudRate = 19200;
                serialPort.DataBits = 8;
                serialPort.PortName = "COM1";
                serialPort.StopBits = StopBits.One;
                serialPort.ReadTimeout = 200;
                serialPort.WriteTimeout = 200;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            }
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    PromptMessageType promptMessageType = PromptMessageType.Null;
                    PromptOccurPlace promptOccurPlace = PromptOccurPlace.SerialPortSendError;
                    if (ex is IOException)
                        promptMessageType = PromptMessageType.IOException;
                    else if (ex is UnauthorizedAccessException)
                        promptMessageType = PromptMessageType.UnauthorizedAccessException;
                    else
                        promptMessageType = PromptMessageType.UnKnown;
                    String portInfos = String.Empty;
                    foreach (String name in SerialPort.GetPortNames())
                    {
                        portInfos += name + " ";
                    }
                    ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, portInfos);
                }
            }
            communicatHelper = new CommunicatHelper();
        }
        private void OnDataArrived(byte[] uartDatas, byte comd)
        {
            if (DataArrived != null)
                DataArrived(uartDatas, comd);
        }
        public void CloseSerialPort()
        {
            if (serialPort != null)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
            }
        }
        public void ClearRecieveData()
        {
            communicatHelper.ClearRecieveData();
        }
        public void SendSerialData(byte[] serialDatas, byte comd)
        {
            int length = serialDatas.Length;
            byte[] sendDatas = new byte[length + 5];
            try
            {
                sendDatas[0] = comd;
                sendDatas[1] = Convert.ToByte(length + 5);
                sendDatas[2] = Convert.ToByte((length + 5) >> 8);
                for (int i = 0; i < length; i++)
                    sendDatas[i + 3] = serialDatas[i];
                int crcValue = 0xFFFF;
                int index = 0;
                for (; index < length + 3; index++)
                {
                    crcValue ^= sendDatas[index];
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crcValue & 0x01) != 0)
                            crcValue = (crcValue >> 1) ^ 0xa001;
                        else
                            crcValue = crcValue >> 1;
                    }
                }
                sendDatas[index] = Convert.ToByte(crcValue & 0xFF);
                sendDatas[index + 1] = Convert.ToByte((crcValue >> 8) & 0xFF);
                serialPort.DiscardOutBuffer();
                serialPort.Write(sendDatas, 0, length + 5);
            }
            catch (Exception ex)
            {
                PromptMessageType promptMessageType = PromptMessageType.Null;
                PromptOccurPlace promptOccurPlace = PromptOccurPlace.SerialPortSendError;
                if (ex is ArgumentOutOfRangeException)
                    promptMessageType = PromptMessageType.ArgumentOutOfRangeException;
                else if (ex is InvalidOperationException)
                    promptMessageType = PromptMessageType.InvalidOperationException;
                else if (ex is TimeoutException)
                    promptMessageType = PromptMessageType.TimeoutException;
                else
                    promptMessageType = PromptMessageType.UnKnown;
                ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType);
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口 接收
        {
            byte[] receiveDatas = null;
            byte receiveComd = 0;
            int bufferLength = serialPort.BytesToRead;
    
            try
            {
                for (int i = 0; i < bufferLength; i++)
                {
                    if (serialPort.IsOpen)
                        communicatHelper.WriteByteToBuffer(Convert.ToByte(serialPort.ReadByte()));
                }
                int checkLength = communicatHelper.GetCheckDataLength();
                int dataLength = communicatHelper.GetDataLength();                
                if (dataLength == checkLength && dataLength > 2 && communicatHelper.GetComd() != 0)
                {
                    if (communicatHelper.CrcCheckOut())
                    {
                        receiveDatas = communicatHelper.GetRecieveData();
                        receiveComd = communicatHelper.GetComd();
                    }
                }
            }
            catch (Exception ex)
            {
                PromptMessageType promptMessageType = PromptMessageType.Null;
                PromptOccurPlace promptOccurPlace = PromptOccurPlace.SerialPortReceiveError;
                if (ex is EndOfStreamException)
                    promptMessageType = PromptMessageType.EndOfStreamException;
                else if (ex is ObjectDisposedException)
                    promptMessageType = PromptMessageType.ObjectDisposedException;
                else if (ex is IOException)
                    promptMessageType = PromptMessageType.IOException;
                else
                    promptMessageType = PromptMessageType.UnKnown;
                ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType);
            }   
            OnDataArrived(receiveDatas, receiveComd);
        }
    }
}
