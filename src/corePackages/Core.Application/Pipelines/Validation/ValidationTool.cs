using FluentValidation;
using FluentValidation.Results;


namespace Core.Application.Pipelines.Validation
{
    public static class ValidationTool
    {
        public static async void ValidateAsync(IValidator validator, object entity)
        {
            ValidationContext<object> context = new(entity);
            ValidationResult result = await validator.ValidateAsync(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
