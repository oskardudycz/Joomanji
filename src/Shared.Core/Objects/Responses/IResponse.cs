using System.Runtime.Serialization;

namespace Shared.Core.Objects.Responses
{
    public interface IResponse
    {
        [DataMember]
        FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}