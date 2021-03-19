using System;
using System.Collections.Generic;

namespace HouHeng.Common.Data
{
    /// <summary>
    /// 视图模型映射基类
    /// </summary>
    public abstract class VMMappingBase<TSource, TDestination>
          where TSource : EntityBase
          where TDestination : VMBase
    {
        public virtual TDestination MapToVM(TSource source)
        {
            throw new NotImplementedException();
        }

        public virtual TSource MapFromVM(TDestination destination)
        {
            throw new NotImplementedException();
        }

        public virtual IList<TDestination> MapToVMs(IList<TSource> sources, int startPosition = 0)
        {
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));

            var vms = new List<TDestination>();
            foreach (var item in sources)
            {
                var vm = MapToVM(item);
                vm.No = ++startPosition;
                vms.Add(vm);
            }
            return vms;
        }

        public virtual IList<TSource> MapFromVMs(IList<TDestination> destinations)
        {
            if (destinations == null)
                throw new ArgumentNullException(nameof(destinations));

            var entities = new List<TSource>();

            foreach (var item in destinations)
            {
                var entity = MapFromVM(item);
                entities.Add(entity);
            }
            return entities;
        }
    }

    /// <summary>
    /// 对象映射接口
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public interface IEntityMapping<TSource, TDestination>
          where TSource : EntityBase
          where TDestination : VMBase
    {
        TDestination MapToVM(TSource source);

        IList<TDestination> MapToVMs(IList<TSource> sources, int startPosition = 0);

        TSource MapFromVM(TDestination destination);

        IList<TSource> MapFromVMs(IList<TDestination> destinations);
    }
}