using System.Runtime.Serialization;
using Shared.Core.Validation;

namespace Shared.Core.Objects.DTO
{
    [DataContract]
    public abstract class DTOBase : ValidatableObjectBase, IDTO
    {
    }
}
