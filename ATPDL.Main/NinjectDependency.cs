using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace ATPDL.Main
{
    public static class NinjectDependency
    {
        public static IKernel BuildKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind(x =>
                x.FromAssembliesMatching("ATPDL.*.dll")
                    .SelectAllClasses()
                    .BindAllInterfaces());

            kernel.Bind(x =>
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindAllInterfaces());
            
            return kernel;
        }
    }
}