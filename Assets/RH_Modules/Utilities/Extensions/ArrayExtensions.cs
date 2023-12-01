using static UnityEngine.Random;

namespace RH_Modules.Utilities.Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandom<T>(this T[] array)
        {
            if (array is { Length:0 })
                throw new($"Attempt to get random element from empty array");
            
            return array[Range(0, array.Length)];
        }
    }
}