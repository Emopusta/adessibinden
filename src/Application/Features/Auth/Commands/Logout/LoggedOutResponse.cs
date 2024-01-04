using Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Logout
{
    public class LoggedOutResponse : IResponse
    {
        public string Message { get; set; }
    }
}
