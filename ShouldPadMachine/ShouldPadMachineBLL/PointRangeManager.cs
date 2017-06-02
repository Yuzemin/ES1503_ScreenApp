using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class ClothClampManager
    {
        public ClothClamp[] LoadClothClamps()
        {
            ShouldPadDAO shouldPadDAO = new ShouldPadDAO();
            PointF[] pointfs = new PointF[6];

            //获得屏上 左 右 中 三个夹布间距
            Single leftClothClipSpace = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.LeftClothClipSpace);
            Single rightClothClipSpace = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.RightClothChipSpace);
            Single middClothClipSpace = (Single)shouldPadDAO.GetDataBaseValue(ShouldPadDataEnum.MiddClothChipSpace);

            //获得6个夹布位置 仅6个加布器内部中间点的坐标
            int invalidPointXDist = 0, invalidPointYDist = 0;
            pointfs[0] = new PointF(-DefaultValue.DefaultValueEx.ClothClampSpace, leftClothClipSpace / 2);
            pointfs[1] = new PointF(-DefaultValue.DefaultValueEx.ClothClampSpace, -leftClothClipSpace / 2);
            pointfs[2] = new PointF(DefaultValue.DefaultValueEx.ClothClampSpace, rightClothClipSpace / 2);
            pointfs[3] = new PointF(DefaultValue.DefaultValueEx.ClothClampSpace, -rightClothClipSpace / 2);
            pointfs[4] = new PointF(0, middClothClipSpace / 2);
            pointfs[5] = new PointF(0, -middClothClipSpace / 2);
            invalidPointXDist = Convert.ToInt32(Math.Round(DefaultValue.DefaultValueEx.InvalidPointXDist * MappingSize.MappingSizeEx.MappingRatio, 0));
            invalidPointYDist = Convert.ToInt32(Math.Round(DefaultValue.DefaultValueEx.InvalidPointYDist * MappingSize.MappingSizeEx.MappingRatio, 0));

            ClothClamp[] clothClamps = new ClothClamp[6];
            Point point = Point.Empty;
            double mappingRation = MappingSize.MappingSizeEx.MappingRatio;
            for (int i = 0; i < clothClamps.Length; i++)
            {
                point.X = Convert.ToInt32(Math.Round(pointfs[i].X * mappingRation, 0));
                point.Y = Convert.ToInt32(Math.Round(pointfs[i].Y * mappingRation, 0));
                clothClamps[i] = new ClothClamp(point, invalidPointXDist, invalidPointYDist);
            }
            return clothClamps;
        }
    }
}
