using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class HandBuilder
    {
        public static Hand Build(string text)
        {
            var str = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.Hand);
            return str.Contains("Right-Handed") ? Hand.Right : Hand.Left;
        }
    }
}