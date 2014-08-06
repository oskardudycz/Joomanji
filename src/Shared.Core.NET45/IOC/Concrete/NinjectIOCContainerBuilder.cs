using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Web.Common;
using Shared.Core.IOC.Attributtes;
using Shared.Core.IOC.Builder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.NET45.IOC.Concrete
{
    public class NinjectIOCContainerBuilder : IOCContainerBuilderBase
    {
        private IKernel _kernel;

        private NinjectIOCContainerBuilder(IKernel kernel)
        {
            _kernel = kernel;
        }

        public static NinjectIOCContainerBuilder Create(IKernel kernel)
        {
            return new NinjectIOCContainerBuilder(kernel);
        }


        protected override Shared.Core.IOC.IIOCContainerScope CreateContainerScope()
        {
            return NinjectIOCContainerScope.Create(_kernel);
        }

        protected override void LoadAssemblies(Shared.Core.IOC.IIOCContainerScope scope)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            LoadAssembliesFromPath(baseDirectory, scope);

            string privateBinPath = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
            LoadAssembliesFromPath(privateBinPath, scope);
        }
        private void LoadAssembliesFromPath(string path, Shared.Core.IOC.IIOCContainerScope scope)
        {
            if (!Directory.Exists(path))
                return;

            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var assemblyFiles = Directory.GetFiles(path)
                .Where(file => Path.GetExtension(file).Equals(".dll", StringComparison.OrdinalIgnoreCase)
                            && currentAssemblies.All(a => a.GetName().Name != Path.GetFileNameWithoutExtension(file)))
                .ToList();

            foreach (var assemblyFilePath in assemblyFiles)
            {
                var assembly = Assembly.LoadFrom(assemblyFilePath);
                scope.Load(assembly);
            }
        }

        protected override void SetConventions(Shared.Core.IOC.IIOCContainerScope scope)
        {
            Bind(x => x.WithoutAttribute<NotInjectedWithConventionsAttribute>()
                .WithoutAttribute<InjectInSingletonScopeAttribute>()
                .WithoutAttribute<InjectInRequestScopeAttribute>()
                .Excluding(typeof(AllInstancesGetter<>))
                .BindDefaultInterfaces(), _kernel);

            Bind(x => x.WithoutAttribute<NotInjectedWithConventionsAttribute>()
                .WithAttribute<InjectInSingletonScopeAttribute>()
                .Excluding(typeof(AllInstancesGetter<>))
                .BindDefaultInterfaces()
                .Configure(el => el.InSingletonScope()), _kernel);

            Bind(x => x.WithoutAttribute<NotInjectedWithConventionsAttribute>()
                .WithAttribute<InjectInRequestScopeAttribute>()
                .Excluding(typeof(AllInstancesGetter<>))
                .BindDefaultInterfaces()
                .Configure(el => el.InRequestScope()), _kernel);
        }

        protected void Bind(Func<IJoinFilterWhereExcludeIncludeBindSyntax, IConfigureForSyntax> configure, IKernel kernel)
        {
            Func<IFromSyntax, IIncludingNonePublicTypesSelectSyntax> selectAllAssemblies = x => x.From(ReflectionExtensions.GetProjectAssemblies());

            kernel.Bind(x => configure(selectAllAssemblies(x).SelectAllClasses()));
        }
    }
}
