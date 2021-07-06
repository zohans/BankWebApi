using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using BankWebApplication.Models;
using System;
using BankWebApplication.Interfaces;

namespace BankWebApplication.Extensions
{
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
                        logger.LogError($"Bank web api unhandled error : {contextFeature.Error}");
                        await context.Response.WriteAsync(new Error()
                        {
                            StatusCode = context.Response.StatusCode,
                            ReferenceNumber = Convert.ToString((DateTime.Now.Ticks - 621355968000000000) / 10000000),
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
