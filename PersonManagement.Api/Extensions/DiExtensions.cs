using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.AppSettings;
using PersonManagement.Business.Contracts.Interfaces;
using PersonManagement.Business.Implementation;
using PersonManagement.Data.Contracts.IRepositories;
using PersonManagement.Data.Repositories;

namespace PersonManagement.Api.Extensions
{
    public static class DiExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IPersonImporter, PersonImporter>();
            services.AddScoped<IAppSettingsProvider, AppSettingsProvider>();
            
            var useSql = bool.Parse(configuration["AppSettings:UseSql"]);
            if (useSql)
            {
                services.AddScoped<IPersonRepository, PersonMsSqlRepository>();
                services.AddScoped<IColorRepository, ColorMsSqlRepository>();
            }
            else
            {
                services.AddScoped<IPersonRepository, PersonCsvRepository>();
                services.AddScoped<IColorRepository, ColorCsvRepository>();
            }

            return services;
        }
    }
}