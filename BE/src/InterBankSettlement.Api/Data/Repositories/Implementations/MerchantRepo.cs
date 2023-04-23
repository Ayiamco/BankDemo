using BankDemo.Infrastructure.Base;
using Dapper.BaseRepository.Components;
using Dapper.BaseRepository.Config;
using Dapper.Repository.interfaces;
using InterBankSettlement.Api.Data.Entities;
using InterBankSettlement.Api.Data.Repositories.Interfaces;
using InterBankSettlement.Api.Queries;

namespace InterBankSettlement.Api.Data.Repositories.Implementations
{
    public class MerchantRepo : BaseRepository<MerchantRepo, IRepositoryLogger<MerchantRepo>>, IMerchantRepo
    {
        public MerchantRepo(IRepositoryLogger<MerchantRepo> logger) : base(logger) { }

        public Task<CommandResp> RegisterMerchant(Merchant merchant)
        {
            var sql = $@"
INSERT INTO Merchants ( Name,BaseUrl,Id,UniqueCode)
VALUES ( @Name,@BaseUrl,@Id,@UniqueCode)
";
            return RunCommand(sql, merchant);
        }

        public async Task<(IEnumerable<GetMerchants.Response>, int?)> GetMerchants(PagedRequest request)
        {
            var sql = @"
SELECT UniqueCode,Name 
FROM Merchants
ORDER BY Name
";
            sql = AddPagination(sql);

            var result = await RunQuery<GetMerchants.Response>(sql, request);

            if (!result.Any()) return (result, 0);


            sql = "SELECT Count(*) From Merchants";
            int? count = await RunScalar<int>(sql);
            return (result, count);
        }

        public static string AddPagination(string sql)
        {
            sql = sql + @"
OFFSET @Page - 1 ROWS 
FETCH NEXT @PageSize ROWS ONLY
";
            return sql;
        }

    }
}
