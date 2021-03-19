using System;
using System.Security.Cryptography;
using System.Text;

namespace Lantern.Windows
{
    /// <summary>
    /// 软件支持
    /// </summary>
    public class SoftwareSupport
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">软件ID</param>
        /// <param name="name">软件名称</param>
        public SoftwareSupport(string id, string name = null)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// 软件ID
        /// </summary>
        public string ID { get; private set; }

        /// <summary>
        /// 软件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 本地机器码
        /// </summary>
        public string LocalMacNum => new SoftReg().getMNum();

        /// <summary>
        /// 生成序列号
        /// </summary>
        /// <param name="macNum">机器码</param>
        /// <param name="lic">16位序列号</param>
        public void GenerateLicense(string macNum, out string lic)
        {
            var uid = $"{macNum}_{ID}";

            lic = GetMd5Str(uid);

            //Directory.CreateDirectory("Output");

            //using (var zip = new ZipFile($"Output\\zj_license_file-{macNum}.zip"))
            //{
            //    zip.AddEntry("license.key", lic);
            //    zip.Save();
            //}
        }

        /// <summary>
        /// 是否锁定
        /// </summary>
        /// <returns></returns>
        public bool IsLocked
        {
            get
            {
                var lic = RegistryUtil.GetValue(RegistryBaseKey.CurrentUser, $"Software\\{Name}", "RegCode");
                if (lic == null)
                {
                    return true;
                }

                var uid = $"{LocalMacNum}_{ID}";

                if (lic.ToString() != GetMd5Str(uid))
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 设置序列号
        /// </summary>
        public void SetLicense(string license)
        {
            RegistryUtil.SetValue(RegistryBaseKey.CurrentUser, $"Software\\{Name}", "RegCode", license);
        }

        private string GetMd5Str(string ConvertString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
            return t2.Replace("-", "").ToUpper();
        }

        /// <summary>
        /// 设置序列号
        /// </summary>
        //public void SetLicenseFromZip(string path)
        //{
        //    using (var zip = new ZipFile(path))
        //    {
        //        ZipEntry e = zip["license.key"];
        //        e.Extract(Path.GetTempPath());
        //        var license = File.ReadAllText($"{Path.GetTempPath()}\\license.key");
        //        RegistryUtil.SetValue(RegistryBaseKey.CurrentUser, $"Software\\{Name}", "RegCode", license);
        //    }
        //}

        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        //private string GetRNum(string macNum)
        //{
        //    return new SoftReg().getRNum(macNum);
        //}
    }
}