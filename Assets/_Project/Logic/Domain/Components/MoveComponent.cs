using _Project.Domain.Core;
using _Project.Messages;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;

namespace _Project.Domain.Components
{
    public class MoveComponent : ActorComponent<MoveMessage>
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private StaticData _staticData;

        [Inject]
        private void Construct(StaticData staticData) => 
            _staticData = staticData;

        protected override void OnReceive(MoveMessage message)
        {
            Vector3 target = transform.position + message.Delta;
            
            target = new(
                Clamp(target.x, -_staticData.WorldSize, _staticData.WorldSize),
                0f,
                Clamp(target.z, -_staticData.WorldSize, _staticData.WorldSize));

            _rigidbody.MovePosition(target);
        }
    }
}
