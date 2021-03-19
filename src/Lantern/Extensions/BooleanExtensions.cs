namespace Lantern.Extensions
{
    /// <summary>
    /// bool类型的扩展辅助操作类
    /// </summary>
    public static class BooleanExtensions
    {
        #region 将布尔值转换为小写字符串

        /// <summary>
        /// 将布尔值转换为小写字符串
        /// </summary>
        /// <param name="value">bool</param>
        /// <returns>小写字符串</returns>
        public static string ToLower(this bool value)
        {
            return value.ToString().ToLower();
        }

        #endregion 将布尔值转换为小写字符串

        #region 将布尔值转换为等效的字符串表示形式

        /// <summary>
        /// 将布尔值转换为等效的字符串表示形式（Yes、No）
        /// </summary>
        /// <param name="value">bool</param>
        /// <returns>等效的字符串表示形式</returns>
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" : "No";
        }

        #endregion 将布尔值转换为等效的字符串表示形式

        #region 将布尔值转换为二进制数字类型

        /// <summary>
        /// 将布尔值转换为二进制数字类型，1:0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToBinaryTypeNumber(this bool value)
        {
            return value ? 1 : 0;
        }

        #endregion 将布尔值转换为二进制数字类型

        #region 结果为true时，输出参数

        /// <summary>
        /// 结果为True时，输出参数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="b">判断源结果</param>
        /// <param name="t">输出值</param>
        /// <returns></returns>
        public static T IsTrue<T>(this bool b, T t)
        {
            return b ? t : default(T);
        }

        /// <summary>
        /// 结果为True时，输出参数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="b">判断源结果</param>
        /// <param name="t">输出值</param>
        /// <returns></returns>
        public static T IsTrue<T>(this bool? b, T t)
        {
            return b.GetValueOrDefault() ? t : default(T);
        }

        #endregion 结果为true时，输出参数

        #region 结果为False时，输出参数

        /// <summary>
        /// 结果为False时，输出参数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="b">判断源结果</param>
        /// <param name="t">输出值</param>
        /// <returns></returns>
        public static T IsFalse<T>(this bool b, T t)
        {
            return !b ? t : default(T);
        }

        /// <summary>
        /// 结果为False时，输出参数
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="b">判断源结果</param>
        /// <param name="t">输出值</param>
        /// <returns></returns>
        public static T IsFalse<T>(this bool? b, T t)
        {
            return !b.GetValueOrDefault() ? t : default(T);
        }

        #endregion 结果为False时，输出参数

        #region 获取中文

        /// <summary>
        /// 获取中文
        /// </summary>
        /// <param name="b">判断源</param>
        /// <param name="strTrue">为True时的中文:是</param>
        /// <param name="strFalse">为Flase时的中文:否</param>
        /// <returns></returns>
        public static string GetName(this bool b, string strTrue = "是", string strFalse = "否")
        {
            return b ? strTrue : strFalse;
        }

        /// <summary>
        /// 获取中文
        /// </summary>
        /// <param name="b">判断源</param>
        /// <param name="strTrue">为True时的中文:是</param>
        /// <param name="strFalse">为Flase时的中文:否</param>
        /// <returns></returns>
        public static string GetName(this bool? b, string strTrue = "是", string strFlase = "否")
        {
            return b.GetValueOrDefault() ? strTrue : strFlase;
        }

        #endregion 获取中文
    }
}