using Shared.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.NET45.Context
{
    class Class1 : IValidatable, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }

        public FluentValidation.Results.ValidationResult Validate()
        {
            throw new NotImplementedException();
        }
    }
}
