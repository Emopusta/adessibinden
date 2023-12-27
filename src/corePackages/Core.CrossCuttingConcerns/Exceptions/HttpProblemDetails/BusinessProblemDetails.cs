using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

internal class BusinessProblemDetails : ExceptionDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Rule violation";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/business";
    }
}
