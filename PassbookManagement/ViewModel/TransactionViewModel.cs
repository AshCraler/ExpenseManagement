using System;
using System.ComponentModel.DataAnnotations;
using PassbookManagement.Models;

namespace PassbookManagement.ViewModel
{
    public class TransactionViewModel
    {
        public string TransactionId { get; set; }

        public string PassbookRefId { get; set; }
        public PassbookViewModel Passbook { get; set; }

        [Display(Name = "Transactor")]
        public string Employee { get; set; }
        
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

        [Display(Name = "Destination Account Id")]
        public string SpendingAccountRefId { get; set; }
        public SpendingAccount SpendingAccount { get; set; }

        public TransactionViewModel() { }
    }
}
