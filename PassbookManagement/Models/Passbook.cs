using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassbookManagement.Models
{
    public class Passbook
    {
        [Key]
        public string PassbookId { get; set; }

        //foreign key
        [ForeignKey("Customer")]
        public string CustomerRefId { get; set; }
        public Customer Customer { get; set; }

        //foreign key
        [ForeignKey("Employee")]
        public string EmployeeRefId { get; set; }
        public Employee Employee { get; set; }

        public string OpenMethod { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Period (month)")]
        public int Period { get; set; }

        //foreign key
        [ForeignKey("InterestValue")]
        [Display(Name = "Current Interest rate Id")]
        public string InterestRefId { get; set; }
        public InterestValue InterestValue { get; set; }

        
        public int Balance { get; set; }

        public bool IsFinalized { get; set; }

        //foreign key
        [ForeignKey("SpendingAccount")]
        [Display(Name = "Beneficiary Account")]
        public string SpendingAccountRefId { get; set; }
        public SpendingAccount SpendingAccount { get; set; }

        //reference entity
        ICollection<ProfitHistory> ProfitHistories { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}
