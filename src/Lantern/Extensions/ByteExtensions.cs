using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lantern.Extensions
{
    /// <summary>
    /// byte类型的扩展辅助操作类
    /// </summary>
    public static class ByteExtensions
    {
        #region To(字节转换)

        /// <summary>
        /// 将byte[]数组转为字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="bytes">byte[]数组</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>字符串</returns>
        public static string ToString(this byte[] bytes, Encoding encoding)
        {
            encoding = (encoding ?? Encoding.UTF8);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// 字节数组转换为16进制字符串表示形式
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>16进制字符串</returns>
        public static string ToHexString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0}", b.ToString("X2").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将byte[]转换成int
        /// </summary>
        /// <param name="bytes">需要转换成整数的byte[]</param>
        /// <returns></returns>
        public static int ToInt(this byte[] bytes)
        {
            //如果传入的字节数组长度小于4,则返回0
            if (bytes.Length < 4)
            {
                return 0;
            }
            int num = 0;
            //如果传入的字节数组长度大于4,需要进行处理
            if (bytes.Length >= 4)
            {
                //创建一个临时缓冲区
                byte[] tempBuffer = new byte[4];
                //将传入的字节数组的前4个字节复制到临时缓冲区
                Buffer.BlockCopy(bytes, 0, tempBuffer, 0, 4);
                //将临时缓冲区的值转换成整数，并赋给num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }
            return num;
        }

        /// <summary>
        /// 将byte[]转换为Base64字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将byte[]转换成long
        /// </summary>
        /// <param name="bytes">需要转换成整数的byte[]</param>
        /// <returns></returns>
        public static long ToInt64(this byte[] bytes)
        {
            //如果传入的字节数组长度小于8,则返回0
            if (bytes.Length < 8)
            {
                return 0;
            }
            long num = 0;
            if (bytes.Length >= 8)
            {
                //创建一个临时缓冲区
                byte[] tempBuffer = new byte[8];
                //将传入的字节数组的前8个字节复制到临时缓冲区
                Buffer.BlockCopy(bytes, 0, tempBuffer, 0, 8);
                //将临时缓冲区的值转换成证书，并赋给num
                num = BitConverter.ToInt64(tempBuffer, 0);
            }
            return num;
        }

        /// <summary>
        /// 将byte[]转换成long
        /// </summary>
        /// <param name="bytes">需要转换成整数的byte[]</param>
        /// <param name="startIndex">开始索引</param>
        /// <returns></returns>
        public static long ToInt64(this byte[] bytes, int startIndex)
        {
            //如果传入的字节数组长度小于8,则返回0
            if (bytes.Length < 8)
            {
                return 0;
            }
            return BitConverter.ToInt64(bytes, startIndex);
        }

        /// <summary>
        /// 将byte[]转换成指定编码的字符串
        /// </summary>
        /// <param name="data">需要转换的byte[]</param>
        /// <param name="encoding">字符串编码</param>
        /// <returns></returns>
        public static string Decode(this byte[] data, Encoding encoding)
        {
            return encoding.GetString(data);
        }

        /// <summary>
        /// 使用指定算法加密，并返回加密后的byte[]
        /// </summary>
        /// <param name="data">byte[]</param>
        /// <param name="hashName">Hash名称</param>
        /// <returns></returns>
        public static byte[] Hash(this byte[] data, string hashName = "")
        {
            HashAlgorithm algorithm;
            if (string.IsNullOrEmpty(hashName))
            {
                algorithm = HashAlgorithm.Create();
            }
            else
            {
                algorithm = HashAlgorithm.Create(hashName);
            }
            return algorithm.ComputeHash(data);
        }

        /// <summary>
        /// 将byte[]转换成内存流
        /// </summary>
        /// <param name="data">byte[]</param>
        /// <returns></returns>
        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }

        #endregion To(字节转换)
    }
}