using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class DefaultPath//默认路径
    {
        private String codePath;
        private String designCodePath;
        private DefaultPath()
        {
            designCodePath = @"F:\Image\ShouldPadMachine\";
        }
        public String BackUpDataPath
        {
            get
            {
                return DataBasePath + @"BackUp\";
            }
        }
        public String ImagePath
        {
            get
            {
                if (codePath == String.Empty || codePath == null)
                    LoadCodePath();
                return codePath + @"\Img\";
            }
        }
        public String BackImagePath//画图悲剧图片
        {
            get { 
                return ImagePath + "BackGroundImage.jpg";
            }
        }
        public String CodePath
        {
            get
            {
                if (codePath == String.Empty || codePath == null)
                    LoadCodePath();
                return codePath;
            }
        }
        public String DataBasePath
        {
            get
            {
                if (codePath == String.Empty || codePath == null)
                    LoadCodePath();
                return codePath + @"\Xml\";
            }
        }
        private static DefaultPath defaultPath;
        public static DefaultPath DefaultPathEx
        {
            get {
                if (defaultPath == null)
                    defaultPath = new DefaultPath();
                return defaultPath;
            }
        }
        private void LoadCodePath()
        {
            if (System.Environment.OSVersion.Platform == PlatformID.WinCE)
            {
                codePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;//获取程序运行的目录，该文件名会包括运行文件自己
                codePath = codePath.Substring(0, codePath.LastIndexOf(@"\"));//提取该文件的运行目录
            }
            else
                codePath = designCodePath;
        }
    }
}
