using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class OperationCanceledProblemDetails : ExceptionDetails
    {
        public OperationCanceledProblemDetails(string detail)
        {
            Title = "Operation Canceled!";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/canceled";
        }
    }
}
