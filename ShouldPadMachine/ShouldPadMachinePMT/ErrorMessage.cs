using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.DelegateEx;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
namespace ShouldPadMachine.ShouldPadMachinePMT
{
    public class ErrorMessage
    {
        private PromptMessageType promptMessageType;
        private PromptOccurPlace promptOccurPlace;
        private object errorInfo;
        public static event OccurErrorEventHandle OccurError;
        public object ErrorInfo
        {
            get
            {
                return errorInfo;
            }
        }
        public PromptMessageType PromptMessageType
        {
            get
            {
                return promptMessageType;
            }
        }
        public PromptOccurPlace PromptOccurPlace
        {
            get {
                return promptOccurPlace;
            }
        }
        private ErrorMessage(PromptOccurPlace promptOccurPlace, PromptMessageType promptMessageType, object errorInfo)
        {
            this.promptMessageType = promptMessageType;
            this.promptOccurPlace = promptOccurPlace;
            this.errorInfo = errorInfo;
        }
        public static void SetErrorMessage(PromptMessageType promptMessageType, object errorInfo)
        {
            OnOccurError(new ErrorMessage(PromptOccurPlace.UnKnown,promptMessageType,errorInfo));
        }
        public static void SetErrorMessage(PromptOccurPlace promptOccurPlace)
        { 
            OnOccurError(new ErrorMessage(promptOccurPlace,PromptMessageType.UnKnown,null));
        }
        public static void SetErrorMessage(PromptOccurPlace promptOccurPlace, PromptMessageType promptMessageType, object errorInfo)
        {
            OnOccurError(new ErrorMessage(promptOccurPlace,promptMessageType,errorInfo));
        }
        public static void SetErrorMessage(PromptOccurPlace promptOccurPlace, PromptMessageType promptMessageType)
        {
            OnOccurError(new ErrorMessage(promptOccurPlace, promptMessageType, null));
        }
        public static void SetErrorMessage(String message)
        { 
            OnOccurError(new ErrorMessage(PromptOccurPlace.Null,PromptMessageType.Null,message));
        }
        private static void OnOccurError(ErrorMessage errorMessage)
        {
            if (OccurError != null)
                OccurError(errorMessage);
        }
    }
}
