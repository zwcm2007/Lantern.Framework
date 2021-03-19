using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ComboBox派生类
    /// </summary>
    public class HhComboBox : ComboBox
    {
        //private static readonly ErrorProvider _errProvider = new ErrorProvider();
        //private Func<HhComboBox, bool> _validator = null;

        #region 属性

        /// <summary>
        /// 是否具有有效数据
        /// </summary>
        //public bool HasValidData
        //{
        //    get { return RaiseValidation(); }
        //}

        #endregion 属性

        /// <summary>
        /// 新增项
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddNewItem<TKey, TValue>(HhComboBoxItem<TKey, TValue> item)
        {
            return Items.Add(item);
        }

        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cboBox"></param>
        /// <param name="key"></param>
        public void SetSelectedItem<TKey, TValue>(TKey key)
            where TKey : IComparable
        {
            foreach (var item in Items)
            {
                var current = item as HhComboBoxItem<TKey, TValue>;
                if (current.Key == null && key == null)
                {
                    this.SelectedItem = item;
                    break;
                }
                else if (current.Key?.CompareTo(key) == 0)
                {
                    this.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// 显示错误
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //public HhComboBox ShowError(string value)
        //{
        //    _errProvider.SetError(this, value);
        //    return this;
        //}

        ///// <summary>
        ///// 清理错误
        ///// </summary>
        ///// <returns></returns>
        //public HhComboBox ClearError()
        //{
        //    _errProvider.SetError(this, "");
        //    return this;
        //}

        //public HhComboBox SetValidator(Func<HhComboBox, bool> validator)
        //{
        //    _validator = validator;
        //    return this;
        //}

        //public Func<HhComboBox, bool> GetValidator()
        //{
        //    return _validator;
        //}

        //protected override void OnSelectedValueChanged(EventArgs e)
        //{
        //    RaiseValidation();
        //    //
        //    base.OnSelectedValueChanged(e);
        //}

        //protected override void OnValidating(CancelEventArgs e)
        //{
        //    //base.OnValidating(e);

        //    RaiseValidation();
        //}

        //private bool RaiseValidation()
        //{
        //    bool isOK = true;
        //    if (_validator != null)
        //    {
        //        isOK = _validator(this);
        //    }
        //    if (isOK)
        //    {
        //        ClearError();
        //    }
        //    return isOK;
        //}
    }
}