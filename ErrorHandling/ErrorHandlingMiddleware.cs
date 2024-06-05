using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetPatientInfo.ErrorHandling;


public class ErrorHandlingMiddleware {
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        }
        catch(Exception ex) {
            _logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var serviceResponse = new ServiceResponse<string> {
            Data = null,
            Success = false,
            Message = "An error occurred while processing your request."
        };
        var result = JsonSerializer.Serialize(serviceResponse);;

        return context.Response.WriteAsync(result);
    }
}
