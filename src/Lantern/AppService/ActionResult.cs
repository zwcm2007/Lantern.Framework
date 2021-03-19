using System;

namespace Lantern.AppService
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class ActionResult : ActionResult<object>
    {
        public ActionResult(ActResultType resultType = ActResultType.NoChanged, string message = null, object data = null)
           : base(resultType, message, data)
        {
        }
    }

    /// <summary>
    /// 泛型操作结果
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class ActionResult<TData> : HhResult<ActResultType, TData>
    {
        public ActionResult(ActResultType resultType = ActResultType.NoChanged, string message = null, TData data = default(TData))
            : base(resultType, message, data)
        {
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        //public string ExceptionMessage { get; set; }

        /// <summary>
        /// 转成字符串信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Message}\r\n{Exception?.Message}";
        }
    }
}