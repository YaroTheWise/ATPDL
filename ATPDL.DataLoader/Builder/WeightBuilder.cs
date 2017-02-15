using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class WeightBuilder
    {
        public static Weight Build(string text)
        {
            return new Weight
            {
                Kg = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.WeightKg),
                Lbs = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.WeightLbs),
            };
        }
    }
}