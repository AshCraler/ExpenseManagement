using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.Models
{
    public class InterestValue
    {
        [Key]
        public string InterestId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Standar Period")]
        [Range(0,36)]
        public int StandardPeriod { get; set; }

        [Required]
        [Display(Name = "Standard Interest Rate per month")]
        [Range(0,100)]
        public float StandardInterestRate { get; set; }

        //reference entity
        public ICollection<Passbook> Passbooks { get; set; }
    }
}
