using System.Collections.Generic;

namespace Shared.Core.Core
{
    public interface IContextValuesProvider
    {
        IDictionary<string, object> Values { get; }
    }
}
