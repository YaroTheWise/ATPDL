using System;

namespace ATPDL.Specification.Models
{
    public class PlayerInfo
    {
        public int? PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string NameCode { get; set; }
        public DateTime Birthday { get; set; }
        public int StartYear { get; set; }
        public string BirthdayPlace { get; set; }
        public string Residence { get; set; }
        public string Nationality { get; set; }
    }
}