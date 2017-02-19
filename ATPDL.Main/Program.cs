using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ATPDL.DataLoader.Interfaces;
using Ninject;

namespace ATPDL.Main
{

    public static class Test2
    {
        public static void Main2()
        {
            var t ="<a href=\"/en/players/christopher-o'connell/o483/overview\" data-ga-label=\"Christopher O'Connell\">Christopher O'Connell</a>";
            
            var r = new Regex(@"/en/players/\w*((-|%20|')\w*)+/\w*/overview");
            var l = r.Match(t);
        }
    }



    public static class Program
    {
        public static void Main()
        {
            ThreadPool.SetMinThreads(200, 200);
            var kernel = NinjectDependency.BuildKernel();
            var loadPlayers = kernel.Get<ILoadPlayers>();

            var start = new StartLoadData(loadPlayers);
            start.Start(941,2221).GetAwaiter().GetResult();
        }
    }

    public class Program1
    {
        public static void Main1(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Test(); //async, passes through immediately
            }
            Console.WriteLine("FIRST"); //prints sooner than pages
            Thread.Sleep(10000); //just to get the output from Test()
        }

        static async void Test()
        {
            var r = await DownloadPage("http://stackoverflow.com");
            Console.WriteLine(r.Substring(0, 50));
        }

        static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
