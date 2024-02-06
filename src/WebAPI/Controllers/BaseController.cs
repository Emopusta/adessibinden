using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BaseController : ControllerBase
{
    protected IMediator Mediator =>
        _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

    private IMediator? _mediator;

    protected SuccessDataResult<T> ReturnResult<T>(T result)
    {
        return new SuccessDataResult<T>(result);
    }
}
