using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace BHair.Business
{
    public class XMLHelper
    {
        public static string strGetConnectString()
        {
            string strLocalAdd = ".\\config.xml";
            string strResult = "";
            if (File.Exists(strLocalAdd))
            {
                try
                {
                    XmlDocument xmlCon = new XmlDocument();
                    xmlCon.Load(strLocalAdd);
                    XmlNode xnCon = xmlCon.SelectSingleNode("Config");
                    strResult = xnCon.SelectSingleNode("LinkString").InnerText;
                }
                catch
                {
                    strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\员工内购数据库.accdb";
                }
            }
            else
            {
                strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\员工内购数据库.accdb";
            }
            return strResult;
        }

        public static string strGetTempConnectString()
        {
            string strLocalAdd = ".\\config.xml";
            string strResult = "";
            if (File.Exists(strLocalAdd))
            {
                try
                {
                    XmlDocument xmlCon = new XmlDocument();
                    xmlCon.Load(strLocalAdd);
                    XmlNode xnCon = xmlCon.SelectSingleNode("Config");
                    strResult = xnCon.SelectSingleNode("TempLinkString").InnerText;
                }
                catch
                {
                    strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\内购SQLQueue.accdb";
                }
            }
            else
            {
                strResult = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\\内购SQLQueue.accdb";
            }
            return strResult;
        }
    }
}
