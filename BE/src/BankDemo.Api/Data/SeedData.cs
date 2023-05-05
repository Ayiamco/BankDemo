using BankDemo.Data.DbContexts;
using BankDemo.Data.Entities;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BankDemo.Api.Data
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
            await dbcontext.Database.MigrateAsync(cancellationToken);

            if (dbcontext.Customers.Any())
                return;

            using var reader = new StreamReader("BankOneCustomers.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var entities = csv.GetRecords<Customer>().ToList();

            await dbcontext.Customers.AddRangeAsync(entities, cancellationToken);
            await dbcontext.SaveChangesAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
