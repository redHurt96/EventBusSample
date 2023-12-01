using UnityEngine;
using UnityEngine.UI;

namespace RH_Modules.Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseActionButton : MonoBehaviour
    {
        private Button _button;

        protected abstract void PerformOnClick();
        protected virtual void PerformOnStart() {}

        private void Start()
        {
            PerformOnStart();
            
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PerformOnClick);
        }

        private void OnDestroy()
        {
            if (_button == null)
                return;
            
            _button.onClick.RemoveListener(PerformOnClick);
        }
    }
}