using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Color;
using static UnityEngine.Gizmos;

namespace RH_Modules.Utilities.Gizmos
{
    public class GizmosSphere : MonoBehaviour
    {
        [SerializeField] private Color _color = red;
        [SerializeField] private float _radius = 1f;

        private void Start()
        {
            if (!isEditor)
                Destroy(this);
        }

        private void OnDrawGizmos()
        {
            color = _color;
            DrawSphere(transform.position, _radius);
        }
    }
}