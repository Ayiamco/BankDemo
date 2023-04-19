using BankDemo.Infrastructure.Base;
using InterBankSettlement.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterBankSettlement.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/Merchant")]
    public class MerchantController : BaseController
    {

        private readonly ILogger<MerchantController> _logger;
        private readonly IMediator mediator;

        public MerchantController(ILogger<MerchantController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [MapToApiVersion("1.0")]
        [HttpPost(Name = "Register")]
        public async Task<IActionResult> Register(RegisterMerchant.Command command, CancellationToken cancellation)
        {
            var result = new BaseApiResponse<RegisterMerchant.Response> { };
            while (!cancellation.IsCancellationRequested)
            {
                result = await mediator.Send(command, cancellation);
            }

            return GetResponse(result);
        }
    }
}