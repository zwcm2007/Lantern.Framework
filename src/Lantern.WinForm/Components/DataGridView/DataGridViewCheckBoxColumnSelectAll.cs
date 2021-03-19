using System;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    public class DataGridViewCheckBoxColumnSelectAll : DataGridViewCheckBoxColumn
    {
        private DataGridViewCheckBoxHeaderCell headerCell;

        public event CheckBoxClickedHandler OnCheckBoxClicked;

        private int TotalCheckedCheckBoxes = 0;
        private bool IsHeaderCheckBoxClicked = false;

        public DataGridViewCheckBoxColumnSelectAll()
        {
            this.headerCell = new DataGridViewCheckBoxHeaderCell();
            base.HeaderCell = this.headerCell;

            this.headerCell.OnCheckBoxClicked += new CheckBoxClickedHandler(this.headerCell_OnCheckBoxClicked);
        }

        public DataGridViewCheckBoxColumnSelectAll(bool threeState)
            : base(threeState)
        {
            this.headerCell = new DataGridViewCheckBoxHeaderCell();
            base.HeaderCell = this.headerCell;
        }

        /// <summary>
        /// 在DataGridView改变时进行事件的绑定
        /// </summary>
        protected override void OnDataGridViewChanged()
        {
            if (this.DataGridView != null)
            {
                this.DataGridView.CellValueChanged -= DataGridView_CellValueChanged;
                this.DataGridView.CellValueChanged += DataGridView_CellValueChanged;
                this.DataGridView.CurrentCellDirtyStateChanged -= DataGridView_CurrentCellDirtyStateChanged;
                this.DataGridView.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            }
        }

        /// <summary>
        /// 在复选的时候进行判断.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (!IsHeaderCheckBoxClicked)
                    RowCheckBoxClick(this.DataGridView[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell);
            }
        }

        /// <summary>
        /// 在复选框被选中的时候触发该事件, 该事件用于触发ValueChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.DataGridView.CurrentCell is DataGridViewCheckBoxCell)
                this.DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// 复选框被点击时所需要做的操作
        /// </summary>
        /// <param name="checkBox"></param>
        private void RowCheckBoxClick(DataGridViewCheckBoxCell checkBox)
        {
            var head = this.headerCell as DataGridViewCheckBoxHeaderCell;
            if (checkBox != null)
            {
                //计算所有被选中的行的数量
                if ((bool)checkBox.Value && TotalCheckedCheckBoxes < this.DataGridView.RowCount)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //当所有复选框都被选中的时候,列的头上的复选框被选中, 反之则不被选中.
                if (TotalCheckedCheckBoxes < this.DataGridView.RowCount)
                    head.IsChecked = false;
                else if (TotalCheckedCheckBoxes == this.DataGridView.RowCount)
                    head.IsChecked = true;
                head.DataGridView.InvalidateCell(head);
            }
        }

        /// <summary>
        /// 头被选中时触发OnCheckBoxClicked事件.
        /// </summary>
        /// <param name="state"></param>
        private void headerCell_OnCheckBoxClicked(bool state)
        {
            if (this.OnCheckBoxClicked != null)
            {
                OnCheckBoxClicked(state);
            }
        }
    }
}