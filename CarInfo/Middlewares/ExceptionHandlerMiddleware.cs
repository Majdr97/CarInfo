namespace CarInfo.Middlewares;

using System;
using System.Net;

using CarInfo.Services.Interfaces;

public class ExceptionHandlerMiddleware(ILog log) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var env = context.RequestServices.GetService<IHostEnvironment>()!;
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            log.Log(LogLevel.Error, $"An un-handled exception occurred. Request Path: {context.Request.Path}, With Status Code:{context.Response.StatusCode}, Exception Message: {ex.Message}", ex);

            var message = env.IsDevelopment() ? ex.Message : "Sorry, something went wrong on our end.";
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(
                new
                {
                    context.Response.StatusCode,
                    Message = message
                }.ToString()!);
        }
    }
}