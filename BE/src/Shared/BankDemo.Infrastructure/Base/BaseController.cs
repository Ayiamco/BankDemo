using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankDemo.Infrastructure.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult GetResponse<TResponse>(TResponse response) where TResponse : BaseApiResponse
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.NotFound:
                    return NotFound(Response);
                case HttpStatusCode.Accepted:
                    return Accepted(response);
                case HttpStatusCode.Created:
                    return Ok(response);
                default:
                    throw new Exception($"Statuscode: {response.StatusCode}  not handled in {nameof(GetResponse)} function.");
            }
        }
    }
}
