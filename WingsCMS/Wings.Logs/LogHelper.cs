using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Wings.Logs
{
    public class LogHelper
    {
        private static ILog m_log;
        static LogHelper()
        {
            XmlConfigurator.ConfigureAndWatch(
                new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config"));
        }
        public static void WriteLog(string message, LogLevel level)
        {
            m_log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            switch (level)
            {
                case LogLevel.FATAL:
                    m_log = LogManager.GetLogger("Fatal");
                    m_log.Fatal(message);
                    break;
                case LogLevel.ERROR:
                    m_log = LogManager.GetLogger("Error");
                    m_log.Error(message);
                    break;
                case LogLevel.WARN:
                    m_log = LogManager.GetLogger("Warn");
                    m_log.Warn(message);
                    break;
                case LogLevel.INFO:
                    m_log = LogManager.GetLogger("Info");
                    m_log.Info(message);
                    break;
                default:
                    m_log = LogManager.GetLogger("Debug");
                    m_log.Debug(message);
                    break;
            }
        }
    }
    public enum LogLevel
    {
        FATAL,
        ERROR,
        WARN,
        INFO,
        DEBUG,
    }


    ///// <summary>
    ///// 日志辅助类
    ///// </summary>
    //public class LogHelper
    //{
    //    private static ILog log;
    //    private static LogHelper logHelper = null;
    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <returns></returns>
    //    public static ILog GetInstance()
    //    {
    //        logHelper = new LogHelper(null);

    //        return log;
    //    }
    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <param name="configPath"></param>
    //    /// <returns></returns>
    //    public static ILog GetInstance(string configPath)
    //    {
    //        logHelper = new LogHelper(configPath);

    //        return log;
    //    }
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="configPath"></param>
    //    private LogHelper(string configPath)
    //    {
    //        if (!string.IsNullOrEmpty(configPath))
    //        {
    //            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(configPath));
    //        }
    //        else
    //        {
    //            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //        }
    //    }

    //}
}
