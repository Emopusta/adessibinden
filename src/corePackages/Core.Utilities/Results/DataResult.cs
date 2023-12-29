using Core.Utilities.Exceptions;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }
        public ExceptionDetails Error { get; }

        public DataResult(T data, ExceptionDetails error, bool success) : base(success)
        {
            Data = data;
            Error = error;
        }
        
    }
}
