using System;
using System.ComponentModel;
using System.Linq;

namespace Lantern.Extensions
{
    /// <summary>
    /// 枚举辅助类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 转成整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        ///  将一个或多个枚举常数的名称或数字值的字符串表示转换成等效的枚举对象
        /// </summary>
        /// <typeparam name="T">泛型枚举</typeparam>
        /// <param name="value">枚举常数的名称或数字值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(T);
            }
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="value">枚举</param>
        /// <returns>返回枚举的描述</returns>
        public static string GetDescription(this Enum value)
        {
            var memberInfo = value.GetType().GetMember(value.ToString()).FirstOrDefault();   //获取成员
            if (memberInfo != null)
            {
                //获取描述特性
                var attr = memberInfo.GetAttribute<DescriptionAttribute>();
                if (attr != null)
                {
                    return attr.Description; //返回当前描述
                }
            }
            return value.ToString();
        }
    }
}