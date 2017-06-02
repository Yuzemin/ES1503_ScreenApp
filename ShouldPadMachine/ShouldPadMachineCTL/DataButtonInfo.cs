using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public class DataButtonInfo
    {
        private Color frameColor;//边框平时颜色
        private DataTypeName dataTypeName;
        private ShouldPadDataEnum mouldDataEnum;
        private MachineBaseDataEnum baseDataEnum;
        private CascadeDataEnum cascadeDataEnum;
        private InOutDataEnum inOutDataEnum;
        private SetDataEnum setDataEnum;
        private bool hasClick;
        private bool freshEnable;
        private bool saveDataEnable;
        private bool modeChange;

      
       
        private DataInfo dataInfo;
        #region 属性
        public bool SaveDataEnable
        {
            get {
                return saveDataEnable;
            }
            set {
                saveDataEnable = value;
            }
        }
        public Color FrameColor
        {
            get
            {
                return frameColor;
            }
            set
            {
                frameColor = value;
            }
        }

        public SetDataEnum SetDataEnum
        {
            get { return setDataEnum; }
            set { setDataEnum = value; }
        }

        public InOutDataEnum InOutDataEnum
        {
            set
            {
                inOutDataEnum = value;
            }
            get
            {
                return inOutDataEnum;
            }
        }
        public CascadeDataEnum CascadeDataEnum
        {
            set
            {
                cascadeDataEnum = value;
            }
            get
            {
                return cascadeDataEnum;
            }
        }
        public bool FreshEnable
        {
            set
            {
                freshEnable = value;
            }
            get
            {
                return freshEnable;
            }
        }
        public bool HasClick
        {
            set
            {
                hasClick = value;
            }
            get
            {
                return hasClick;
            }
        }
        public MachineBaseDataEnum BaseDataEnum
        {
            set
            {
                baseDataEnum = value;
            }
            get
            {
                return baseDataEnum;
            }
        }
        public ShouldPadDataEnum ShouldPadDataEnum
        {
            set
            {
                mouldDataEnum = value;
            }
            get
            {
                return mouldDataEnum;
            }
        }
        public DataTypeName DataTypeName
        {
            set
            {
                dataTypeName = value;
            }
            get
            {
                return dataTypeName;
            }
        }
        public DataInfo DataInfo
        {
            get
            {
                return dataInfo;
            }
            set
            {
                dataInfo = value;
            }
        }
        public bool ModeChange
        {
            get { return modeChange; }
            set { modeChange = value; }
        }

        #endregion
        public DataButtonInfo()
        {
            freshEnable = true;
            cascadeDataEnum = CascadeDataEnum.Null;
            mouldDataEnum = ShouldPadDataEnum.Null;
            inOutDataEnum = InOutDataEnum.Null;
            hasClick = false;
            dataTypeName = DataTypeName.Null;
            baseDataEnum = MachineBaseDataEnum.Null;
            frameColor = Color.Empty;
            dataInfo = null;
            saveDataEnable = true;
        }
    }
    public class ImageDataButtonInfo
    {
        private Color frameColor;//边框平时颜色
        private Image imageNormal;
        private Image imagePress;
        private ImageType imageType;
        private Color colorPress;
        private Color colorNormal;
        private ButtonStatus buttonStatus;
        private int imageWidth;
        private int indent;
        public Color FrameColor
        {
            get
            {
                return frameColor;
            }
            set
            {
                frameColor = value;
            }
        }

    

        public int ImageWidth
        {
            get
            {
                return imageWidth;
            }
            set
            {
                imageWidth = value;
            }
        }
        public ButtonStatus ButtonStatus
        {
            get
            {
                return buttonStatus;
            }
            set
            {
                buttonStatus = value;
            }
        }
        public Image ImageNormal
        {
            get
            {
                return imageNormal;
            }
            set
            {
                imageNormal = value;
            }
        }
        public Image ImagePress
        {
            get
            {
                return imagePress;
            }
            set
            {
                imagePress = value;
            }
        }
        public Color ColorPress
        {
            get
            {
                return colorPress;
            }
            set
            {
                colorPress = value;
            }
        }
        public Color ColorNormal
        {
            get
            {
                return colorNormal;
            }
            set
            {
                colorNormal = value;
            }
        }
        public ImageType ImageType
        {
            get
            {
                return imageType;
            }
            set
            {
                imageType = value;
            }
        }
        public int Indent
        {
            get
            {
                return indent;
            }
            set
            {
                indent = value;
            }
        }
        public ImageDataButtonInfo()
        {
            imageNormal = null;
            imagePress = null;
            imageType = ImageType.Null;
            buttonStatus = ButtonStatus.Normal;
            indent = 2;
        }
    }
    public class ImageButtonInfo
    {
        private Image imageNormal;
        private Image imagePress;
        private ButtonType buttonType;
        private ButtonStatus buttonStatus;
        private ImageType imageType;//图片类型
        private Color frameNormalColor;//边框平时颜色
        private Color framePressColor;//边框按下颜色
        #region 属性
        public ButtonStatus ButtonStatus
        {
            get
            {
                return buttonStatus;
            }
            set
            {
                buttonStatus = value;
            }
        }
        public ButtonType ButtonType
        {
            get
            {
                return buttonType;
            }
            set
            {
                buttonType = value;
            }
        }
        public Image ImageNormal
        {
            get
            {
                return imageNormal;
            }
            set
            {
                imageNormal = value;
            }
        }
        public Image ImagePress
        {
            get
            {
                return imagePress;
            }
            set
            {
                imagePress = value;
            }
        }
        public Color FramePressColor
        {
            get
            {
                return framePressColor;
            }
            set
            {
                framePressColor = value;
            }
        }
        public Color FrameNormalColor
        {
            get
            {
                return frameNormalColor;
            }
            set
            {
                frameNormalColor = value;
            }
        }
        public ImageType ImageType
        {
            get
            {
                return imageType;
            }
            set
            {
                imageType = value;
            }
        }
        #endregion
        public ImageButtonInfo()
        {
            buttonType = ButtonType.ClickButton;
            buttonStatus = ButtonStatus.Normal;
            imageType = ImageType.Null;
            frameNormalColor = Color.Empty;
            framePressColor = Color.Empty;
        }
    }
}
