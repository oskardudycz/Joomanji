using FluentValidation;

namespace Shared.Core.Validation
{
    public class NestedComponentValidator<T> : AbstractValidator<T>
    {
        public override FluentValidation.Results.ValidationResult Validate(T instance)
        {
            return base.Validate(instance);
        }
    }
}
