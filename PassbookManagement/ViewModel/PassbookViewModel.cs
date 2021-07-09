using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using PassbookManagement.Models;

namespace PassbookManagement.ViewModel
{
    public class PassbookViewModel
    {
        
        public string PassbookId { get; set; }

        public string CustomerRefId { get; set; }
        
        [Display(Name = "Employee created")]
        public string Employee { get; set; }
        

        [Display(Name = "Open method")]
        public string OpenMethod { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Period (month)")]
        public int Period { get; set; }

        
        [Display(Name = "Current Interest rate")]
        public string Interest { get; set; }
        public SelectList InterestList { get; set; }
        
        [DataType(DataType.Currency)]
        public int Balance { get; set; }

        public bool IsFinalized { get; set; }

        
        [Display(Name = "Beneficiary Account")]
        public string SpendingAccountRefId { get; set; }
        
        //reference entity
        ICollection<ProfitHistory> ProfitHistories { get; set; }
        ICollection<TransactionViewModel> Transactions { get; set; }

        public PassbookViewModel() { }
        public PassbookViewModel(Passbook passbook)
        {
            this.PassbookId = passbook.PassbookId;
            this.CustomerRefId = passbook.CustomerRefId;
            this.Employee = passbook.Employee.FullName;
            this.OpenMethod = passbook.OpenMethod;
            this.CreateDate = passbook.CreateDate;
            this.Period = passbook.Period;
            this.Interest = passbook.InterestValue.Name;
            this.InterestList = null;
            this.Balance = passbook.Balance;
            this.IsFinalized = passbook.IsFinalized;
            this.SpendingAccountRefId = passbook.SpendingAccountRefId;
        }
    }
}
