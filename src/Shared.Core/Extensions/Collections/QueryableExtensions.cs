﻿using System;
using System.Linq;

namespace Shared.Core.Extensions.Collections
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int page, int pageSize)
        {
            if (page < 0)
            {
                throw new ArgumentException("Page number should be greater than or equal to 0");
            }

            if (pageSize < 0)
            {
                throw new ArgumentException("Page size should be greater than or equal to 0");
            }

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}