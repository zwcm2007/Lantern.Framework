using DangKe.WinForm.Common;
using DangKe.WinForm.Components;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DangKe.WinForm.Sample
{
    public partial class Form3 : HhForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        protected override List<HotKeyEntity> FormHotKeys
        {
            get
            {
                base.FormHotKeys.Add(new HotKeyEntity(10)
                {
                    KeyVal = Keys.Escape,
                    CallBack = () =>
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                });
                return base.FormHotKeys;
            }
        }
    }
}