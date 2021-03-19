using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lantern.WinForm.Common
{
    /// <summary>
    /// 热键实体
    /// </summary>
    public class HotKeyEntity  //: Entity<int>
    {
        public const string __TableName = "HotKeyRec";
        public const string __Id = "Id";
        public const string __ClassId = "ClassId";
        public const string __Name = "Name";
        public const string __Code = "Code";
        public const string __Modifier = "Modifier";
        public const string __KeyVal = "KeyVal";
        public const string __Sort = "Sort";

        /// <summary>
        /// 构造函数
        /// </summary>
        public HotKeyEntity(int id)
        {
            Id = id;
        }

        #region 属性

        /// <summary>
        /// 热键代码
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 热键代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 热键名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 热键组合键
        /// </summary>
        public KeyModifiers Modifier { get; set; }

        /// <summary>
        /// 热键键值
        /// </summary>
        public Keys KeyVal { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 热键回调
        /// </summary>
        public HotKeyCallBack CallBack { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (Modifier != KeyModifiers.None && KeyVal != Keys.None)
                {
                    return $"{Modifier} + {GetKeyName(KeyVal)}";
                }
                else if (Modifier == KeyModifiers.None && KeyVal != Keys.None)
                {
                    return GetKeyName(KeyVal);
                }
                else if (Modifier != KeyModifiers.None && KeyVal == Keys.None)
                {
                    return Modifier.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 键名
        /// </summary>
        public string GetKeyName(Keys keyVal)
        {
            if (KeyVal >= Keys.D0 && KeyVal <= Keys.D9)
            {
                return KeyVal.ToString().Substring(1);
            }
            else
            {
                return KeyVal.ToString();
            }
        }

        #endregion 属性

        #region 内部方法

        /// <summary>
        /// 内部注册
        /// </summary>
        internal bool Regist(IntPtr hWnd)
        {
            bool ret = RegisterHotKey(hWnd, Id, (int)Modifier, KeyVal);
            return ret;
        }

        /// <summary>
        /// 内部注销
        /// </summary>
        internal bool Unregist(IntPtr hWnd)
        {
            bool ret = UnregisterHotKey(hWnd, Id);
            return ret;
        }

        #endregion 内部方法

        #region 外部方法

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion 外部方法
    }

    /// <summary>
    /// 组合控制键
    /// </summary>
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8
    }

    /// <summary>
    /// 热键回调
    /// </summary>
    public delegate void HotKeyCallBack();
}