using System;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.ViewModel
{
    public class InterestValueViewModel
    {
        public string InterestId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Standar Period (month)")]
        [Range(0, 36)]
        public int StandardPeriod { get; set; }

        [Required]
        [Display(Name = "Standard Interest Rate per month")]
        [Range(0, 100)]
        public float StandardInterestRate { get; set; }

    }
}
