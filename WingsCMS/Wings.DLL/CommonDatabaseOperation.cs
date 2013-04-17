using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wings.DLL;
using Wings.Common;

namespace Wings.DLL
{
    /// <summary>
    /// 提供各个实体的类
    /// </summary>
    public class CommonDatabaseOperation<T>
    {
        #region 常量
        /// <summary>
        /// 数据路字符串连接
        /// </summary>
        private string connectionString;
        /// <summary>
        /// 配置文件名称
        /// </summary>
        //private readonly string configString;
        #endregion _Endregion;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        CommonDatabaseOperation()
        {
            connectionString = "";// new DESEncrypt().Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["SystemConnection"].ToString(), null);
        }
        #endregion

        #region 嵌套类
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly CommonDatabaseOperation<T> instance = new CommonDatabaseOperation<T>();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 唯一实例
        /// </summary>
        public static CommonDatabaseOperation<T> Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        #endregion

        #region 实现方法
        /// <summary>
        /// 获得 EntityControl 对象。
        /// 通过name 来读取。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EntityControl<T> GetEntityControl(string name)
        {
            connectionString = new DESEncrypt().Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings[name + ".Connection"].ToString(), null);
            return GetControl(name, connectionString);
        }

        /// <summary>
        /// 获得 EntityControl 对象。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connstr"></param>
        /// <returns></returns>
        public EntityControl<T> GetEntityControl(string name, string connstr)
        {
            return GetControl(name, connstr);
        }

        /// <summary>
        /// 获得 EntityControl 对象。
        /// 通过name 来读取。
        /// </summary>
        /// <param name="name">类名</param>
        /// <param name="cfgname">配置文件数据库链接</param>
        /// <param name="type">在此无用，只是为了方法重载，可用NULL代替</param>
        /// <returns></returns>
        public EntityControl<T> GetEntityControl(string name, string cfgname, string type)
        {
            connectionString = new DESEncrypt().Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings[cfgname + ".Connection"].ToString(), null);
            return GetControl(name, connectionString);
        }

        public EntityControl<T> GetControl(string name, string connstr)
        {
            EntityControl<T> entityControl = null;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(connstr))
            {
                return null;
            }
            switch (name)
            {
                //case DatabaseIdentifierConstant.DATABASE_FERRT_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_FERRT_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_FERRT_IDENTIFIER_XML, connstr);
                //    break;
                case DatabaseIdentifierConstant.DATABASE_WINGS_IDENTIFIER:
                    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_WINGS_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_WINGS_IDENTIFIER_XML, connstr);
                    break;
                //case DatabaseIdentifierConstant.DATABASE_Passport_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_Passport_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_Passport_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_DUGU_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_DUGU_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_DUGU_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_FerryLogs_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_FerryLogs_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_FerryLogs_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_Game_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_Game_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_Game_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_DuguLog_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_DuguLog_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_DuguLog_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_MySql_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_MySql_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_MySql_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_Games_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_Games_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_Games_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_GamesLogs_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_GamesLogs_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_GamesLogs_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_Passports_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_Passports_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_Passports_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_SAME_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_SAME_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_SAME_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_SHOP_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_SHOP_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_SHOP_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_JIUREN_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_JIUREN_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_JIUREN_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_MoShen_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_MoShen_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_MoShen_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_DUGUExt_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_DUGUExt_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_DUGUExt_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_ADSYS_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_ADSYS_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_ADSYS_IDENTIFIER_XML, connstr);
                //    break;
                //case DatabaseIdentifierConstant.DATABASE_Handlers_IDENTIFIER:
                //    entityControl = new EntityControl<T>(DatabaseIdentifierConstant.DATABASE_Handlers_IDENTIFIER, DatabaseIdentifierConstant.DATABASE_Handlers_IDENTIFIER_XML, connstr);
                //    break;

                default:
                    break;
            }
            return entityControl;
        }
        #endregion

    }
}
