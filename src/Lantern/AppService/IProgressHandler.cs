using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lantern.AppService
{
    /// <summary>
    /// 进度处理程序
    /// </summary>
    /// <typeparam name="TProgress"></typeparam>
    public interface IProgressHandler<TProgress>
    {
        Task<ActionResult> ExecuteAsync(CancellationToken token = default, IProgress<TProgress> progress = null);
    }
}