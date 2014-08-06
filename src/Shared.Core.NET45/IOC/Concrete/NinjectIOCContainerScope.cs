using Ninject;
using Ninject.Modules;
using Shared.Core.IOC;
using Shared.Core.IOC.Attributtes;
using Shared.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.NET45.IOC.Concrete
{
    [NotInjectedWithConventionsAttribute]
    public class NinjectIOCContainerScope : IIOCContainerScope
    {
        private readonly IKernel _activationBlock;

        private NinjectIOCContainerScope(IKernel activationBlock)
        {
            _activationBlock = activationBlock;
        }

        public static IIOCContainerScope Create(IKernel activationBlock)
        {
            var scope = new NinjectIOCContainerScope(activationBlock);

            scope.Bind<IIOCContainerScope, NinjectIOCContainerScope>(scope);

            return scope;
        }

        public T Resolve<T>()
        {
            return _activationBlock.Get<T>();
        }

        public object Resolve(Type t)
        {
            return _activationBlock.Get(t);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _activationBlock.GetAll<T>();
        }

        public T ResolveKeyed<T>(object t)
        {
            return _activationBlock.Get<T>(t.ToString());
        }

        public void Dispose()
        {
            _activationBlock.Dispose();
        }

        public void Bind<TInterface, TConcrete>()
            where TConcrete : TInterface
        {
            _activationBlock.Bind<TInterface>().To<TConcrete>();
        }


        public void Bind<TInterface, TConcrete>(TConcrete constant) where TConcrete : TInterface
        {
            _activationBlock.Bind<TInterface>().ToConstant<TConcrete>(constant);
        }

        public void Load(params Assembly[] assemblies)
        {
            _activationBlock.Load(assemblies);
        }

        public void Load(params IModule[] module)
        {
            _activationBlock.Load(module.Cast<INinjectModule>().ToArray());
        }

        public IList<IModule> GetLoadedModules()
        {
            return _activationBlock.GetModules().OfType<IModule>().ToList();
        }
    }
}
