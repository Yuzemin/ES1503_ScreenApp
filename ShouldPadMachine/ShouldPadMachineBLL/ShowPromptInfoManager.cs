using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachineModel;

namespace ShouldPadMachine.ShouldPadMachineBLL
{
    class ShowPromptInfoManager
    {
        private Bitmap bitmap;
        private PromptInfoModel[] showPromptInfoDatas;
        private Rectangle drawRect;
        private ShouldPadMachine.ShouldPadMachineModel.Region[] regions;
        private int wide = 30;//单个数据宽的宽
        private PromptType promptType;
        private int[][] errorDatas;
        private String[] promptField;
        private int showNumber;//显示个数
        private int showIndex;
        public ShowPromptInfoManager(Rectangle rect, PromptType proptType)
        {
            drawRect = rect;
            bitmap = new Bitmap(rect.Width, rect.Height);
            Graphics.FromImage(bitmap).Clear(Color.White);
            this.promptType = proptType;
            showNumber = 30;//显示30个数据
            showIndex = 1;
        }
        public void SetPromptInfoDatas(PromptInfoModel[] promptInfoDatas)
        {
            this.showPromptInfoDatas = promptInfoDatas;
            showIndex = 1;
            PromptInfoModel[] infoDatas = GetCurrentPromptInfoDatas(showIndex);
            CreateBitmap(infoDatas);
            DrawPromptInfo(infoDatas);
        }
        public PromptInfoModel[] GetCurrentPromptInfoDatas(int index)
        {
            int startIndex = (index - 1) * showNumber;
            int endIndex = index * showNumber;
            if (endIndex > showPromptInfoDatas.Length)
                endIndex = showPromptInfoDatas.Length;
            PromptInfoModel[] infoDatas = new PromptInfoModel[endIndex - startIndex];
            for (int i = startIndex; i < endIndex; i++)
            {
                infoDatas[i - startIndex] = showPromptInfoDatas[i]; 
            }
            return infoDatas;
        }
        public void MoveNextData()//移到下一批数据
        {
            showIndex++;
            if ((showIndex - 1) * showNumber >= showPromptInfoDatas.Length)
                showIndex--;
            PromptInfoModel[] infoDatas = GetCurrentPromptInfoDatas(showIndex);
            CreateBitmap(infoDatas);
            DrawPromptInfo(infoDatas);
        }
        public bool HaveNextData()
        { 
            bool haveNextData;
            if (showPromptInfoDatas != null && showIndex * showNumber < showPromptInfoDatas.Length)
                haveNextData = true;
            else
                haveNextData = false;
            return haveNextData;
        }
        public bool HavePreData()
        { 
            bool havePreData;
            if (showPromptInfoDatas != null &&  showIndex > 1)
                havePreData = true;
            else
                havePreData = false;
            return havePreData;
        }
        public void MovePreData()
        {
            showIndex--;
            if (showIndex == 0)
                showIndex++;
            PromptInfoModel[] infoDatas = GetCurrentPromptInfoDatas(showIndex);
            CreateBitmap(infoDatas);
            DrawPromptInfo(infoDatas);
        }
        public void SetPromptField(String[] fieldName)
        {
            promptField = fieldName;
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }
        private void DrawPromptInfo(PromptInfoModel[] promptInfoDatas)
        {
            Graphics pe = Graphics.FromImage(bitmap);
            pe.Clear(Color.White);
            Rectangle singleRect;
            Rectangle[] rects;
            Font wordFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
            SolidBrush wordBrush = new SolidBrush(Color.Black);
            StringFormat filedFormat = new StringFormat();
            StringFormat dataFormat = new StringFormat();
            dataFormat.Alignment = StringAlignment.Near;
            dataFormat.LineAlignment = StringAlignment.Center;
            filedFormat.Alignment = StringAlignment.Center;
            filedFormat.LineAlignment = StringAlignment.Center;
            Rectangle filedRect;
            Rectangle dataRect;
            String[] errorInfoList = new String[5];
            for (int i = 0; i < promptInfoDatas.Length; i++)
            {
                rects = GetInfoRects(regions[i].StartY, regions[i].EndY);
                errorInfoList[0] = promptInfoDatas[i].PromptID;
                errorInfoList[1] = promptInfoDatas[i].PromptInfo;
                errorInfoList[2] = promptInfoDatas[i].PromptTime;
                errorInfoList[3] = promptInfoDatas[i].RunTime;
                errorInfoList[4] = promptInfoDatas[i].CodeVersion;
                for (int j = 0; j < rects.Length; j++)
                {
                    Pen pen = new Pen(Color.Blue);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    pe.DrawLine(pen, rects[j].X, rects[j].Y + rects[j].Height, rects[j].X + rects[j].Width, rects[j].Y + rects[j].Height);
                    pen.Dispose();
                    filedRect = new Rectangle(rects[j].X, rects[j].Y, rects[j].Width / 4, rects[j].Height);
                    dataRect = new Rectangle(rects[j].X + filedRect.Width, rects[j].Y, rects[j].Width - filedRect.Width, rects[j].Height);
                    if (promptType == PromptType.ErrorInfo)
                    {
                        if (j == 1)
                        {
                            pe.DrawString(promptField[j], wordFont, wordBrush, filedRect, filedFormat);
                            String[] errorStrings;
                            String singleErrorString;
                            Rectangle[] errorInfoRects;
                            int[] promptDatas = errorDatas[i];
                            int errorStringLength = promptDatas.Length / 5;
                            if (promptDatas.Length % 5 == 0)
                                errorStringLength--;
                            errorStrings = new String[errorStringLength + 1];
                            for (int k = 0; k < promptDatas.Length; k++)
                            {
                                singleErrorString = promptDatas[k].ToString();
                                singleErrorString = singleErrorString.PadLeft(6, ' ');
                                errorStrings[k / 5] += singleErrorString + " ";
                            }
                            errorInfoRects = new Rectangle[errorStrings.Length];
                            int gain = rects[j].Height;
                            if (errorInfoRects.Length != 0)
                                gain /= errorInfoRects.Length;
                            for (int k = 0; k < errorInfoRects.Length; k++)
                            {
                                errorInfoRects[k] = new Rectangle(dataRect.X, dataRect.Y + k * gain, dataRect.Width, dataRect.Height / errorInfoRects.Length);
                            }
                            for (int k = 0; k < errorInfoRects.Length; k++)
                            {
                                pe.DrawString(errorStrings[k], wordFont, wordBrush, errorInfoRects[k], dataFormat);
                            }
                        }
                        else
                        {
                            pe.DrawString(promptField[j], wordFont, wordBrush, filedRect, filedFormat);
                            pe.DrawString(errorInfoList[j], wordFont, wordBrush, dataRect, dataFormat);
                        }
                    }
                    else
                    {
                        pe.DrawString(promptField[j], wordFont, wordBrush, filedRect, filedFormat);
                        pe.DrawString(errorInfoList[j], wordFont, wordBrush, dataRect, dataFormat);
                    }
                }
                singleRect = new Rectangle(0, regions[i].StartY, bitmap.Width - 1, regions[i].EndY - regions[i].StartY);
                pe.DrawRectangle(new Pen(Color.Red), singleRect);
            }
        }
        private void CreateBitmap(PromptInfoModel[] promptInfoDatas)//创建画布大小,并且每个数据占有的矩形区域----regions
        {
            if (bitmap != null)
                bitmap.Dispose();
            regions = new ShouldPadMachine.ShouldPadMachineModel.Region[promptInfoDatas.Length];
            int mould = 0;//求模
            int result = 0;//求商
            int wideCount = 0;
            errorDatas = new int[promptInfoDatas.Length][];
            for (int i = 0; i < promptInfoDatas.Length; i++)
            {
                if (promptType == PromptType.ErrorInfo)
                {
                    String strErrorDatas = promptInfoDatas[i].PromptInfo;
                    int[] promptDatas = new int[] { };
                    if (strErrorDatas != String.Empty)
                    {
                        String[] strDatas = strErrorDatas.Split(',');
                        promptDatas = new int[strDatas.Length];
                        for (int j = 0; j < promptDatas.Length; j++)
                        {
                            promptDatas[j] = Convert.ToInt32(strDatas[j]);
                        }
                    }
                    errorDatas[i] = promptDatas;
                    mould = promptDatas.Length % 5;
                    result = promptDatas.Length / 5;
                    regions[i].StartY = wideCount * wide + drawRect.Y;
                    if (promptDatas.Length == 0)
                        wideCount += 1;
                    else
                    {
                        if (mould != 0)
                            wideCount += result + 1;
                        else
                            wideCount += result;   
                    }
                }
                else
                {
                    regions[i].StartY = wideCount * wide + drawRect.Y;
                    wideCount += 1;
                }
                wideCount += 4;
                regions[i].EndY = drawRect.Y + wideCount * wide;
            }
            int height;
            int width;
            if (wideCount * wide < drawRect.Height)
            {
                width = drawRect.Width + 20;
                height = drawRect.Height;
            }
            else
            {
                width = drawRect.Width;
                height = wideCount * wide + 2;
            }
            bitmap = new Bitmap(width, height);
        }
        private Rectangle[] GetInfoRects(int startY, int endY)
        {
            int count = (endY - startY) / wide;//获得可以平分成几个矩形
            int sigleHeight = wide;
            int newStartY, newEndY;
            Rectangle[] rects = new Rectangle[5];//因为数据库中只有五个元素，所以得分成五个大的矩形
            int datasCount = count - 4;
            int addCount = 1;
            newStartY = startY;
            newEndY = startY;
            for (int i = 0; i < rects.Length; i++)
            {
                if (i == 1)
                    addCount = datasCount;
                else
                    addCount = 1;
                newEndY = newEndY + addCount * wide;
                rects[i] = new Rectangle(0, newStartY, drawRect.Width, newEndY - newStartY);
                newStartY = newEndY;
            }
            return rects;
        }
        public void Dispose()
        {
            bitmap.Dispose();
            errorDatas = null;
            promptField = null;
            regions = null;
            showPromptInfoDatas = null;
        }
    }
}
