using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lantern.Utils
{
    /// <summary>
    /// FTP工具
    /// </summary>
    public class FtpUtil
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FtpUtil()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FtpUtil(string host, int port, string userName, string password)
        {
            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="localDir"></param>
        /// <param name="remotePaths"></param>
        public int DownloadFiles(string localDir, IEnumerable<string> remotePaths)
        {
            FtpClient client = null;

            try
            {
                int ret = 0;

                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Encoding = Encoding.UTF8;
                client.Connect();

                if (client.IsConnected)
                {
                    ret = client.DownloadFiles(localDir, remotePaths);
                }
                return ret;
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="localDir"></param>
        /// <param name="remotePaths"></param>
        public async Task<int> DownloadFilesAsync(string localDir, IEnumerable<string> remotePaths, CancellationToken tokenSource = default, IProgress<FtpProgress> progress = null)
        {
            FtpClient client = null;

            try
            {
                int ret = 0;

                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Encoding = Encoding.UTF8;
                client.Connect();

                if (client.IsConnected)
                {
                    ret = await client.DownloadFilesAsync(localDir, remotePaths, FtpLocalExists.Overwrite, FtpVerify.None, FtpError.None, tokenSource, progress);
                }
                return ret;
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="localPaths"></param>
        /// <param name="remoteDir"></param>
        /// <returns></returns>
        public int UploadFiles(IEnumerable<string> localPaths, string remoteDir)
        {
            FtpClient client = null;

            try
            {
                int ret = 0;

                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Encoding = System.Text.Encoding.UTF8;
                client.Connect();

                if (client.IsConnected)
                {
                    //if (client.DirectoryExists(remotePath))
                    //{
                    //    client.DeleteDirectory(remotePath);
                    //}

                    ret = client.UploadFiles(localPaths, remoteDir);
                }

                return ret;
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="localPaths"></param>
        /// <param name="remoteDir"></param>
        /// <returns></returns>
        public async Task<int> UploadFilesAsync(IEnumerable<string> localPaths, string remoteDir, bool clearDirBeforeUpload, CancellationToken tokenSource = default, IProgress<FtpProgress> progress = null)
        {
            FtpClient client = null;

            try
            {
                int ret = 0;

                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Encoding = Encoding.UTF8;
                client.Connect();

                if (client.IsConnected)
                {
                    if (clearDirBeforeUpload && client.DirectoryExists(remoteDir))
                    {
                        client.DeleteDirectory(remoteDir);
                    }

                    ret = await client.UploadFilesAsync(localPaths, remoteDir, FtpRemoteExists.Overwrite, true, FtpVerify.None, FtpError.None, tokenSource, progress);
                }

                return ret;
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 获取远程目录文件数量
        /// </summary>
        /// <returns></returns>
        public int GetFileCount(string remotePath)
        {
            FtpClient client = null;

            try
            {
                int ret = 0;

                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Connect();

                if (client.IsConnected)
                {
                    FtpListItem[] items = client.GetListing(remotePath);

                    ret = items.Where(item => item.Type == FtpFileSystemObjectType.File && Path.GetExtension(item.Name).ToLower() == ".tif")
                       .Count();
                }

                return ret;
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task DeleteFileAsync(string path)
        {
            FtpClient client = null;

            try
            {
                client = new FtpClient(Host, Port, new NetworkCredential(UserName, Password));
                client.ConnectTimeout = 5000;
                client.Encoding = Encoding.UTF8;
                client.Connect();

                if (client.IsConnected)
                {
                    await client.DeleteFileAsync(path);
                }
            }
            finally
            {
                if (client != null)
                {
                    if (client.IsConnected)
                        client.Disconnect();
                    client.Dispose();
                }
            }
        }
    }
}