using Lantern.WinForm.Properties;
using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ToolStripButton派生类
    /// </summary>
    public class HhToolStripButton : ToolStripButton
    {
        private bool _isSelected;

        /// <summary>
        /// 选中是否启用
        /// </summary>
        public bool SelectedEnabled { get; set; }

        /// <summary>
        /// 获取或设置选中状态
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                BackgroundImage = _isSelected ? Resource1.btn_bg : null;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (SelectedEnabled)
            {
                IsSelected = !IsSelected;
            }
            //
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //
            //Rectangle rect = e.ClipRectangle;
            //Graphics g = e.Graphics;
            //g.DrawLine(Pens.Blue, 0, 0, rect.Width, 0);
            //rect.w
            //rect = new Rectangle(rect.X, rect.Y, rect.Width - 1, rect.Height - 2);
        }

        public void ClickSelf()
        {
            if (Enabled)
            {
                OnClick(EventArgs.Empty);
            }
        }
    }
}