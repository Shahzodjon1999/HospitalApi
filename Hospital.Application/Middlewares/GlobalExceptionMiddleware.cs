using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Hospital.Application.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate requestDelegate,ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = requestDelegate;
        _logger= logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
           Console.WriteLine(httpContext.Connection.LocalIpAddress);
        }
        catch (Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            object messageInfo = null;
#if DEBUG
            messageInfo = new
            {
                errorMessage = ex.Message,
                stackTrace = ex.StackTrace
            };
#else
                messageInfo = new
                {
                    errorMessage = "Internal server error",
                    stackTrace = ""
                };
#endif

            _logger.LogInformation(ex.Message);
            await httpContext.Response.WriteAsJsonAsync<dynamic>(messageInfo);
        }
    }
}
