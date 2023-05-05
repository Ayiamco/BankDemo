using BankDemo.Data.Models;
using BankDemo.Infrastructure.Base;
using InterBankSettlement.Api.Commands;
using InterBankSettlement.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterBankSettlement.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/merchants")]
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
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterMerchant.Command command, CancellationToken cancellation)
        {
            var result = new BaseApiResponse<RegisterMerchant.Response> { };
            while (!cancellation.IsCancellationRequested)
            {
                result = await mediator.Send(command, cancellation);
                return GetResponse(result);
            }
            return GetResponse(result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] GetMerchants.Request request, CancellationToken cancellation)
        {
            var result = new BaseApiResponse<PagedResponse<GetMerchants.Response>> { };
            while (!cancellation.IsCancellationRequested)
            {
                result = await mediator.Send(request, cancellation);
                return GetResponse(result);
            }

            return GetResponse(result);
        }
    }
}