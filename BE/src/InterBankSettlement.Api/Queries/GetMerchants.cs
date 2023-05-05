using AutoMapper;
using BankDemo.Data.Models;
using BankDemo.Data.Repositories.Interfaces;
using BankDemo.Infrastructure.Base;
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
            private readonly IMapper mapper;

            public Handler(IMerchantRepo merchantRepo, IMapper mapper)
            {
                this.merchantRepo = merchantRepo;
                this.mapper = mapper;
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
                        Result = new PagedResponse<Response>(mapper.Map<IEnumerable<Response>>(result.Items), result.Count ?? 0, request.Page, request.PageSize)
                    };
                }
                return new BaseApiResponse<PagedResponse<Response>>();
            }
        }
    }
}
