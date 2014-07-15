using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Shared.Core.Validation
{
    public interface IValidatable : IValidatableObject
    {
        FluentValidation.Results.ValidationResult Validate();
    }
}
