using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassbookManagement.Models
{
    public class ProfitHistory
    {
        //foreign key
        [ForeignKey("Passbook")]
        public string PassbookRefId { get; set; }
        public Passbook Passbook { get; set; }

        [Display(Name = "Applied Interest rate")]
        [Range(0,100)]
        public float AppliedInterest { get; set; }

        [Display(Name = "Capital money")]
        [DataType(DataType.Currency)]
        public int Capital { get; set; }

        [DataType(DataType.Currency)]
        public int Profit { get; set; }

        [Display(Name = "Certain Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CertainDate { get; set; }

        [Display(Name = "Profit type")]
        public string ProfitType { get; set; }
    }
}
