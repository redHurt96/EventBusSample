using _Project.Domain.Core;
using _Project.Messages;
using UnityEngine;

namespace _Project.Domain.Components
{
    public class MoveComponent : ActorComponent<MoveMessage>
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        protected override void OnReceive(MoveMessage message)
        {
            Vector3 target = transform.position + message.Delta;
            _rigidbody.MovePosition(target);
        }
    }
}
