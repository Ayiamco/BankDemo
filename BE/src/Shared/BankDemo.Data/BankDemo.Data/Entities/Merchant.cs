namespace BankDemo.Data.Entities
{
    public class Merchant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string BaseUrl { get; set; }

        public string UniqueCode { get; set; }
    }
}