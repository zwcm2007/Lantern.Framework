using HouHeng.Common;
using System;
using System.Windows.Forms;

namespace HouHeng.WinForm.Common
{
    /// <summary>
    /// 注册对话框
    /// </summary>
    public partial class RegDialog : HhDialog
    {
        private SoftReg _softReg = new SoftReg();

        private string _macCode = "";

        public Action<string> RegisterAction { get; set; } = null;
        //public Action CancelAction { get; set; } = null;

        public RegDialog()
        {
            InitializeComponent();
        }

        protected override void InitializeOnLoad()
        {
            base.InitializeOnLoad();
            //
            this.txtRegCode.Focus();
            this.timer1.Enabled = true;
            this.btnReg.Enabled = false;
        }

        /// <summary>
        /// 注册
        /// </summary>
        private void btnReg_Click(object sender, EventArgs e)
        {
            var regCode = txtRegCode.Text.Trim();
            if (regCode == "")
            {
                MessageBox.Show("注册码输入不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.btnReg.Enabled = false;
            this.btnCancel.Enabled = false;

            var _regCode = _softReg.getRNum(_macCode); // 真实注册码

            if (!regCode.Equals(_regCode))
            {
                MessageBox.Show("注册码验证失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.btnReg.Enabled = !this.btnReg.Enabled;
                this.btnCancel.Enabled = !this.btnCancel.Enabled;
                return;
            }

            // 执行注册委托
            RegisterAction?.Invoke(_regCode);

            this.DialogResult = DialogResult.OK;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            _macCode = _softReg.getMNum();
            txtMCode.Text = _macCode;
            this.btnReg.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}