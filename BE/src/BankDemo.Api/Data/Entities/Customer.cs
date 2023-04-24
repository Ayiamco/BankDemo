namespace BankDemo.Api.Data.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
