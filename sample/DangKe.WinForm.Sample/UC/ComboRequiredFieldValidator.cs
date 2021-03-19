using DevComponents.DotNetBar.Validator;
using System.Windows.Forms;

namespace DangKe.DotNetBar.Sample
{
    public class ComboRequiredFieldValidator : RequiredFieldValidator
    {
        public ComboRequiredFieldValidator(string errorMessage)
            : base(errorMessage)
        {
        }

        protected override bool IsEmpty(Control input, object value)
        {
            if (input is ComboBox cboBox)
            {
                if (value == null || value.ToString() == "" || value.ToString() == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return base.IsEmpty(input, value);
        }
    }
}