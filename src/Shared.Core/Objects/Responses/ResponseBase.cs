using Shared.Core.Validation;
using System.Runtime.Serialization;

namespace Shared.Core.Objects.Responses
{
    [DataContract]
    public abstract class ResponseBase : ValidatableObjectBase, IResponse
    {
        [DataMember]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }

        public ResponseBase()
        {
            ValidationResult = new FluentValidation.Results.ValidationResult();
        }
    }
}