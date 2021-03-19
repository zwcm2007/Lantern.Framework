using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lantern.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEquatable{T}"/>
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 根据第三方条件是否为真来决定是否执行指定条件的查询
        /// </summary>
        /// <param name="source"> 要查询的源 </param>
        /// <param name="predicate"> 查询条件 </param>
        /// <param name="condition"> 第三方条件 </param>
        /// <typeparam name="T"> 动态类型 </typeparam>
        /// <returns> 查询的结果 </returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            //source.CheckNotNull("source");
            //predicate.CheckNotNull("predicate");

            return condition ? source.Where(predicate) : source;
        }
    }
}