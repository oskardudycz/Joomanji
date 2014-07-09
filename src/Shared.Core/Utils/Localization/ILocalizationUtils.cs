using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Utils.Localization
{
    public interface ILocalizationUtils
    {
        string LookupResource(Type resourceManagerProvider, string resourceKey, params object[] formatParams);
        string LookupResource<T>(string resourceKey, params object[] formatParams);
        string LookupResource(ResourceQualifiedKey resourceQualifiedKey, params object[] formatParams);
        ResourceManager GetResourceManager(Type resourceManagerProvider);
    }
}
