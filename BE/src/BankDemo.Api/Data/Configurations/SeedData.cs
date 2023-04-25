using BankDemo.Api.Data.DbContexts;
using BankDemo.Api.Data.Entities;
using CsvHelper;
using System.Globalization;

namespace BankDemo.Api.Data.Configurations
{
    public class SeedData : IHostedService
    {
        private readonly BankOneDbContext dbcontext;

        public SeedData(IServiceProvider serviceProvider)
        {
            var dbcontext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<BankOneDbContext>();
            this.dbcontext = dbcontext;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (dbcontext.Customers.Any())
                return;

            using var reader = new StreamReader("BankOneCustomers.xlsx");
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
