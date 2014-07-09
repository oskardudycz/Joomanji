using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Extensions.Dynamic
{
    public static class DynamicExtensions
    {
        public static dynamic ToExpando(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var property in value.GetType().GetProperties())
                expando.Add(property.Name, property.GetValue(value, null));

            return expando as ExpandoObject;
        }
    }
}
