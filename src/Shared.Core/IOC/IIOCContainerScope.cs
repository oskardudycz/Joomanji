using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.IOC
{
    public interface IIOCContainerScope : IIOCContainer, IDisposable
    {
        void Bind<TInterface, TConcrete>() where TConcrete : TInterface;
        void Bind<TInterface, TConcrete>(TConcrete constant) where TConcrete : TInterface;
    }
}
