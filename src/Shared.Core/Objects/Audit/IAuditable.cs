using System;

namespace Shared.Core.Core
{
    public interface IAuditable
    {
        object ModifiedBy { get; set; }
        DateTime ModificationTimestamp { get; set; }
    }
}
