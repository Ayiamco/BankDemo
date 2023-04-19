using Dapper.BaseRepository.Components;
using Dapper.Repository.interfaces;
using InterBankSettlement.Api.Data.Entities;

namespace InterBankSettlement.Api.Data.Repositories.Implementations
{
    public class MerchantsRepo : BaseRepository<MerchantsRepo, IRepositoryLogger<MerchantsRepo>>, IMerchantsRepo
    {
        public MerchantsRepo(IRepositoryLogger<MerchantsRepo> logger) : base(logger)
        {

        }

        public Task RegisterMerchant(Merchant merchant)
        {
            merchant.Id = Guid.NewGuid();
            merchant.UniqueCode = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12);
            var sql = $@"
INSERT INTO Merchants 
Name = @Name
BaseUrl = @BaseUrl
Id = @Id
UniqueCode =@UniqueCode
";
            return RunCommand(sql, merchant);
        }
    }
}
