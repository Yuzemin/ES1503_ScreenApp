using System;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class MessageString
    {
        public static String GetMessageString(PromptOccurPlace promptOccurPlace, PromptMessageType promptMessageType,Object obj)
        {
            String messageString = String.Empty;
            LanguageLibrary languageLibrary = new LanguageLibrary("中文");
            String[] messagePlaces = languageLibrary.PromptOccurPlace;
            String[] messageTypes = languageLibrary.PromptMessageType;
            int placeIndex = (int)promptOccurPlace;
            int typeIndex = (int)promptMessageType;
            if (placeIndex < messagePlaces.Length && typeIndex < messageTypes.Length)
            {
                String[] messageFields = languageLibrary.MessageFiledStrings;
                messageString += String.Format("{0} {1}\n", messageFields[0], messagePlaces[placeIndex]);
                messageString += String.Format("{0} {1}\n", messageFields[1], messageTypes[typeIndex]);
                if (obj != null)
                    messageString += String.Format("{0} {1}", messageFields[2], obj.ToString());
            }
            else
            {
                if (obj !=null)
                    messageString = obj.ToString();
            }
            return messageString;
        }
    }
}
