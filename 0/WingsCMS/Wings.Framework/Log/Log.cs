using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public sealed class Log : ILog
    {
        private readonly static Log instance = new Log();
        private readonly static Log operainstance = new Log("Wings.Opera.Logger");
        public static Log Instance
        {
            get
            {
                return instance;
            }
        }
        public static Log OperaInstance
        {
            get {
                return operainstance;
            }
        }
        static Log() { }
        public Log() 
        {

        }
        public Log(string action) {
            log = log4net.LogManager.GetLogger(action);
        }
        private static log4net.ILog log = log4net.LogManager.GetLogger("Wings.Logger");

        public bool IsDebugEnabled
        {
            get { return log.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return log.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return log.IsWarnEnabled; }
        }

        public void Debug(object message)
        {
            if (IsDebugEnabled)
            {
                log.Debug(message);
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (IsDebugEnabled)
            {
                log.Debug(message, exception);
            }
        }

        public void Error(object message)
        {
            if (IsErrorEnabled)
            {
                log.Error(message);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                log.Error(message, exception);
            }
        }

        public void Fatal(object message)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(message);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (IsFatalEnabled)
            {
                log.Fatal(message, exception);
            }
        }

        public void Info(object message)
        {
            if (IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        public void Info(object message, Exception exception)
        {
            if (IsInfoEnabled)
            {
                log.Info(message, exception);
            }
        }

        public void Warn(object message)
        {
            if (IsWarnEnabled)
            {
                log.Info(message);
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (IsWarnEnabled)
            {
                log.Info(message, exception);
            }
        }
        /// <summary>
        /// 用户操作日志记录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="operaname"></param>
        /// <param name="IsSuccess"></param>
        /// <param name="other"></param>
        public void OperaInfo(string account, string operaname, bool IsSuccess, object other)
        {
            if (IsInfoEnabled)
            {
                string otherinfo = Newtonsoft.Json.JsonConvert.SerializeObject(other);
                log.Info(string.Format("用户：【{0}】：操作：{1} {2} 说明：{3}", account, operaname, IsSuccess ? "成功" : "失败", otherinfo));
            }
        }
    }
}
