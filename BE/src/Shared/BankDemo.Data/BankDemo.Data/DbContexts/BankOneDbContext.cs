using BankDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankDemo.Data.DbContexts
{
    public class BankOneDbContext : DbContext
    {
        public BankOneDbContext(DbContextOptions<BankOneDbContext> dbContext) : base(dbContext)
        {

        }


        public DbSet<Customer> Customers { get; set; }
    }
}
