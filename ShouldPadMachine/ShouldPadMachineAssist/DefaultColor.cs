using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    public class DefaultColor
    {
        private static DefaultColor defaultColor;
        private Color defaultMovePlueColor;
        private Color defaultPlueColor;      //默认的移动光标颜色
        private Color defaultBackGroundColor;//默认的背景颜色
        private Color defaultStringColor;
        private Color defaultShapeColor;
        private Color defaultIrregularColor;
        private Color defaultRangeColor;
        private Color defaultWarnColor;
        public static DefaultColor DefaultColorEx
        {
            get {
                if (defaultColor == null)
                    defaultColor = new DefaultColor();
                return defaultColor;
            }
        }
        public Color DefaultMovePlusColor
        {
            get {
                return defaultMovePlueColor;
            }
        }
        public Color DefaultRangeColor
        {
            get
            {
                return defaultRangeColor;
            }
        }
        public Color DefaultIrregularColor
        {
            get
            {
                return defaultIrregularColor;
            }
        }
        public Color DefaultShapeColor
        {
            get
            {
                return defaultShapeColor;
            }
        }
        public Color DefaultStringColor
        {
            get
            {
                return defaultStringColor;
            }
        }
        public Color DefaultPlueColor
        {
            get
            {
                return defaultPlueColor;
            }
        }
        public Color DefaultBackGroundColor
        {
            get
            {
                return defaultBackGroundColor;
            }
            set
            {
                defaultBackGroundColor = value;
            }
        }
        public Color DefalultWarnColor
        {
            get
            {
                return defaultWarnColor;
            }
            set
            {
                defaultWarnColor = value;
            }
        }
        private DefaultColor()
        {
            defaultMovePlueColor = Color.FromArgb(250,0,250);
            defaultBackGroundColor = Color.FromArgb(128, 128, 128);
            defaultPlueColor = Color.Blue;
            defaultStringColor = Color.Red;
            defaultShapeColor = Color.Black;
            defaultIrregularColor = Color.Red;
            defaultRangeColor = Color.Yellow;
            defaultWarnColor = Color.Green; ;
        }


    }
}
