using DevComponents.DotNetBar.Validator;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DangKe.DotNetBar.Sample
{
    public partial class ValidatorUC2 : UserControl
    {
        public List<CodeNamePair> list = new List<CodeNamePair>();

        public ValidatorUC2()
        {
            InitializeComponent();
            //
            //
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.superValidator1.CancelValidatingOnControl = false;
            this.superValidator1.ValidationType = eValidationType.ValidatingEventPerControl;

            //var customValidator = new CustomValidator();
            //customValidator.GetValue += CustomValidator_GetValue;
            //customValidator.ValidateValue += CustomValidator_ValidateValue;

            var comboRequiredFieldValidator = new ComboRequiredFieldValidator("请选择");
            this.superValidator1.SetValidator1(this.comboBox1, comboRequiredFieldValidator);
            //
            //this.superValidator1.SetValidator1(this.comboBox1, customValidator);
        }

        private void ValidatorUC2_Load(object sender, System.EventArgs e)
        {
            //
            list.Add(new CodeNamePair("", ""));
            list.Add(new CodeNamePair("1", "青蛙"));
            list.Add(new CodeNamePair("2", "牛蛙"));
            list.Add(new CodeNamePair("3", "田鸡"));

            comboBox1.DataSource = list;
            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedValue = "1";
        }

        private void comboBox1_Validated(object sender, System.EventArgs e)
        {
            //superValidator1.Validate();
        }

        private void CustomValidator_GetValue(object sender, ValidatorGetValueEventArgs ea)
        {
            throw new System.NotImplementedException();
        }

        private void CustomValidator_ValidateValue(object sender, ValidateValueEventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() == "")
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
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