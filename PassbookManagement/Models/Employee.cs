using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; }

        [Display(Name = "Full name")]
        [StringLength(100)]
        [Required]
        public string FullName { get; set; }

        [Display(Name = "Birth day")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        [StringLength(15)]
        [Required]
        [RegularExpression(@"[0-9]")]
        public string IdCardNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required]
        public string PhoneNumber { get; set; }

        //reference entity
        public ICollection<Passbook> Passbooks { get; set; }
        public ICollection<SpendingAccount> SpendingAccounts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
