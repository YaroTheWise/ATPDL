using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATPDL.DB.Model
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [StringLength(200)]
        public string NameCode { get; set; }
        public DateTime Birthday { get; set; }
        public int StartYear { get; set; }
        [Required]
        [StringLength(100)]
        public string BirthdayPlace { get; set; }
        [Required]
        [StringLength(100)]
        public string Residence { get; set; }
        [Required]
        [StringLength(10)]
        public string NationalityCode { get; set; }
        public int Hand { get; set; }
        public int Backhand { get; set; }
        public int WeightKg { get; set; }
        public int WeightLbs { get; set; }
        public int HeightCm { get; set; }
        [Required]
        [StringLength(10)]
        public string HeightFoot { get; set; }
    }
}
