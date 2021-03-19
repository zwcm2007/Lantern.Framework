using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// ListView派生类
    /// </summary>
    public class HhListView : ListView
    {
        private readonly Color SelectedColor = Color.LightGray;
        private readonly Color UnSelectedColor = Color.White;
        private int _previousIndex = -1; //之前选中的索引
        private int _selectedIndex = -1; //当前选中的索引
        private bool _isKeepDown; // 判断上下键是否按下状态

        public HhListView()
        {
            HideSelection = false;
            MultiSelect = false;
        }

        /// <summary>
        /// 选中的索引
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                if (MultiSelect)
                    throw new InvalidOperationException("当MultiSelect为true时, SelectedIndex属性无效");
                return _selectedIndex;
            }
            set
            {
                if (MultiSelect)
                    throw new InvalidOperationException("当MultiSelect为true时, SelectedIndex属性无效");

                if (value != _selectedIndex)
                {
                    _previousIndex = _selectedIndex;
                    _selectedIndex = value;

                    if (_selectedIndex >= 0)
                    {
                        //if (HideSelection)
                        //{
                        //    if (_previousIndex >= 0) Items[_previousIndex].BackColor = UnSelectedColor;
                        //    Items[_selectedIndex].BackColor = SelectedColor;
                        //}

                        Items[_selectedIndex].Selected = true;
                    }
                }
            }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!MultiSelect) // 当单选情况
            {
                if (_isKeepDown) return;

                if ((SelectedIndices.Count > 0 && SelectedIndex != SelectedIndices[0]))
                {
                    SelectedIndex = SelectedIndices[0];
                    //
                    base.OnSelectedIndexChanged(e);
                }
            }
            else
            {
                base.OnSelectedIndexChanged(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                _isKeepDown = true; // 上下键按下状态
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            //
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                _isKeepDown = false; // 上下键非按下状态
                //
                OnSelectedIndexChanged(EventArgs.Empty);
            }
        }
    }
}