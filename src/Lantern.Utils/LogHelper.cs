using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

namespace Lantern.Utils
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class LogHelper
    {
        private static ILog logInfo;

        private static ILog logError;

        private static ILog logDebug;

        static LogHelper()
        {
            ILoggerRepository repository = LogManager.CreateRepository("LanternRepository");

            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));

            logInfo = LogManager.GetLogger(repository.Name, "loginfo");

            logError = LogManager.GetLogger(repository.Name, "logerror");

            logDebug = LogManager.GetLogger(repository.Name, "logdebug");
        }

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="ex">异常</param>
        public static void Info(string mesage, Exception ex = null)
        {
            logInfo.Info(mesage, ex);

            if (logInfo.IsInfoEnabled)
            {
                logInfo.Info(mesage, ex);
            }
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="ex">异常</param>
        public static void Error(string message, Exception ex = null)
        {
            if (logError.IsErrorEnabled)
            {
                logError.Error(message, ex);
            }
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="ex">异常</param>
        public static void Debug(string message, Exception ex = null)
        {
            if (logDebug.IsDebugEnabled)
            {
                logDebug.Debug(message, ex);
            }
        }

        /// <summary>
        /// 美化错误信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误信息</returns>
        //private static string BeautyErrorMsg(Exception ex)
        //{
        //    string errorMsg = $"【异常类型】:{ex.GetType().Name}\r\n【异常信息】:{ex.Message}\r\n【内部异常】:{ex.InnerException}\r\n【堆栈调用】:{ ex.StackTrace}";

        //    return errorMsg;
        //}
    }
}