using System;

namespace HouHeng.Common.Data
{
    /// <summary>
    /// WebApi返回结果
    /// </summary>
    public class WebApiResult : WebApiResult<Object>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public WebApiResult(WebApiResultType resultType = WebApiResultType.NoChanged, string msg = null, object data = null)
            : base(resultType, msg, data)
        {
        }
    }

    /// <summary>
    /// WebApi返回结果
    /// </summary>
    public class WebApiResult<TData> : HhResult<WebApiResultType, TData>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public WebApiResult(WebApiResultType resultType = WebApiResultType.NoChanged, string msg = null, TData data = default(TData))
            : base(resultType, msg, data)
        { }

        public bool Success
        {
            get
            {
                return ResultType == WebApiResultType.Success;
            }
        }
    }
}