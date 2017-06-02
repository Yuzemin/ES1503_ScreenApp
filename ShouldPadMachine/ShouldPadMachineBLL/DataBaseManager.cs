using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class MachineInfoManager
    {
        private String screenCodeVersion;
        public MachineInfoManager()
        {
            screenCodeVersion = "DJ.V1.001";
        }
        public void ChangeVerifyDate(int code)//code:0~12,若为0，关闭到期时间检测，其他的数字让到期时间延长相应的月数
        {
            if (code == 0)
                CloseVerify();
            else
            {
                MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
                String expiratData = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ExpiratDate);
                String[] exirats = expiratData.Split('-');
                if (exirats.Length > 2)
                {
                    String year = exirats[0];
                    String month = exirats[1];
                    int monthValue = Convert.ToInt32(month) + code;
                    int yearValue = Convert.ToInt32(year);
                    if (monthValue > 12)
                    {
                        monthValue -= 12;
                        yearValue++;
                    }
                    expiratData = yearValue.ToString() + "-" + monthValue.ToString().PadLeft(2, '0') + "-" + exirats[2];
                    machineInfoDAO.SetDataBaseValue(MachineInfoEnum.ExpiratDate, expiratData);  //待
                }
            }
        }
        public void CreateBootLoadImage()
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            machineInfoDAO.SetDataBaseValue(MachineInfoEnum.CreateImageEnable, false);
            String sourceImagePath = DefaultPath.DefaultPathEx.ImagePath + "BootLoader.jpg";
            String destImagePath = @"\ResidentFlash\BootLoader.jpg";
            FileOperManager.DeleteFile(destImagePath);
            FileOperManager.CopyFile(sourceImagePath, destImagePath, true);
            MachineInfoModel machineInfoModel = new MachineInfoModel();
            machineInfoModel.BoardCodeVersion = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardCodeVersion);
            machineInfoModel.BoardID = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardID);
            machineInfoModel.BoardLoadTime = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardLoadTime);
            machineInfoModel.BoardModifyTime = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardModifyTime);
            machineInfoModel.MachineID = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.MachineID);
            machineInfoModel.ScreenCodeVersion = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ScreenCodeVersion);
            machineInfoModel.ScreenLoadTime = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ScreenLoadTime);
            machineInfoModel.ScreenModifyTime = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ScreenModifyTime);
            CreateMachineImage createMachineImage = new CreateMachineImage();
            createMachineImage.CreateMachineInfoImage(destImagePath, machineInfoModel);
        }
        public void UpdataMachineInfoImage()
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            String sqlScreenCodeVersion = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ScreenCodeVersion);
            bool shouldCreatBootLoadImage = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.CreateImageEnable) == "1" ?true:false;
            if (screenCodeVersion != sqlScreenCodeVersion)
            {
                shouldCreatBootLoadImage = true;
                machineInfoDAO.SetDataBaseValue(MachineInfoEnum.ScreenCodeVersion, screenCodeVersion);
            }
            if (shouldCreatBootLoadImage)
            {
                CreateBootLoadImage();
            }
        }
        public byte[] GetVerifyDatas()
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            String strInfo = String.Empty;
            String strModifyTime = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardModifyTime);
            String strCodeVersion = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.BoardCodeVersion);
            strInfo = strModifyTime + "/" + strCodeVersion;
            if (strInfo.Length < 10)
                return null;
            String temp_string = strInfo.PadRight((int)32, (char)0);
            byte[] temp = System.Text.Encoding.Default.GetBytes(temp_string);
            return temp;
        }
        public void CloseVerify()
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            machineInfoDAO.SetDataBaseValue(MachineInfoEnum.OpenVerifyEnable,false);
        }
        public void SetMachineInfoValue(MachineInfoEnum machineInfoEnum, String value)
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            machineInfoDAO.SetDataBaseValue(machineInfoEnum.ToString(),value);
        }
        public String GetMachineInfoValue(MachineInfoEnum machineInfoEnum)
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            return machineInfoDAO.GetDataBaseValue(machineInfoEnum);
        }
        public bool CheckDueDate()
        {
            MachineInfoDAO machineInfoDAO = new MachineInfoDAO();
            bool flag = true;
            bool checkEnable = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.OpenVerifyEnable) == "1"?true:false;
            if (checkEnable)
            {
                String expirateData = machineInfoDAO.GetDataBaseValue(MachineInfoEnum.ExpiratDate);
                String nowDataTime= String.Empty;
                try
                {
                    nowDataTime = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd");
                }
                catch
                {
                    ErrorMessage.SetErrorMessage(PromptOccurPlace.DataTimeError,PromptMessageType.ReadSystemDateException);
                }
                if (nowDataTime.CompareTo(expirateData) > 0)
                {
                    flag = false;
                }
                else
                {
                    if (expirateData.Length > 4 && nowDataTime.Length > 4)
                    {
                        int expirateYear = Convert.ToInt32(expirateData.Substring(0, 4));
                        int nowDataYear = Convert.ToInt32(nowDataTime.Substring(0, 4));
                        if (nowDataYear - expirateYear > 200)
                        {
                            flag = false;
                        }
                    }
                }
            }
            return flag;
        }
    }
    public class ShouldPadInfoManager
    {
        public void SetShouldPadPoints(Point[] shapePoints)
        {
            String shapePointInfos = String.Empty;
            for (int i = 0; i < shapePoints.Length; i++)
                shapePointInfos += String.Format("{0} {1},",shapePoints[i].X,shapePoints[i].Y);
            shapePointInfos = shapePointInfos.TrimEnd(',');
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            shouldPadDAO.SetDataBaseValue(ShouldPadDataEnum.ShapePoints, shapePointInfos);
        }
        public Point[] GetShouldPadPoints()
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            String shapePointInfos = shouldPadDAO.GetShapePointInfos();
            String[] singlePointInfos = null;
            if (String.IsNullOrEmpty(shapePointInfos))
                singlePointInfos = new String[0];
            else
                singlePointInfos = shapePointInfos.Split(',');
            String[] singlePoints = null;
            int pointX = 0, pointY = 0;
            Point[] shapePoints = new Point[singlePointInfos.Length];
            for (int i = 0; i < singlePointInfos.Length; i++)
            {
                singlePoints = singlePointInfos[i].Split(' ');
                if (singlePoints.Length > 1)
                {
                    pointX = Convert.ToInt32(singlePoints[0]);
                    pointY = Convert.ToInt32(singlePoints[1]);
                }
                shapePoints[i] = new Point(pointX,pointY);
            }
            return shapePoints;
        }

    }
}
