using Core.Application.Pipelines;
using Core.Application.Responses;

namespace Core.Application.Decorators;

public class ExampleDecoratorForCommandHandler<TCommand, TResponse> : ICommandRequestHandler<TCommand, TResponse> 
    where TCommand : ICommandRequest<TResponse>
    where TResponse : IResponse
{
    private readonly ICommandRequestHandler<TCommand, TResponse> _commandRequestHandler;

    public ExampleDecoratorForCommandHandler(ICommandRequestHandler<TCommand, TResponse> commandRequestHandler)
    {
        _commandRequestHandler = commandRequestHandler;
    }

    public Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
    {
        var result = _commandRequestHandler.Handle(request, cancellationToken);

        Console.WriteLine("Example Decorator Pattern for Command Request Handlers Works!!!");

        return result;
    }
}
