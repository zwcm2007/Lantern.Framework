using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lantern.AppService
{
    /// <summary>
    /// 实体基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TKey> : EntityBase
    {
        [Key]
        [DisplayName("主键")]
        public TKey Id { get; set; }

        public EntityBase()
        {
            //if (typeof(TKey) == typeof(Guid))
            //{
            //    Id = Guid.NewGuid();
            //}
        }

        /// <summary>
        /// 判断两个实体是否是同一数据记录的实体
        /// </summary>
        /// <param name="obj">要比较的实体信息</param>
        /// <returns></returns>
        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }

        //    var entity = obj as EntityBase<TKey>;
        //    if (entity == null)
        //    {
        //        return false;
        //    }
        //    return entity.Id.Equals(this.Id);
        //}

        /// <summary>
        /// 用作特定类型的哈希函数
        /// </summary>
        /// <returns></returns>
        //public override int GetHashCode()
        //{
        //    if (Id == null)
        //    {
        //        return 0;
        //    }
        //    return Id.ToString().GetHashCode();
        //}
    }

    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class EntityBase
    {
        protected string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}