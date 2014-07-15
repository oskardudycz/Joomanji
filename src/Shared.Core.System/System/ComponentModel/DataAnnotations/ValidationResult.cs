#region Assembly System.ComponentModel.DataAnnotations.dll, v4.0.0.0
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.ComponentModel.DataAnnotations.dll
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel.DataAnnotations
{
    // Summary:
    //     Represents a container for the results of a validation request.
    public class ValidationResult
    {
        // Summary:
        //     Represents the success of the validation (true if validation was successful;
        //     otherwise, false).
        public static readonly ValidationResult Success;

        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.ValidationResult
        //     class by using an error message.
        //
        // Parameters:
        //   errorMessage:
        //     The error message.
        public ValidationResult(string errorMessage) 
        {
            ErrorMessage = errorMessage;
        }
        //
        // Summary:
        //     Initializes a new instance of the System.ComponentModel.DataAnnotations.ValidationResult
        //     class by using an error message and a list of members that have validation
        //     errors.
        //
        // Parameters:
        //   errorMessage:
        //     The error message.
        //
        //   memberNames:
        //     The list of member names that have validation errors.
        public ValidationResult(string errorMessage, IEnumerable<string> memberNames) : this(errorMessage) 
        {
            MemberNames = memberNames;
        }

        // Summary:
        //     Gets the error message for the validation.
        //
        // Returns:
        //     The error message for the validation.
        public string ErrorMessage { get; set; }
        //
        // Summary:
        //     Gets the collection of member names that indicate which fields have validation
        //     errors.
        //
        // Returns:
        //     The collection of member names that indicate which fields have validation
        //     errors.
        public IEnumerable<string> MemberNames { get; private set; }
    }
}
