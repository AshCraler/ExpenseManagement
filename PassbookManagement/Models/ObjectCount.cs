using System;
using System.ComponentModel.DataAnnotations;

namespace PassbookManagement.Models
{
    public class ObjectCount
    {
        [Required]
        public int CustomerCount { get; set; }

        [Required]
        public int EmployeeCount { get; set; }

        [Required]
        public int SpendAccountCount { get; set; }

        [Required]
        public int PassbookCount { get; set; }

        [Required]
        public int TransactionCount { get; set; }

        [Required]
        public int InterestCount { get; set; }
    }
}
