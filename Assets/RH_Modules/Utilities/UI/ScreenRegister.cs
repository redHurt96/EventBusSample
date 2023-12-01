using UnityEngine;

namespace RH_Modules.Utilities.UI
{
    public class ScreenRegister : MonoBehaviour
    {
        [SerializeField] private string _firstScreen;
        
        private void Awake()
        {
            Screen.ClearCache();
            
            foreach (Screen screen in FindObjectsOfType<Screen>(true))
            {
                screen.Register();
                screen.SetActive(false);
            }

            if (!string.IsNullOrEmpty(_firstScreen))
                Screen.Show(_firstScreen, false);
        }
    }
}