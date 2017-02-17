using ATPDL.DataLoader.Interfaces;
using Ninject;

namespace ATPDL.Main
{
    public static class Program
    {
        public static void Main()
        {
            var kernel = NinjectDependency.BuildKernel();
            var loadPlayers = kernel.Get<ILoadPlayers>();

            var start = new StartLoadData(loadPlayers);
            start.Start().GetAwaiter().GetResult();
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
