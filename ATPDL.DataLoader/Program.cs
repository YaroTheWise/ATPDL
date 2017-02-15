using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATPDL.DataLoader
{
    public static class Program
    {
        public static void Main()
        {
            //var text = "<span class=\"table-birthday\">(1233.22.11)</span>";
            //var regex = new Regex("<span class=\"table-birthday\">\\((?<id>\\d{4}.\\d{2}.\\d{2})\\)</span>");

            //var match = regex.Match(text);

            //var t =  match.Groups["id"].Value;

            //var t = new HttpClient
            //{
            //    BaseAddress = new Uri("http://www.atpworldtour.com")
            //};

            //var response = t.GetAsync("/en/players/alexander-zverev/z355/overview").GetAwaiter().GetResult();
            //var t2 = response.Content.ReadAsStringAsync().Result;
            //var re34sponse = t.GetAsync("/en/players/alexander-zverev/z355/overview").GetAwaiter().GetResult();

  //          var text1 = @"t	Birthplace
		////</div>
		////<div class=""table-value"">
		////	Glasgow, Scotland
		////</div>";
  //          var text2 = @"t	Birthplace</div><div class=""table-value"">
		//	Glasgow, Scotland
		//</div>";


  //          var rt = "\\ru";

  //          var regex4 = new Regex("(?=[\r]).*");
  //          var matx = regex4.Match(rt);


  //          var text21 = @"Birthplace</div><div class=""table-value"">Glasgow, Scotland</div>";
  //          //var text21 = @"Birthplace</div><div class=""table-value""></div>";
  //          var regex = new Regex("Birthplace.*</div>.*<div class=\"table-value\">(?<id>.*)</div>");
  //          var regex2 = new Regex("Birthplace</div><div class=\"table-value\">(?<id>.*)</div>");
  //          var regex3 = new Regex("Birthplace(\\r|\\n|\\t)*</div>(\\r|\\n|\\t)*<div class=\"table-value\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>");

  //          var match = regex.Match(text1);
  //          var match2 = regex.Match(text2);
  //          var match3 = regex3.Match(text1);

  //          var t =  match.Groups["id"].Value;
  //          var t2 =  match3.Groups["id"].Value.Trim();

            var client = new DataLoader();
            client.LoadPlayers().GetAwaiter().GetResult();
        }
    }
}
