using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;
using System.Web;

namespace Wings.Common
{
    /// <summary>
    /// Url输入管理类
    /// </summary>
    public class Url
    {
        /// <summary>
        /// 获取Url参数值
        /// </summary>
        /// <param name="paramKey">参数名</param>
        /// <returns></returns>
        public static string ParamValue(string paramKey)
        {
            if (System.Web.HttpContext.Current.Request[paramKey] != null)
            {
                string paramValue = System.Web.HttpContext.Current.Request[paramKey].ToString();
                if (paramValue != null)
                {
                    return UrlDecode(FilterParam(paramValue)).Trim();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Url参数值,并转换成int型，转换失败返回-1
        /// </summary>
        /// <param name="paramKey">参数名</param>
        /// <returns></returns>
        public static int ParamValueOfInt(string paramKey)
        {
            int result = -1;
            string temp = ParamValue(paramKey).Trim();
            if (!int.TryParse(temp, out result))
            {
                result = -1;
            }
            return result;
        }

        public static string ParamValue(string paramKey, System.Web.HttpContext context)
        {
            if (context.Request[paramKey] != null)
            {
                string paramValue = context.Request[paramKey].ToString();
                if (paramValue != null)
                {
                    return FilterParam(paramValue).Trim();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramKey"></param>
        /// <param name="context"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ParamValue(string paramKey, System.Web.HttpContext context, int len)
        {
            if (context.Request[paramKey] != null)
            {
                string paramValue = context.Request[paramKey].ToString();
                if (paramValue != null)
                {
                    string temp = string.Empty;
                    temp = FilterParam(paramValue).Trim();
                    if (len <= temp.Length)
                    {
                        temp = temp.Substring(0, len);
                    }
                    return temp;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取Url参数值,并转换成int型，转换失败返回-1
        /// </summary>
        /// <param name="paramKey">参数名</param>
        /// <returns></returns>
        public static int ParamValueOfInt(string paramKey, System.Web.HttpContext context)
        {
            int result = -1;
            string temp = ParamValue(paramKey, context);
            if (!int.TryParse(temp, out result))
            {
                result = -1;
            }
            return result;
        }

        /// <summary>
        /// 过滤传入值，防止sql注入
        /// </summary>
        /// <param name="param">待过滤内容</param>
        /// <returns></returns>
        public static string FilterParam(string param)
        {
            string result = param;
            string filter = "'|'',--|, @|,declare|";
            string[] words = filter.Split(',');
            foreach (var each in words)
            {
                string[] kv = each.Split('|');
                string k = kv[0];
                string v = "";
                if (kv.Length > 1)
                {
                    v = kv[1];
                }
                result = result.Replace(k, v);
            }
            return result;
        }
        /// <summary>
        /// 获取当前Url编码后的地址
        /// </summary>
        public static string Path
        {
            get
            {
                return System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }

        /// <summary>
        /// 查找游戏XML节点值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnString(string id, string name)
        {
            DESEncrypt Encrypt = new DESEncrypt();
            string XMLPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "XML/ServerAPP.xml";
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(XMLPath))
            {
                xmlDoc.Load(XMLPath);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("ServerAPP").ChildNodes;//获取ServerAPP节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型   
                    if (xe.GetAttribute("F" + Encrypt.Encrypt("ID", null)) == Encrypt.Encrypt(id, null))
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点     
                        foreach (XmlNode xn1 in nls)//遍历     
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型     
                            if (xe2.Name == "F" + Encrypt.Encrypt(name, null))
                            {
                                return xe2.InnerText;
                            }
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 查找游戏XML节点值
        /// </summary>
        /// <param name="area">大区ID</param>
        /// <param name="ser">服务器ID[-1表示查询大区连接]</param>
        /// <param name="name">节点名称</param>
        /// <returns></returns>
        public static string GetConnString(string area, string ser, string name)
        {
            if (ser != "-1")
            {
                DESEncrypt Encrypt = new DESEncrypt();
                string XMLPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "XML/ServerAPP.xml";
                XmlDocument xmlDoc = new XmlDocument();
                if (File.Exists(XMLPath))
                {
                    xmlDoc.Load(XMLPath);
                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("ServerAPP").ChildNodes;//获取ServerAPP节点的所有子节点
                    foreach (XmlNode xn in nodeList)//遍历所有子节点
                    {
                        XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型   
                        if (xe.GetAttribute("F" + Encrypt.Encrypt("ID", null)) == Encrypt.Encrypt(area, null))
                        {
                            XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点     
                            foreach (XmlNode xn1 in nls)//遍历     
                            {
                                XmlElement xe2 = (XmlElement)xn1;//转换类型     
                                if (xe2.Name == "Servers")
                                {
                                    XmlNodeList subnodeList = xe.SelectSingleNode("Servers").ChildNodes;//获取Servers节点的所有子节点
                                    foreach (XmlNode subxn in subnodeList)//遍历所有子节点
                                    {
                                        XmlElement subxe = (XmlElement)subxn;//将子节点类型转换为XmlElement类型   
                                        if (subxe.GetAttribute("F" + Encrypt.Encrypt("ID", null)) == Encrypt.Encrypt(ser, null))
                                        {
                                            XmlNodeList subnls = subxe.ChildNodes;//继续获取xe子节点的所有子节点     
                                            foreach (XmlNode subxn1 in subnls)//遍历     
                                            {
                                                XmlElement subxe2 = (XmlElement)subxn1;//转换类型    
                                                if (subxe2.Name == "F" + Encrypt.Encrypt(name, null))
                                                {
                                                    return subxe2.InnerText;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return "";
            }
            else
                return GetConnString(area, name);
        }

        /// <summary>
        /// 查找通行证XML节点值
        /// </summary>
        /// <param name="id">服务器ID</param>
        /// <param name="valid">节点名</param>
        /// <returns></returns>
        public static string GetPassConnString(string id, string name)
        {
            DESEncrypt Encrypt = new DESEncrypt();
            string XMLPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "XML/PassConnAPP.xml";
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(XMLPath))
            {
                xmlDoc.Load(XMLPath);
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("PassConnAPP").ChildNodes;//获取ServerAPP节点的所有子节点
                foreach (XmlNode xn in nodeList)//遍历所有子节点
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型   
                    if (xe.GetAttribute("F" + Encrypt.Encrypt("ID", null)) == Encrypt.Encrypt(id, null))
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点     
                        foreach (XmlNode xn1 in nls)//遍历     
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型     
                            if (xe2.Name == "F" + Encrypt.Encrypt(name, null))
                            {
                                return xe2.InnerText;
                            }
                        }
                    }
                }
            }
            return "";
        }
        /// <summary>
        ///  编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }

        #region 获取客户端ip地址
        /// <summary> 
        /// 获取客户端ip地址 
        /// </summary> 
        public static string ClientIPAddress
        {
            get { return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; }
        }
        #endregion
    }
}
