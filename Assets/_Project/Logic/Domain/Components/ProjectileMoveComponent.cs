using _Project.Domain.Core;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Domain.Components
{
    public class ProjectileMoveComponent : ActorComponent
    {
        private StaticData _staticData;
        private IMessagePublisher _publisher;

        [Inject]
        private void Construct(StaticData staticData, IMessagePublisher messagePublisher)
        {
            _publisher = messagePublisher;
            _staticData = staticData;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            
            if (Abs(position.x) >= _staticData.WorldSize || Abs(position.z) >= _staticData.WorldSize)
                _publisher.Publish(new DestroyMessage(ID));
            else
                _publisher.Publish(new MoveMessage(ID, transform.forward * (_staticData.Hero.ProjectileSpeed * deltaTime)));
        }
    }
}