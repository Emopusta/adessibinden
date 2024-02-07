using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

internal class ValidationProblemDetails : ExceptionDetails
{
    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Type = "https://example.com/probs/validation";
        Title = "Validation error(s)";
        Detail = "One or more validation errors occurred.";
        ValidationErrors = errors;
        Status = StatusCodes.Status400BadRequest;
    }
}
