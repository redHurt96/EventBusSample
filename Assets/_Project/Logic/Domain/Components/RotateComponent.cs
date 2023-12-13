using _Project.Domain.Core;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class RotateComponent : ActorComponent<RotateMessage>
    {
        private Transform _transform;

        [Inject]
        private void Construct(IMessageReceiver receiver) => 
            _transform = transform;

        protected override void OnReceive(RotateMessage message)
        {
            Vector3 direction = new Vector3(message.To.x, 0f, message.To.z) - _transform.position;
            _transform.forward = direction;
        }
    }
}