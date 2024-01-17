using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class DbUptadeProblemDetails : ExceptionDetails
    {
        public DbUptadeProblemDetails(string detail)
        {
            Title = "DBUpdate error";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/argument-null";
        }
    }
}
