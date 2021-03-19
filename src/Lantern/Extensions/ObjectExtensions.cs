using System;
using System.Collections.Generic;
using System.Text;

namespace Lantern.Extensions
{
    /// <summary>
    /// Object扩展类
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 将指定对象的值转换为 16 位带符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short ToInt16(this object value, short defaultVal = 0)
        {
            if (value == null || value == DBNull.Value || value.ToString().IsNullOrWhiteSpace())
            {
                return defaultVal;
            }

            return Convert.ToInt16(value);
        }

        /// <summary>
        /// 将指定对象的值转换为 32 位带符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt32(this object value, short defaultVal = 0)
        {
            if (value == null || value == DBNull.Value || value.ToString().IsNullOrWhiteSpace())
            {
                return defaultVal;
            }

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 将指定对象转换为时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(this object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// 将指定对象转换为时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return new DateTime(1999, 1, 1, 0, 0, 0);
            }

            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// 将指定对象的值转换为 8 位无符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this object value, byte defaultVal = 0)
        {
            if (value == null || value == DBNull.Value)
            {
                return defaultVal;
            }
            return Convert.ToByte(value);
        }

        /// <summary>
        /// 将指定对象转成Guid类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this object value)
        {
            if (value is Guid)
            {
                return (Guid)value;
            }

            return Guid.Empty;
        }

        /// <summary>
        /// 将指定对象转成Boolean类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(this object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }

        public static string Join<T>(this List<T> source, char splitChar = ',')
        {
            StringBuilder sb = new StringBuilder();
            source.ForEach((value) =>
            {
                if (sb.Length > 0) sb.Append(splitChar);
                if (typeof(T) == typeof(string) || typeof(T) == typeof(Guid) ||
                   typeof(T) == typeof(bool))
                {
                    sb.Append($"'{value}'");
                }
                else
                {
                    sb.Append($"{value}");
                }
            });

            return sb.ToString();
        }
    }
}