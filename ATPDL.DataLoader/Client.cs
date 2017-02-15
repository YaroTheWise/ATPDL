using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATPDL.DataLoader.Builder;
using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.HttpClient;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification;
using ATPDL.Specification.Models;
using static System.Int32;

namespace ATPDL.DataLoader
{
    public class DataLoader
    {
        public async Task LoadPlayers()
        {
            var text = await Client.GetAllplayers();
            var list = RegexHelper.SearchListString(text, RegexPlayerInfoTemplates.Player);

            var players = GetPlayers(list);
        }



        private List<Player> GetPlayers(List<string> list)
        {
            List<Player> players = new List<Player>();

            foreach (var item in list)
            {
                var text = Client.Get(item);
                var player = PlayerBuilder.Build(text);
                players.Add(player);
            }

            return players;
        }
    }
}