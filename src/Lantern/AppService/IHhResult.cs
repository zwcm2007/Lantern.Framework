using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lantern.AppService
{
    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IHhResult<TResultType> : IHhResult<TResultType, object>
    {
    }

    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="TResultType"></typeparam>
    /// <typeparam name="TData"></typeparam>
    public interface IHhResult<TResultType, TData>
    {
        /// <summary>
        /// 获取或设置结果类型
        /// </summary>
        TResultType ResultType { get; set; }

        /// <summary>
        /// 获取或设置 结果数据
        /// </summary>
        TData Data { get; set; }

        /// <summary>
        /// 获取或设置返回消息
        /// </summary>
        string Message { get; set; }
    }

}