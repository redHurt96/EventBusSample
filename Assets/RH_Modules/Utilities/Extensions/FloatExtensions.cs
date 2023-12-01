using static UnityEngine.Mathf;

namespace RH_Modules.Utilities.Extensions
{
    public static class FloatExtensions
    {
        public static bool ApproximatelyEqual(this float a, float b) => 
            Approximately(a, b);
    }
}