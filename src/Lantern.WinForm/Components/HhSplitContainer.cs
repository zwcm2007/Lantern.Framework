using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// SplitContainer派生类
    /// http://www.cnblogs.com/JustYong/p/5552244.html
    /// </summary>
    [ToolboxBitmap(typeof(SplitContainer))]
    public partial class HhSplitContainer : SplitContainer
    {
        #region 字段

        /// <summary>
        /// 控制器绘制区域
        /// </summary>
        private Rectangle ControlRect
        {
            get
            {
                var rect = new Rectangle();

                if (Orientation == Orientation.Horizontal)
                {
                    rect.X = Width <= 80 ? 0 : Width / 2 - 40;
                    rect.Y = SplitterDistance;
                    rect.Width = 80;
                    rect.Height = 9;
                }
                else
                {
                    rect.X = SplitterDistance;
                    rect.Y = Height <= 80 ? 0 : Height / 2 - 40;
                    rect.Width = 9;
                    rect.Height = 80;
                }
                return rect;
            }
        }

        /// <summary>
        /// 鼠标状态(进入或离开)
        /// </summary>
        private MouseState _mouseState = MouseState.Normal;

        /// <summary>
        /// 定义折叠或展开的是哪一个面板
        /// </summary>
        private SplitterPanelEnum _collpaseOrExpandPanel;

        /// <summary>
        /// Splitter是否固定
        /// </summary>
        private bool _isSplitterFixed = true;

        /// <summary>
        /// 当前是否为折叠状态
        /// </summary>
        private bool _collpased;

        #endregion 字段

        #region 属性

        /// <summary>
        /// 进行折叠或展开的SplitterPanel,设置为属性，所以可以在页面进行重新设置
        /// </summary>
        [DefaultValue(SplitterPanelEnum.Panel1)]
        public SplitterPanelEnum CollpaseOrExpandPanel
        {
            get { return _collpaseOrExpandPanel; }
            set
            {
                if (value != _collpaseOrExpandPanel)
                {
                    _collpaseOrExpandPanel = value;
                    Invalidate(ControlRect);
                }
            }
        }

        /// <summary>
        /// 设定Panel1是否为默认折叠
        /// </summary>
        private bool _panel1Collapsed;

        [DefaultValue(false)]
        public new bool Panel1Collapsed
        {
            get
            {
                return _panel1Collapsed;
            }
            set
            {
                //只有当CollpaseOrExpandPanel = Panel时，Panel1Collapsed的设置才会有效
                if (CollpaseOrExpandPanel == SplitterPanelEnum.Panel1 && value != _panel1Collapsed)
                {
                    _panel1Collapsed = value;
                    //设置_collpased值为value的相反值，再调用CollpaseOrExpand()进行折叠或展开.
                    _collpased = !value;

                    CollpaseOrExpand();
                }
            }
        }

        /// <summary>
        /// 设置Panel2是否为默认折叠
        /// </summary>
        private bool _panel2Colapsed;

        [DefaultValue(false)]
        public new bool Panel2Collapsed
        {
            get
            {
                return _panel2Colapsed;
            }
            set
            {
                //只有当CollpaseOrExpandPanel = Pane2时，Panel1Collapsed的设置才会有效
                if (CollpaseOrExpandPanel == SplitterPanelEnum.Panel2 && value != _panel2Colapsed)
                {
                    _panel2Colapsed = value;
                    //设置_collpased值为value的相反值，再调用CollpaseOrExpand()进行折叠或展开
                    _collpased = !value;

                    CollpaseOrExpand();
                }
            }
        }

        /// <summary>
        /// 用于固定保存显式设定的SplitterDistance,因为基类的SplitterDistance属性会变动
        /// </summary>
        public int DefaultSplitterDistance { get; set; }

        #endregion 属性

        #region 构造函数

        public HhSplitContainer()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer, true);

            Panel1MinSize = 0;
            Panel2MinSize = 0;
        }

        #endregion 构造函数

        #region 重载

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color = _mouseState == MouseState.Normal ? SystemColors.ButtonShadow : SystemColors.ControlDarkDark;

            //需要绘制的图片
            Bitmap bmp = CreateControlImage(color);

            //对图片进行旋转
            RotateFlip(bmp);

            //清除绘制区域
            e.Graphics.SetClip(SplitterRectangle);
            e.Graphics.Clear(BackColor);
            //绘制
            e.Graphics.DrawImage(bmp, ControlRect);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //鼠标在控制按钮区域
            if (SplitterRectangle.Contains(e.Location))
            {
                if (ControlRect.Contains(e.Location))
                {
                    //如果拆分器可移动，则鼠标在控制按钮范围内时临时关闭拆分器
                    if (!IsSplitterFixed)
                    {
                        IsSplitterFixed = true;

                        _isSplitterFixed = false;
                    }

                    Cursor = Cursors.Hand;
                    _mouseState = MouseState.Hover;
                    Invalidate(ControlRect);
                }
                else
                {
                    //如果拆分器为临时关闭，则开启拆分器
                    if (!_isSplitterFixed)
                    {
                        IsSplitterFixed = false;
                        Cursor = Orientation == Orientation.Horizontal ? Cursors.HSplit : Cursors.VSplit;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                    }
                    _mouseState = MouseState.Normal;
                    Invalidate(ControlRect);
                }
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Cursor = Cursors.Default;

            _mouseState = MouseState.Normal;

            Invalidate(ControlRect);

            base.OnMouseLeave(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (ControlRect.Contains(e.Location))
            {
                CollpaseOrExpand();
            }

            base.OnMouseClick(e);
        }

        #endregion Override

        #region 方法

        /// <summary>
        /// 折叠或展开
        /// 1.当当前状态为折叠状态时，则进行展开操作
        /// 2.当当前状态为展开状态时，则进行折叠操作
        /// </summary>
        private void CollpaseOrExpand()
        {
            //当前为缩小状态，进行Expand操作
            if (_collpased)
            {
                //展开
                SplitterDistance = DefaultSplitterDistance;
            }
            //当前为伸展状态，进行Collpase操作
            else
            {
                //折叠
                if (_collpaseOrExpandPanel == SplitterPanelEnum.Panel1)
                {
                    SplitterDistance = 0;
                }
                else
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        SplitterDistance = Height - 9;
                    }
                    else
                    {
                        SplitterDistance = Width - 9;
                    }
                }
            }

            _collpased = !_collpased;

            Invalidate(ControlRect); //局部刷新绘制
        }

        /// <summary>
        /// 需要绘制的用于折叠窗口的按钮样式
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Bitmap CreateControlImage(Color color)
        {
            var bmp = new Bitmap(80, 9);
            for (int x = 5; x <= 30; x += 5)
            {
                for (int y = 1; y <= 7; y += 3)
                {
                    bmp.SetPixel(x, y, color);
                }
            }
            for (int x = 50; x <= 75; x += 5)
            {
                for (int y = 1; y <= 7; y += 3)
                {
                    bmp.SetPixel(x, y, color);
                }
            }

            int k = 0;
            for (int y = 7; y >= 1; y--)
            {
                for (int x = 35 + k; x <= 45 - k; x++)
                {
                    bmp.SetPixel(x, y, color);
                }
                k++;
            }

            return bmp;
        }

        private void RotateFlip(Bitmap bmp)
        {
            if (Orientation == Orientation.Horizontal)
            {
                if (_collpaseOrExpandPanel == SplitterPanelEnum.Panel1 && !_collpased ||
                    _collpaseOrExpandPanel == SplitterPanelEnum.Panel2 && _collpased)
                {
                    bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                else
                {
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
                }
            }
            else
            {
                if (_collpaseOrExpandPanel == SplitterPanelEnum.Panel1 && !_collpased ||
                    _collpaseOrExpandPanel == SplitterPanelEnum.Panel2 && _collpased)
                {
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipX);
                }
                else
                {
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipX);
                }
            }
        }

        #endregion 方法

        #region 枚举

        private enum MouseState
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,

            /// <summary>
            /// 鼠标移入
            /// </summary>
            Hover
        }

        public enum SplitterPanelEnum
        {
            Panel1,
            Panel2
        }

        #endregion 枚举
    }
}