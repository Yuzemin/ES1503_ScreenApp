using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineFactory;
using ShouldPadMachine.ShouldPadMachineDAL;
using ShouldPadMachine.ShouldPadMachineUI;

namespace ShouldPadMachine.ShouldPadMachineCTL
{
    public partial class DataButton : Control, IDisposable
    {
        private DataButtonInfo dataButtonInfo;
        public DataButton()
        {
            InitializeComponent();
            dataButtonInfo = new DataButtonInfo();
        }
        #region 父控件属性隐藏
        protected new int TabIndex
        {
            set
            {
                base.TabIndex = value;
            }
            get
            {
                return base.TabIndex;
            }
        }
        protected new AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }
            set
            {
                base.Anchor = value;
            }
        }
        #endregion
        #region 属性
        public bool SaveDataEnable
        {
            set
            {
                dataButtonInfo.SaveDataEnable = value;
                if (value ==  true)
                {
                    dataButtonInfo.HasClick = true;
                    OnTextChanged(null);
                }
            }
        }
        
        public DataInfo ButtonDataInfo
        {
            get
            {
                DataInfo dataInfo = null;
                DataInfoSet dataInfoSet = MouldDataFactory.CreateDataInfo(dataButtonInfo.DataTypeName);
                String elementName = GetButtonElement();
                if (dataInfoSet != null && elementName != String.Empty)
                    dataInfo = dataInfoSet[elementName];
                if (dataInfo == null)
                    dataInfo = new DataInfo();
                return dataInfo;
            }
        }
        public Color FrameColor
        {
            get
            {
                return dataButtonInfo.FrameColor;
            }
            set
            {
                if (dataButtonInfo.FrameColor != value)
                {
                    dataButtonInfo.FrameColor = value;
                    this.Refresh();
                }
            }
        }
        public CascadeDataEnum CascadeDataElement
        {
            set
            {
                dataButtonInfo.CascadeDataEnum = value;
            }
            get
            {
                return dataButtonInfo.CascadeDataEnum;
            }
        }
        public SetDataEnum SetDataElement
        {
            set
            {
                dataButtonInfo.SetDataEnum = value;
            }
            get
            {
                return dataButtonInfo.SetDataEnum;
            }
        }
        public bool HasClick
        {
            get
            {
                return dataButtonInfo.HasClick;
            }
            set
            {
                dataButtonInfo.HasClick = value;
            }
        }
        public DataTypeName DataTypeName
        {
            get
            {
                return dataButtonInfo.DataTypeName;
            }
            set
            {
                dataButtonInfo.DataTypeName = value;
            }
        }
        public ShouldPadDataEnum ShouldPadDataEnum
        {
            get
            {
                return dataButtonInfo.ShouldPadDataEnum;
            }
            set
            {
                dataButtonInfo.ShouldPadDataEnum = value;
            }
        }
        public MachineBaseDataEnum BaseDataElement
        {
            get
            {
                return dataButtonInfo.BaseDataEnum;
            }
            set
            {
                dataButtonInfo.BaseDataEnum = value;
            }
        }
        public InOutDataEnum InOutDataElement
        {
            get
            {
                return dataButtonInfo.InOutDataEnum;
            }
            set
            {
                dataButtonInfo.InOutDataEnum = value;
            }
        }
      
        public bool FreshEnable
        {
            set
            {
                dataButtonInfo.FreshEnable = value;
                this.Refresh();
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Refresh();
                }

            }
        }
        #endregion
        protected virtual Rectangle GetTextRect()
        {
            return new Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top,
                                                        this.ClientRectangle.Width, this.ClientRectangle.Height);
        }
        private String GetUnitString()
        {
            String unitString = String.Empty;
            LanguageLibrary languageLibrary = new LanguageLibrary("中文");
            if (dataButtonInfo.DataInfo != null)
            {
                switch (dataButtonInfo.DataInfo.UnitType)
                {
                    case UnitType.MM:
                        unitString = languageLibrary.OtherStrings[(int)OtherStringType.MM];
                        break;
                    case UnitType.Pin:
                        unitString = languageLibrary.OtherStrings[(int)OtherStringType.Pin];
                        break;
                }
            }
            return unitString;
        }
        protected override void OnClick(EventArgs e)
        {
            if (FlowDrawForm.modelChange)
            {
                HasClick = true;
            }
            base.OnClick(e);
        }
        private void DrawFrame(Graphics pe)
        {
            if (dataButtonInfo.FrameColor != Color.Empty)
            {
                int indent = 2;
                Rectangle[] frameRects = new Rectangle[4];
                Color frameColor = dataButtonInfo.FrameColor;
                frameRects[0] = new Rectangle(0, 0, this.Size.Width, indent);
                frameRects[1] = new Rectangle(this.Size.Width - indent, 0, indent, this.Size.Height);
                frameRects[2] = new Rectangle(0, 0, indent, this.Size.Height);
                frameRects[3] = new Rectangle(0, this.Size.Height - indent, this.Size.Width, indent);
                SolidBrush solidBrush = new SolidBrush(frameColor);
                for (int i = 0; i < frameRects.Length; i++)
                    pe.FillRectangle(solidBrush, frameRects[i]);
                solidBrush.Dispose();
                solidBrush = null;
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (dataButtonInfo.HasClick)
            {
                dataButtonInfo.HasClick = false;
                int sqliteData = 0;
                double showData;
                string showDataId=null;
                if (DataTypeName != DataTypeName.Null && dataButtonInfo.SaveDataEnable)
                {
                    String elementName = GetButtonElement();
                    if (elementName == "ID")
                    {
                        DataBaseDAO dataBaseDAO = MouldDataFactory.CreateDataBaseDAO(DataTypeName);
                        showDataId = base.Text;                     
                        if (System.Environment.OSVersion.Platform == PlatformID.WinCE)
                            dataBaseDAO.SetDataBaseValue(elementName, showDataId.ToString());
                    }
                    else
                    {
                        DataBaseDAO dataBaseDAO = MouldDataFactory.CreateDataBaseDAO(DataTypeName);
                        showData = Convert.ToDouble(base.Text);
                        if (elementName != String.Empty && elementName != "Null")
                        {
                            dataButtonInfo.DataInfo = ButtonDataInfo;
                            sqliteData = DataChange.ChangeShowDataToXmlData(dataButtonInfo.DataInfo, showData);
                            if (elementName != String.Empty && elementName != "Null" && System.Environment.OSVersion.Platform == PlatformID.WinCE)
                                dataBaseDAO.SetDataBaseValue(elementName, sqliteData.ToString());
                        }
                    }
                }
            }
        }
        private String GetButtonElement()
        {
            String elementName = String.Empty;
            switch (DataTypeName)
            {
                case DataTypeName.InOutDataTable:
                    elementName = dataButtonInfo.InOutDataEnum.ToString();
                    break;
                case DataTypeName.BaseDataTable:
                    elementName = dataButtonInfo.BaseDataEnum.ToString();
                    break;
                case DataTypeName.ShouldPadDataTable:
                    elementName = dataButtonInfo.ShouldPadDataEnum.ToString();
                    break;
                case DataTypeName.CascadeDataTable:
                    elementName = dataButtonInfo.CascadeDataEnum.ToString();
                    break;
                case DataTypeName.FlowDataTable:
                    elementName = dataButtonInfo.SetDataEnum.ToString();
                    break;
                default:
                    break;
            }
            return elementName;
        }
        private String GetShowData()
        {
            int count = System.Environment.TickCount;
            String showString = String.Empty;
            int showData = 0;
            string showSData=null;
            showString = this.Text;

            if (DataTypeName != DataTypeName.Null)
            {
                String elementName = GetButtonElement();
                DataBaseDAO dataBaseDAO = MouldDataFactory.CreateDataBaseDAO(DataTypeName);
                if (elementName == "ID")
                {
                    if (elementName != String.Empty && elementName != "Null" && System.Environment.OSVersion.Platform == PlatformID.WinCE)
                    {
                        showSData = dataBaseDAO.GetDataBaseValue(elementName);
                        showString = showSData;
                    }
                }
                else
                {
                    if (elementName != String.Empty && elementName != "Null" && System.Environment.OSVersion.Platform == PlatformID.WinCE)
                    {
                        showData = Convert.ToInt32(dataBaseDAO.GetDataBaseValue(elementName));
                        dataButtonInfo.DataInfo = ButtonDataInfo;
                        showString = DataChange.ChangeXmlDataToShowData(dataButtonInfo.DataInfo, showData).ToString();
                    }
                }
            }
            return showString;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            // TODO: 在此处添加自定义绘制代码
            if (dataButtonInfo.FreshEnable)
            {
                dataButtonInfo.FreshEnable = false;
                base.Text = GetShowData();
            }
            /*************************************为控件绘制文本属性**************************/
            StringFormat fontAlignMent = new StringFormat();
            String strText = this.Text;
            Rectangle textRect = GetTextRect();//获得图形矩形
            Font textFont = new System.Drawing.Font(this.Font.Name, this.Font.Size, this.Font.Style);
            SolidBrush fontBrush = new System.Drawing.SolidBrush(this.ForeColor);
            fontAlignMent.Alignment = StringAlignment.Center;//设置字体显示时候的对齐方式
            fontAlignMent.LineAlignment = StringAlignment.Center;
            String text = this.Text;
            if (System.Environment.OSVersion.Platform == PlatformID.WinCE && (dataButtonInfo.DataInfo != null && dataButtonInfo.DataInfo.UnitType != UnitType.Null))
                text += " " + GetUnitString();
            pe.Graphics.DrawString(text, textFont, fontBrush, textRect, fontAlignMent);
            if (dataButtonInfo.FrameColor != Color.Empty)
                //pe.Graphics.FillRectangle()
                DrawFrame(pe.Graphics);
            fontBrush.Dispose();
            fontAlignMent.Dispose();
            textFont.Dispose();
            fontBrush.Dispose();
            base.OnPaint(pe);
        }
    }
}
