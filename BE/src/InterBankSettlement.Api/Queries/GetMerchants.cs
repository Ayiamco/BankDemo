using BankDemo.Infrastructure.Base;
using InterBankSettlement.Api.Data.Repositories.Interfaces;
using MediatR;

namespace InterBankSettlement.Api.Queries
{
    public class GetMerchants
    {
        public class Request : PagedRequest, IRequest<BaseApiResponse<PagedResponse<Response>>>
        {
        }

        public class Response
        {
            public string Name { get; set; }

            public string UniqueCode { get; set; }
        }

        public class Handler : IRequestHandler<Request, BaseApiResponse<PagedResponse<Response>>>
        {
            private readonly IMerchantRepo merchantRepo;

            public Handler(IMerchantRepo merchantRepo)
            {
                this.merchantRepo = merchantRepo;
            }

            public async Task<BaseApiResponse<PagedResponse<Response>>> Handle(Request request, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = await merchantRepo.GetMerchants(request);
                    return new BaseApiResponse<PagedResponse<Response>>
                    {
                        ErrorMessage = string.Empty,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        Result = new PagedResponse<Response>(result.Items, result.Count ?? 0, request.Page, request.PageSize)
                    };
                }
                return new BaseApiResponse<PagedResponse<Response>>();
            }
        }
    }
}
