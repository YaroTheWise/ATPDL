using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class PlayerRankingBuilder
    {
        public static PlayerRanking Build(string text)
        {
            return new PlayerRanking
            {
                SinglesRanking = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.SinglesRanking),
                DoublesRanking = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.DoublesRanking),
            };
        }
    }
}