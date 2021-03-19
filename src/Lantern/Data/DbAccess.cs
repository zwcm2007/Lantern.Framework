using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Lantern.Data
{
    /// <summary>
    /// 说 明: .NET通用数据库操作帮助类,可支持Odbc、OleDb、OracleClient、SqlClient、SqlServerCe等多种数据库提供程序操作
    /// 作 者: fengjueqing
    /// 时 间: 2017-03-21 10:12:45
    /// </summary>
    public sealed class DbAccess
    {
        #region 属性

        /// <summary>
        /// 当前默认配置的数据库提供程序DbProviderFactory
        /// </summary>
        public DbProviderFactory ProviderFactory { get; private set; }

        /// <summary>
        /// 当前的数据库提供程序类型
        /// </summary>
        public DbProviderType ProviderType { get; private set; }

        /// <summary>
        /// 当前的数据库连接字符串
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// 参数前缀
        /// </summary>
        public string DbParameterPrefix
        {
            get
            {
                string result;
                if (ProviderType == DbProviderType.Oracle || ProviderType == DbProviderType.OracleDataAccess
                    || ProviderType == DbProviderType.OracleManagedDataAccess)
                    result = ":";
                else
                    result = "@";
                return result;
            }
        }

        #endregion 属性

        #region 构造函数

        public DbAccess(string connectionString, string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
            {
                throw new ArgumentNullException(nameof(providerName), "数据库提供程序名称参数值不能为空,请在配置文件中配置该项值!");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "数据库链接串参数值不能为空,请在配置文件中配置该项值!");
            }

            //
            ConnectionString = connectionString;
            //
            ProviderType = ProviderFactoryHelper.GetDbProviderType(providerName);
            //创建默认配置的数据库提供程序
            ProviderFactory = CreateDbProviderFactory(providerName);
        }

        #endregion 构造函数

        #region 创建DbProviderFactory对象(静态方法)

        /// <summary>
        /// 根据配置的数据库提供程序的DbProviderName名称来创建一个数据库配置的提供程序DbProviderFactory对象
        /// </summary>
        public static DbProviderFactory CreateDbProviderFactory(string providerName)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(providerName);
            return dbFactory;
        }

        #endregion 创建DbProviderFactory对象(静态方法)

        #region 创建DbConnection对象(静态方法)

        /// <summary>
        /// 根据数据库连接字符串参数来创建数据库链接.
        /// </summary>
        /// <param name="connectionString">数据库连接配置字符串</param>
        /// <param name="providerName">数据库提供程序的名称</param>
        /// <returns></returns>
        public static DbConnection CreateDbConnection(string connectionString, string providerName)
        {
            DbProviderFactory dbFactory = CreateDbProviderFactory(providerName);
            DbConnection dbConn = dbFactory.CreateConnection();
            dbConn.ConnectionString = connectionString;
            return dbConn;
        }

        #endregion 创建DbConnection对象(静态方法)

        #region 创建DbCommand对象

        public DbCommand CreateDbCommand(string commandText, IList<DbParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            DbConnection connection = ProviderFactory.CreateConnection();
            //connection.ConnectionString = s_ConnectionString;
            connection.ConnectionString = ConnectionString;
            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            cmd.Parameters.Clear();
            if (parameters != null && parameters.Count != 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }
            return cmd;
        }

        #endregion 创建DbCommand对象

        #region 创建CreateDbParameter对象

        /// <summary>
        ///创建CreateDbParameter对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string name, object value, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            DbParameter parameter = ProviderFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = (value ?? "");
            if (value is DateTime)
            {
                parameter.DbType = DbType.DateTime;
            }
            parameter.Direction = parameterDirection;
            return parameter;
        }

        /// <summary>
        ///创建CreateDbParameter对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        public DbParameter CreateDbParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            DbParameter parameter = ProviderFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = (value ?? "");
            parameter.DbType = dbType;
            parameter.Direction = parameterDirection;
            return parameter;
        }

        #endregion 创建CreateDbParameter对象

        #region 执行事务

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool ExecuteTransaction(Action<DbCommand> action)
        {
            bool isSuccess = false;
            using (DbConnection connection = ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                using (DbTransaction trans = connection.BeginTransaction())
                {
                    using (DbCommand command = ProviderFactory.CreateCommand())
                    {
                        try
                        {
                            command.Transaction = trans;
                            command.Connection = connection;
                            action(command);
                            trans.Commit();
                            isSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            if (command.Connection != null)
                            {
                                command.Connection.Close();
                            }
                        }
                    }
                }
            }
            return isSuccess;
        }

        #endregion 执行事务

        #region ExecuteNonQuery

        /// <summary>
        /// 执行相应的SQL命令，返回影响的数据记录数，如果不成功则返回-1
        /// </summary>
        /// <param name="sql">需要执行的SQL命令</param>
        /// <returns>返回影响的数据记录数，如果不成功则返回-1</returns>
        public int ExecuteNonQuery(string commandText, IList<DbParameter> commandParameters = null, CommandType commandType = CommandType.Text)
        {
            using (DbCommand cmd = CreateDbCommand(commandText, commandParameters, commandType))
            {
                try
                {
                    cmd.Connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd.Connection != null)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        #endregion ExecuteNonQuery

        #region ExecuteDataSet

        /// <summary>
        /// 执行相应的SQL命令，返回一个DataSet数据集合
        /// </summary>
        /// <param name="sql">需要执行的SQL语句</param>
        /// <returns>返回一个DataSet数据集合</returns>
        public DataSet ExecuteDataSet(string commandText, IList<DbParameter> commandParameters = null, CommandType commandType = CommandType.Text)
        {
            using (DbCommand cmd = CreateDbCommand(commandText, commandParameters, commandType))
            {
                try
                {
                    DataSet ds = cmd.ExecuteDataSet(this);
                    return ds;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd.Connection != null)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
        }

        #endregion ExecuteDataSet

        #region ExecuteDataTable

        /// <summary>
        /// 执行相应的SQL命令，返回一个DataTable数据集
        /// </summary>
        /// <param name="sql">需要执行的SQL语句</param>
        /// <returns>返回一个DataTable数据集</returns>
        public DataTable ExecuteDataTable(string commandText, IList<DbParameter> commandParameters = null, CommandType commandType = CommandType.Text)
        {
            using (DbCommand cmd = CreateDbCommand(commandText, commandParameters, commandType))
            {
                try
                {
                    DataTable dt = cmd.ExecuteDataTable(this);
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (ProviderType != DbProviderType.SQLite) // 修改by fengjq 2017/5/9
                    {
                        if (cmd.Connection != null)
                        {
                            cmd.Connection.Close();
                        }
                    }
                }
            }
        }

        #endregion ExecuteDataTable

        #region ExecuteReader

        /// <summary>
        /// 执行相应的SQL命令，返回一个DbDataReader数据对象，如果没有则返回null值
        /// </summary>
        /// <param name="sql">需要执行的SQL命令</param>
        /// <returns>返回一个DbDataReader数据对象，如果没有则返回null值</returns>
        public DbDataReader ExecuteReader(string commandText, IList<DbParameter> commandParameters = null, CommandType commandType = CommandType.Text)
        {
            DbCommand cmd = CreateDbCommand(commandText, commandParameters, commandType);

            DbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);//当reader读取结束时自动关闭数据库链接

            return reader;
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        /// <summary>
        /// 执行相应的SQL命令，返回结果集中的第一行第一列的值，如果不成功则返回null值
        /// </summary>
        /// <param name="sql">需要执行的SQL命令</param>
        /// <returns>返回结果集中的第一行第一列的值，如果不成功则返回null值</returns>
        public object ExecuteScalar(string commandText, IList<DbParameter> commandParameters = null, CommandType commandType = CommandType.Text)
        {
            DbCommand cmd = CreateDbCommand(commandText, commandParameters, commandType);
            cmd.Connection.Open();
            object ret = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return ret;
        }

        #endregion ExecuteScalar
    }
}