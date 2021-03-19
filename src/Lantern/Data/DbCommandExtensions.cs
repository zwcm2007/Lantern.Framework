using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Lantern.Data
{
    /// <summary>
    /// DbCommand扩展类
    /// </summary>
    public static class DbCommandExtensions
    {
        /// <summary>
        /// ExecuteDataTable扩展方法
        /// </summary>
        /// <param name="command"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(this DbCommand command, DbAccess db)
        {
            DataTable result = null;
            using (DbDataAdapter adapter = db.ProviderFactory.CreateDataAdapter())
            {
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                result = dt;
            }
            return result;
        }

        /// <summary>
        /// ExecuteDataSet扩展方法
        /// </summary>
        /// <param name="command"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(this DbCommand command, DbAccess db)
        {
            DataSet result = null;
            using (DbDataAdapter dbDataAdapter = db.ProviderFactory.CreateDataAdapter())
            {
                DataSet ds = new DataSet();
                dbDataAdapter.SelectCommand = command;
                dbDataAdapter.Fill(ds);
                result = ds;
            }
            return result;
        }

        /// <summary>
        /// ExecuteNonQuery扩展方法
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commmandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(this DbCommand command, string commmandText, IList<DbParameter> parameters = null, CommandType commandType = CommandType.Text)
        {
            command.CommandText = commmandText;
            command.CommandType = commandType;

            if (parameters != null && parameters.Count != 0)
            {
                command.Parameters.Clear();
                foreach (var item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
            int result = command.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// ExecuteScalar扩展方法
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commmandText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static object ExecuteScalar(this DbCommand command, string commmandText, IList<DbParameter> parameters = null,
            CommandType commandType = CommandType.Text)
        {
            command.CommandText = commmandText;
            command.CommandType = commandType;

            if (parameters != null && parameters.Count != 0)
            {
                command.Parameters.Clear();
                foreach (var item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
            object result = command.ExecuteScalar();
            return result;
        }
    }
}