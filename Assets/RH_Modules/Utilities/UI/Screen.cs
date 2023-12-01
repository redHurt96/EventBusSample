using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RH_Modules.Utilities.UI
{
    public class Screen : MonoBehaviour
    {
        private static Dictionary<string, Screen> _screens = new();

        public static void Show(string screenType, bool closeCurrent = true)
        {
            screenType = screenType.ToLower();
            bool isAnyActive = _screens.Values.Any(x => x.gameObject.activeSelf);
            
            if (closeCurrent && isAnyActive)   
                CloseCurrent();
            
            _screens[screenType].SetActive(true);
        }

        private static void CloseCurrent() =>
            _screens
                .First(x => x.Value.gameObject.activeSelf)
                .Value
                .SetActive(false);

        public static void ClearCache() => 
            _screens = new();

        public void SetActive(bool isActive) => 
            gameObject.SetActive(isActive);

        public void Register() => 
            _screens.Add(gameObject.name.ToLower(), this);
    }
}