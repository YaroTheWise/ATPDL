using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class BackhandBuilder
    {
        public static Backhand Build(string text)
        {
            var str = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.Hand);
            return str.Contains("Two-Handed") ?  Backhand.Two: Backhand.One;
        }
    }
}