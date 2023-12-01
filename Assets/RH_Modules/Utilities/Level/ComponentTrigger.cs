using UnityEngine;

namespace RH_Modules.Utilities.Level
{
    public abstract class ComponentTrigger<T> : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out T component))
                ExecuteOnEnter(component);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out T component))
                ExecuteOnExit(component);
        }

        protected abstract void ExecuteOnEnter(T component);
        protected virtual void ExecuteOnExit(T component) {}
    }
}