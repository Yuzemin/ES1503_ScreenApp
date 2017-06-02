using System;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class PromptInfoFormManager
    {
        private PromptType promptType;
        private PromptInfoModel promptInfoModel;
        public String[] PromptInfoStrings
        {
            get {
                String[] promptInfoStrings = null;
                MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
                String userLanguage = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.UseLanguage);
                LanguageLibrary languageLibray = new LanguageLibrary(userLanguage);
                if (promptType == PromptType.ErrorInfo)
                    promptInfoStrings = languageLibray.ErrorStrings;
                else
                    promptInfoStrings = languageLibray.WarnStrings;
                return promptInfoStrings;
             }
        }
        public String BoardCodeVersion
        {
            set {
                promptInfoModel.CodeVersion = value;
            }
        }
        public int PromptInfoID
        {
            set {
                promptInfoModel.PromptID = value.ToString();
            }
        }
        public String PromptInfoName
        {
            set {
                promptInfoModel.PromptName = value;
            }
        }
        public String MachineRunTime
        {
            set {
                promptInfoModel.RunTime = value;
            }
        }
        public String PromptOccurTime
        {
            set {
                promptInfoModel.PromptTime = value;
            }
        }
        public PromptInfoFormManager(PromptType promptType)
        {
            this.promptType = promptType;
            promptInfoModel = new PromptInfoModel();
        }
        public void SetErrorInfos(ErrorInfo errorInfo)
        {
            String errorID = String.Empty;
            String errorData = String.Empty;
            if (errorInfo.ErrorData == null || errorInfo.ErrorData.Length == 0)
            {
                for (int i = 0; i < errorInfo.ErrorData.Length; i++)
                    errorData += errorInfo.ErrorData[i].ToString() + ",";
            }
            errorID = errorInfo.ErrorID.ToString();
            promptInfoModel.PromptID = errorID;
            promptInfoModel.PromptInfo = errorData;
        }
        public void SavePromptInfo()
        {
            PromptInfoDAO promptInfoDAO = new PromptInfoDAO(promptType);
            promptInfoDAO.SetDataBaseValue(promptInfoModel);
        }
    }
}
