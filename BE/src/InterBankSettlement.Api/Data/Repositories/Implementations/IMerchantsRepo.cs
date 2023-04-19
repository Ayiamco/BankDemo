using InterBankSettlement.Api.Data.Entities;

namespace InterBankSettlement.Api.Data.Repositories.Implementations
{
    public interface IMerchantsRepo
    {
        Task RegisterMerchant(Merchant merchant);
    }
}