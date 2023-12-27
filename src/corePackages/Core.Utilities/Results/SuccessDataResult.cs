namespace Core.Utilities.Results

{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, default, true, message)
        {
        }
        public SuccessDataResult(T data) : base(data, default, true)
        {
        }
        public SuccessDataResult(string message) : base(default, default, true, message)
        {
        }
        public SuccessDataResult() : base(default, default, true)
        {
        }

    }
}
