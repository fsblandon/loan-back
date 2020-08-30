using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanApp.Models
{
    public class LoanContext: DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> CreditLoan { get; set; }
    }
}
