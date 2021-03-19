using Lantern.WinForm.Properties;
using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ToolStripSplitButton派生类
    /// </summary>
    public class HhToolStripSplitButton : ToolStripSplitButton
    {
        private bool _isSelected;

        /// <summary>
        /// 选中是否启用
        /// </summary>
        public bool SelectedEnabled { get; set; }

        /// <summary>
        /// 是否应在被单击时自动显示为选中或未选中
        /// </summary>
        //public bool SelectOnClick { get; set; } = true;

        /// <summary>
        /// 指示是否只能取消选中
        /// </summary>
        public bool CancelSelectedOnly { get; set; }

        /// <summary>
        /// 获取或设置选中状态
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.BackgroundImage = _isSelected ? Resource1.btn_bg : null;
            }
        }

        protected override void OnButtonClick(EventArgs e)
        {
            if (SelectedEnabled)
            {
                if (CancelSelectedOnly)
                {
                    if (IsSelected) IsSelected = !IsSelected;
                }
                else
                {
                    IsSelected = !IsSelected;
                }
            }

            //
            base.OnButtonClick(e);
        }

        public void ClickSelf()
        {
            if (Enabled)
            {
                OnButtonClick(EventArgs.Empty);
            }
        }
    }
}