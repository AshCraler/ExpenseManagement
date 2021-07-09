using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassbookManagement.Models;

namespace PassbookManagement.Data
{
    public class PassBookManagementContext : DbContext
    {
        public PassBookManagementContext(DbContextOptions<PassBookManagementContext> options)
            : base(options)
        {
        }

        public DbSet<PassbookManagement.Models.Customer> Customer { get; set; }

        public DbSet<PassbookManagement.Models.Passbook> Passbook { get; set; }

        public DbSet<PassbookManagement.Models.SpendingAccount> SpendingAccount { get; set; }

        public DbSet<PassbookManagement.Models.Transaction> Transaction { get; set; }

        public DbSet<PassbookManagement.Models.Employee> Employee { get; set; }

        public DbSet<PassbookManagement.Models.InterestValue> Interest { get; set; }
    }
}