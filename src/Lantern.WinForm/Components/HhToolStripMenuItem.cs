using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ToolStripMenuItem派生类
    /// </summary>
    public class HhToolStripMenuItem : ToolStripMenuItem
    {
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        public void ClickSelf()
        {
            OnClick(EventArgs.Empty);
        }
    }
}