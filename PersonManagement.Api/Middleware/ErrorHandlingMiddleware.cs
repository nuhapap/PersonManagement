using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PersonManagement.Api.Middleware
{
    [ExcludeFromCodeCoverage]
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = GetHttpStatusCode();
            var logId = GetLogId(exception);

            var result = logId > 0
                ? JsonConvert.SerializeObject(new { error = $"LogId: {logId} - ErrorMessage: {exception.Message}" })
                : JsonConvert.SerializeObject(new { error = $"ErrorMessage: {exception.Message}" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

        private HttpStatusCode GetHttpStatusCode()
        {
            var code = HttpStatusCode.InternalServerError;

            // For different exception types
            // if (exception is ArgumentNullException)
            // {
            //    code = HttpStatusCode.BadRequest;
            // }
            return code;
        }

        private int GetLogId(Exception exception)
        {
            // Do Something with the exception, log id for example
            return 1;
        }
    }
}