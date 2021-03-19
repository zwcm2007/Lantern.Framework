using System.Collections.Generic;
using System.Data.Common;

namespace Lantern.Data
{
    /// <summary>
    /// ProviderFactory帮助类
    /// </summary>
    public class ProviderFactoryHelper
    {
        private static Dictionary<DbProviderType, string> providerInvariantNames;

        private static Dictionary<DbProviderType, DbProviderFactory> providerFactories;

        static ProviderFactoryHelper()
        {
            providerInvariantNames = new Dictionary<DbProviderType, string>();
            providerFactories = new Dictionary<DbProviderType, DbProviderFactory>();
            providerInvariantNames.Add(DbProviderType.SqlServer, "System.Data.SqlClient");
            providerInvariantNames.Add(DbProviderType.OleDb, "System.Data.OleDb");
            providerInvariantNames.Add(DbProviderType.ODBC, "System.Data.ODBC");
            providerInvariantNames.Add(DbProviderType.Oracle, "System.Data.OracleClient");
            providerInvariantNames.Add(DbProviderType.OracleDataAccess, "Oracle.DataAccess.Client");
            providerInvariantNames.Add(DbProviderType.OracleManagedDataAccess, "Oracle.ManagedDataAccess.Client");
            providerInvariantNames.Add(DbProviderType.MySql, "MySql.Data.MySqlClient");
            providerInvariantNames.Add(DbProviderType.SQLite, "System.Data.SQLite");
            providerInvariantNames.Add(DbProviderType.Firebird, "FirebirdSql.Data.Firebird");
            providerInvariantNames.Add(DbProviderType.PostgreSql, "Npgsql");
            providerInvariantNames.Add(DbProviderType.DB2, "IBM.Data.DB2.iSeries");
            providerInvariantNames.Add(DbProviderType.Informix, "IBM.Data.Informix");
            providerInvariantNames.Add(DbProviderType.SqlServerCe, "System.Data.SqlServerCe");
        }

        /// <summary>
        /// 将提供程序类型转成对应程序名称
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static string GetProviderInvariantName(DbProviderType providerType)
        {
            return providerInvariantNames[providerType];
        }

        /// <summary>
        /// 将提供程序名称转成对应程序类型
        /// </summary>
        /// <param name="providerInvariantName"></param>
        /// <returns></returns>
        public static DbProviderType GetDbProviderType(string providerInvariantName)
        {
            DbProviderType returnType = DbProviderType.Unknown;
            foreach (var item in providerInvariantNames)
            {
                if (item.Value == providerInvariantName)
                {
                    returnType = item.Key;
                    break;
                }
            }
            return returnType;
        }

        public static DbProviderFactory GetDbProviderFactory(DbProviderType providerType)
        {
            if (!providerFactories.ContainsKey(providerType))
            {
                providerFactories.Add(providerType, ImportDbProviderFactory(providerType));
            }
            return providerFactories[providerType];
        }

        private static DbProviderFactory ImportDbProviderFactory(DbProviderType providerType)
        {
            string providerName = providerInvariantNames[providerType];
            DbProviderFactory factory = null;
            try
            {
                factory = DbProviderFactories.GetFactory(providerName);
            }
            catch
            {
                factory = null;
            }
            return factory;
        }
    }
}