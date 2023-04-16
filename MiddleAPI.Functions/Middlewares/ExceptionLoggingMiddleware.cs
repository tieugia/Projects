using AzureFunctions.Extensions.Middleware.Abstractions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MiddleAPI.Middlewares
{
    public class ExceptionLoggingMiddleware : NonHttpMiddlewareBase
    {
        readonly ILogger<ExceptionLoggingMiddleware> _logger;

        public ExceptionLoggingMiddleware(ILogger<ExceptionLoggingMiddleware> logger)
        {
            _logger = logger;
        }

        public override async Task InvokeAsync()
        {
            try
            {
                var timerData = Data as TimerInfo;
                _logger.LogInformation($"{ExecutionContext.FunctionName} Request triggered");
                await Next.InvokeAsync();
                _logger.LogInformation($"{ExecutionContext.FunctionName} Request processed without any exceptions");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}