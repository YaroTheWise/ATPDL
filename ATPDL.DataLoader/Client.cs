using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATPDL.Specification;
using static System.Int32;

namespace ATPDL.DataLoader
{
    //public class Client1
    //{
    //    private const string url = "http://www.atpworldtour.com";
    //    private const string template = @"/en/players/\w*(-\w*)+/\w*/overview";
    //    private const int topCount = 10; //2000

    //    private readonly int i;

    //    public Client1()
    //    {
            
    //    }

    //    public async Task GetData()
    //    {
    //        var client = new HttpClient();

    //        client.BaseAddress = new Uri(url);
    //        HttpResponseMessage t = await client.GetAsync($"/en/rankings/singles/?rankRange=1-{topCount}");

    //        var text = t.Content.ReadAsStringAsync().Result;
    //        Regex regex = new Regex(template);

    //       var urls = regex.Matches(text);
    //        var urlList = urls.Cast<Match>().Select(match => match.Value).ToList();
    //        PersonBilder(urlList);
    //    }

    //    private void PersonBilder(List<string> urls)
    //    {

    //        var 
    //        throw new NotImplementedException();
    //    }
    //}


    public class DataLoader
    {
        public async Task LoadPlayers()
        {
            var text = await Client.GetAllplayers();
            var list = TextSearcher.SearchListString(text, RegexTemplates.Player);

            var players = GetUsers(list);
        }

        private List<Player> GetUsers(List<string> list)
        {
            List<Player> players = new List<Player>();

            foreach (var item in list)
            {
                var text = Client.Get(item);
                var player = TextSearcher.PlayerBuilder(text);
                players.Add(player);
            }

            return players;
        }
    }

    public static class RegexTemplates
    {
        public const string Player = @"/en/players/\w*(-\w*)+/\w*/overview";
        public const string BirthDay = "<span class=\"table-birthday\">\\s*\\((?<id>\\d{4}.\\d{2}.\\d{2})\\)\\s*</span>";
        public const string StartYear = "Turned Pro</div>\\s*<div class=\"table-big-value\">\\s*(?<id>\\d{4})\\s*</div>";
        //public const string BirthdayPlace1 = "Birthplace</div><div class=\"table-value\">(?<id>\\s*)</div>";
        public const string BirthdayPlace = "Birthplace(\\r|\\n|\\t)*</div>(\\r|\\n|\\t)*<div class=\"table-value\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>";
        public const string FirstName = "<div class=\"first-name\">(?<id>\\w+)</div>";
        public const string LastName = "<div class=\"last-name\">(?<id>\\w+)</div>";
        public const string SinglesRanking = "div data-singles=\"(?<id>\\d+)\" data-doubles=\"\\d+\"";
        public const string DoublesRanking = "div data-singles=\"\\d+\" data-doubles=\"(?<id>\\d+)\"";
        public const string PlayerCode = @"/en/players/\w*(-\w*)+/(?<id>\w*)/overview";
        public const string PlayerNameCode = @"/en/players/(?<id>\w*(-\w*)+)/\w*/overview";
    }

    public static class TextSearcher
    {
        public static List<string> SearchListString(string text, string template)
        {
            var regex = new Regex(template);
            var matches = regex.Matches(text);

            return matches.Cast<Match>().Select(match => match.Value).ToList();
        }

        public static Player PlayerBuilder(string text)
        {
            return new Player
            {
                Birthday = GetValueDate(text, RegexTemplates.BirthDay),
                Code = GetValueString(text, RegexTemplates.PlayerCode),
                NameCode = GetValueString(text, RegexTemplates.PlayerNameCode),
                FirstName = GetValueString(text, RegexTemplates.FirstName),
                LastName = GetValueString(text, RegexTemplates.LastName),
                StartYear = GetValueInt(text, RegexTemplates.StartYear),
                BirthdayPlace = GetValueString(text, RegexTemplates.BirthdayPlace),
                SinglesRanking = GetValueInt(text, RegexTemplates.SinglesRanking),
                DoublesRanking = GetValueInt(text, RegexTemplates.DoublesRanking),
            };
        }

        private static string GetValueString(string text, string template)
        {
            var regex = new Regex(template);
            var match = regex.Match(text);

            return match.Groups["id"].Value.Trim();
        }

        private static int GetValueInt(string text, string template)
        {
            var regex = new Regex(template);
            var match = regex.Match(text);

            var str = match.Groups["id"].Value;

            int result;
            return !TryParse(str, out result) ? 0 : result;
        }

        private static DateTime GetValueDate(string text, string template)
        {
            var regex = new Regex(template);
            var match = regex.Match(text);

            var str = match.Groups["id"].Value;

            DateTime result;
            if (!DateTime.TryParse(str, out result))
            {
                return new DateTime(1980,1,1);
            }

            return result;
        }
    }

    public static class Client
    {
        private const string url = "http://www.atpworldtour.com";
        private const string urlRankings = "/en/rankings/singles/?rankRange=1-10";
        
        private static HttpClient HttpClient { get; set; }

        static Client()
        {
            HttpClient = new HttpClient
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