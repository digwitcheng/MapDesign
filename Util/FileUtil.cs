using AGV_V1._0.NLog;
using AGV_V1._0.Util;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace AGV_V1._0.Algorithm
{
    class FileUtil
    {
        public static XmlDocument xmlfile;

        /// <summary>
        /// 初始化mapXML配置文件
        /// </summary>
        public static void LoadMapXml(string pathMap)
        {
            if (!File.Exists(pathMap))
            {
                throw new FileNotFoundException("mapXml");
            }
            xmlfile = new XmlDocument();
            xmlfile.Load(pathMap);
            //XML2.0:获取地图的格子数
            XmlNode map_w = xmlfile.SelectSingleNode("config/Map/Widthnum");
            XmlNode map_h = xmlfile.SelectSingleNode("config/Map/Heightnum");

            ConstDefine.g_WidthNum = Convert.ToInt32(map_w.InnerText);
            ConstDefine.g_HeightNum = Convert.ToInt32(map_h.InnerText);
            Logs.Info("load map success");
        }

        public static void SaveDesignedMap(ElecMap Elc)
        {
            SaveFileDialog sfd = new SaveFileDialog(); 
            sfd.Title = "保存地图";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "文件| *.xml";
            sfd.FileName = "ElcMap";
            sfd.ShowDialog();

            string path = sfd.FileName;
            if (path == "")
            {
                return;
            }
            
                CreateXmlFile(Elc,path);


          }

        private static void CreateXmlFile(ElecMap elc,string path)
        {
           
                XmlDocument xmlDoc = new XmlDocument();
                //创建Xml声明部分，即<?xml version="1.0" encoding="utf-8" ?>  
                XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(declaration);
                //创建根节点  
                XmlNode configRoot = xmlDoc.CreateElement("config");
            XmlNode mapRoot = xmlDoc.CreateElement("Map");
            configRoot.AppendChild(mapRoot);
            XmlNode gridRoot = xmlDoc.CreateElement("Grid");
            configRoot.AppendChild(gridRoot);

            xmlDoc.AppendChild(configRoot);
                CreateNode(xmlDoc, mapRoot, "Heightnum", elc.HeightNum + "",null);
                CreateNode(xmlDoc, mapRoot, "Widthnum", elc.WidthNum + "",null);
                
                for (int i = 0; i < elc.HeightNum; i++)
                {
                    for (int j = 0; j < elc.WidthNum; j++)
                    {

                    char[] dir = new char[4]{'0','0','0','0'};
                    if( elc.mapnode[i, j].UpDifficulty < MapNode.UNABLE_PASS)
                    {
                        dir[0] = '1';
                    }
                    if (elc.mapnode[i, j].DownDifficulty < MapNode.UNABLE_PASS)
                    {
                        dir[1] = '1';
                    }
                    if (elc.mapnode[i, j].LeftDifficulty < MapNode.UNABLE_PASS)
                    {
                        dir[2] = '1';
                    }
                    if (elc.mapnode[i, j].RightDifficulty < MapNode.UNABLE_PASS)
                    {
                        dir[3] = '1';
                    }
                    string direction ="0000";
                    if (elc.mapnode[i, j].IsAbleCross)
                    {
                        direction = new string(dir);
                    }

                    CreateNode(xmlDoc, gridRoot, "td" + i + "-" + j, elc.mapnode[i, j].Type.ToString(),direction);                       
                    }
                }
            try
            {
                //保存Xml文档  
                xmlDoc.Save(path);                
                MessageBox.Show("保存成功");
            }catch(Exception ex)
            {
                MessageBox.Show("保存失败:" + ex.ToString());
            }
        }
        /// <summary> 
        /// 创建节点 
        /// </summary> 
        /// <param name="xmldoc"></param> 
        /// <param name="parentnode"></param> 
        /// <param name="name"></param> 
        /// <param name="value"></param> 
         static void CreateNode(XmlDocument xmldoc, XmlNode parentnode, string name, string value,string attribute)
        {
            XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            if (attribute != null)
            {
                XmlAttribute xmlAttribute = xmldoc.CreateAttribute("direction");
                xmlAttribute.InnerText = attribute;
                node.Attributes.Append(xmlAttribute);
            }            
            parentnode.AppendChild(node);            

        }
        internal static string  LoadTemplateMap()
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Title = "保存地图";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "文件| *.xml";
            sfd.ShowDialog();
            string path = sfd.FileName;
            return path;

        }
   
    }
}
