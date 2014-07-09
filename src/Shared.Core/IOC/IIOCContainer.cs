using Shared.Core.IOC.Attributtes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.IOC
{
    public interface IIOCContainer
    {
        T Resolve<T>();
        object Resolve(Type t);

        IEnumerable<T> ResolveAll<T>();
        T ResolveKeyed<T>(object t);
    }
}
