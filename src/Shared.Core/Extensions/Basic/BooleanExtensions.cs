using Shared.Core.Resources;
using System;
using System.Resources;

namespace Shared.Core.Extensions
{
    public static class BooleanExtensions
    {
        public static string DisplayName(this bool boolValue)
        {
            var resourceManager = new ResourceManager(typeof(CommonResources));
            var booleanValueName = string.Empty;

            try
            {
                var resourceName = resourceManager.GetString("Boolean_" + boolValue.ToString());
                if (string.IsNullOrEmpty(resourceName))
                {
                    return booleanValueName;
                }

                return resourceName;
            }
            catch (Exception)
            {
                return booleanValueName;
            }
        }
    }
}