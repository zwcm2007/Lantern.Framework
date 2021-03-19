using DevComponents.DotNetBar.Validator;
using System.Windows.Forms;

namespace DangKe.DotNetBar.Sample
{
    public partial class ValidatorUC : UserControl
    {
        public ValidatorUC()
        {
            InitializeComponent();
            //
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            this.superValidator1.CancelValidatingOnControl = false;
            this.superValidator1.ValidationType = eValidationType.ValidatingEventPerControl;
            this.superValidator1.SetValidator1(this.textBox1, new RequiredFieldValidator("必填"));
        }
    }
}