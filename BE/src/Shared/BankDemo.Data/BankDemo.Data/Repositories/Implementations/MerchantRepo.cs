using BankDemo.Data.Entities;
using BankDemo.Data.Models;
using BankDemo.Data.Repositories.Interfaces;
using Dapper.BaseRepository.Components;
using Dapper.BaseRepository.Config;
using Dapper.Repository.interfaces;

namespace BankDemo.Data.Repositories.Implementations
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

        public async Task<(IEnumerable<Merchant>, int?)> GetMerchants(PagedRequest request)
        {
            var sql = @"
SELECT UniqueCode,Name 
FROM Merchants
ORDER BY Name
";
            sql = AddPagination(sql);

            var result = await RunQuery<Merchant>(sql, request);

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
