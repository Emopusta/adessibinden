using Core.Utilities.Exceptions;

namespace Core.Utilities.Results

{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
        ExceptionDetails Error { get; }

    }
}
