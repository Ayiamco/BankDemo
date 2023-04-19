using System.Net;

namespace BankDemo.Infrastructure.Base
{
    public class BaseApiResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string? Message { get; set; } = "Sorry we could not process your request at this time.";

        public string? ErrorMessage { get; set; }
    }

    public class BaseApiResponse<T> : BaseApiResponse
    {
        public T? Result { get; set; }
    }
}
