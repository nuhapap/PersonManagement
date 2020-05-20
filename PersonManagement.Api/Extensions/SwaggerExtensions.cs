using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PersonManagement.Api.Extensions
{
    public static class SwaggerExtensions
    {
        private const string Title = "Person Management API";
        private const string Version = "v1";

        public static IServiceCollection AddSwaggerMiddleware(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = Title, Version = Version });
            });

            return services;

        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"Swagger UI - {Title}";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Title} {Version}");
            });

            return app;
        }
    }
}