using System;
using UnityEngine;

namespace RH_Modules.Utilities.Level
{
    public abstract class ComponentCollision<T> : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out T component))
                ExecuteOnEnter(component);
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.TryGetComponent(out T component))
                ExecuteOnExit(component);
        }

        protected abstract void ExecuteOnEnter(T component);
        protected virtual void ExecuteOnExit(T component) {}
    }
}