using UnityEngine;

namespace RH_Modules.Utilities.Level
{
    [RequireComponent(typeof(Renderer))]
    public class InvisibleObjectsRenderer : MonoBehaviour
    {
        private void Awake() => 
            GetComponent<Renderer>().enabled = false;
    }
}