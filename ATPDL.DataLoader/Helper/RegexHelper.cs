using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ATPDL.DataLoader.Helper
{
    public static class RegexHelper
    {
       
        public static string GetValueString(string text, string template)
        {
            var regex = new Regex(template);
            var match = regex.Match(text);

            return match.Groups["id"].Value.Replace("&#39;", "'").Replace("&quot;", "\"").Trim();
        }

        public static int GetValueInt(string text, string template)
        {
            var str = GetValueString(text, template);

            int result;
            return !Int32.TryParse(str, out result) ? 0 : result;
        }

        public static DateTime GetValueDate(string text, string template)
        {
            var str = GetValueString(text, template);

            DateTime result;
            if (!DateTime.TryParse(str, out result))
            {
                return new DateTime(1980, 1, 1);
            }

            return result;
        }

        public static List<string> SearchListString(string text, string template)
        {
            var regex = new Regex(template);
            var matches = regex.Matches(text);

            return matches.Cast<Match>()
                .Select(match => match.Value.Replace("&#39;", "'").Replace("&quot;", "\"").Trim())
                .ToList();
        }
    }
}