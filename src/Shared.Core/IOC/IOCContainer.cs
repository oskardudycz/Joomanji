using Shared.Core.Context;
using Shared.Core.IOC.Attributtes;
using System;
using System.Collections.Generic;

namespace Shared.Core.IOC
{
    [NotInjectedWithConventions]
    public class IOCContainer : IIOCContainer
    {
        public static IIOCContainer Instance { get; private set; }

        private IOCContainer(IIOCContainerScope scope)
        {
            ContainerScope = scope;
        }

        /// <summary>
        /// Gets container to resolve components from.
        /// </summary>
        private IIOCContainerScope ContainerScope { get; set; }

        public static void Initialize(IIOCContainerScope scope)
        {
            Instance = new IOCContainer(scope);
            scope.Bind<IIOCContainer, IOCContainer>((IOCContainer)Instance);
        }

        public virtual T Resolve<T>()
        {
            return ContainerScope.Resolve<T>();
        }

        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return ContainerScope.ResolveAll<T>();
        }

        public virtual object Resolve(Type t)
        {
            return ContainerScope.Resolve(t);
        }

        public virtual T ResolveKeyed<T>(object t)
        {
            return ContainerScope.ResolveKeyed<T>(t);
        }
    }
}