using System.ComponentModel;

namespace Lantern.AppService
{
    /// <summary>
    /// 表示业务操作结果的枚举
    /// </summary>
    public enum ActResultType
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Success,

        /// <summary>
        /// 操作取消
        /// </summary>
        [Description("操作取消")]
        Cancel,

        /// <summary>
        /// 输入信息验证失败
        /// </summary>
        [Description("输入信息验证失败。")]
        ValidError,

        /// <summary>
        /// 指定参数的数据不存在
        /// </summary>
        [Description("指定参数的数据不存在。")]
        NotFound,

        /// <summary>
        /// 操作取消或操作没引发任何变化
        /// </summary>
        [Description("操作没有引发任何变化")]
        NoChanged,

        /// <summary>
        /// 操作无效
        /// </summary>
        [Description("操作无效")]
        Invalid,

        /// <summary>
        /// 操作引发错误
        /// </summary>
        [Description("操作引发错误")]
        Error
    }
}