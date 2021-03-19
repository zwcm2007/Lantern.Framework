using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// TextBox派生类
    /// </summary>
    public class HhTextBox : TextBox
    {
        //private static readonly ErrorProvider _errProvider = new ErrorProvider();

        private Color _defaultForeColor;

        //private Func<HhTextBox, bool> _validator;

        /// <summary>
        /// 是否只能输入数字
        /// </summary>
        public bool IsDigital { get; set; }

        /// <summary>
        /// 是否具有有效数据
        /// </summary>
        //public bool HasValidData
        //{
        //    get { return RaiseValidation(); }
        //}

        public HhTextBox()
        {
            _defaultForeColor = ForeColor;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (IsDigital)
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            //ForeColor = _defaultForeColor;
            //
            base.OnKeyPress(e);
        }

        //public HhTextBox ShowError(string value)
        //{
        //    _errProvider.SetError(this, value);
        //    //this.ForeColor = Color.Red;
        //    return this;
        //}

        //public HhTextBox ClearError()
        //{
        //    _errProvider.SetError(this, "");
        //    //this.ForeColor = _defaultForeColor;
        //    return this;
        //}

        //public HhTextBox SetValidator(Func<HhTextBox, bool> validator)
        //{
        //    _validator = validator;
        //    return this;
        //}

        //public Func<HhTextBox, bool> GetValidator()
        //{
        //    return _validator;
        //}

        //protected virtual bool RaiseValidation()
        //{
        //    bool isOK = true;
        //    if (_validator != null)
        //    {
        //        isOK = _validator(this);
        //    }
        //    if (isOK)
        //    {
        //        if (this.DataBindings["Text"] != null && this.DataBindings["Text"].DataSourceUpdateMode == DataSourceUpdateMode.OnValidation)
        //        {
        //            this.DataBindings["Text"].WriteValue();
        //        }
        //        ClearError();
        //    }
        //    return isOK;
        //}

        //protected override void OnValidating(CancelEventArgs e)
        //{
        //    if (!this.Enabled || this.ReadOnly)
        //    {
        //        return;
        //    }
        //    RaiseValidation();
        //    //base.OnValidating(e);
        //}

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (!this.Focused)
        //    {
        //        RaiseValidation();
        //    }
        //    base.OnTextChanged(e);
        //}
    }
}