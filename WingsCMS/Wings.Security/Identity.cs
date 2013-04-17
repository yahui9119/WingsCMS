using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Wings.Common;
using System.Data;
using Wings.Common.Cache;
using System.Collections;

namespace Wings.Security
{
    public class Identity
    {
        private bool m_isAuthenticated = false;
        private int m_uid = 0;
        private string m_account = null;
        private IList m_roles = null;

        public Identity()
        {
        }

        public Identity(int uid, string account, IList roles)
        {
            Identity user = new Identity();
            user.m_account = account;
            user.m_uid = uid;
            user.m_roles = roles;
            user.m_isAuthenticated = true;
            WebCache webcache = WebCache.GetCacheService(true);
            webcache.Add<Identity>("Identity" + System.Web.HttpContext.Current.User.Identity.Name, user);
        }

        public static Identity Current
        {
            get
            {
                string account = System.Web.HttpContext.Current.User.Identity.Name;
                WebCache webcache = WebCache.GetCacheService(true);
                if (webcache.Get<Identity>("Identity" + account) == null)
                    new Identity(0, System.Web.HttpContext.Current.User.Identity.Name, null);
                return webcache.Get<Identity>("Identity" + account);
            }
        }

        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool IsAuthenticated { get { return m_isAuthenticated; } }
        /// <summary>
        /// 获取当前用户编号
        /// </summary>
        public int UserId { get { return m_uid; } }
        /// <summary>
        /// 获取当前用户的账号
        /// </summary>
        public string Account { get { return m_account; } }
        /// <summary>
        /// 获取当前用户角色
        /// </summary>
        public IList Roles { get { return m_roles; } }
        ///// <summary>
        ///// 验证指定页面是否有指定权限
        ///// </summary>
        ///// <param name="pageID">页面标识</param>
        ///// <param name="permissionCode">权限代号</param>
        ///// <param name="type">1:true2:false3:null</param>
        ///// <returns></returns>
        //public static bool HasPermission(string uid,string pageID, int permissionCode,out int type)
        //{
        //    DataTable dt = new DataTable();
        //    //HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies["permList"];
        //    //if (Cookie != null)
        //    //    dt = (DataTable)JsonConvert.DeserializeObject(new DESEncrypt().Decrypt(Cookie.Value, null), typeof(DataTable));
        //    //else
        //    //    return false;

        //    dt = TConvert.GetPerm(uid);
        //    if (dt == null)
        //    {
        //        type = 3;
        //        return false;
        //    }
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        DataRow[] rows = dt.Select(string.Format("moduleID='{0}'", pageID));
        //        if (rows.Length > 0)
        //        {
        //            if ((int.Parse(rows[0]["controlCode"].ToString()) & permissionCode) == permissionCode)
        //            {
        //                type = 1;
        //                return true;
        //            }
        //            else
        //            {
        //                type = 2;
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            type = 2;
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        type = 2;
        //        return false;
        //    }
        //}
    }
}
