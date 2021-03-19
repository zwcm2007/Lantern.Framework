//using DangKe.Data;
using DangKe.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DangKe.WinForm.Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var a = "[{fieldLength: 50, defaultVal:\'档号\'},{fieldLength: 50, defaultVal:\'档号]'}]";

            //var dt = DbManager.Instance("setting").ExecuteDataTable($"select * from OperOption");

            var b = "[ { str1: \"黄某某1-0\", str2: \"001\", upTableKey: \"7440f751-6cd2-42ab-8a0f-7d04fc4c3097\", guidId: \"c028f3b2-a488-4413-9a5b-1c4c673db150\", sort: 0, webid: \"0-1-0\", webupid: \"1-0\" }, " +
                      "{ str1: \"黄某某2-4\", str2: \"001\", upTableKey: \"12793076-0217-4777-960d-b9011f9b80ba\", guidId: \"400eb2c9-1992-45db-b835-66378cc40cf4\", sort: 0, webid: \"3-2-0\", webupid: \"2-0\" }" +
                     "]";

            //DataTable dt = new DataTable();


            var cols = new List<DataGridViewColumn>();

            cols.Add(new DataGridViewTextBoxColumn() { Name = "str1", HeaderText = "标题1", DataPropertyName = "str1", Visible = true });
            cols.Add(new DataGridViewTextBoxColumn() { Name = "str2", HeaderText = "标题2", DataPropertyName = "str2", Visible = true });

            hhDataGridView1.Columns.AddRange(cols.ToArray());

            //hhDataGridView1.Columns.Add(new DataGridTextBoxColumn { HeaderText = "标题1" });
            //hhDataGridView1.Columns.Add(new DataGridViewColumn { DataPropertyName = "str2", HeaderText = "标题2" });


            var dt = JsonHelper.FromJson<DataTable>(b);

            DataView dv = dt.DefaultView;
            dv.RowFilter = $"upTableKey='12793076-0217-4777-960d-b9011f9b80ba'";
            hhDataGridView1.DataSource = dv;

            //hhDataGridView1.DataSource = dt;

        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData(string upTableKey)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            SeriLogHelper.Info("fdfdsf");
        }
    }
}