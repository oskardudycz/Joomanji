using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Core.Validation
{
  public interface IValidatable : IValidatableObject
  {
      FluentValidation.Results.ValidationResult Validate();
  }
}
