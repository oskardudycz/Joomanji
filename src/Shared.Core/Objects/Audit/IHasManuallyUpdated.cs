using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.Utils.Collections
{
    public interface IHasManuallyUpdatedField
    {
        bool WasManuallyUpdated { get; set; }
    }
}
