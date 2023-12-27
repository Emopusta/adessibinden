using Core.Utilities.Exceptions;

namespace Core.Utilities.Results

{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(ExceptionDetails error, string message) : base(default, error, false, message)
        {

        }
        public ErrorDataResult(ExceptionDetails error) : base(default,error, false)
        {

        }

        public ErrorDataResult(string message) : base(default, default, false, message)
        {
        }
        public ErrorDataResult() : base(default, default, false)
        {
        }
    }
}
