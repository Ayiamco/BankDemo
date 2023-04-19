using Dapper.Repository.interfaces;
using Microsoft.Extensions.Logging;

namespace BankDemo.Infrastructure.Config
{
    public class RepoLogger<TRepo> : IRepositoryLogger<TRepo>
    {
        private readonly ILogger<TRepo> logger;

        public RepoLogger(ILogger<TRepo> logger)
        {
            this.logger = logger;
        }
        public void LogError(string message)
        {
            logger.LogError(message);
        }

        public void LogError(string message, Exception ex)
        {
            logger.LogError(ex, message);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }

        public void LogInformation(string message, Exception ex)
        {
            logger.LogInformation(ex, message);
        }
    }
}
