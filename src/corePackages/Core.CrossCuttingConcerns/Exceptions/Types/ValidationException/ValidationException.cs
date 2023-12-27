using Core.Utilities.Exceptions;

namespace Core.CrossCuttingConcerns.Exceptions.Types.ValidationException
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; set; }

        public ValidationException():base()
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string? message):base(message)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
            Errors = Array.Empty<ValidationExceptionModel>();
        }

        public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
        {
            IEnumerable<string> arr = errors.Select(
                e => $"{Environment.NewLine} -- {e.Property}: {string.Join(Environment.NewLine, values: e.Errors ?? Array.Empty<string>())}"
                );
            return $"Validation failed: {string.Join(string.Empty, arr)}";
        }
    }
}
