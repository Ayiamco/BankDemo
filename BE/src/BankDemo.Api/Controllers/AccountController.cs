using BankDemo.Infrastructure.Base;
using Microsoft.AspNetCore.Components;

namespace BankDemo.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> logger;

        public AccountController(ILogger<AccountController> logger)
        {
            this.logger = logger;
        }
    }
}
