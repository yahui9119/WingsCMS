using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Wings.Common.Cache;

namespace Wings.Common
{
    public class TConvert
    {
        public TConvert()
        {
        }
        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable ToDataTable(IList list)
        {
            try
            {
                DataTable result = new DataTable();
                if (list != null && list.Count > 0)
                {
                    PropertyInfo[] propertys = list[0].GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        ArrayList tempList = new ArrayList();
                        foreach (PropertyInfo pi in propertys)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        object[] array = tempList.ToArray();
                        result.LoadDataRow(array, true);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


        /// <summary>
        /// DataTable转Json字符串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTable2Json(DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return "[]";
            StringBuilder jsonBuilder = new StringBuilder();
            // jsonBuilder.Append("{");    
            //jsonBuilder.Append(dt.TableName.ToString());   
            jsonBuilder.Append("[");//转换成多个model的形式   
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            //  jsonBuilder.Append("}");   
            return jsonBuilder.ToString();
        }

        /// <summary>
        /// Json字符串转DataTable
        /// </summary>
        /// <param name="jsons"></param>
        /// <returns></returns>
        public static DataTable Json2DataTable(object[] objects)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("state");
            for (int i = 0; i < objects.Count(); i++)
            {
                Dictionary<string, object> json = (Dictionary<string, object>)(objects[i]);
                object id;
                object state;
                json.TryGetValue("id", out id);
                json.TryGetValue("state", out state);
                DataRow dr = dt.NewRow();
                dr["id"] = id;
                dr["state"] = state;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 序列化DataTable
        /// </summary>
        /// <param name="Dt">要序列化的DataTable</param>
        /// <returns></returns>
        public static string SerializeDataTable(DataTable Dt)
        {
            // 序列化DataTable
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            serializer.Serialize(writer, Dt);
            writer.Close();
            return sb.ToString();
        }

        /// <summary>
        /// 反序列化DataTable
        /// </summary>
        /// <param name="Xml">序列化字符串</param>
        /// <returns></returns>
        public static DataTable DeserializeDataTable(string Xml)
        {
            StringReader strReader = new StringReader(Xml);
            XmlReader xmlReader = XmlReader.Create(strReader);
            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            DataTable dt = serializer.Deserialize(xmlReader) as DataTable;
            return dt;
        }

        //public static void SetPerm(DataTable dt, string uid)
        //{
        //    WebCache webcache = WebCache.GetCacheService(true);
        //    webcache.Add<string>("Perms" + uid, JsonConvert.SerializeObject(dt),CachePriority.High, DateTime.Now.AddMinutes(20));
        //}

        //public static DataTable GetPerm(string uid)
        //{
        //    WebCache webcache = WebCache.GetCacheService(true);
        //    if (webcache.Contains("Perms" + uid))
        //    {
        //        string permStr = webcache.Get<string>("Perms" + uid);
        //        if (!string.IsNullOrEmpty(permStr) || permStr != "")
        //            return (DataTable)JsonConvert.DeserializeObject(permStr, typeof(DataTable));
        //        else
        //            return null;
        //    }
        //    return null;
        //}
    }
}
