using UnityEngine;
using static UnityEngine.Vector3;

namespace _Project.Domain.Components
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _lerp;

        private Transform _target;
        
        public void ProvideTarget(Transform target) =>
            _target = target;

        private void LateUpdate()
        {
            if (_target == null)
                return;
            
            transform.position = Lerp(transform.position, _target.position + _offset, _lerp);
        }
    }
}