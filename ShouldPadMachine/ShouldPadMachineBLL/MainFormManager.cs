using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineFactory;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    public class MainFormManager
    {
        public SerialDataManager serialDataManager;
        private ShapeOperManager shapeOperManager;
        private ShouldPadShapeInfo shouldPadShapeInfo;
        public static int PatternTotalNeedle;//通讯21里面 花型总针数
        

        public ShouldPadShapeInfo ShouldPadShapeInfo
        {
            get {
                return shouldPadShapeInfo;
            }
        }
        public int SelectPointIndex
        {
            get
            {
                return shapeOperManager.SelectPointIndex + 1;
            }
        }
        public int TotalNumber
        {
            get {
                int number = 0;
                if (shouldPadShapeInfo != null && shouldPadShapeInfo.ShapePoints != null)
                {
                    number = shouldPadShapeInfo.ShapePoints.Length;
                    PatternTotalNeedle = number;
                }

                return number;
            }
        }
        public bool CheckMachineInfoData()//检测机器信息数据-----机器是否到期,是否有版本
        {
            MachineInfoManager machineInfoManager = new MachineInfoManager();
            ScreenStatueData.ScreenStatueDataEX.VerifyDatas = machineInfoManager.GetVerifyDatas();
            machineInfoManager.UpdataMachineInfoImage();
            return machineInfoManager.CheckDueDate();
        }

        //开机时候的数据初始化
        public void InitSystemData()
        {
            SystemTimeManager.SystemTimerEx.GetStartTime();

            //读入机器参数XML
            MachineBaseDataDAO baseDataDAO = new MachineBaseDataDAO();
            baseDataDAO.LoadAllData();
            

            //读入花形参数XML
            ShouldPadDAO mouldDataDAO = new ShouldPadDAO();
            mouldDataDAO.FileIndex = baseDataDAO.GetSDataBaseValue(MachineBaseDataEnum.ID);
            mouldDataDAO.LoadAllData();

            DataTypeName[] dataTableNames = new DataTypeName[] {DataTypeName.InOutDataTable };
            DataBaseDAO dataBaseDAO = null;
            for (int i = 0; i < dataTableNames.Length; i++)
            {
                dataBaseDAO = MouldDataFactory.CreateDataBaseDAO(dataTableNames[i]);
                dataBaseDAO.LoadAllData();
            }
            FlowDataDAO setDataDAO = new FlowDataDAO();
            setDataDAO.LoadAllData();
            serialDataManager = new SerialDataManager();
            serialDataManager.OpenSerialPort();
        }
        public void UpdataShouldDatas(string fileID)  // 根据文件号读入 文件信息
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            shouldPadDAO.FileIndex = fileID;
            shouldPadDAO.LoadAllData();
            LoadShouldPadInfo();
            LoadSizeRadio(MappingSize.MappingSizeEx.ScreenSize);
        }

        private void LoadShouldPadInfo()
        {
            ShouldPadInfoManager shouldPadImfoManager = new ShouldPadInfoManager();
            ClothClampManager clothClampManager = new ClothClampManager();
            Point[] shapePoints = shouldPadImfoManager.GetShouldPadPoints();
            shouldPadShapeInfo = new ShouldPadShapeInfo(shapePoints, clothClampManager.LoadClothClamps());
        }
        public void LoadShouldPadImage()
        {
            shapeOperManager.SetShouldPadShapeInfo(shouldPadShapeInfo);
            ChangeToLowerMachinePoint();
        }
        public Bitmap GetShapeImage()
        {
            return shapeOperManager.GetShapeBitmap();
        }
        public void SingleStepSwitch(bool open)
        {

            if (open)
            {
                shapeOperManager.MoveType = MoveType.MoveShapeSelectPoint;
                shapeOperManager.SelectPointIndex = 0;
                ScreenStatueData.ScreenStatueDataEX.SelectPointIndex = 0;
                ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.SingleStepMode;
                ScreenStatueData.ScreenStatueDataEX.ScreenWorkedStatue = ScreenWorkedStatue.SingleStepStatue;
            }
            else
            {
                shapeOperManager.MoveType = MoveType.Null;
                ScreenStatueData.ScreenStatueDataEX.InterfaceMode = InterfaceMode.MainFormMode;
                ScreenStatueData.ScreenStatueDataEX.ScreenWorkedStatue = ScreenWorkedStatue.NormalStatue;
            }
        }
        public void MoveDitection(String directionName)
        {
            DirectionType directionType = (DirectionType)Enum.Parse(typeof(DirectionType), directionName, true);
            shapeOperManager.MovePlus(directionType);
            ScreenStatueData.ScreenStatueDataEX.SelectPointIndex = shapeOperManager.SelectPointIndex;
        }
        public void SetShouldPadShapeInfo(ShouldPadShapeInfo shouldPadShapeInfo, bool savePoints)
        {
            this.shouldPadShapeInfo = shouldPadShapeInfo;
            if (savePoints)
            {
                ShouldPadInfoManager shouldPadInfoManager = new ShouldPadInfoManager();
                shouldPadInfoManager.SetShouldPadPoints(shouldPadShapeInfo.ShapePoints);
            }
        }
        public void ChangeToLowerMachinePoint()
        {
            if (shouldPadShapeInfo != null)
            { 
                Point[] shapePoints = null;
                if (shouldPadShapeInfo.ShapePoints == null)
                    shapePoints = new Point[0];
                else
                { 
                    shapePoints = new Point[shouldPadShapeInfo.ShapePoints.Length];
                    shouldPadShapeInfo.ShapePoints.CopyTo(shapePoints, 0);
                }
                PointF lowerShapePoint = PointF.Empty;
                Point[] serialShapePoints = new Point[shapePoints.Length];
                double mappingRation = MappingSize.MappingSizeEx.MappingRatio;
                for (int i = 0; i < shapePoints.Length; i++)
                {
                    lowerShapePoint.X = (Single)Math.Round(Convert.ToDouble(shapePoints[i].X / mappingRation), 2);
                    lowerShapePoint.Y = (Single)Math.Round((Single)shapePoints[i].Y / mappingRation, 2);
                    serialShapePoints[i] = new Point(Convert.ToInt32(lowerShapePoint.X * 100), Convert.ToInt32(lowerShapePoint.Y * 100));
                }
                LowerShouldPointCollect.LowerShouldPointCollectEx.SetShouldPadPoints(serialShapePoints);
            }
        }
        public void LoadSizeRadio(Size screenSize)//加载图片比例
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            Single padWidth = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.ShouldPadWidth);
            Single padLength = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.ShouldPadLength);
            Single radianLevel = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.RadianLevel);
            MappingSize.MappingSizeEx.LowerMachineSize = new SizeF(padLength + radianLevel * 2, padWidth);
            MappingSize.MappingSizeEx.ScreenSize = screenSize;
            LoadShouldPadInfo();
            shapeOperManager = new ShapeOperManager(DefaultValue.DefaultValueEx.DefaultBackSize);
        }
        public void CloseSerialPort()
        {
            if (serialDataManager != null)
                serialDataManager.CloseSerialPort();
        }
    }
}
