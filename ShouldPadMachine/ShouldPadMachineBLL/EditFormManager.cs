using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ShouldPadMachine.ShouldPadMachineCTL;
using ShouldPadMachine.ShouldPadMachinePMT;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;


namespace ShouldPadMachine.ShouldPadMachineBLL
{
    
    class EditFormManager
    {
        private double originalMappingRatio;//原始比例---参与放大运算
        private ShapeOperManager shapeOperManager;
        private ShouldPadShapeInfo shouldPadShapeInfo; //坐标点和夹布器坐标
        private List<EditShouldPadInfo> editShouldPadInfoList;//参数 坐标 比例
        private EditShouldPadInfo editShouldPadInfo;
        private List<UserOperType> userOperTypeList;        

        public List<Tablet> ParamList = new List<Tablet>();

        public List<EditShouldPadInfo> EditShouldPadInfoList
        {
            get {
                return editShouldPadInfoList;
            }
        }
        private UserOperType UserOperType
        {
            set {
                UserOperType userOperType = UserOperType.Null;
                if(userOperTypeList.Count > 0) 
                    userOperType = userOperTypeList[userOperTypeList.Count - 1];
                if (value == UserOperType.CalculationOper || value == UserOperType.ModifyOper)
                    editShouldPadInfo = editShouldPadInfoList[editShouldPadInfoList.Count - 1];
            }
        }

        public void Edit_SaveAllParam()
        {
            if (ParamList.Count != 0)
            {
                ShouldPadDAO dataBaseDAO = new ShouldPadDAO();
                foreach (Tablet Tab in ParamList)
                    dataBaseDAO.SetDataBaseValue((ShouldPadDataEnum)Convert.ToInt16(Tab.Tag), Tab.Content);
            }
        }

        public int GetShapePointLength
        {
            get
            {
                return shapeOperManager.ShapePointLength;
            }
        }
        public bool HaveIrregularPoint
        {
            get {
                return shapeOperManager.HaveIttegularPoint;
            }
        }
        public ShouldPadShapeInfo ShouldPadShapeInfo
        {
            get {
                return shouldPadShapeInfo;
            }
            set {
                shouldPadShapeInfo = value;
            }
        }
        public EditFormManager()
        {
            shapeOperManager = new ShapeOperManager(DefaultValue.DefaultValueEx.DefaultBackSize);
            editShouldPadInfoList = new List<EditShouldPadInfo>();
            userOperTypeList = new List<UserOperType>();
        }
        public Bitmap RevokeOper()
        {
            if (editShouldPadInfoList.Count >= 2)
            {
                editShouldPadInfoList.RemoveAt(editShouldPadInfoList.Count - 1);
                if (userOperTypeList.Count >= 2)
                {
                    userOperTypeList.RemoveAt(userOperTypeList.Count - 1);
                    UserOperType = userOperTypeList[0];
                }
                EditShouldPadInfo editShouldPadInfo = editShouldPadInfoList[editShouldPadInfoList.Count - 1];
                shouldPadShapeInfo = editShouldPadInfo.ShouldPadShapeInfo;
                if (editShouldPadInfo.ShapeParams != null)
                {
                    if (ParamList.Count != 0)
                    {
                        for (int i = 0; i < editShouldPadInfo.ShapeParams.Length; i++)
                            ParamList[i].Content = editShouldPadInfo.ShapeParams[i].ToString();
                        Edit_SaveAllParam();
                    }
                }
                originalMappingRatio = editShouldPadInfo.OriginalMappingRatio;
                shapeOperManager.SetShouldPadShapeInfo(shouldPadShapeInfo);
            }
            return shapeOperManager.GetShapeBitmap();
        }
 
        private Bitmap GetBitMapVal(PointF[] PointFs)
        {
            //将坐标点转化为屏幕上的点
            Point[] shapePoints = ChangToScreenPoints(PointFs);

            //将花型坐标和夹布器坐标存入ShapeInfo中
            ClothClamp[] clothClamps = LoadClothClamps();
            shouldPadShapeInfo = new ShouldPadShapeInfo(shapePoints, clothClamps);

            //保存图像比例
            originalMappingRatio = MappingSize.MappingSizeEx.MappingRatio;

            //将花型参数 点和夹布器坐标 比例 存入一个元素项中
            AddEditOperParams();

            shapeOperManager.SetShouldPadShapeInfo(shouldPadShapeInfo);
            SetUserOperType(UserOperType.CalculationOper);
            return shapeOperManager.GetShapeBitmap();
        }

        public Bitmap LeftDrawShouldPadShape(int shapeType)
        {
            PointCal LeftShape = null;
            PointF[] PointLine = null;

            if (ParamList.Count != 0)
            {
                PointLine = null;
                LeftShape = null;

                if (shapeType == 0)
                    LeftShape = new StandardShape(ParamList);
                else if (shapeType == 1)
                    LeftShape = new EllipseShape(ParamList);
                else if (shapeType == 2)
                    LeftShape = new EllipseOutSide(ParamList);
                else if (shapeType == 3)
                    LeftShape = new JagInside(ParamList);
                else if (shapeType == 4)
                    LeftShape = new JagOutSide(ParamList);
                else if (shapeType == 5)
                    LeftShape = new MulitEllShape(ParamList);
                else if (shapeType == 6)
                    LeftShape = new JagWithEll(ParamList);

                PointLine = LeftShape.GetLeftPoint().ToArray();
            }
            return GetBitMapVal(PointLine);
        }

        public Bitmap RightDrawShouldPadShape(int shapeType)
        {
            PointCal RightShape = null;
            PointF[] PointLine = null;

            if (ParamList.Count != 0)
            {
                PointLine = null;
                RightShape = null;
                if (shapeType == 0)
                    RightShape = new StandardShape(ParamList);
                else if (shapeType == 1)
                    RightShape = new EllipseShape(ParamList);
                else if (shapeType == 2)
                    RightShape = new EllipseOutSide(ParamList);
                else if (shapeType == 3)
                    RightShape = new JagInside(ParamList);
                else if (shapeType == 4)
                    RightShape = new JagOutSide(ParamList);
                else if (shapeType == 5)
                    RightShape = new MulitEllShape(ParamList);
                else if (shapeType == 6)
                    RightShape = new JagWithEll(ParamList);

                PointLine = RightShape.GetHalfPoint().ToArray();
            }
            return GetBitMapVal(PointLine);
        }

        public Bitmap DrawShouldPadShape(int shapeType)
        {
            PointCal AllShape = null;
            PointF[] PointLine = null;

            if (ParamList.Count != 0)
            {
                PointLine = null;
                AllShape = null;

                if (shapeType == 0)
                    AllShape = new StandardShape(ParamList);
                else if (shapeType == 1)
                    AllShape = new EllipseShape(ParamList);
                else if (shapeType == 2)
                    AllShape = new EllipseOutSide(ParamList);
                else if (shapeType == 3)
                    AllShape = new JagInside(ParamList);
                else if (shapeType == 4)
                    AllShape = new JagOutSide(ParamList);
                else if (shapeType == 5)
                    AllShape = new MulitEllShape(ParamList);
                else if (shapeType == 6)
                    AllShape = new JagWithEll(ParamList);

                PointLine = AllShape.GetAllPoint().ToArray();
            }
            return GetBitMapVal(PointLine);
        }


        private void SetUserOperType(UserOperType userOperType)
        {
            UserOperType = userOperType;
            userOperTypeList.Add(userOperType);
        }

        //将花型参数 点和夹布器坐标 比例 存入一个元素项中
        public void AddEditOperParams()
        {
            Single[] shapeParams = null;
            if (ParamList.Count != 0)
            {
                shapeParams = new float[ParamList.Count];
                for (int i = 0; i < shapeParams.Length; i++)
                    shapeParams[i] = Convert.ToSingle(ParamList[i].Content);
            }
            editShouldPadInfoList.Add(new EditShouldPadInfo(shapeParams, shouldPadShapeInfo,originalMappingRatio));
        }

        public ClothClamp[] LoadClothClamps()
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            PointF[] pointfs = new PointF[6];

            Single middClothClipSpace = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.MiddClothChipSpace - 1].Content);
            Single leftClothClipSpace = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.LeftClothClipSpace - 1].Content);
            Single rightClothClipSpace = Convert.ToSingle(ParamList[(int)ShouldPadDataEnum.RightClothChipSpace - 1].Content);

            int invalidPointXDist = 0, invalidPointYDist = 0;
            pointfs[0] = new PointF(-DefaultValue.DefaultValueEx.ClothClampSpace, leftClothClipSpace / 2);  //夹布器间距
            pointfs[1] = new PointF(-DefaultValue.DefaultValueEx.ClothClampSpace, -leftClothClipSpace / 2);
            pointfs[2] = new PointF(DefaultValue.DefaultValueEx.ClothClampSpace, rightClothClipSpace / 2);
            pointfs[3] = new PointF(DefaultValue.DefaultValueEx.ClothClampSpace, -rightClothClipSpace / 2);
            pointfs[4] = new PointF(0, middClothClipSpace / 2);
            pointfs[5] = new PointF(0, -middClothClipSpace / 2);
            invalidPointXDist = Convert.ToInt32(Math.Round(DefaultValue.DefaultValueEx.InvalidPointXDist * MappingSize.MappingSizeEx.MappingRatio, 0));
            invalidPointYDist = Convert.ToInt32(Math.Round(DefaultValue.DefaultValueEx.InvalidPointYDist * MappingSize.MappingSizeEx.MappingRatio, 0));

            ClothClamp[] clothClamps = new ClothClamp[6];
            Point point = Point.Empty;
            double mappingRatio = MappingSize.MappingSizeEx.MappingRatio;
            for (int i = 0; i < clothClamps.Length; i++)
            {
                point.X = Convert.ToInt32(Math.Round(pointfs[i].X * mappingRatio, 0));
                point.Y = Convert.ToInt32(Math.Round(pointfs[i].Y * mappingRatio, 0));
                clothClamps[i] = new ClothClamp(point, invalidPointXDist, invalidPointYDist);
            }
            return clothClamps;
        }

        public Bitmap  RecountClampCloth()
        {
            ClothClamp[] clothClamps = LoadClothClamps();
            shouldPadShapeInfo = new ShouldPadShapeInfo(shouldPadShapeInfo.ShapePoints, clothClamps);
            shapeOperManager.SetShouldPadShapeInfo(shouldPadShapeInfo);
            AddEditOperParams();
            return shapeOperManager.GetShapeBitmap();
        }
        
        public Bitmap SetShouldPadPoints(ShouldPadShapeInfo shapeInfos)
        {
            editShouldPadInfoList.Clear();
            userOperTypeList.Clear();
            shouldPadShapeInfo = shapeInfos;
            shapeOperManager.SetShouldPadShapeInfo(shapeInfos);
            originalMappingRatio = MappingSize.MappingSizeEx.MappingRatio;
            return shapeOperManager.GetShapeBitmap();
        }
        public Bitmap SetShouldPadPoints(Point[] shapePoints)
        {
            shouldPadShapeInfo = new ShouldPadShapeInfo(shapePoints, shouldPadShapeInfo.ClothClamps);
            shapeOperManager.SetShouldPadShapeInfo(shouldPadShapeInfo);
            AddEditOperParams();
            SetUserOperType(UserOperType.ModifyOper);
            return shapeOperManager.GetShapeBitmap();
        }
        private PointF GetMiddlePoint(PointF point1, PointF point2)
        {
            Single middX = (point2.X - point1.X) / 2;
            Single middY = (point2.Y - point1.Y) / 2;
            return new PointF(point1.X + middX, point1.Y + middY);
        }

        private Point[] ChangToScreenPoints(PointF[] pointFs)
        {
            Point[] screenPoints = new Point[pointFs.Length];
            double mappingRatio = MappingSize.MappingSizeEx.MappingRatio;
            int pointX, pointY;
            for (int i = 0; i < pointFs.Length; i++)
            {
                pointX = Convert.ToInt32(pointFs[i].X * mappingRatio);
                pointY = Convert.ToInt32(pointFs[i].Y * mappingRatio);
                screenPoints[i] = new Point(pointX, pointY);
            }
            return screenPoints;
        }

    }
}
