using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ShouldPadMachine.ShouldPadMachineAssist
{
    class LanguageLibrary
    {
        private String[] promptOccurPlace;
        private String[] promptMessageType;
        private String[] errorStrings;
        private String[] warnStrings;
        private String[] otherString;
        private String[] messageFiledStrings;
        public String[] MessageFiledStrings
        {
            get
            {
                return messageFiledStrings;
            }
        }
        public String[] PromptOccurPlace
        {
            get
            {
                return promptOccurPlace;
            }
        }
        public String[] PromptMessageType
        {
            get
            {
                return promptMessageType;
            }
        }
        public String[] ErrorStrings
        {
            get
            {
                return errorStrings;
            }
        }
        public String[] WarnStrings
        {
            get
            {
                return warnStrings;
            }
        }
        public String[] OtherStrings
        {
            get
            {
                return otherString;
            }
        }
        public LanguageLibrary(String useLanguage)
        {
            if (useLanguage == "英文")
            {
                errorStrings = new String[] { 
                     "Shaft X Fails To Return To 'Zero' ,It May Be Caused By\nThe Following Reasion:\n"+
                    "1.Shaft X is Jammed.2.X Proximity Switch Is Damaged.\n3.X Motor Wires Or Encoder Wires Fall Off.",      //1
                    "The Machine May Be Affected Due To Greatly Fluctuater\n Voltage.Please Try To Restart The machine",   //2
                    "Shaft X Fails To Go To Specific Position,It May Be Caused By\n The Following Reasons:\n"+
                    "1.Shaft X is Jammed.2.X Motor Wires Or Encoder Wires Fall Off.",                                      //3
                    "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",   //4
                    "Shaft Y Fails To Return To 'Zero' ,It May Be Caused By\n The Following Reasion:\n"+
                    "1.Shaft Y is Jammed.2.Y Proximity Switch Is Damaged.\n3.Y Motor Wires Or Encoder Wires Fall Off.",      //5
                     "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",  //6
                    "Shaft Y Fails To Go To Specific Position,It May Be Caused By\n The Following Reasons:\n"+
                    "1.Shaft Y is Jammed.2.Y Motor Wires Or Encoder Wires Fall Off.",                                      //7
                     "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",  //8
                    "Shaft Z Fails To Return To 'Zero' ,It May Be Caused By\n The Following Reasion:\n"+
                    "1.Shaft Z is Jammed.2.Z Proximity Switch Is Damaged.\n3.Z Motor Wires Or Encoder Wires Fall Off.",      //9
                     "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",  //10
                    "Shaft Z Fails To Go To Specific Position,It May Be Caused By\n The Following Reasons:\n"+
                    "1.Shaft Z is Jammed.2.Z Motor Wires Or Encoder Wires Fall Off.",                                      //11
                     "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine", //12
                     "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine", //13
                    "The Proximity Switch In Main Shaft Can't Be Found",                                                  //14
                    "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",  //15
                    "The Servo Motor Can't Make The Machine Park In An Accurate \nPosition.",                               //16
                    "X Motor Has Excessive Current Problems.\nPlease Turn Off Power Source To Check Whether Motor"+
                    "Wire Has a Short Circuit Problem",                                                                   //17
                    "Y Motor Has Excessive Current Problems.\nPlease Turn Off Power Source To Check Whether Motor\n"+
                    "Wire Has a Short Circuit Problem",                                                                   //18
                    "Z Motor Has Excessive Current Problems.\nPlease Turn Off Power Source To Check Whether Motor\n"+
                    "Wire Has a Short Circuit Problem",                                                                   //19
                    "The Main Board Is Damaged.Please Try To Restart The Machine",                                        //20
                    "Machine Is Interference,Please Restart The Machine",                                                 //21
                    "Machine Is Interference,Please Restart The Machine",                                                 //22
                    "Motherboard Is Damaged,Please Restart The Machine",                                                 //23
                    "Motherboard Is Damaged,Please Restart The Machine",                                                 //24
                    "The Servo Motor Has Excessive Current Problem,It May Be Caused By\n The Following Reasions:\n"+        //25
                    "1.Servo Motor Has Short Circuit Problem.2.The Main Board Is Damaged.\n3.The Machine Is OverLoaded",
                    "The Speed Of Servo Motor Is Too Fast",                                                               //26
                    "The Machine May Be Affected Due To Greatly Fluctuater Voltage.\nPlease Try To Restart The machine",   //27
                    "The Servo Encoder Is Not Found.Please Check Encoder Wires.",                                        //28
                    "The Servo Speed Fails To Keep Up,It May Be Caused By The Following Reasons:\n"+
                    "1.The Servo Speed Is Set To Be Too Fast.2.The Main Shaft Is Too Heavy Or Is Jammed",                //29
                    "Motherboard Is Damaged,Please Restart The Machine",                                                 //30
                };
                warnStrings = new String[]{
                    "310V Voltage Is Too Low",
                    "310V Voltage Is Too Excessive",
                    "140V Voltage Is Too Low",
                    "140V Voltage Is Too Excessive",
                    "24V Voltage Is Too Low",
                    "24V Voltage Is Too Excessive",
                    "Production Volume Can't Save",
                    "Servo Motor Is Too Heavy",
                    "The Version Is Not Correct,But\n"
                     +"Don't Affect The Machine To Work.",
                     "NO 140 V power supply"
                };
                otherString = new String[] { 
                    "针",
                    "mm",
                    "验证码到期，请与商家联系！",
                    "ID",
                    "序列号"
                };
            }
            else
            {

                errorStrings = new String[] { 
                    "X轴回零失败，机器可能有以下原因造成：\n1、X轴卡死 2、X光电开关损坏 3、X电机或编码器线脱落。",//1
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //2
                    "X轴走不到指定位置，可能有以下原因造成：\n1、 X轴卡死 2、X电机或编码器线脱落。",              //3
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //4
                    "Y轴回零失败，机器可能有以下原因造成：\n1、Y轴卡死 2、Y光电开关损坏 3、Y电机或编码器线脱落",  //5
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //6
                    "Y轴走不到指定位置，可能有以下原因造成：\n1、 Y轴卡死 2、Y电机或编码器线脱落。",              //7
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //8
                    "Z轴回零失败，机器可能有以下原因造成：\n1、 Z轴卡死 2、Z光电开关损坏 3、Z电机或编码器线脱落", //9
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //10
                    "Z轴走不到指定位置，可能有以下原因造成：\n1、 Z轴卡死 2、Z电机或编码器线脱落。",              //11
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //12
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //13
                    "主轴光电开关找不到。",                                                                       //14
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //15
                    "伺服电机停车不准。",                                                                         //16
                    "X电机过流\n请关电源检查电机线有无短路现象。",                                                //17
                    "Y电机过流\n请关电源检查电机线有无短路现象。",                                                //18
                    "Z电机过流\n请关电源检查电机线有无短路现象。",                                                //19
                    "主板损坏，请尝试重启机器",                                                                   //20
                    "没有气压，请检查！",                                                                         //21
                    "机器受到干扰，请重新启动机器。",                                                             //22
                    "主板损坏，请尝试重启机器",                                                                   //23
                    "主板损坏，请尝试重启机器",                                                                   //24
                    "伺服电机过流，可能有以下原因造成：\n1、伺服电机短路，2、主板损坏3、机器过载",                //25
                    "伺服速度过高",                                                                               //26
                    "机器可能受到电压波动过大影响，请尝试重启机器。",                                             //27
                    "伺服编码器找不到，请检查编码器线。",                                                         //28
                    "伺服速度跟不上，可能有以下原因造成：\n1、伺服速度设置过快 2、主轴过重或卡死",                //29
                    "主板损坏，请尝试重启机器",                                                                   //30
                };
                warnStrings = new String[]{
                    "310V电压过低",
                    "310V电压过高",
                    "140V电压过低",
                    "140V电压过高",
                    "24V电压过低",
                    "24V电压过高",
                    "生产数量保存不了",
                    "伺服电机过重",
                    "程序版本过低,"+"但\n不影响机器工作!",
                    "检测不到140V电\n源"
                };
                otherString = new String[] { 
                    "针",
                    "mm",
                    "验证码到期，请与商家联系！",
                    "ID",
                    "序列号"
                };
                messageFiledStrings = new String[] { 
                    "错误地方：",
                    "错误原因：",
                    "错误信息：",
                };
                promptOccurPlace = new String[] { 
                    "操作串口----接收",
                    "操作串口---发送",
                    "操作文件",
                    "操作图片",
                    "操作数据---写入",
                    "操作数据---读取",
                    "逻辑出错",
                    "操作系统时间",
                    "操作注册表",
                    "操作对话框",
                    "不可预知"
                };
                promptMessageType = new String[]{
                    "下标溢出",
                    "加密文件，用户没有读取注册表所需的权限",
                    "对象已经被破坏",
                    "发生不可预知的错误",
                    "读取系统时间时出错",
                    "文件加载或分析错误----格式被破坏",
                    "打开文件时发生了I/O错误",
                    "当前平台不支持此操作或指定了一个只读文件",
                    "未被引用错误",
                    "无限递归错误",
                    "属性无效错误",
                    "指定端口已经打开",
                    "该操作未在超时时间到期之前完成",
                    "已经操纵的文件末端错误",
                    "不可预知的错误",
                };
            }
        }
        public void Dispose()
        {
            errorStrings = null;
            warnStrings = null;
            otherString = null;
        }
    }
}
