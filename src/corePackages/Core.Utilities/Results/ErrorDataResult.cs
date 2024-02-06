using Core.Utilities.Exceptions;

namespace Core.Utilities.Results;

public class ErrorDataResult<T> : DataResult<T>
{     
    public ErrorDataResult(ExceptionDetails error) : base(default,error, false) { }
    public ErrorDataResult() : base(default, default, false) { }
}
