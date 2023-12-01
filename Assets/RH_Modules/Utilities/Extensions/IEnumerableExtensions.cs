using System;
using System.Collections.Generic;

namespace RH_Modules.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T obj in source)
                action(obj);

            return source;
        }
    }
}