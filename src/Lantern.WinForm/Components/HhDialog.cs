using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// 对话框
    /// </summary>
    public class HhDialog : HhForm
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public HhDialog()
        {
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public bool CloseBoxEnabled { get; set; } = true;   // 关闭按钮默认可用

        /// <summary>
        /// 禁用关闭按钮
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                if (CloseBoxEnabled == false)
                {
                    CreateParams myCp = base.CreateParams;
                    myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                    return myCp;
                }
                return base.CreateParams;
            }
        }
    }
}