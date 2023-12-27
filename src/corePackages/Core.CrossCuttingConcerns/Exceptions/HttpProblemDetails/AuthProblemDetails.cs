using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

internal class AuthProblemDetails : ExceptionDetails
{
    public AuthProblemDetails(string detail)
    {
        Title = "Authorization error";
        Detail = detail;
        Status = StatusCodes.Status401Unauthorized;
        Type = "https://example.com/probs/authorization";
    }
}
