using BankDemo.Data.Entities;
using BankDemo.Data.Models;
using Dapper.BaseRepository.Config;

namespace BankDemo.Data.Repositories.Interfaces
{
    public interface IMerchantRepo
    {
        Task<CommandResp> RegisterMerchant(Merchant merchant);
        Task<(IEnumerable<Merchant> Items, int? Count)> GetMerchants(PagedRequest request);
    }
}