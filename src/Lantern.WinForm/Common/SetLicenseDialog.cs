using HouHeng.Common;
using System;
using System.Windows.Forms;

namespace HouHeng.WinForm.Common
{
    /// <summary>
    /// 软件注册对话框
    /// </summary>
    public partial class SetLicenseDialog : HhDialog
    {
        /// <summary>
        /// 软件支持
        /// </summary>
        private SoftwareSupport _support;

        /// <summary>
        /// 序列号
        /// </summary>
        private string License
        {
            get
            {
                return $"{txtLicPart1.Text}{txtLicPart2.Text}{txtLicPart3.Text}{txtLicPart4.Text}";
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="support"></param>
        public SetLicenseDialog(SoftwareSupport support)
        {
            InitializeComponent();
            //
            _support = support;
        }

        protected override void InitializeOnLoad()
        {
            base.InitializeOnLoad();
            //
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            _support.SetLicense(License);

            this.btnReg.Enabled = false;
            this.btnCancel.Enabled = false;

            if (!_support.IsLocked)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("序列号验证失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnReg.Enabled = !btnReg.Enabled;
                btnCancel.Enabled = !btnCancel.Enabled;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            txtMCode.Text = _support.LocalMacNum;
            txtLicPart1.Focus();
        }

        private void txtLicPart_TextChanged(object sender, EventArgs e)
        {
            var txtLicPart = sender as TextBox;

            if (txtLicPart.TextLength == 4)
            {
                if (txtLicPart == txtLicPart1)
                {
                    txtLicPart2.Focus();
                }
                else if (txtLicPart == txtLicPart2)
                {
                    txtLicPart3.Focus();
                }
                else if (txtLicPart == txtLicPart3)
                {
                    txtLicPart4.Focus();
                }
            }

            btnReg.Enabled = License.Length == 16;
        }

        private void txtLicPart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}