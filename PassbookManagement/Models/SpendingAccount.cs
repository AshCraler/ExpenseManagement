using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassbookManagement.Models
{
    public class SpendingAccount
    {
        [Key]
        public string AccountId { get; set; }

        //foreign key
        [ForeignKey("Customer")]
        public string CustomerRefId { get; set; }
        public Customer Customer { get; set; }

        //foreign key
        [ForeignKey("Employee")]
        public string EmployeeRefId { get; set; }
        public Employee Employee { get; set; }

        [Range(0,100)]
        public float InterestRate { get; set; }

        [DataType(DataType.Currency)]
        public int Balance { get; set; }

        //reference entity
        public ICollection<Passbook> Passbooks { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
