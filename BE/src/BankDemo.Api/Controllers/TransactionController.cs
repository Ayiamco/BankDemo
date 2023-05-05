using BankDemo.Infrastructure.Base;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankDemo.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/transaction")]
    public class TransactionController : BaseController
    {

        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpPost("credit")]
        public IActionResult Credit()
        {
            Debug.WriteLine($"Logger:{_logger.GetHashCode()} ");
            Debug.WriteLine($"Controller:{GetHashCode()} ");
            return Ok("we are getting there.");
        }


        [HttpPost("debit")]
        public IActionResult Debit()
        {
            return Ok("we are getting there.");
        }
    }
}