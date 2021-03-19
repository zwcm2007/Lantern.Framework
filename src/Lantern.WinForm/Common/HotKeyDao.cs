using Lantern.Data;
using Lantern.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static Lantern.WinForm.Common.HotKeyEntity;

namespace Lantern.WinForm.Common
{
    /// <summary>
    /// 热键数据访问对象
    /// </summary>
    public class HotKeyDao
    {
        public DbAccess DB => DbManager.Instance("setting");

        public bool Update(HotKeyEntity entity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($"update {__TableName} set ");
            sql.Append($"{__KeyVal}={(int)entity.KeyVal},");
            sql.Append($"{__Modifier}={(int)entity.Modifier}");
            sql.Append(" where ");
            sql.Append($"{__Id}={entity.Id}");

            return DB.ExecuteNonQuery(sql.ToString()) > 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HotKeyEntity> GetAll()
        {
            var dt = DB.ExecuteDataTable($"select * from {__TableName} order by {__ClassId},{__Sort}");
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            var entities = new List<HotKeyEntity>();
            foreach (DataRow row in dt.Rows)
            {
                var id = row[__Id].ToInt16();

                entities.Add(new HotKeyEntity(id)
                {
                    ClassId = row[__ClassId].ToInt16(),
                    Modifier = (KeyModifiers)row[__Modifier].ToInt16(),
                    KeyVal = (Keys)row[__KeyVal].ToInt16(),
                    Name = row[__Name].ToString(),
                    Sort = row[__Sort].ToInt16(),
                    Code = row[__Code].ToString()
                });
            }
            return entities;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotKeyEntity GetEntityById(int id)
        {
            var dt = DB.ExecuteDataTable($"select * from {__TableName} where id={id}");
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                return new HotKeyEntity(dr[__Id].ToInt16())
                {
                    KeyVal = (Keys)dr[__KeyVal].ToInt16(),
                    Modifier = (KeyModifiers)dr[__Modifier].ToInt16(),
                    Code = dr[__Code].ToString(),
                    Name = dr[__Name].ToString(),
                    Sort = dr[__Sort].ToInt16(),
                    ClassId = dr[__ClassId].ToInt16()
                };
            }
            return null;
        }

        /// <summary>
        /// 热键是否已使用
        /// </summary>
        /// <returns></returns>
        public bool IsExist(KeyModifiers modifier, Keys keyVal)
        {
            string sql = $"select count(*) from {__TableName} where" +
                $" {__KeyVal}={(int)keyVal} and {__Modifier}={(int)modifier}";
            var result = DB.ExecuteScalar(sql);

            if (result.ToInt16() > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsExist(HotKeyEntity entity)
        {
            string sql = $"select count(*) from {__TableName} where {__Id}!={entity.Id}" +
                $" and {__KeyVal}={(int)entity.KeyVal} and {__Modifier}={(int)entity.Modifier}";
            var result = DB.ExecuteScalar(sql);

            if (result.ToInt16() > 0)
            {
                return true;
            }
            return false;
        }
    }
}