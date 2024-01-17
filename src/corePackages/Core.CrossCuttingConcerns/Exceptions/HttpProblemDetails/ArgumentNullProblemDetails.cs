using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
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
}
