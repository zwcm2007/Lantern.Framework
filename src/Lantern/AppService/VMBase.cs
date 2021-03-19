using System.ComponentModel;

namespace HouHeng.Common.Data
{
    /// <summary>
    /// 视图模型基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class VMBase<TKey> : VMBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("ID")]
        public TKey Id { get; set; }
    }

    /// <summary>
    /// 视图模型基类
    /// </summary>
    public class VMBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        [DisplayName("序号")]
        public int No { get; set; }
    }
}