using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;
using PassbookManagement.Framework;
using PassbookManagement.Models;

namespace PassbookManagement.ViewModel
{
    public class CustomerViewModel
    {
        
        public string CustomerId { get; set; }

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
        public string IdCardNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required]
        public string PhoneNumber { get; set; }

        
        
        public string SignatureImagePath { get; set; }
        

        //reference entity
        public LoginAccount LoginAccount { get; set; }
        public SpendingAccountViewModel SpendingAccount { get; set; }
        public ICollection<PassbookViewModel> Passbooks { get; set; }

        public CustomerViewModel(Customer customer)
        {
            this.FullName = customer.FullName;
            this.BirthDay = customer.BirthDay;
            this.IdCardNumber = customer.IdCardNumber;
            this.Email = customer.Email;
            this.PhoneNumber = customer.PhoneNumber;
            this.SignatureImagePath = customer.SignatureImagePath;
            
        }

        
    }
}
