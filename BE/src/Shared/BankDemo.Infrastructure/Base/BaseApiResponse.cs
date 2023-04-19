using System.Net;

namespace BankDemo.Infrastructure.Base
{
    public class BaseApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public string? Message { get; set; }

        public string? ErrorMessage { get; set; }
    }
}
