using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ArgumentNullProblemDetails : ExceptionDetails
{
    public ArgumentNullProblemDetails(string detail)
    {
        Title = "Argument Null error";
        Detail = detail;
        Status = StatusCodes.Status406NotAcceptable;
        Type = "https://example.com/probs/argument-null";
    }
}
