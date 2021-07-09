using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.ViewModel
{
    public class SpendingAccountViewModel
    {
        public string AccountId { get; set; }

        public string CustomerRefId { get; set; }
        public CustomerViewModel Customer { get; set; }

        [Display(Name = "Employee name")]
        public string Employee { get; set; }
        

        [Range(0, 100)]
        public float InterestRate { get; set; }

        [DataType(DataType.Currency)]
        public int Balance { get; set; }

        //reference entity
        public ICollection<PassbookViewModel> Passbooks { get; set; }
        public ICollection<TransactionViewModel> Transactions { get; set; }
    }
}
