using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Data.Contexts;

namespace PersonManagement.Api.Extensions
{
    public static class ContextExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // dotnet ef migrations add InitialDb --project ../PersonManagement.Data --context PersonManagementDbContext
            //
            services.AddDbContext<PersonManagementDbContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("PersonManagementDB");
                config.UseSqlServer(connectionString, b =>
                {
                    b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            return services;
        }
    }
}
