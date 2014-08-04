using System.Collections.Generic;
using System.Linq;
using Shared.Core.IOC;

namespace Shared.Core.IOC.Attributtes
{
    public interface IAllInstancesGetter<T>
    {
        IList<T> List { get; }
    }

    public class AllInstancesGetter<T> : IAllInstancesGetter<T>
    {
        private IList<T> _list;

        public IList<T> List
        {
            get { return _list ?? (_list = IOCContainer.Instance.ResolveAll<T>().ToList()); }
        }
    }
}