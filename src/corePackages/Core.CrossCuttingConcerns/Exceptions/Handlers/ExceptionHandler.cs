using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;
using Microsoft.EntityFrameworkCore;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) =>
        exception switch
        {
            BusinessException businessException => HandleException(businessException),
            ValidationException validationException => HandleException(validationException),
            AuthException authException => HandleException(authException),
            ArgumentNullException argumentNullException => HandleException(argumentNullException),
            DbUpdateException dbUpdateException => HandleException(dbUpdateException),
            OperationCanceledException operationCancelledException => HandleException(operationCancelledException),
            _ => HandleException(exception)
        };

    protected abstract Task HandleException(BusinessException businessException);
    protected abstract Task HandleException(ValidationException validationException);
    protected abstract Task HandleException(AuthException authException);
    protected abstract Task HandleException(ArgumentNullException argumentNullException);
    protected abstract Task HandleException(DbUpdateException dbUpdateException);
    protected abstract Task HandleException(OperationCanceledException operationCancelledException);
    protected abstract Task HandleException(Exception exception);
}
