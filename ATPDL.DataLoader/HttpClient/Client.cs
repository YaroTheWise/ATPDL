using System;
using System.Threading.Tasks;

namespace ATPDL.DataLoader.HttpClient
{
    public static class Client
    {
        private const string url = "http://www.atpworldtour.com";
        private const string urlRankings = "/en/rankings/singles/?rankRange=1-10";
        
        private static System.Net.Http.HttpClient HttpClient { get; set; }

        static Client()
        {
            HttpClient = new System.Net.Http.HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public static async Task<string> GetAllplayers()
        {
            var response = await HttpClient.GetAsync(urlRankings);
            return response.Content.ReadAsStringAsync().Result;
        }

        public static string Get(string url)
        {
            var response = HttpClient.GetAsync(url).GetAwaiter().GetResult(); ;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}