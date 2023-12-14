using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;

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
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
