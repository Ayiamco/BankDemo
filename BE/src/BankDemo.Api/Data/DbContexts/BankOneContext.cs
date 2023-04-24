using BankDemo.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankDemo.Api.Data.DbContexts
{
    public class BankOneContext : DbContext
    {
        public BankOneContext()
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
