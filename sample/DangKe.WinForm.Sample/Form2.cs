using DangKe.WinForm.Components;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DangKe.WinForm.Sample
{
    public partial class Form2 : Form
    {
        public List<CodeNamePair> list = new List<CodeNamePair>();

        public Form2()
        {
            InitializeComponent();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            list.Add(new CodeNamePair("1", "青蛙"));
            list.Add(new CodeNamePair("2", "牛蛙"));
            list.Add(new CodeNamePair("3", "田鸡"));

            var cboBox1 = new HhComboBox();

            cboBox1.DataSource = list;
            cboBox1.ValueMember = "Code";
            cboBox1.DisplayMember = "Name";
            cboBox1.SelectedValue = "2";

            this.Controls.Add(cboBox1);
        }

        private void hhButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.hhComboBox1.SelectedValue.ToString());
            this.hhComboBox1.SelectedValue = "3";
        }
    }

    /// <summary>
    /// 键/值对
    /// </summary>
    public class CodeNamePair
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        public CodeNamePair(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}