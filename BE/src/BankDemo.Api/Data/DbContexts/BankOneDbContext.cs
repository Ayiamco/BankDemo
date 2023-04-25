using BankDemo.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankDemo.Api.Data.DbContexts
{
    public class BankOneDbContext : DbContext
    {
        public BankOneDbContext(DbContextOptions<BankOneDbContext> dbContext) : base(dbContext)
        {

        }


        public DbSet<Customer> Customers { get; set; }
    }
}
