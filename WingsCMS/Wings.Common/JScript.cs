using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Common
{
    /// <summary>
    /// Javascript管理类
    /// </summary>
    public class JScript
    {
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="msg">消息内容</param>
        public static void Alert(string msg)
        {
            Excute(string.Format("alert(\"{0}\");", msg));
        }
        public static void Alert(string msg, string action)
        {
            Excute(string.Format("alert(\"{0}\");{1}", msg, action));
        }
        /// <summary>
        /// 执行脚本
        /// </summary>
        /// <param name="cmd">命令</param>
        public static void Excute(string cmd)
        {
            System.Web.HttpContext.Current.Response.Write(string.Format("<script>{0}</script>", cmd));
        }
    }
}
