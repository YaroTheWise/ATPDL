using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class HeightBuilder
    {
        public static Height Build(string text)
        {
            return new Height
            {
                Foot = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.HeightFoot),
                Cm = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.HeightCm),
            };
        }
    }
}