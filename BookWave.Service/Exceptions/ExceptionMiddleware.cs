using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookWave.Service.Exceptions;
public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string message = "An unexpected error occurred.";

        if (exception is NotFoundException notFoundException)
        {
            statusCode = notFoundException.StatusCode;
            message = notFoundException.Message;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(new
        {
            error = message,
            statusCode = (int)statusCode
        }.ToString());
    }
}