using Egras.LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using Egras.Entities;

namespace EgrasWebAPI.API.Extentions
{
    /// <summary>
    /// Manage Exception handling globally
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something went wrong : {contextFeature.Error}");

                        await context.Response.WriteAsync(new ResponseMessages()
                        {
                            status = context.Response.StatusCode.ToString(),
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
        }
    }
}
