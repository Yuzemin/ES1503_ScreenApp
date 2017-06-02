using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Security;
using ShouldPadMachine.ShouldPadMachineModel;
using ShouldPadMachine.ShouldPadMachineAssist.Enum;
using ShouldPadMachine.ShouldPadMachinePMT;

namespace ShouldPadMachine.ShouldPadMachineDAL
{
    public class XmlHelper
    {
        public static void CreateXml(InfoHashTable hashTable, String xmlName)
        {
            String directName = Path.GetDirectoryName(xmlName);
            if (!Directory.Exists(directName))
                Directory.CreateDirectory(directName);
            XmlTextWriter xmlTextWriter = null;
            try
            {
                xmlTextWriter = new XmlTextWriter(xmlName, Encoding.UTF8);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteStartDocument();
                foreach (SingleHashTable singleHashTable in hashTable)
                {
                    if (singleHashTable.Value != null)
                        xmlTextWriter.WriteElementString(singleHashTable.Key.ToString(), singleHashTable.Value.ToString());
                    else
                    {
                        if (singleHashTable.Key.ToString() == "End")
                            xmlTextWriter.WriteEndElement();
                        else
                            xmlTextWriter.WriteStartElement(singleHashTable.Key.ToString());
                    }
                }
                xmlTextWriter.WriteEndDocument();
            }
            catch(Exception ex)
            {
                PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlWriteError;
                PromptMessageType promptMessageType = PromptMessageType.Null;
                if (ex is IOException)
                    promptMessageType = PromptMessageType.IOException;
                else if (ex is UnauthorizedAccessException)
                    promptMessageType = PromptMessageType.UnauthorizedAccessException;
                else if (ex is NullReferenceException)
                    promptMessageType = PromptMessageType.NullReferenceException;
                else if (ex is SecurityException)
                    promptMessageType = PromptMessageType.SecurityException;
                else
                    promptMessageType = PromptMessageType.UnKnown;
                ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(xmlName));
            }
            finally
            {
                if (xmlTextWriter != null)
                {
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                    xmlTextWriter = null;
                }
            }
        }
        public static void AppendElementValues(InfoHashTable hashTable, String xmlName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(xmlName);
                XmlNode rootNode = xmlDocument.DocumentElement;
                XmlNode appendNode = null;
                XmlElement appendElement = null;
                foreach (String key in hashTable.Keys)
                {
                    if (hashTable[key] != null)
                    {
                        appendElement = xmlDocument.CreateElement(key);
                        appendElement.InnerText = hashTable[key].ToString();
                        if (appendNode != null)
                            appendNode.AppendChild(appendElement);
                    }
                    else
                    {
                        if (key != "End")
                            appendNode = xmlDocument.CreateElement(key);
                        else
                            rootNode.AppendChild(appendNode);
                    }
                }
                xmlDocument.Save(xmlName);
            }
            catch (Exception ex)
            {
                PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlWriteError;
                PromptMessageType promptMessageType = PromptMessageType.Null;
                if (ex is XmlException)
                    promptMessageType = PromptMessageType.XmlException;
                else if (ex is IOException)
                    promptMessageType = PromptMessageType.IOException;
                else if (ex is NullReferenceException)
                    promptMessageType = PromptMessageType.NullReferenceException;
                else if (ex is UnauthorizedAccessException)
                    promptMessageType = PromptMessageType.UnauthorizedAccessException;
                else
                    promptMessageType = PromptMessageType.UnKnown;
                ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(xmlName));
            }
        }
        public static void AppendElementValues(String elementName, String elementValue, String xmlName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(xmlName);
                XmlNode rootNode = xmlDocument.DocumentElement;
                XmlElement appendElement = xmlDocument.CreateElement(elementName);
                appendElement.InnerText = elementValue;
                rootNode.AppendChild(appendElement);
                xmlDocument.Save(xmlName);
                xmlDocument = null;
            }
            catch (Exception ex)
            {
                PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlWriteError;
                PromptMessageType promptMessageType = PromptMessageType.Null;
                if (ex is XmlException)
                    promptMessageType = PromptMessageType.XmlException;
                else if (ex is IOException)
                    promptMessageType = PromptMessageType.IOException;
                else if (ex is NullReferenceException)
                    promptMessageType = PromptMessageType.NullReferenceException;
                else if (ex is UnauthorizedAccessException)
                    promptMessageType = PromptMessageType.UnauthorizedAccessException;
                else
                    promptMessageType = PromptMessageType.UnKnown;
                ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(xmlName));
            }
        }
        public static void SetElementValue(String fileName, String elementName, String elementValue)
        {
            if (File.Exists(fileName))
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(fileName);
                    XmlNode xmlNode = xmlDocument.DocumentElement;
                    XmlNode currentNode = xmlNode.SelectSingleNode(elementName);
                    if (currentNode != null)
                        currentNode.InnerText = elementValue;
                    xmlDocument.Save(fileName);
                }
                catch(Exception ex)
                {
                    PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlWriteError;
                    PromptMessageType promptMessageType = PromptMessageType.Null;
                    if (ex is XmlException)
                        promptMessageType = PromptMessageType.XmlException;
                    else if (ex is IOException)
                        promptMessageType = PromptMessageType.IOException;
                    else if (ex is UnauthorizedAccessException)
                        promptMessageType = PromptMessageType.UnauthorizedAccessException;
                    else if (ex is NullReferenceException)
                        promptMessageType = PromptMessageType.NullReferenceException;
                    else
                        promptMessageType = PromptMessageType.UnKnown;
                    ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(fileName));
                }
                finally
                {
                    xmlDocument = null;
                }
            }
        }
        public static void ModifyElementValue(String xmlName, InfoHashTable infoHashTable)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlName);
            XmlNode rootNode = xmlDocument.DocumentElement;
            XmlNode currentRootNode = null;
            XmlNode currentNode = null;
            foreach (SingleHashTable singleHashTable in infoHashTable)
            {
                if (singleHashTable.Value == null)
                    currentRootNode = rootNode.SelectSingleNode(singleHashTable.Key.ToString());
                else
                {
                    if (currentRootNode != null && currentRootNode.HasChildNodes)
                    {
                        currentNode = currentRootNode.SelectSingleNode(singleHashTable.Key.ToString());
                        if (currentNode != null)
                            currentNode.InnerText = singleHashTable.Value.ToString();
                    }
                }
            }
            xmlDocument.Save(xmlName);
        }
        public static String GetElementValue(String xmlName, String elementName)
        {
            String backInfo = String.Empty;
            if (File.Exists(xmlName))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlName);
                XmlNode xmlNode = xmlDocument.DocumentElement;
                XmlNode curentNode = xmlNode.SelectSingleNode(elementName);
                if (curentNode != null)
                    backInfo = curentNode.InnerText;
                xmlDocument = null;
            }
            return backInfo;
        }
        public static int GetChildNodesCount(String xmlName,String xpath)
        { 
            int count = 0;
            if(File.Exists(xmlName))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlName);
                XmlNode xmlNode = xmlDocument.DocumentElement;
                if(xpath != String.Empty)
                    xmlNode = xmlNode.SelectSingleNode(xpath);
                count = xmlNode.ChildNodes.Count;
            }
            return count;
        }
        public static int GetChildNodesCount(String xmlName)
        {
            return GetChildNodesCount(xmlName, String.Empty);
        }
        /// <summary>
        /// 该函数用于读写只有一个父级，最简单的XML格式
        /// </summary>
        /// <param name="xmlName"></param>
        /// <param name="elementNames"></param>
        /// <returns></returns>
        public static InfoHashTable ReadXmlValues(String xmlName, String[] elementNams)
        {
            InfoHashTable infoHashTable = null;
            if (File.Exists(xmlName))
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(xmlName);
                    XmlNode xmlRootNode = xmlDocument.DocumentElement;
                    XmlNode xmlCurrentNode = null;
                    infoHashTable = new InfoHashTable();
                    List<String> notFoundDataList = new List<string>();
                    for (int i = 0; i < elementNams.Length; i++)
                    {
                        xmlCurrentNode = xmlRootNode.SelectSingleNode(elementNams[i]);
                        if (xmlCurrentNode != null)
                            infoHashTable.Add(elementNams[i], xmlCurrentNode.InnerText);
                        else
                        {
                            infoHashTable.Add(elementNams[i], "0");
                            notFoundDataList.Add(elementNams[i]);
                        }
                    }
                    if (notFoundDataList.Count > 0)
                        for (int i = 0; i < notFoundDataList.Count; i++)
                            AppendElementValues(notFoundDataList[i], "0", xmlName);
                }
                catch (Exception ex)
                {
                    PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlReadError;
                    PromptMessageType promptMessageType = PromptMessageType.Null;
                    if (ex is XmlException)
                        promptMessageType = PromptMessageType.XmlException;
                    else if (ex is IOException)
                        promptMessageType = PromptMessageType.IOException;
                    else if (ex is NullReferenceException)
                        promptMessageType = PromptMessageType.NullReferenceException;
                    else if (ex is UnauthorizedAccessException)
                        promptMessageType = PromptMessageType.UnauthorizedAccessException;
                    else
                        promptMessageType = PromptMessageType.UnKnown;
                    ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(xmlName));
                }
                finally
                {
                    xmlDocument = null;
                }
            }
            return infoHashTable;
        }
        /// <summary>
        /// 遍历整个Xml，将读取元素名和元素的值
        /// </summary>
        /// <param name="xmlName"></param>
        /// <returns></returns>
        public static InfoHashTable ReadXmlValues(String xmlName)
        {
            InfoHashTable infoHashTable =new InfoHashTable();
            if (File.Exists(xmlName))
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(xmlName);
                    XmlNode rootNode = xmlDocument.DocumentElement;
                    TraverseXmlNode(rootNode, infoHashTable);
                    xmlDocument.Save(xmlName);
                    xmlDocument = null;
                }
                catch(Exception ex)
                {
                    PromptOccurPlace promptOccurPlace = PromptOccurPlace.XmlReadError;
                    PromptMessageType promptMessageType = PromptMessageType.Null;
                    if (ex is XmlException)
                        promptMessageType = PromptMessageType.XmlException;
                    else if (ex is IOException)
                        promptMessageType = PromptMessageType.IOException;
                    else if (ex is NullReferenceException)
                        promptMessageType = PromptMessageType.NullReferenceException;
                    else if (ex is UnauthorizedAccessException)
                        promptMessageType = PromptMessageType.UnauthorizedAccessException;
                    else if (ex is StackOverflowException)
                        promptMessageType = PromptMessageType.StackOverflowException;
                    else
                        promptMessageType = PromptMessageType.UnKnown;
                    ErrorMessage.SetErrorMessage(promptOccurPlace, promptMessageType, Path.GetFileName(xmlName));
                }
            }
            return infoHashTable;
        }
        private static void TraverseXmlNode(XmlNode rootNode, InfoHashTable infoHashTable)
        {
            if (rootNode == null)
                return;
            if (rootNode is XmlElement)
            {
                if (rootNode.HasChildNodes)
                {
                    if (rootNode.FirstChild.NodeType == XmlNodeType.Text)
                        infoHashTable.Add(rootNode.Name, rootNode.FirstChild.Value);
                    else
                    {
                        infoHashTable.Add(rootNode.Name, null);
                        TraverseXmlNode(rootNode.FirstChild, infoHashTable);
                        infoHashTable.Add("End", null);
                    }
                }
                if (rootNode.NextSibling != null)
                    TraverseXmlNode(rootNode.NextSibling, infoHashTable);
            }
        }
    }
}
