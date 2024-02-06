namespace Core.Utilities.Results;
public class SuccessDataResult<T> : DataResult<T>
{
    public SuccessDataResult(T data) : base(data, default, true) { }
    public SuccessDataResult() : base(default, default, true) { }
}
