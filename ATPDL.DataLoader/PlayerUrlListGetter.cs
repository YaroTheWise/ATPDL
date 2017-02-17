using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Interfaces;
using ATPDL.DataLoader.Templates;

namespace ATPDL.DataLoader
{
    public class PlayerUrlListGetter : IPlayerUrlListGetter
    {
        public async Task<List<string>> Get(System.Net.Http.HttpClient httpClient, int from, int to)
        {
            var response = await httpClient.GetAsync(string.Format(UrlResource.Rankings, from, to));
            var result = await response.Content.ReadAsStringAsync();
            return RegexHelper.SearchListString(result, RegexPlayerInfoTemplates.Player);
        }
    }
}