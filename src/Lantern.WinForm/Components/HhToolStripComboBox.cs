using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ToolStripComboBox派生类
    /// </summary>
    public class HhToolStripComboBox : ToolStripComboBox
    {
        /// <summary>
        /// 是否数字型输入框
        /// </summary>
        public bool IsDigital { get; set; }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (IsDigital)
            {
                if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            //
            base.OnKeyPress(e);
        }

        protected override void OnClick(EventArgs e)
        {
            //
            base.OnClick(e);
        }
    }
}