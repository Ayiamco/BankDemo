using BankDemo.Api.Data.DbContexts;
using BankDemo.Api.Data.Entities;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BankDemo.Api.Data.Configurations
{
    public class SeedData : IHostedService
    {
        private readonly BankOneDbContext dbcontext;
        private readonly IServiceProvider serviceProvider;

        public SeedData(IServiceProvider serviceProvider)
        {
            var dbcontext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<BankOneDbContext>();
            this.dbcontext = dbcontext;
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //Run Migrations
            await dbcontext.Database.MigrateAsync();

            if (dbcontext.Customers.Any())
                return;

            using var reader = new StreamReader("BankOneCustomers.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var entities = csv.GetRecords<Customer>().ToList();

            await dbcontext.Customers.AddRangeAsync(entities);
            await dbcontext.SaveChangesAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
