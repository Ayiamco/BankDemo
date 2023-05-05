using BankDemo.Infrastructure.Base;
using MediatR;

namespace BankDemo.Api.Queries
{
    public class GetAccountName
    {
        public class Request : IRequest<BaseApiResponse<string>>
        {

        }

        public class Handler : IRequestHandler<Request, BaseApiResponse<string>>
        {
            public Handler()
            {

            }

            public Task<BaseApiResponse<string>> Handle(Request request, CancellationToken cancellationToken)
            {
                //call accounts repo to get account Number
                return Task.FromResult(new BaseApiResponse<string>());
            }
        }
    }
}