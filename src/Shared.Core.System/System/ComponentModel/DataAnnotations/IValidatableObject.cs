#region Assembly System.ComponentModel.DataAnnotations.dll, v4.0.0.0
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.ComponentModel.DataAnnotations.dll
#endregion

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel.DataAnnotations
{
    // Summary:
    //     Provides a way for an object to be invalidated.
    public interface IValidatableObject
    {
        // Summary:
        //     Determines whether the specified object is valid.
        //
        // Parameters:
        //   validationContext:
        //     The validation context.
        //
        // Returns:
        //     A collection that holds failed-validation information.
        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
