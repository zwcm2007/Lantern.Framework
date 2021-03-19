using DangKe.ImageProcessing.WinForm;
using DangKe.WinForm.Components;
using System.Windows.Forms;

namespace DangKe.WinForm.Sample
{
    public partial class ScanForm : HhForm
    {
        protected readonly ImageViewerContainerUC ImageViewerContainerUC;
        protected readonly ImageScanUC ImageScanUC;
        protected readonly ScanListUC ScanListUC;

        public ScanForm()
        {
            InitializeComponent();
            //
            ScanListUC = new ScanListUC() { Dock = DockStyle.Fill };
            ImageScanUC = new ImageScanUC(this) { Dock = DockStyle.Fill };
            ImageViewerContainerUC = new ImageViewerContainerUC() { Dock = DockStyle.Fill };

            this.splitContainer1.Panel2.Controls.Add(ImageScanUC);
            this.splitContainer2.Panel1.Controls.Add(ScanListUC);
            this.splitContainer2.Panel2.Controls.Add(ImageViewerContainerUC);
        }

        protected override void InitializeOnLoad()
        {
            base.InitializeOnLoad();
        }

        protected override void FinalizeOnClosed()
        {
            ImageScanUC.UpdateConfig();
        }
    }
}