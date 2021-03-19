using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Lantern.Extensions
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExtensions
    {
        #region 正则表达式

        #region IsMatch(是否匹配正则表达式)

        /// <summary>
        /// 确定所指定的正则表达式在指定的输入字符串中是否找到了匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this string value, string pattern)
        {
            if (value == null)
            {
                return false;
            }
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 确定所指定的正则表达式在指定的输入字符串中找到匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="options">规则</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this string value, string pattern, RegexOptions options)
        {
            if (value == null)
            {
                return false;
            }
            return Regex.IsMatch(value, pattern, options);
        }

        #endregion IsMatch(是否匹配正则表达式)

        #endregion 正则表达式

        #region 字符串判断

        #region IsNullOrEmpty(是否空字符串)

        /// <summary>
        /// 确认指定的字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 确认指定的字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        #endregion IsNullOrEmpty(是否空字符串)

        #region IfEmpty(检查字符串是否为空)

        /// <summary>
        /// 检查字符串是否为空，若为空则返回默认值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string IfEmpty(this string value, string defaultValue)
        {
            return !value.IsNullOrEmpty() ? value : defaultValue;
        }

        #endregion IfEmpty(检查字符串是否为空)

        #region ExceptionIfNullOrEmpty(空字符串异常判断)

        /// <summary>
        /// 如果字符串为空，抛出异常<see cref="ArgumentException"/>
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="message">如果值为空，则将该消息显示</param>
        /// <param name="name">传入参数名</param>
        /// <returns></returns>
        public static string ExceptionIfNullOrEmpty(this string value, string message, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message, name);
            }
            return value;
        }

        #endregion ExceptionIfNullOrEmpty(空字符串异常判断)

        #region IsImageFile

        /// <summary>
        /// 判断指定路径是否图片文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>结果</returns>
        public static bool IsImageFile(this string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }
            byte[] filedata = File.ReadAllBytes(fileName);
            if (filedata.Length == 0)
            {
                return false;
            }
            ushort code = BitConverter.ToUInt16(filedata, 0);
            switch (code)
            {
                case 0x4D42://bmp
                case 0xD8FF://jpg
                case 0x4947://gif
                case 0x5089://png
                    return true;

                default:
                    return false;
            }
        }

        #endregion IsImageFile

        #region Contains(确定输入字符串是否包含指定字符串)

        /// <summary>
        /// 确定输入字符串是否包含指定字符串
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <param name="comparisonValue">包含字符串</param>
        /// <param name="comparisonType">区域</param>
        /// <returns></returns>
        public static bool Contains(this string inputValue, string comparisonValue, StringComparison comparisonType)
        {
            return (inputValue.IndexOf(comparisonValue, comparisonType) != -1);
        }

        /// <summary>
        /// 确定输入字符串是否包含指定字符串，且字符串不为空
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <param name="comparisonValue">指定字符串</param>
        /// <returns></returns>
        public static bool ContainsEquivalenceTo(this string inputValue, string comparisonValue)
        {
            return BothStringsAreEmpty(inputValue, comparisonValue) ||
                   StringContainsEquivalence(inputValue, comparisonValue);
        }

        /// <summary>
        /// 两个字符串是否均为空
        /// </summary>
        /// <param name="inputValue">字符串1</param>
        /// <param name="comparisonValue">字符串2</param>
        /// <returns></returns>
        private static bool BothStringsAreEmpty(string inputValue, string comparisonValue)
        {
            return (inputValue.IsNullOrWhiteSpace() && comparisonValue.IsNullOrWhiteSpace());
        }

        /// <summary>
        /// 确定输入字符串是否包含指定字符串，且两个字符串不为空
        /// </summary>
        /// <param name="inputValue">输入字符串</param>
        /// <param name="comparisonValue">指定字符串</param>
        /// <returns></returns>
        private static bool StringContainsEquivalence(string inputValue, string comparisonValue)
        {
            return ((!inputValue.IsNullOrWhiteSpace()) && inputValue.Contains(comparisonValue, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// 确定字符串是否包含所提供的值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="values">提供的值</param>
        /// <returns></returns>
        public static bool ContainsAny(this string value, params string[] values)
        {
            return value.ContainsAny(StringComparison.CurrentCulture, values);
        }

        /// <summary>
        /// 确定字符串是否包含所提供的值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="comparisonType">区域性比较</param>
        /// <param name="values">提供的值</param>
        /// <returns></returns>
        public static bool ContainsAny(this string value, StringComparison comparisonType, params string[] values)
        {
            return values.Any(v => value.IndexOf(v, comparisonType) > -1);
        }

        /// <summary>
        /// 确定字符串是否包含所有提供的值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="values">提供的值</param>
        /// <returns></returns>
        public static bool ContainsAll(this string value, params string[] values)
        {
            return value.ContainsAll(StringComparison.CurrentCulture, values);
        }

        /// <summary>
        /// 确定字符串是否包含所有提供的值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="comparisonType">区域性比较</param>
        /// <param name="values">提供的值</param>
        /// <returns></returns>
        public static bool ContainsAll(this string value, StringComparison comparisonType, params string[] values)
        {
            return values.All(v => value.IndexOf(v, comparisonType) > -1);
        }

        #endregion Contains(确定输入字符串是否包含指定字符串)

        #region IsNumeric(是否单精度浮点数)

        /// <summary>
        /// 是否单精度浮点数（Float）
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            float output;
            return float.TryParse(value, out output);
        }

        #endregion IsNumeric(是否单精度浮点数)

        #region EquivalentTo(字符串是否全等)

        /// <summary>
        /// 确定两个指定的字符串具有相同的值，参数指定区域性、大小写及比较所选用的规则
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="whateverCaseString">比较字符串</param>
        /// <param name="comparison">区域性</param>
        /// <returns></returns>
        public static bool EquivalentTo(this string value, string whateverCaseString, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return string.Equals(value, whateverCaseString, comparison);
        }

        #endregion EquivalentTo(字符串是否全等)

        #region EqualsAny(确定字符串是否与所提供的值相等)

        /// <summary>
        /// 确定字符串是否与所提供的值相等
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="comparisonType">区域性比较</param>
        /// <param name="values">提供的值</param>
        /// <returns></returns>
        public static bool EqualsAny(this string value, StringComparison comparisonType, params string[] values)
        {
            return values.Any(v => value.Equals(v, comparisonType));
        }

        #endregion EqualsAny(确定字符串是否与所提供的值相等)

        #region IsLike(通配符比较)

        /// <summary>
        /// 任何模式通配符比较
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="patterns">模式</param>
        /// <returns></returns>
        public static bool IsLikeAny(this string value, params string[] patterns)
        {
            return patterns.Any(value.IsLike);
        }

        /// <summary>
        /// 通配符比较
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="pattern">模式</param>
        /// <returns></returns>
        public static bool IsLike(this string value, string pattern)
        {
            if (value == pattern)
            {
                return true;
            }
            if (pattern[0] == '*' && pattern.Length > 1)
            {
                return value.Where((t, index) => value.Substring(index).IsLike(pattern.Substring(1))).Any();
            }
            else if (pattern[0] == '*')
            {
                return true;
            }
            else if (pattern[0] == value[0])
            {
                return value.Substring(1).IsLike(pattern.Substring(1));
            }
            return false;
        }

        #endregion IsLike(通配符比较)

        #region IsItemInEnum(检查数据是否在给定的枚举定义)

        /// <summary>
        /// 检查数据是否在给定的枚举定义
        /// </summary>
        /// <typeparam name="TEnum">泛型枚举</typeparam>
        /// <param name="value">匹配的枚举</param>
        /// <returns>匿名方法条件</returns>
        public static Func<bool> IsItemInEnum<TEnum>(this string value) where TEnum : struct
        {
            return () => string.IsNullOrEmpty(value) || !Enum.IsDefined(typeof(TEnum), value);
        }

        #endregion IsItemInEnum(检查数据是否在给定的枚举定义)

        #region IsRangeLength(判断字符串长度是否在指定范围内)

        /// <summary>
        /// 判断字符串长度是否在指定范围内
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>
        public static bool IsRangeLength(this string source, int minLength, int maxLength)
        {
            return source.Length >= minLength && source.Length <= maxLength;
        }

        #endregion IsRangeLength(判断字符串长度是否在指定范围内)

        #endregion 字符串判断

        #region 字符串操作

        #region Remove(移除字符串)

        /// <summary>
        /// 从当前字符串中移除任何指定的字符
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="removeChar">需要移除的字符</param>
        /// <returns></returns>
        public static string Remove(this string value, params char[] removeChar)
        {
            var result = value;
            if (!string.IsNullOrEmpty(result) && removeChar != null)
            {
                Array.ForEach(removeChar, c => result = result.Remove(c.ToString()));
            }
            return result;
        }

        /// <summary>
        /// 从当前字符串中移除任何指定的字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="strings">需要移除的字符串</param>
        /// <returns></returns>
        public static string Remove(this string value, params string[] strings)
        {
            return strings.Aggregate(value, (current, c) => current.Replace(c, string.Empty));
        }

        /// <summary>
        /// 从当前字符串中移除指定索引的字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="index">索引</param>
        /// <param name="isLeft">是否左侧</param>
        /// <returns></returns>
        public static string Remove(this string value, int index, bool isLeft = true)
        {
            if (value.Length <= index)
            {
                return "";
            }
            if (isLeft)
            {
                return value.Substring(index);
            }
            return value.Substring(0, value.Length - index);
        }

        /// <summary>
        /// 移除当前字符串中的所有特殊字符
        /// </summary>
        /// <param name="value">输入字符串</param>
        /// <returns>调整后的字符串</returns>
        public static string RemoveAllSpecialCharacters(this string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            foreach (var c in value.Where(Char.IsLetterOrDigit))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 去除字符串末尾指定的符号
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="defaultChar">需要去除的符号，默认：,</param>
        /// <returns></returns>
        public static string RemoveEnd(this string value, string defaultChar = ",")
        {
            if (!value.IsNullOrEmpty())
            {
                if (value.EndsWith(defaultChar))
                {
                    value = value.Substring(0, value.LastIndexOf(defaultChar, StringComparison.Ordinal));
                }
            }
            return value;
        }

        /// <summary>
        /// 指定清除标签的内容
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="tag">标签</param>
        /// <param name="options">选项</param>
        /// <returns></returns>
        public static string Remove(this string str, string tag, RegexOptions options = RegexOptions.None)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }
            return tag.IsNullOrEmpty() ? str : Regex.Replace(str, tag, "", options);
        }

        #endregion Remove(移除字符串)

        #region FormatWith(格式化填充)

        /// <summary>
        /// 将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式
        /// </summary>
        /// <param name="format">字符串格式，占位符以{n}表示</param>
        /// <param name="args">用于填充占位符的参数</param>
        /// <returns>格式化后的字符串</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            //format.CheckNotNull("format");
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        #endregion FormatWith(格式化填充)

        #region ReverseString(反转字符串)

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="value">要反转的字符串</param>
        /// <returns>反转后的字符串</returns>
        public static string ReverseString(this string value)
        {
            //value.CheckNotNull("value");
            return new string(value.Reverse().ToArray());
        }

        #endregion ReverseString(反转字符串)

        #region Split(字符串分割成数组)

        /// <summary>
        /// 以指定字符串作为分隔符将指定字符串分隔成数组
        /// </summary>
        /// <param name="value">要分割的字符串</param>
        /// <param name="strSplit">字符串类型的分隔符</param>
        /// <param name="removeEmptyEntries">是否移除数据中元素为空字符串的项</param>
        /// <returns>分割后的数据</returns>
        public static string[] Split(this string value, string strSplit, bool removeEmptyEntries = false)
        {
            return value.Split(new[] { strSplit },
                removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }

        #endregion Split(字符串分割成数组)

        #region GetTextLength(获取字符串长度)

        /// <summary>
        /// 获取字符串长度，支持汉字，每个汉字长度为2个字节
        /// </summary>
        /// <param name="value">参数字符串</param>
        /// <returns>当前字符串的长度，每个汉字长度为2个字节</returns>
        public static int GetTextLength(this string value)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            byte[] bytes = ascii.GetBytes(value);
            foreach (byte b in bytes)
            {
                if (b == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }
            return tempLen;
        }

        #endregion GetTextLength(获取字符串长度)

        #region TrimToMaxLength(切割字符串)

        /// <summary>
        /// 切割字符串，指定最大长度
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="maxLength">指定最大长度</param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string value, int maxLength)
        {
            return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
        }

        /// <summary>
        /// 切割字符串，并指定最大长度和添加后缀
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="maxLength">指定最大长度</param>
        /// <param name="suffix">后缀</param>
        /// <returns></returns>
        public static string TrimToMaxLength(this string value, int maxLength, string suffix)
        {
            return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
        }

        #endregion TrimToMaxLength(切割字符串)

        #region Truncate(截断字符串)

        /// <summary>
        /// 截断字符串，是否添加圆点
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="length">截断长度</param>
        /// <param name="userElipse">是否使用圆点</param>
        /// <returns></returns>
        public static string Truncate(this string value, int length, bool userElipse = false)
        {
            int e = userElipse ? 3 : 0;
            if (length - e <= 0)
            {
                throw new InvalidOperationException(string.Format("Length must be greater than {0}.", e));
            }
            if (value.IsNullOrEmpty() || value.Length <= length)
            {
                return value;
            }
            return value.Substring(0, length - e) + new string('.', e);
        }

        #endregion Truncate(截断字符串)

        #region PadBoth(指定字符串长度)

        /// <summary>
        /// 指定字符串长度，如果字符串长度大于指定的字符串长度，则截断字符串，若字符串长度小于指定字符串长度，则填充字符到指定字符串长度
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="width">指定字符串长度</param>
        /// <param name="padChar">填充字符</param>
        /// <param name="truncate">是否截断</param>
        /// <returns></returns>
        public static string PadBoth(this string value, int width, char padChar, bool truncate = false)
        {
            int diff = width - value.Length;
            if (diff == 0 || diff < 0 && !(truncate))
            {
                return value;
            }
            else if (diff < 0)
            {
                return value.Substring(0, width);
            }
            else
            {
                return value.PadLeft(width - diff / 2, padChar).PadRight(width, padChar);
            }
        }

        #endregion PadBoth(指定字符串长度)

        #region Ensure(确保字符串包含指定字符串)

        /// <summary>
        /// 确保字符串包含指定前缀
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static string EnsureStartsWith(this string value, string prefix)
        {
            return value.StartsWith(prefix) ? value : string.Concat(prefix, value);
        }

        /// <summary>
        /// 确保字符串包含指定后缀
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="suffix">后缀</param>
        /// <returns></returns>
        public static string EnsureEndWith(this string value, string suffix)
        {
            return value.EndsWith(suffix) ? value : string.Concat(value, suffix);
        }

        #endregion Ensure(确保字符串包含指定字符串)

        #region Repeat(重复指定字符串)

        /// <summary>
        /// 重复指定字符串，根据指定重复次数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="repeatCount">重复次数</param>
        /// <returns>重复字符串</returns>
        public static string Repeat(this string value, int repeatCount)
        {
            if (value.Length == 1)
            {
                return new string(value[0], repeatCount);
            }
            StringBuilder sb = new StringBuilder(repeatCount * value.Length);
            while (repeatCount-- > 0)
            {
                sb.Append(value);
            }
            return sb.ToString();
        }

        #endregion Repeat(重复指定字符串)

        #region ExtractNumber(提取字符串中所有数字)

        /// <summary>
        /// 提取指定字符串中所有数字
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string ExtractNumber(this string value)
        {
            return
                value.Where(Char.IsDigit).Aggregate(new StringBuilder(value.Length), (sb, c) => sb.Append(c)).ToString();
        }

        #endregion ExtractNumber(提取字符串中所有数字)

        #region ConcatWith(连接字符串)

        /// <summary>
        /// 连接两个字符串
        /// </summary>
        /// <param name="value">目标字符串</param>
        /// <param name="values">源字符串</param>
        /// <returns>连接后的字符串</returns>
        public static string ConcatWith(this string value, params string[] values)
        {
            return string.Concat(value, string.Concat(values));
        }

        #endregion ConcatWith(连接字符串)

        #region Join(连接元素)

        /// <summary>
        /// 连接字符串数组的所有元素，根据指定分隔符
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">值</param>
        /// <param name="separator">分隔符</param>
        /// <param name="obj">对象数组</param>
        /// <returns></returns>
        public static string Join<T>(this string value, string separator, T[] obj)
        {
            if (obj == null || obj.Length == 0)
            {
                return value;
            }
            if (separator == null)
            {
                separator = string.Empty;
            }
            Converter<T, string> converter = o => o.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(value);
            sb.Append(separator);
            sb.Append(string.Join(separator, Array.ConvertAll(obj, converter)));
            return sb.ToString();
        }

        /// <summary>
        /// 将字符串数组连接为字符串，如果值不为null或System.String.Empty，则将字符串数组连接
        /// </summary>
        /// <param name="values">字符串数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>字符串</returns>
        public static string JoinNotNullOrEmpty(this string[] values, string separator)
        {
            var items = values.Where(s => !string.IsNullOrEmpty(s)).ToList();
            return string.Join(separator, items.ToArray());
        }

        #endregion Join(连接元素)

        #region Get(获取范围字符串)

        /// <summary>
        /// 获取指定字符串参数之前的字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="x">指定字符串参数</param>
        /// <returns></returns>
        public static string GetBefore(this string value, string x)
        {
            var xPos = value.IndexOf(x, StringComparison.Ordinal);
            return xPos == -1 ? string.Empty : value.Substring(0, xPos);
        }

        /// <summary>
        /// 获取指定字符串参数之间的字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="x">指定左侧字符串参数</param>
        /// <param name="y">指定右侧字符串参数</param>
        /// <returns></returns>
        public static string GetBetween(this string value, string x, string y)
        {
            var xPos = value.IndexOf(x, StringComparison.Ordinal);
            var yPos = value.LastIndexOf(y, StringComparison.Ordinal);
            if (xPos == -1 || yPos == -1)
            {
                return string.Empty;
            }
            var startIndex = xPos + x.Length;
            return startIndex >= yPos ? string.Empty : value.Substring(startIndex, yPos - startIndex).Trim();
        }

        /// <summary>
        /// 获取指定字符串参数之后的字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="x">指定字符串参数</param>
        /// <returns></returns>
        public static string GetAfter(this string value, string x)
        {
            var xPos = value.IndexOf(x, StringComparison.Ordinal);
            if (xPos == -1)
            {
                return string.Empty;
            }
            var startIndex = xPos + x.Length;
            return startIndex >= value.Length ? string.Empty : value.Substring(startIndex).Trim();
        }

        /// <summary>
        /// 获取字符串指定长度左边的部分
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="leftLength">指定字符串长度</param>
        /// <returns></returns>
        public static string Left(this string value, int leftLength)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (leftLength >= value.Length)
            {
                throw new ArgumentOutOfRangeException("leftLength", leftLength,
                    "leftLength must be less than length of string");
            }
            return value.Substring(0, leftLength);
        }

        /// <summary>
        /// 获取字符串指定长度右边的部分
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="rightLength">指定字符串长度</param>
        /// <returns></returns>
        public static string Right(this string value, int rightLength)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (rightLength >= value.Length)
            {
                throw new ArgumentOutOfRangeException("rightLength", rightLength,
                    "rightLength must be less than length of string");
            }
            return value.Substring(value.Length - rightLength);
        }

        /// <summary>
        /// 获取字符串指定索引部分
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="index">指定索引</param>
        /// <returns></returns>
        public static string SubstringFrom(this string value, int index)
        {
            return index < 0 && index < value.Length ? value : value.Substring(index, value.Length - index);
        }

        #endregion Get(获取范围字符串)

        #region ReplaceAll(替换字符串指定的所有值)

        /// <summary>
        /// 替换字符串中指定的所有值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="oldValues">需要替换的值</param>
        /// <param name="replacePredicate">替换谓词</param>
        /// <example>
        /// <code>
        ///         var str = "White Red Blue Green Yellow Black Gray";
        ///         var achromaticColors = new[] {"White", "Black", "Gray"};
        ///         str = str.ReplaceAll(achromaticColors, v => "[" + v + "]");
        ///         // str == "[White] Red Blue Green Yellow [Black] [Gray]"
        /// </code>
        /// </example>
        /// <returns></returns>
        public static string ReplaceAll(this string value, IEnumerable<string> oldValues,
            Func<string, string> replacePredicate)
        {
            StringBuilder sb = new StringBuilder(value);
            foreach (var oldValue in oldValues)
            {
                var newValue = replacePredicate(oldValue);
                sb.Replace(oldValue, newValue);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换字符串中指定的所有值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="oldValues">需要替换的值</param>
        /// <param name="newValue">新值</param>
        /// <example>
        /// 	<code>
        ///         var str = "White Red Blue Green Yellow Black Gray";
        ///         var achromaticColors = new[] {"White", "Black", "Gray"};
        ///         str = str.ReplaceAll(achromaticColors, "[AchromaticColor]");
        ///         // str == "[AchromaticColor] Red Blue Green Yellow [AchromaticColor] [AchromaticColor]"
        /// 	</code>
        /// </example>
        /// <returns></returns>
        public static string ReplaceAll(this string value, IEnumerable<string> oldValues, string newValue)
        {
            StringBuilder sb = new StringBuilder(value);
            foreach (var oldValue in oldValues)
            {
                sb.Replace(oldValue, newValue);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 替换字符串中指定的所有值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="oldValues">需要替换的值</param>
        /// <param name="newValues">新的值</param>
        /// <example>
        /// 	<code>
        ///         var str = "White Red Blue Green Yellow Black Gray";
        ///         var achromaticColors = new[] {"White", "Black", "Gray"};
        ///         var exquisiteColors = new[] {"FloralWhite", "Bistre", "DavyGrey"};
        ///         str = str.ReplaceAll(achromaticColors, exquisiteColors);
        ///         // str == "FloralWhite Red Blue Green Yellow Bistre DavyGrey"
        /// 	</code>
        /// </example>
        /// <returns></returns>
        public static string ReplaceAll(this string value, IEnumerable<string> oldValues, IEnumerable<string> newValues)
        {
            StringBuilder sb = new StringBuilder(value);
            var newValueEnum = newValues.GetEnumerator();
            foreach (var oldValue in oldValues)
            {
                if (!newValueEnum.MoveNext())
                {
                    throw new ArgumentOutOfRangeException("newValues", "newValues sequence is shorter than oldValues sequence");
                }
                sb.Replace(oldValue, newValueEnum.Current);
            }
            if (newValueEnum.MoveNext())
            {
                throw new ArgumentOutOfRangeException("newValues", "newValues sequence is longer than oldValues sequence");
            }
            return sb.ToString();
        }

        #endregion ReplaceAll(替换字符串指定的所有值)

        #region ParseStringToEnum(解析字符串到枚举项)

        /// <summary>
        /// 如果存在该枚举，解析字符串到字符串枚举项，否则返回默认枚举
        /// </summary>
        /// <typeparam name="TEnum">泛型枚举</typeparam>
        /// <param name="value">需转换为枚举的字符串</param>
        /// <param name="ignorecase">是否区分大小写</param>
        /// <returns>枚举项</returns>
        /// <example>
        /// 	<code>
        /// 		public enum EnumTwo {  None, One,}
        /// 		object[] items = new object[] { "One".ParseStringToEnum《EnumTwo》(), "Two".ParseStringToEnum《EnumTwo》() };
        /// 	</code>
        /// </example>
        public static TEnum ParseStringToEnum<TEnum>(this string value, bool ignorecase = default(bool))
            where TEnum : struct
        {
            return value.IsItemInEnum<TEnum>()()
                ? default(TEnum)
                : (TEnum)Enum.Parse(typeof(TEnum), value, ignorecase);
        }

        #endregion ParseStringToEnum(解析字符串到枚举项)

        #region EncodeEmailAddress(编码电子邮件地址)

        /// <summary>
        /// 将电子邮件地址进行编码，以便于链接仍然有效
        /// </summary>
        /// <param name="emailAddress">邮箱地址</param>
        /// <returns>编码后的邮箱地址</returns>
        public static string EncodeEmailAddress(this string emailAddress)
        {
            string tempHtmlEncode = emailAddress;
            for (int i = tempHtmlEncode.Length; i >= 1; i--)
            {
                int acode = Convert.ToInt32(tempHtmlEncode[i - 1]);
                string repl;
                switch (acode)
                {
                    case 32:
                        repl = " ";
                        break;

                    case 34:
                        repl = "\"";
                        break;

                    case 38:
                        repl = "&";
                        break;

                    case 60:
                        repl = "<";
                        break;

                    case 62:
                        repl = ">";
                        break;

                    default:
                        if (acode >= 32 && acode <= 127)
                        {
                            repl = "&#" + Convert.ToString(acode) + ";";
                        }
                        else
                        {
                            repl = "&#" + Convert.ToString(acode) + ";";
                        }
                        break;
                }
                if (repl.Length > 0)
                {
                    tempHtmlEncode = tempHtmlEncode.Substring(0, i - 1) +
                                     repl + tempHtmlEncode.Substring(i);
                }
            }
            return tempHtmlEncode;
        }

        #endregion EncodeEmailAddress(编码电子邮件地址)

        #region RepairZero(补足位数)

        /// <summary>
        /// 补足位数，指定字符串的固定长度，如果字符串小于固定长度，则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        /// <returns></returns>
        public static string RepairZero(this string text, int limitedLength)
        {
            return text.PadLeft(limitedLength, '0');
        }

        #endregion RepairZero(补足位数)

        #endregion 字符串操作

        #region 字符串安全

        #region UrlEncode(Url编码)

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="source">url编码字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string UrlEncode(this string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return HttpUtility.UrlEncode(source, encoding);
        }

        #endregion UrlEncode(Url编码)

        #region UrlDecode(Url解码)

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="source">url编码字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string UrlDecode(this string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return HttpUtility.UrlDecode(source, encoding);
        }

        #endregion UrlDecode(Url解码)

        #region ToHtmlSafe(Html字符串进行安全编码)

        /// <summary>
        /// Html字符串进行安全编码
        /// </summary>
        /// <param name="value">当前Html字符串实例</param>
        /// <returns>安全的Html字符串</returns>
        public static string ToHtmlSafe(this string value)
        {
            return value.ToHtmlSafe(false, false);
        }

        /// <summary>
        /// Html字符串进行安全编码
        /// </summary>
        /// <param name="value">当前Html字符串实例</param>
        /// <param name="all">是否所有字符进行安全编码，或只是部分需要</param>
        /// <returns>安全的Html字符串</returns>
        public static string ToHtmlSafe(this string value, bool all)
        {
            return value.ToHtmlSafe(all, false);
        }

        /// <summary>
        /// Html字符串进行安全编码
        /// </summary>
        /// <param name="value">当前Html字符串实例</param>
        /// <param name="all">是否所有字符进行安全编码，或只是部分需要</param>
        /// <param name="replace">是否对空格以及换行符进行编码</param>
        /// <returns>安全的Html字符串</returns>
        public static string ToHtmlSafe(this string value, bool all, bool replace)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }
            var entities = new[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29,
                30, 31, 34, 39, 38, 60, 62, 123, 124, 125, 126, 127, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169,
                170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190,
                191, 215, 247, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209,
                210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230,
                231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251,
                252, 253, 254, 255, 256, 8704, 8706, 8707, 8709, 8711, 8712, 8713, 8715, 8719, 8721, 8722, 8727, 8730,
                8733, 8734, 8736, 8743, 8744, 8745, 8746, 8747, 8756, 8764, 8773, 8776, 8800, 8801, 8804, 8805, 8834,
                8835, 8836, 8838, 8839, 8853, 8855, 8869, 8901, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923,
                924, 925, 926, 927, 928, 929, 931, 932, 933, 934, 935, 936, 937, 945, 946, 947, 948, 949, 950, 951, 952,
                953, 954, 955, 956, 957, 958, 959, 960, 961, 962, 963, 964, 965, 966, 967, 968, 969, 977, 978, 982, 338,
                339, 352, 353, 376, 402, 710, 732, 8194, 8195, 8201, 8204, 8205, 8206, 8207, 8211, 8212, 8216, 8217,
                8218, 8220, 8221, 8222, 8224, 8225, 8226, 8230, 8240, 8242, 8243, 8249, 8250, 8254, 8364, 8482, 8592,
                8593, 8594, 8595, 8596, 8629, 8968, 8969, 8970, 8971, 9674, 9824, 9827, 9829, 9830
            };
            StringBuilder sb = new StringBuilder();
            foreach (var item in value)
            {
                if (all || entities.Contains(item))
                {
                    sb.Append("&#" + ((int)item) + ";");
                }
                else
                {
                    sb.Append(item);
                }
            }
            return replace
                ? sb.Replace("", "<br />").Replace("\n", "<br />").Replace(" ", "&nbsp;").ToString()
                : sb.ToString();
        }

        #endregion ToHtmlSafe(Html字符串进行安全编码)

        #region EncodeBase64(Base64字符串编码)

        /// <summary>
        /// 对字符串进行Base64字符串编码，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>Base64编码字符串</returns>
        public static string EncodeBase64(this string value, Encoding encoding = null)
        {
            encoding = (encoding ?? Encoding.UTF8);
            var bytes = encoding.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        #endregion EncodeBase64(Base64字符串编码)

        #region DecodeBase64(Base64字符串解码)

        /// <summary>
        /// 对字符串进行Base64字符串解码
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>解码字符串</returns>
        public static string DecodeBase64(this string value, Encoding encoding = null)
        {
            encoding = (encoding ?? Encoding.UTF8);
            var bytes = Convert.FromBase64String(value);
            return encoding.GetString(bytes);
        }

        #endregion DecodeBase64(Base64字符串解码)

        #region EncryptToBytes(字符串加密为字节数组)

        /// <summary>
        /// 将字符串加密成字节数组
        /// </summary>
        /// <param name="value">值，需要加密的字符串</param>
        /// <param name="pwd">密匙，使用密匙来加密字符串</param>
        /// <returns></returns>
        public static byte[] EncryptToBytes(this string value, string pwd)
        {
            var asciiEncoder = new ASCIIEncoding();
            byte[] bytes = asciiEncoder.GetBytes(value);
            return CryptBytes(pwd, bytes, true);
        }

        /// <summary>
        /// 加密或解密字节数组，使用Rfc2898DeriveBytes与TripleDESCryptoServiceProvider的加密提供程序生成的密匙和初始化向量
        /// </summary>
        /// <param name="pwd">需要加密或解密的密码字符串</param>
        /// <param name="bytes">用来加密的字节数组</param>
        /// <param name="encrypt">true：加密，false：解密</param>
        /// <returns></returns>
        private static byte[] CryptBytes(string pwd, byte[] bytes, bool encrypt)
        {
            //第三方加密服务商
            var desProvider = new TripleDESCryptoServiceProvider();
            //找到此提供程序的有效密钥大小
            int keySizeBits = 0;
            for (int i = 1024; i >= 1; i--)
            {
                if (desProvider.ValidKeySize(i))
                {
                    keySizeBits = i;
                    break;
                }
            }
            //获取此提供程序的块大小
            int blockSizeBits = desProvider.BlockSize;
            //生成密钥和初始化向量
            byte[] key = null;
            byte[] iv = null;
            byte[] salt =
            {
                0x10, 0x20, 0x12, 0x23, 0x37, 0xA4, 0xC5, 0xA6, 0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45
            };
            MakeKeyAndIv(pwd, salt, keySizeBits, blockSizeBits, ref key, ref iv);
            //进行加密或解密
            ICryptoTransform cryptoTransform = encrypt
                ? desProvider.CreateEncryptor(key, iv)
                : desProvider.CreateDecryptor(key, iv);
            //创建输出流
            var outStream = new MemoryStream();
            //附加一个加密流输出流
            var cryptoStream = new CryptoStream(outStream, cryptoTransform, CryptoStreamMode.Write);
            //写字节到加密流中
            cryptoStream.Write(bytes, 0, bytes.Length);
            try
            {
                cryptoStream.FlushFinalBlock();
            }
            catch (CryptographicException)
            {
                // Ignore this one. The password is bad.
            }
            //保存结果
            byte[] result = outStream.ToArray();
            //关闭流
            try
            {
                cryptoStream.Close();
            }
            catch (CryptographicException)
            {
                // Ignore this one. The password is bad.
            }
            outStream.Close();
            return result;
        }

        /// <summary>
        /// 使用密码生成密匙和一个初始化向量（Rfc2898DeriveBytes）
        /// </summary>
        /// <param name="pwd">用于生成字节的输入密码</param>
        /// <param name="salt">用于生成字节的salt值</param>
        /// <param name="keySizeBits">生成密匙的大小</param>
        /// <param name="blockSizeBits">加密提供程序所使用的输入块的大小</param>
        /// <param name="key">生成输出密匙字节</param>
        /// <param name="iv">生成输出初始化向量</param>
        private static void MakeKeyAndIv(string pwd, byte[] salt, int keySizeBits, int blockSizeBits, ref byte[] key,
            ref byte[] iv)
        {
            var deriveBytes = new Rfc2898DeriveBytes(pwd, salt, 1234);
            key = deriveBytes.GetBytes(keySizeBits / 8);
            iv = deriveBytes.GetBytes(blockSizeBits / 8);
        }

        #endregion EncryptToBytes(字符串加密为字节数组)

        #region DecryptFromBytes(字节数组解密为字符串)

        /// <summary>
        /// 将字节数组解密成字符串，前提该字节数组已加密
        /// </summary>
        /// <param name="value">值，要解密的字节数组</param>
        /// <param name="pwd">密匙，使用密匙来解密字符串</param>
        /// <returns></returns>
        public static string DecryptFromBytes(this byte[] value, string pwd)
        {
            byte[] bytes = CryptBytes(pwd, value, false);
            var asciiEncoder = new ASCIIEncoding();
            return new string(asciiEncoder.GetChars(bytes));
        }

        #endregion DecryptFromBytes(字节数组解密为字符串)

        #region EncryptToString(字符串加密)

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="value">值，需要加密的字符串</param>
        /// <param name="pwd">密匙，使用密匙来加密字符串</param>
        /// <returns></returns>
        public static string EncryptToString(this string value, string pwd)
        {
            return value.EncryptToBytes(pwd).ToHexString();
        }

        #endregion EncryptToString(字符串加密)

        #region DecryptFromString(字符串解密)

        /// <summary>
        /// 字符串解密，前提字符串已加密
        /// </summary>
        /// <param name="value">值，要解密的字符串</param>
        /// <param name="pwd">密匙，使用密匙来解密字符串</param>
        /// <returns></returns>
        public static string DecryptFromString(this string value, string pwd)
        {
            byte[] bytes = value.HexStringToBytes();
            return DecryptFromBytes(bytes, pwd);
        }

        #endregion DecryptFromString(字符串解密)

        #endregion 字符串安全

        #region 字符串转换

        #region ToBytes(转换成Byte[])

        /// <summary>
        /// 将字符串转为byte[]数组，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>byte[]数组</returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            encoding = (encoding ?? Encoding.ASCII);
            return encoding.GetBytes(value);
        }

        #endregion ToBytes(转换成Byte[])

        #region ToXDocument(转换成XDocument)

        /// <summary>
        /// 字符串转为XDocument（Linq to Xml Dom）
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static XDocument ToXDocument(this string xml)
        {
            return XDocument.Parse(xml);
        }

        #endregion ToXDocument(转换成XDocument)

        #region ToXElement(转换成XElement)

        /// <summary>
        /// 字符串转为XElement对象（Linq to Xml XElement）
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static XElement ToXElement(this string xml)
        {
            return XElement.Parse(xml);
        }

        #endregion ToXElement(转换成XElement)

        #region ToXmlDocument(转换成XmlDocument)

        /// <summary>
        /// 字符串转为XmlDocument对象（Xml Dom）
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this string xml)
        {
            var documnet = new XmlDocument();
            documnet.LoadXml(xml);
            return documnet;
        }

        #endregion ToXmlDocument(转换成XmlDocument)

        #region ToXPath(转换成XPath)

        /// <summary>
        /// 字符串转为XmlPathDom对象（Xml XPath Dom）
        /// </summary>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static XPathNavigator ToXPath(this string xml)
        {
            var documnet = new XPathDocument(new StringReader(xml));
            return documnet.CreateNavigator();
        }

        #endregion ToXPath(转换成XPath)

        #region HexStringToBytes(16进制字符串转换成字节数组)

        /// <summary>
        /// 16进制字符串转换为字节数组
        /// </summary>
        /// <param name="value">16进制字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexStringToBytes(this string value)
        {
            value = value.Replace(" ", "");
            int maxByte = value.Length / 2 - 1;
            var bytes = new byte[maxByte + 1];
            for (int i = 0; i <= maxByte; i++)
            {
                bytes[i] = byte.Parse(value.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);
            }
            return bytes;
        }

        #endregion HexStringToBytes(16进制字符串转换成字节数组)

        #region ToUnicodeString(转换成Unicode字符串)

        /// <summary>
        /// 转换成Unicode字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns></returns>
        public static string ToUnicodeString(this string source)
        {
            string outString = "";
            if (!string.IsNullOrEmpty(source))
            {
                outString = source.Aggregate(outString, (current, t) => current + (@"\u" + ((int)t).ToString("x").ToUpper()));
            }
            return outString;
        }

        #endregion ToUnicodeString(转换成Unicode字符串)

        #region ToSecureString(转换成安全字符串)

        /// <summary>
        /// 将字符串转为安全字符串
        /// </summary>
        /// <param name="value">普通字符串</param>
        /// <param name="markReadOnly">是否只读</param>
        /// <returns>安全字符串</returns>
        public static SecureString ToSecureString(this string value, bool markReadOnly = true)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }
            SecureString temp = new SecureString();
            foreach (char c in value)
            {
                temp.AppendChar(c);
            }
            if (markReadOnly)
            {
                temp.MakeReadOnly();
            }
            return temp;
        }

        #endregion ToSecureString(转换成安全字符串)

        #region ToUnSecureString(转换成普通字符串)

        /// <summary>
        /// 将安全字符串转为普通字符串
        /// </summary>
        /// <param name="value">安全字符串</param>
        /// <returns>普通字符串</returns>
        public static string ToUnSecureString(this SecureString value)
        {
            if (ReferenceEquals(value, null))
            {
                return null;
            }
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion ToUnSecureString(转换成普通字符串)

        #region ToDateTime(时间戳转换成时间)

        /// <summary>
        /// 将时间戳转换成时间
        /// </summary>
        /// <param name="timeStamp">时间戳格式字符串</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string timeStamp)
        {
            if (timeStamp.Length > 10)
            {
                timeStamp = timeStamp.Substring(0, 10);
            }
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lIime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lIime);
            return dateTimeStart.Add(toNow);
        }

        #endregion ToDateTime(时间戳转换成时间)

        #endregion 字符串转换

        public static int ToInt32(this string value, int defaultVal = 0)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }
            return defaultVal;
        }

        public static Guid ToGuid(this string value)
        {
            Guid result;
            if (Guid.TryParse(value, out result))
            {
                return result;
            }
            return Guid.Empty;
        }
    }
}