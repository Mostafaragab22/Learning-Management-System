using System.Net;
using System.Text.Json;
using Learning_Management_System.Core.Exceptions;

namespace Learning_Management_System.API.Middelware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {         
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode;
        string message;
        IEnumerable<string> errors = null;

        switch (ex)
        {
            case NotFoundException notFound:
                statusCode = HttpStatusCode.NotFound; // 404
                message = notFound.Message;
                errors = notFound is { } nf ? nf.Errors ?? new[] { nf.Message } : null;
                break;

            case BadRequestException badRequest:
                statusCode = HttpStatusCode.BadRequest; // 400
                message = badRequest.Message;
                errors = badRequest.Errors;
                break;

            case UnauthorizedException unauthorized:
                statusCode = HttpStatusCode.Unauthorized; // 401
                message = unauthorized.Message;
                errors = unauthorized.Errors;
                break;

            case ForbiddenException forbidden:
                statusCode = HttpStatusCode.Forbidden; // 403
                message = forbidden.Message;
                errors = forbidden.Errors;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError; // 500
                message = "An unexpected error occurred.";
                errors = new[] { ex.Message };
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message,
            errors
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
