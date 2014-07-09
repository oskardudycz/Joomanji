using System;

namespace Shared.Core.Utils.Collections
{
    public interface IIsSelfReferenced
    {
        Guid? SelfReferenceID { get; set; }
    }
}
