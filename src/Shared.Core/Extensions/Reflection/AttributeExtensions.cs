using System;
using System.Linq;

namespace Shared.Core.Extensions
{
    public static class AttributeExtensions
    {
        /// <summary>
        /// Gets attribute value. Usage: string name = typeof(MyClass).GetAttributeValue((SomeAttribute attr) => attr.Name);
        /// </summary>
        public static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
}