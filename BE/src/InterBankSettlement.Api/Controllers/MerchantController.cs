using Microsoft.AspNetCore.Mvc;

namespace InterBankSettlement.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/WeatherForecast")]
    public class MerchantController : ControllerBase
    {

        private readonly ILogger<MerchantController> _logger;

        public MerchantController(ILogger<MerchantController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<> Get()
        {

        }
    }
}