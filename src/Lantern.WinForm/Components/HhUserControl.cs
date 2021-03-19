using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// 用户控件派生类
    /// </summary>
    public class HhUserControl : UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            InitializeOnLoad();

            base.OnLoad(e);
        }

        protected virtual void InitializeOnLoad()
        {
        }
    }
}