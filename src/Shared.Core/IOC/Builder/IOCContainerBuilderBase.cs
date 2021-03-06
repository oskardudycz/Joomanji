﻿using Shared.Core.IOC.Attributtes;
using Shared.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.IOC.Builder
{

    [NotInjectedWithConventions]
    public abstract class IOCContainerBuilderBase : IIOCContainerBuilder
    {
        public void Build()
        {
            var scope = CreateContainerScope();

            LoadAssemblies(scope);
            LoadModules(scope);
            SetConventions(scope);

            IOCContainer.Initialize(scope);
        }

        protected abstract IIOCContainerScope CreateContainerScope();

        protected abstract void LoadAssemblies(IIOCContainerScope scope);

        private void LoadModules(IIOCContainerScope scope)
        {
            var modules = scope.ResolveAll<IModule>();
            var currentlyLoadedModulesNames = scope.GetLoadedModules().Select(el=>el.Name).ToList();

            var notLoadedModules = modules.Where(el => !currentlyLoadedModulesNames.Contains(el.Name)).ToList();

            scope.Load(modules.ToArray());
        }

        protected abstract void SetConventions(IIOCContainerScope scope);        
    }
}
