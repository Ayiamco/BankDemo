using Dapper.BaseRepository.Config;
using InterBankSettlement.Api.Data.Entities;

namespace InterBankSettlement.Api.Data.Repositories.Implementations
{
    public interface IMerchantRepo
    {
        Task<CommandResp> RegisterMerchant(Merchant merchant);
    }
}