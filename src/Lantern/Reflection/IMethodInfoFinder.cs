using System;
using System.Reflection;

namespace Lantern.Reflection
{
    /// <summary>
    /// 定义方法信息查找器
    /// </summary>
    public interface IMethodInfoFinder
    {
        /// <summary>
        /// 查找指定条件的方法信息
        /// </summary>
        /// <param name="type">控制器类型</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        MethodInfo[] Find(Type type, Func<MethodInfo, bool> predicate);

        /// <summary>
        /// 从指定类型查找方法信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        MethodInfo[] FindAll(Type type);
    }
}