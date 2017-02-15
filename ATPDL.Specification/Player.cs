using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATPDL.Specification
{
    public class Player
    {
        public int? PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string NameCode { get; set; }
        public DateTime Birthday { get; set; }
        public int StartYear { get; set; }
        public string BirthdayPlace { get; set; }
        public int SinglesRanking { get; set; }
        public int DoublesRanking { get; set; }
    }
}
