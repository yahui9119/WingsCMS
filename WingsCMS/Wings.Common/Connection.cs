using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Wings.Common.Cache;
using System.IO;

namespace Wings.Common
{
    public class Connection
    {
        public Connection()
        {
        }

        /// <summary>
        /// 获取数据库连接串
        /// </summary>
        /// <param name="serid">服务器ID</param>
        /// <returns></returns>
        public static string GetConnStr(string serid)
        {
            WebCache webcache = WebCache.GetCacheService(true);
            string connStr = webcache.Get<string>(string.Format("connStr{0}", serid));
            if (string.IsNullOrEmpty(connStr))
            {
                connStr = Url.GetConnString(serid, "connStr");
                webcache.Add<string>(string.Format("connStr{0}", serid), connStr, DateTime.Now.AddMinutes(20));
            }
            return connStr;
        }
        /// <summary>
        /// 获取数据库连接串
        /// </summary>
        /// <param name="serid">服务器ID</param>
        /// <returns></returns>
        public static void SetConnStr()
        {
            WebCache webcache = WebCache.GetCacheService(true);
            string XMLPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "XML/ServerAPP.xml";
            XmlDocument xmlDoc = new XmlDocument();
            DESEncrypt Encrypt = new DESEncrypt();
            if (File.Exists(XMLPath))
            {
                xmlDoc.Load(XMLPath);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("ServerAPP").ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    xe.GetAttribute("F" + Encrypt.Encrypt("ID", null));
                    XmlNodeList nls = xe.ChildNodes;
                    foreach (XmlNode xn1 in nls)
                    {
                        XmlElement xe2 = (XmlElement)xn1;
                        if (xe2.Name == "F" + Encrypt.Encrypt("connStr", null))
                        {
                            webcache.Add<string>(string.Format("connStr{0}", Encrypt.Decrypt(xe.GetAttribute("F" + Encrypt.Encrypt("ID", null)), null)), xe2.InnerText, DateTime.Now.AddMinutes(20));
                            continue;
                        }
                    }
                }
            }
        }
    }
}
