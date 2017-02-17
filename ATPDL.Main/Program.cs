using System;
using System.Reflection;
using System.Threading;
using ATPDL.Service;
using ATPDL.Specification.Game;
using Ninject;

namespace ATPDL.Main
{
    public static class Program
    {
        public static void Main()
        {
            var kernel = NinjectDependency.BuildKernel();
            //Test.GoMatch();

            //   var client = new DataLoader.DataLoader();
            // client.LoadPlayers().GetAwaiter().GetResult();

            //var kernel = new StandardKernel();
            //kernel.Load(Assembly.GetExecutingAssembly());


            // kernel.Load(Assembly.GetExecutingAssembly());
            
            
            //var intenal = kernel.Get<IInternalInterface>();
            //test.Test();
        }
    }

   
}
