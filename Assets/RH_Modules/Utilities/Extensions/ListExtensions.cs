using System.Collections.Generic;
using static UnityEngine.Random;

namespace RH_Modules.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> list)
        {
            if (list is { Count:0 })
                throw new($"Attempt to get random element from empty list");
            
            return list[Range(0, list.Count)];
        }
    }
}