using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lantern.WinForm.Components
{
    public delegate void CheckBoxClickedHandler(bool state);

    internal class DataGridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        private CheckBoxState _cbState = CheckBoxState.UncheckedNormal;
        private Point _cellLocation = new Point();
        private bool _checked;
        private Point checkBoxLocation;
        private Size checkBoxSize;

        public bool IsChecked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                if (this._checked)
                {
                    this._cbState = CheckBoxState.CheckedNormal;
                }
                else
                {
                    this._cbState = CheckBoxState.UncheckedNormal;
                }
            }
        }

        public event CheckBoxClickedHandler OnCheckBoxClicked;

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point point = new Point(e.X + this._cellLocation.X, e.Y + this._cellLocation.Y);
            if (((point.X >= this.checkBoxLocation.X) && (point.X <= (this.checkBoxLocation.X + this.checkBoxSize.Width))) && ((point.Y >= this.checkBoxLocation.Y) && (point.Y <= (this.checkBoxLocation.Y + this.checkBoxSize.Height))))
            {
                this._checked = !this._checked;
                bool temp = this._checked;
                if (this.OnCheckBoxClicked != null)
                {
                    this.OnCheckBoxClicked(this._checked);
                    base.DataGridView.InvalidateCell(this);
                }
                foreach (DataGridViewRow row in base.DataGridView.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex]).Value = temp;
                }
                base.DataGridView.RefreshEdit();
            }
            base.OnMouseClick(e);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            Point point = new Point();
            Size glyphSize = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
            point.X = (cellBounds.Location.X + (cellBounds.Width / 2)) - (glyphSize.Width / 2);
            point.Y = (cellBounds.Location.Y + (cellBounds.Height / 2)) - (glyphSize.Height / 2);
            this._cellLocation = cellBounds.Location;
            this.checkBoxLocation = point;
            this.checkBoxSize = glyphSize;
            if (this._checked)
            {
                this._cbState = CheckBoxState.CheckedNormal;
            }
            else
            {
                this._cbState = CheckBoxState.UncheckedNormal;
            }
            CheckBoxRenderer.DrawCheckBox(graphics, this.checkBoxLocation, this._cbState);
        }
    }
}