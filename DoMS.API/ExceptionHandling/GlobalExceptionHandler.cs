using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DoMS.Shared.Exceptions;

namespace DoMS.API.ExceptionHandling
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IProblemDetailsService _problemDetailsService;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsService problemDetailsService)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // 1. capture trace id to match client report with with server logs:
            var traceID = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            // 2. logging everything we can:
            _logger.LogError(exception, "New Captured Exception! [TraceID: {TraceID}], [Path: {Path}], [Method: {Method}], [Message: {Message}]", traceID,httpContext.Request.Path,httpContext.Request.Method, exception.Message);
            // 3. makeup the error shape and map the status codes:
            var (statusCode, title) = exception switch
            {
                CustomException customEx => (customEx.StatusCode, "Business Rule Violation"),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Access Denied"),
                KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource Not Found"),
                CustomConflictException => (StatusCodes.Status409Conflict, "Conflict Detected"),
                _ => (StatusCodes.Status500InternalServerError, "System Error")
            };
            httpContext.Response.StatusCode = statusCode;
            // 4. hide the real full trace from the client:
            var detail = exception is CustomException or CustomConflictException or KeyNotFoundException or UnauthorizedAccessException ? exception.Message : "Unhandled exception occured, please contact the support with provided TraceID.";
            // 5. construct the issue response shape
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = httpContext.Request.Path
            };
            // 6. attach TraceID for the support so they can specify the issue:
            problemDetails.Extensions["traceID"] = traceID;
            // 7. send the response:
            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = problemDetails
            });
        }
    }
}
