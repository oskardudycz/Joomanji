using Shared.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Shared.Core.Extensions.Collections
{
    public static class CollectionExtensions
    {
        public static bool RemoveById<T>(this ICollection<T> source, object id)
            where T : IHasId
        {
            var elementToRemove = source.GetById(id);

            return source.Remove(elementToRemove);
        }
    }
}
