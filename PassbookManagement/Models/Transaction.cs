using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassbookManagement.Models
{
    public class Transaction
    {
        [Key]
        public string TransactionId { get; set; }

        //foreign key
        [Required]
        [ForeignKey("Passbook")]
        public string PassbookRefId { get; set; }
        public Passbook Passbook { get; set; }

        //foreign key
        [ForeignKey("Employee")]
        public string EmployeeRefId { get; set; }
        public Employee Employee { get; set; }

        public string TransactionMethod { get; set; }

        public string TransactionType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        [Required]
        public bool IsViolation { get; set; }

        [Display(Name = "Transact Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        //foreign key
        [Display(Name = "Destination Account Id")]
        [ForeignKey("SpendingAccount")]
        public string SpendingAccountRefId { get; set; }
        public SpendingAccount SpendingAccount { get; set; }
    }
}
