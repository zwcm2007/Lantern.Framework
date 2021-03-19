using Lantern.AppService;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lantern.WinForm.Components
{
    /// <summary>
    /// 进度条
    /// </summary>
    public partial class HhProgressDialog<TProgress> : HhDialog, IProgress<TProgress>
    {
        /// <summary>
        /// 进度处理程序
        /// </summary>
        private IProgressHandler<TProgress> _handler;

        /// <summary>
        /// 取消令牌源
        /// </summary>
        protected CancellationTokenSource CancellationTokenSource { get; private set; } = new CancellationTokenSource();

        /// <summary>
        /// 操作结果
        /// </summary>
        public ActionResult ActionResult { get; private set; } = new ActionResult(ActResultType.NoChanged);

        /// <summary>
        /// 进度显示
        /// </summary>
        protected string ProgressDisplay
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// 是否可取消
        /// </summary>
        public bool CanCancel
        {
            get { return btnCancel.Enabled; }
            set { btnCancel.Enabled = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public HhProgressDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public HhProgressDialog(IProgressHandler<TProgress> handler)
            : this()
        {
            _handler = handler;
        }

        protected override void InitializeOnLoad()
        {
            base.InitializeOnLoad();
            //
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    if (_handler != null)
                    {
                        ActionResult = await _handler.ExecuteAsync(CancellationTokenSource.Token, this);
                    }
                }
                finally
                {
                    DialogResult = DialogResult.OK;
                }
            },
            CancellationTokenSource.Token);
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();

            ActionResult.ResultType = ActResultType.Cancel;

            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 报告进度
        /// </summary>
        /// <param name="value"></param>
        public virtual void Report(TProgress value)
        {
        }
    }
}