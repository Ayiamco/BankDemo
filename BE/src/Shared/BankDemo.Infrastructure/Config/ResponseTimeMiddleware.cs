using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BankDemo.Infrastructure.Config
{
    public class ResponseTimeMiddleware : IMiddleware
    {
        private readonly ILogger<ResponseTimeMiddleware> logger;

        public ResponseTimeMiddleware(ILogger<ResponseTimeMiddleware> logger)
        {
            this.logger = logger;
        }

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var timein = DateTime.UtcNow;

            next(context);

            var timeSpent = DateTime.UtcNow - timein;
            var logMessage = $"Route: {context.Request.Path}; CompletionTime: {timeSpent.TotalMilliseconds} MilliSeconds";
            Debug.WriteLine(logMessage);
            logger.LogInformation(logMessage);
            return Task.CompletedTask;
        }
    }
}
