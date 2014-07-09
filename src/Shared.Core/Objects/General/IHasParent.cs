using System;

namespace Shared.Core.Utils.Collections
{
    public interface IHasParent
    {
        Guid? ParentId { get; set; }
    }
}
