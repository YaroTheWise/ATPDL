namespace ATPDL.DataLoader.Templates
{
    public static class RegexPlayerInfoTemplates
    {
        public const string Player = @"/en/players/\w*(-\w*)+/\w*/overview";
        public const string BirthDay = "<span class=\"table-birthday\">\\s*\\((?<id>\\d{4}.\\d{2}.\\d{2})\\)\\s*</span>";
        public const string StartYear = "Turned Pro</div>\\s*<div class=\"table-big-value\">\\s*(?<id>\\d{4})\\s*</div>";
        //public const string BirthdayPlace1 = "Birthplace</div><div class=\"table-value\">(?<id>\\s*)</div>";
        public const string BirthdayPlace = "Birthplace(\\r|\\n|\\t)*</div>(\\r|\\n|\\t)*<div class=\"table-value\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>";
        public const string FirstName = "<div class=\"first-name\">(?<id>\\w+)</div>";
        public const string LastName = "<div class=\"last-name\">(?<id>\\w+)</div>";
        public const string SinglesRanking = "div data-singles=\"(?<id>\\d+)\" data-doubles=\"\\d+\"";
        public const string DoublesRanking = "div data-singles=\"\\d+\" data-doubles=\"(?<id>\\d+)\"";
        public const string PlayerCode = @"/en/players/\w*(-\w*)+/(?<id>\w*)/overview";
        public const string PlayerNameCode = @"/en/players/(?<id>\w*(-\w*)+)/\w*/overview";
        public const string Residence = "Residence(\\r|\\n|\\t)*</div>(\\r|\\n|\\t)*<div class=\"table-value\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>";
        public const string Nationality = "<div class=\"player-flag-code\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>";
        public const string Hand = "Plays(\\r|\\n|\\t)*</div>(\\r|\\n|\\t)*<div class=\"table-value\">(\\r|\\n|\\t)*(?<id>.*)(\\r|\\n|\\t)*</div>";
        public const string WeightLbs = "<span class=\"table-weight-lbs\">(?<id>\\d*)</span>";
        public const string WeightKg = "<span class=\"table-weight-kg-wrapper\">\\((?<id>\\d*)kg\\)</span>";
        public const string HeightFoot = "<span class=\"table-height-ft\">(?<id>.*)</span>";
        public const string HeightCm = "<span class=\"table-height-cm-wrapper\">\\((?<id>\\d{3})cm\\)</span>";
    }
}