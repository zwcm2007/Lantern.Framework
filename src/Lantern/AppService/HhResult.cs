using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lantern.AppService
{
    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    public abstract class HhResult<TResultType> : HhResult<TResultType, object>, IHhResult<TResultType>
    {
        protected HhResult(TResultType resultType = default(TResultType), string message = null, object data = null)
            : base(resultType, message, data)
        {
        }
    }

    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public abstract class HhResult<TResultType, TData> : IHhResult<TResultType, TData>
    {
        protected HhResult(TResultType resultType = default(TResultType), string message = null, TData data = default(TData))
        {
            ResultType = resultType;
            Message = message;
            Data = data;
        }

        public TResultType ResultType { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}