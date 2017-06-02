using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineModel;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;


namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class FileOperManager
    {
        public static Bitmap GetBitmap(String imagePath)
        {
            Bitmap bitmap = null;
            if (File.Exists(imagePath))
            {
                try
                {
                    bitmap = new Bitmap(imagePath);
                }
                catch
                {
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.ImageError, PromptMessageType.UnKnown,Path.GetFileName(imagePath));
                }
            }
            return bitmap;
        }
        public static void CopyFile(String sourceFilePath,String destFilePath,  bool overwrite)
        {
            try
            {
                if (File.Exists(sourceFilePath))
                {
                    if(!Directory.Exists(Path.GetDirectoryName(destFilePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(destFilePath));
                    File.Copy(sourceFilePath, destFilePath, overwrite);
                }
            }
            catch
            {
                ErrorMessage.SetErrorMessage(PromptOccurPlace.FileError, PromptMessageType.UnKnown, Path.GetFileName(destFilePath));
            }
        }
        public static void DeleteFile(String fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
        
    }
}
