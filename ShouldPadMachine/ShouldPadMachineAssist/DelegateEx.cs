using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    namespace DelegateEx
    {
        public delegate void DataArrivedEventHandle(byte[] uartDatas, byte comd);//数据接收委托
        public delegate void FeedbackEventHandle(UartComdEventArgs lowerDataInfo);//反馈数据委托
        public delegate void FormHideEventHandle();
        public delegate void ReflectToObjectDelegate(object sender, String text);
        public delegate void OccurErrorEventHandle(ErrorMessage errorMessage);
        public delegate void ShowErrorMessageDelegate(ErrorMessage errorMessage);
        public delegate void NoValueEventHandle();
        public delegate void PictruBoxFeedbackEventHandle(int lowerDataInfo);//通知pictureBox画画

        public delegate void NoticeCALFeedbackEventHandle(string tag);
        public delegate void MessageBoxShowReCall();
    }
}
