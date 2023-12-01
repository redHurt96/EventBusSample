using System;

namespace RH_Modules.Utilities.Extensions
{
    public static class FluentExtensions
    {
        public static T With<T>(this T self, Action<T> set)
        {
            set.Invoke(self);
            return self;
        }
        
        public static T With<T>(this T self, Action<T> apply, bool when)
        {
            if (when)
                apply?.Invoke(self);
            
            return self;
        }
        
        public static T With<T>(this T self, Action<T> apply, Func<bool> when)
        {
            if (when())
                apply?.Invoke(self);
            
            return self;
        }
    }
}