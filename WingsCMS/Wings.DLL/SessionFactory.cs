using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace Wings.DLL
{
    /// <summary>
    /// Session的创建类
    /// </summary>
    public sealed class SessionFactory
    {
        #region 私有变量
        //保存所有Sessions,一个数据库对应一个
        private Dictionary<string, ISessionFactory> dicSessionFactorys = new Dictionary<string, ISessionFactory>(StringComparer.InvariantCultureIgnoreCase);
        //保存所有Configurations, 一个数据库对应一个
        private Dictionary<string, Configuration> dicConfigurations = new Dictionary<string, Configuration>(StringComparer.InvariantCultureIgnoreCase);
        //保存所有Connection, 一个数据库对应一个
        private Dictionary<string, string> dicConnections = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        //保存所有Session
        [ThreadStatic]
        private Dictionary<string, ISession> dicSessions = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        SessionFactory()
        {
        }
        #endregion

        #region 嵌套类
        class Nested
        {
            static Nested()
            {
            }
            internal static readonly SessionFactory instance = new SessionFactory();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 唯一实例
        /// </summary>
        public static SessionFactory Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        #endregion

        #region 实现公有方法
        /// <summary>
        /// 通过 NHibernate 的配置文件(hibernate.cfg.xml)读取 NHibernate 配置信息。
        /// 该配置文件中不包含程序集名称，通过 cfg.AddAssembly(assemblyName); 语句来添加。
        /// 一个数据库就缓存了一个session
        /// </summary>
        /// <param name="assemblyName">配置映射类的程序集名称</param>
        /// <param name="nhibernateConfigName">NHibernate 的配置文件名称</param>
        /// <param name="connectionString">数据路字符串连接</param>
        /// <returns>ISession</returns>
        public ISession OpenSession(string assemblyName, string nhibernateConfigName, string connectionString)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(nhibernateConfigName))
                {
                    return null;
                }
                ISession session = GetSessionByName(assemblyName);
                if (session == null || (!dicConnections.ContainsKey(assemblyName) || dicConnections[assemblyName] != connectionString))
                {
                    Configuration cfg = GetConfiguration(assemblyName, nhibernateConfigName, connectionString);
                    ISessionFactory sessionnFactory = GetSessionFactory(assemblyName, cfg, connectionString);
                    session = sessionnFactory.OpenSession();
                    SaveSeesionByName(assemblyName, session);
                    dicConnections[assemblyName] = connectionString;
                }
                return session;
            }
            catch (HibernateConfigException ex)
            {
                //SysExceptionLog.InputLog(ex, typeof(SessionFactory), Url.ClientIPAddress, Identity.Current.Account);
                return null;
            }
        }

        public ISessionFactory GetSessionFactory(string assemblyName, string nhibernateConfigName, string connectionString)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(nhibernateConfigName))
                {
                    return null;
                }
                ISessionFactory sessionnFactory = null;
                if ((!dicConnections.ContainsKey(assemblyName) || dicConnections[assemblyName] != connectionString))
                {
                    Configuration cfg = GetConfiguration(assemblyName, nhibernateConfigName, connectionString);
                    sessionnFactory = GetSessionFactory(assemblyName, cfg, connectionString);
                }
                return sessionnFactory;
            }
            catch (HibernateConfigException ex)
            {
                //SysExceptionLog.InputLog(ex, typeof(SessionFactory), Url.ClientIPAddress, Identity.Current.Account);
                return null;
            }
        }

        /// <summary>
        /// 获得 Configuration 对象
        /// </summary>
        /// <param name="assemblyName">配置映射类的程序集名称</param>
        /// <param name="nhibernateConfigName">NHibernate 的配置文件名称</param>
        /// <param name="connectionString">数据路字符串连接</param>
        /// <returns>Configuration 对象</returns>
        public Configuration GetConfiguration(string assemblyName, string nhibernateConfigName, string connectionString)
        {
            Configuration cfg = null;
            try
            {
                //锁定 dicConfigurations 字典
                lock (dicConfigurations)
                {
                    if (!dicConfigurations.ContainsKey(assemblyName) || (!dicConnections.ContainsKey(assemblyName) || dicConnections[assemblyName] != connectionString))
                    {
                        //附加在程序集中
                        cfg = new Configuration().Configure(Assembly.GetExecutingAssembly(), nhibernateConfigName);
                        cfg.AddAssembly(assemblyName);
                        Dictionary<string, string> properties = new Dictionary<string, string>();
                        properties.Add(NHibernate.Cfg.Environment.ConnectionString, connectionString);
                        cfg.AddProperties(properties);
                        dicConfigurations[assemblyName] = cfg;
                    }
                    else
                    {
                        cfg = dicConfigurations[assemblyName];
                    }
                }
            }
            catch (HibernateConfigException ex)
            {
                //SysExceptionLog.InputLog(ex, typeof(SessionFactory), Url.ClientIPAddress, Identity.Current.Account);
                return null;
            }
            return cfg;
        }
        #endregion

        #region 实现私有方法
        /// <summary>
        /// 通过程序集名获得一个 ISessionFactory 对象
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        private ISessionFactory GetSessionFactory(string assemblyName, Configuration cfg, string connectionStr)
        {
            ISessionFactory sessionnFactory = null;
            try
            {
                lock (dicSessionFactorys)
                {
                    if (!dicSessionFactorys.ContainsKey(assemblyName) || (!dicConnections.ContainsKey(assemblyName) || dicConnections[assemblyName] != connectionStr))
                    {
                        sessionnFactory = cfg.BuildSessionFactory();
                        dicSessionFactorys[assemblyName] = sessionnFactory;
                    }
                    else
                    {
                        sessionnFactory = dicSessionFactorys[assemblyName];
                    }
                }
            }
            catch (HibernateConfigException ex)
            {
                //SysExceptionLog.InputLog(ex, typeof(SessionFactory), Url.ClientIPAddress, Identity.Current.Account);
                return null;
            }
            return sessionnFactory;
        }

        /// <summary>
        /// 通过名称获得Session  保存Session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ISession GetSessionByName(string name)
        {
            ///延迟初始化
            if (dicSessions == null)
            {
                dicSessions = new Dictionary<string, ISession>(StringComparer.InvariantCultureIgnoreCase);
            }
            ISession session = null;
            if (dicSessions.ContainsKey(name))
            {
                session = dicSessions[name];
                if (session != null)
                {
                    if (!session.IsConnected)
                        session.Reconnect();
                    session.Clear();
                }
            }
            return session;
        }

        /// <summary>
        /// 通过名称保存Session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SaveSeesionByName(string name, ISession value)
        {
            if (value.IsConnected)
            {
                value.Disconnect();
            }
            dicSessions[name] = value;
        }

        /// <summary>
        /// 关闭Session
        /// </summary>
        /// <param name="name">key</param>
        public void CloseSession(string name)
        {
            dicSessions[name].Close();
            dicSessions.Remove(name);
        }

        #endregion
    }
}
