using BankDemo.Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankDemo.Api.Controllers.BankOne
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/transaction")]
    public class TransactionController : BaseController
    {

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("credit")]
        public IActionResult Credit()
        {
            Debug.WriteLine($"Logger:{_logger.GetHashCode()} ");
            Debug.WriteLine($"Controller:{this.GetHashCode()} ");
            return Ok("we are getting there.");
        }


        [MapToApiVersion("1.0")]
        [HttpPost("debit")]
        public IActionResult Debit()
        {
            return Ok("we are getting there.");
        }
    }
}