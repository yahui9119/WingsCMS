using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wings.Framework.Log
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class Log : ILog
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Wings.Logger");

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

        public   void Debug(object message)
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
                log.Debug(message,exception);
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
                log.Error(message,exception);
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
                log.Fatal(message,exception);
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
                log.Info(message,exception);
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
                log.Info(message,exception);
            }
        }
    }
}
