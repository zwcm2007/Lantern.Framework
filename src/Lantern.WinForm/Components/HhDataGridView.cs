using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// 自定义DataGridView控件
    /// </summary>
    public class HhDataGridView : DataGridView
    {
        private bool _rowChecked = false;

        public HhDataGridView()
        {
            this.RowTemplate.Height = 23; //行高
            this.ColumnHeadersHeight = 25; //列标题高度
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersVisible = false; // 行标题不可见
            this.AllowUserToResizeRows = false;
            this.MultiSelect = false;
            this.ReadOnly = false;
        }

        /// <summary>
        /// 行是否可勾选
        /// </summary>
        public bool CanRowChecked
        {
            get { return _rowChecked; }
            set
            {
                if (_rowChecked != value)
                {
                    _rowChecked = value;

                    if (_rowChecked)
                    {
                        var col = new DataGridViewCheckBoxColumnSelectAll()
                        {
                            Name = "selectAllColumn",
                            HeaderText = "",
                            Width = 50,
                            ReadOnly = false,
                            Frozen = true,
                        };
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        Columns.Insert(0, col);  // 插入第一列
                    }
                    else
                    {
                        if (Columns.Count > 0 && Columns[0] is DataGridViewCheckBoxColumnSelectAll)
                        {
                            Columns.RemoveAt(0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 但数据源绑定完成后，全选勾自动去掉
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in Columns)
            {
                if (col is DataGridViewCheckBoxColumnSelectAll)
                {
                    var cell = (DataGridViewCheckBoxHeaderCell)col.HeaderCell;
                    if (cell.IsChecked)
                    {
                        cell.IsChecked = false;
                        InvalidateCell(cell); // 把全选列头单元格打勾去掉
                    }
                }
            }
            //
            base.OnDataBindingComplete(e);
        }
    }
}