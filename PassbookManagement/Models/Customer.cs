using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }

        [Display(Name = "Full name")]
        [StringLength(100)]
        [Required]
        public string FullName { get; set; }

        [Display(Name ="Birth day")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }

        [StringLength(15)]
        [Required]
        
        public string IdCardNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please choose signature image")]
        public string SignatureImagePath { get; set; }

        //reference entity
        public LoginAccount LoginAccount { get; set; }
        public SpendingAccount SpendingAccount { get; set; }
        public ICollection<Passbook> Passbooks { get; set; }
    }
}
