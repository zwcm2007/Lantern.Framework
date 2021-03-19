using HouHeng.Common;
using System;
using System.Windows;

namespace HouHeng.WinForm.Common
{
    /// <summary>
    /// 注册码生成对话框
    /// </summary>
    public partial class GetLicenseDialog : HhDialog
    {
        /// <summary>
        /// 软件支持
        /// </summary>
        private SoftwareSupport _support;

        /// <summary>
        /// 序列号
        /// </summary>
        private string[] _lic = new string[4];

        /// <summary>
        /// 对话框标题
        /// </summary>
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public GetLicenseDialog(SoftwareSupport support)
        {
            InitializeComponent();
            //
            _support = support;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _support.GenerateLicense(this.txtMCode.Text, out string lic);

            for (int i = 0; i < 4; i++)
            {
                _lic[i] = lic.Substring(i * 4, 4);

                if (i == 0) txtLicPart1.Text = _lic[i];
                if (i == 1) txtLicPart2.Text = _lic[i];
                if (i == 2) txtLicPart3.Text = _lic[i];
                if (i == 3) txtLicPart4.Text = _lic[i];
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var lic = string.Join("-", _lic);

            Clipboard.SetDataObject(lic);
        }

        private void txtMCode_TextChanged(object sender, EventArgs e)
        {
            btnGenerate.Enabled = txtMCode.TextLength == txtMCode.MaxLength;
        }
    }
}