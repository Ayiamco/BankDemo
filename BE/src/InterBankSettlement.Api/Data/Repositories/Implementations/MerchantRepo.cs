using Dapper.BaseRepository.Components;
using Dapper.BaseRepository.Config;
using Dapper.Repository.interfaces;
using InterBankSettlement.Api.Data.Entities;

namespace InterBankSettlement.Api.Data.Repositories.Implementations
{
    public class MerchantRepo : BaseRepository<MerchantRepo, IRepositoryLogger<MerchantRepo>>, IMerchantRepo
    {
        public MerchantRepo(IRepositoryLogger<MerchantRepo> logger) : base(logger) { }

        public Task<CommandResp> RegisterMerchant(Merchant merchant)
        {
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
