using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class HeightBuilder
    {
        public static Height Build(string text)
        {
            var str = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.HeightFoot);
            var foot = str.Replace("&#39;", "'").Replace("&quot;", "\"");

            return new Height
            {
                Foot = foot,
                Cm = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.HeightCm),
            };
        }
    }
}