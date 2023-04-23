using BankDemo.Infrastructure.Base;
using Dapper.BaseRepository.Config;
using InterBankSettlement.Api.Data.Entities;
using InterBankSettlement.Api.Queries;

namespace InterBankSettlement.Api.Data.Repositories.Interfaces
{
    public interface IMerchantRepo
    {
        Task<CommandResp> RegisterMerchant(Merchant merchant);
        Task<(IEnumerable<GetMerchants.Response> Items, int? Count)> GetMerchants(PagedRequest request);
    }
}