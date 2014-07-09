using Shared.Core.Context;
using System;
using System.Collections.Generic;

namespace Shared.Core.IOC
{
    public abstract class IOCContainer : IIOCContainer
    {
        public static IIOCContainer Instance;

        private static IIOCContainerScopeProvider _scopeProvider;

        private const string ValuesComponents = "Components";

        /// <summary>
        /// Gets container to resolve components from.
        /// </summary>
        private static IIOCContainerScope Components { get; set; }

        public static void Initialize(IIOCContainerScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;

            Components = scopeProvider.BeginScope();

            Instance = Components.Resolve<IIOCContainer>();
        }

        public virtual T Resolve<T>()
        {
            return Components.Resolve<T>();
        }

        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return Components.ResolveAll<T>();
        }

        public virtual object Resolve(Type t)
        {
            return Components.Resolve(t);
        }

        public virtual T ResolveKeyed<T>(object t)
        {
            return Components.ResolveKeyed<T>(t);
        }
    }
}