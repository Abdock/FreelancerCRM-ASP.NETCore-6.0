using System.Net;
using Application.Responses;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters;

public class ErrorHandlingAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<ErrorHandlingAttribute> _logger;

    public ErrorHandlingAttribute(ILogger<ErrorHandlingAttribute> logger)
    {
        _logger = logger;
    }

    public override async Task OnExceptionAsync(ExceptionContext context)
    {
        var exception = context.Exception;

        var status = exception switch
        {
            ResourceNotFoundException => HttpStatusCode.NotFound,
            ArgumentNullException => HttpStatusCode.BadRequest,
            ArgumentException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var error = new ErrorResponse
        {
            ErrorStatusCode = (int) status,
            ErrorMessage = exception.Message
        };
        context.Result = new ObjectResult(error)
        {
            StatusCode = error.ErrorStatusCode
        };
        _logger.LogError("{ExceptionMessage}", exception.Message);

        context.ExceptionHandled = true;
        await base.OnExceptionAsync(context);
    }
}