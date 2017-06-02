using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class CreateMachineImage
    {
        private String[] machineInfoFields;
        public CreateMachineImage()
        {
            machineInfoFields = new string[] { 
            "Step Motor Version:","Servo Motor Version:","Lower Machine Version:","Screen Version:","Lower Machine Modify Time:","Screen Modify Time:",
            "Lower Machine Load Time:","Screen Load Time:","Machine ID:","Board ID:"
            };
        }
        public void CreateMachineInfoImage(String imagePath, MachineInfoModel machineInfoModel)
        {
            Graphics pe;
            Bitmap bitmap;
            String[] machineDatas;
            int length = machineInfoFields.Length;
            bool haveBitmap = true;
            int charCount;
            Rectangle[] machineRects = new Rectangle[length];
            Rectangle[] fieldRects = new Rectangle[length];
            Rectangle[] dataRects = new Rectangle[length];
            if (File.Exists(imagePath))
                bitmap = new Bitmap(imagePath);
            else
            {
                haveBitmap = false;
                bitmap = new Bitmap(800, 480);
            }
            pe = Graphics.FromImage(bitmap);
            int height = bitmap.Height * 7 / 12;
            if (haveBitmap == false)
            {
                height = 30;
                pe.Clear(Color.FromArgb(80, 133, 177));
            }
            Rectangle rect = new Rectangle(5, height, bitmap.Width-5, bitmap.Height / 3 + 20);
            int wide = rect.Height / ((length + 1) / 2);
            machineDatas = new String[fieldRects.Length];
            machineDatas[0] = machineInfoModel.StepMotorVersion;
            machineDatas[1] = machineInfoModel.ServoMotorVersion;
            machineDatas[2] = machineInfoModel.BoardCodeVersion;
            machineDatas[3] = machineInfoModel.ScreenCodeVersion;
            machineDatas[4] = machineInfoModel.BoardModifyTime;
            machineDatas[5] = machineInfoModel.ScreenModifyTime;
            machineDatas[4] = machineInfoModel.BoardLoadTime;
            machineDatas[7] = machineInfoModel.ScreenLoadTime;
            machineDatas[8] = machineInfoModel.MachineID;
            machineDatas[9] = machineInfoModel.BoardID;
            for (int i = 0; i < machineInfoFields.Length; i++)
            {
                machineRects[i].X = rect.X + (i % 2) * rect.Width / 2 + (i % 2) * 20;
                machineRects[i].Width = rect.Width / 2 - (i % 2) * 20 + ((i+1)%2) * 20;
                machineRects[i].Y = rect.Y + (i / 2) * wide;
                machineRects[i].Height = wide;
            }
            StringFormat wordFormat = new StringFormat();
            StringFormat dataFormat = new StringFormat();
            dataFormat.LineAlignment = StringAlignment.Near;
            dataFormat.Alignment = StringAlignment.Near;
            wordFormat.LineAlignment = StringAlignment.Near;
            wordFormat.Alignment = StringAlignment.Near;
            Font wordFont = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold);
            SolidBrush wordBrush;
            SizeF sizef;
            for (int i = 0; i < machineRects.Length; i++)
            {
                sizef = pe.MeasureString(machineInfoFields[i], wordFont);
                charCount = (int)sizef.Width + 5;
                fieldRects[i] = new Rectangle(machineRects[i].X, machineRects[i].Y, charCount, machineRects[i].Height);
                dataRects[i] = new Rectangle(fieldRects[i].X + fieldRects[i].Width, fieldRects[i].Y, machineRects[i].Width - fieldRects[i].Width, machineRects[i].Height);
            }
            for (int i = 0; i < length; i++)
            {
                if (i < 3)
                    wordBrush = new SolidBrush(Color.Yellow);
                else
                    wordBrush = new SolidBrush(Color.Green);
                pe.DrawString(machineInfoFields[i], wordFont, wordBrush, fieldRects[i], wordFormat);
                pe.DrawString(machineDatas[i], wordFont, wordBrush, dataRects[i], dataFormat);
            }
            String bootloaderPath = imagePath;
            bitmap.Save(bootloaderPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Dispose();
            machineDatas = null;
        }
    }
}
