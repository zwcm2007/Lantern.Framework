using System.Collections.Generic;
using System.Configuration;

namespace Lantern.Data
{
    /// <summary>
    /// 说 明: 数据库管理类
    /// 作 者: fengjueqing
    /// 时 间: 2017-03-21 10:12:45
    /// </summary>
    public static class DbManager
    {
        private static readonly IDictionary<string, DbAccess> _instances = new Dictionary<string, DbAccess>();

        static DbManager()
        {
            Refresh();
        }

        public static DbAccess Instance(string key = "default")
        {
            if (!_instances.ContainsKey(key))
            {
                throw new KeyNotFoundException($"找不到<connectionStrings>中name为\"{key}\"的配置项");
            }
            return _instances[key];
        }

        public static void Refresh()
        {
            _instances.Clear();

            for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            {
                var connSetting = ConfigurationManager.ConnectionStrings[i];

                DbAccess db = new DbAccess(connSetting.ConnectionString, connSetting.ProviderName);

                _instances.Add(connSetting.Name, db);
            }
        }
    }
}