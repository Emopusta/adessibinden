using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set => _response = value;
    }

    private HttpResponse? _response;

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new BusinessProblemDetails(businessException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<BusinessProblemDetails>(details), Options()));
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        var details = new InternalServerErrorProblemDetails(exception.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<InternalServerErrorProblemDetails>(details), Options()));
    }

    protected override Task HandleException(ArgumentNullException argumentNullException)
    {
        Response.StatusCode = StatusCodes.Status406NotAcceptable;
        var details = new ArgumentNullProblemDetails(argumentNullException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<InternalServerErrorProblemDetails>(details), Options()));
    }

    protected override Task HandleException(DbUpdateException dbUpdateException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        var details = new DbUptadeProblemDetails(dbUpdateException.InnerException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<InternalServerErrorProblemDetails>(details), Options()));
    }

    protected override Task HandleException(AuthException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        var details = new AuthProblemDetails(authorizationException.Message);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<AuthProblemDetails>(details), Options()));
    }

    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        ValidationProblemDetails details = new ValidationProblemDetails(validationException.Errors);
        return Response.WriteAsync(JsonSerializer.Serialize(new ErrorDataResult<ValidationProblemDetails>(details), Options()));
    }

    private static JsonSerializerOptions Options()
    {
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return options;
    }
}
