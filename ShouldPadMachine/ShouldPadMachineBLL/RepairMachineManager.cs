using System;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineFactory;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class RepairMachineManager
    {
        public void RepairCopyMachineDatas(String fileName)
        {
            String sourcePath, destPath;
            destPath = DefaultPath.DefaultPathEx.DataBasePath + fileName;
            sourcePath = DefaultPath.DefaultPathEx.BackUpDataPath + fileName;
            FileOperManager.DeleteFile(destPath);
            FileOperManager.CopyFile(sourcePath, destPath, true);
        }
        /// <summary>
        /// 获得发生错误的文件名，将该文件删除，并且将程序中的属于该文件的数据进行保存
        /// </summary>
        /// <param name="fileName"></param>
        public void RepairSaveMachineDatas(String fileName)
        {
            String[] pathNames = new string[] { "InOutData", "ShouldPadData", "BaseData" };
            DataTypeName[] dataTypeNames = new DataTypeName[] {DataTypeName.InOutDataTable
            ,DataTypeName.ShouldPadDataTable,DataTypeName.BaseDataTable};
            DataTypeName dataTypeName = DataTypeName.Null;
            fileName = DefaultPath.DefaultPathEx.DataBasePath + fileName;
            FileOperManager.DeleteFile(fileName);
            for (int i = 0; i < pathNames.Length; i++)
            {
                if (fileName.IndexOf(pathNames[i]) != -1)
                {
                    dataTypeName = dataTypeNames[i];
                    break;
                }
            }
            DataBaseDAO dataBaseDAO = MouldDataFactory.CreateDataBaseDAO(dataTypeName);
            if (dataBaseDAO != null)
                dataBaseDAO.SaveAllDataBase();
        }
    }
}
