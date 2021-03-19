using System.Diagnostics;
using System.IO;

namespace Lantern.Utils
{
    /// <summary>
    /// Dos cmd命令执行工具类
    /// </summary>
    public class CmdUtil
    {
        #region 运行Dos命令

        /// <summary>
        /// 运行Dos命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public static string Run(string command)
        {
            string str = "";
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(startInfo))
            {
                if (process != null)
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        str = reader.ReadToEnd();
                    }
                    process.WaitForExit();
                }
            }
            return str.Trim();
        }

        /// <summary>
        /// 运行进程
        /// </summary>
        /// <param name="exe">执行程序路径</param>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public static string Run(string exe, string command)
        {
            string result = "";
            using (Process process = new Process())
            {
                process.StartInfo.FileName = exe;
                process.StartInfo.Arguments = command;
                process.StartInfo.UseShellExecute = false;//输出信息重定向
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();//启动线程
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                }
                process.WaitForExit();//等待进程结束
            }
            return result.Trim();
        }

        #endregion 运行Dos命令
    }
}