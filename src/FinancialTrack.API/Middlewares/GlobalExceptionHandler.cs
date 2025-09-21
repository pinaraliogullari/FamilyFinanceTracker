using System.Net;
using System.Text.Json;
using FinancialTrack.Application.Exceptions;

namespace FinancialTrack.API.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "BadRequest:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (AccessViolationException ex)
        {
            _logger.LogWarning(ex, "Forbidden:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.Forbidden, ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.Unauthorized, ex.Message);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogWarning(ex, "{Source}:{ErrorMessage}", ex.Source, ex.Message);
            await HandleException(context, HttpStatusCode.ServiceUnavailable, ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning(ex, "InvalidOperation:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.Conflict, ex.Message);
        }
        catch (NotFoundUserException ex)
        {
            _logger.LogWarning(ex, "NotFound:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (FluentValidation.ValidationException ex)
        {
            _logger.LogWarning(ex, "{Source}:{ErrorMessage}", ex.Source, ex.Message);
            await HandleValidationException(context, HttpStatusCode.BadRequest, ex);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Service Error:{ErrorMessage}", ex.Message);
            await HandleException(context, HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    private async Task HandleException(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = message,
            Errors = new List<string> { message }
        };
        var json = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(json);
    }

    private async Task HandleValidationException(HttpContext context, HttpStatusCode statusCode,
        FluentValidation.ValidationException ex)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        var errors = ex.Errors.Select(e => e.ErrorMessage).ToList();
        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = "Validation failed.",
            Errors = errors
        };
        var json = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(json);
    }
}