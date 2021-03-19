using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Lantern.Extensions
{
    /// <summary>
    /// 键值对集合（NameValueCollection）扩展
    /// </summary>
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// 将键值对集合转换成字典
        /// </summary>
        /// <param name="source">键值对集合</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            if (source != null)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string key in source.AllKeys)
                {
                    dict.Add(key, source[key]);
                }
                return dict;
            }
            return null;
        }

        /// <summary>
        /// 将键值对集合转换成查询字符串
        /// </summary>
        /// <param name="source">键值对集合</param>
        /// <param name="valueFunc">值操作</param>
        /// <returns></returns>
        public static string ToQueryString(this NameValueCollection source)
        {
            if (source != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string key in source.AllKeys)
                {
                    sb.Append($"{key}={source[key]}&");
                }
                sb.TrimEnd("&");
                return sb.ToString();
            }
            return string.Empty;
        }
    }
}