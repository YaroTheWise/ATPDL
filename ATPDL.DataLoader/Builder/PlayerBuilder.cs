using System.Text;
using ATPDL.DataLoader.Helper;
using ATPDL.DataLoader.Templates;
using ATPDL.Specification;
using ATPDL.Specification.Models;

namespace ATPDL.DataLoader.Builder
{
    public static class PlayerBuilder
    {
        public static Player Build(string text)
        {
            var result = new Player
            {
                Info = new PlayerInfo
                {
                    Birthday = RegexHelper.GetValueDate(text, RegexPlayerInfoTemplates.BirthDay),
                    Code = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.PlayerCode),
                    NameCode = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.PlayerNameCode),
                    FirstName = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.FirstName),
                    LastName = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.LastName),
                    StartYear = RegexHelper.GetValueInt(text, RegexPlayerInfoTemplates.StartYear),
                    BirthdayPlace = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.BirthdayPlace),
                    Residence = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.Residence),
                    Nationality = RegexHelper.GetValueString(text, RegexPlayerInfoTemplates.Nationality),
                },
                PhysicalParameter = new PlayerPhysicalParameter
                {
                    Backhand = BackhandBuilder.Build(text),
                    Hand = HandBuilder.Build(text),
                    Height = HeightBuilder.Build(text),
                    Weight = WeightBuilder.Build(text),
                }
            };
            
            return result;
        }
    }
}