using FluentValidation.Validators;
using System;

namespace Shared.Core.Validation
{
    public class MustNotValidator<TProperty> : PropertyValidator
    {
        private readonly Func<TProperty, bool> _action;

        public MustNotValidator(Func<TProperty, bool> action)
            : base(Resources.ValidationResources.Validator_MustNot_Message)
        {
            _action = action;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue is TProperty)
            {
                return !_action((TProperty)context.PropertyValue);
            }

            throw new ArgumentException();
        }
    }
}
