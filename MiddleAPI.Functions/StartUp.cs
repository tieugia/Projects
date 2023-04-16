using AzureFunctions.Extensions.Middleware.Abstractions;
using AzureFunctions.Extensions.Middleware.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MiddleAPI.Helpers;
using MiddleAPI.Middlewares;

[assembly: FunctionsStartup(typeof(MiddleAPI.StartUp))]
namespace MiddleAPI
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigUtilInitializer.InitForAzureFunction("WebMiddleAPIServiceBusFunction/");
            var services = builder.Services;
            BaseServices.RegisterServices(services);

            services.AddScoped<IMobileDbContext>(x =>
            {
                return new MobileDbContext(AppSettingUtil.MiddleApiConnectionString);
            });

            services.AddScoped<INonHttpMiddlewareBuilder, NonHttpMiddlewareBuilder>((serviceProvider) =>
            {
                var funcBuilder = new NonHttpMiddlewareBuilder();
                funcBuilder.Use(new ExceptionLoggingMiddleware(serviceProvider.GetService<ILogger<ExceptionLoggingMiddleware>>()));
                return funcBuilder;
            });
        }
    }
}
