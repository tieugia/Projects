﻿using Microsoft.Extensions.DependencyInjection;

namespace ModernisationChallenge.DAL.Services
{
    public static class BaseServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
             .FromAssembliesOf(typeof(BaseServices))
             .AddClasses()
             .AsImplementedInterfaces()
             .WithScopedLifetime());
        }
    }
}