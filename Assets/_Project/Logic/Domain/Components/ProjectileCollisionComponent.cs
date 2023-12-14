using _Project.Domain.Core;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class ProjectileCollisionComponent : ActorComponent
    {
        private IMessagePublisher _publisher;
        private StaticData _staticData;

        [Inject]
        private void Construct(IMessagePublisher publisher, StaticData staticData)
        {
            _staticData = staticData;
            _publisher = publisher;
        }

        private void OnTriggerEnter(Collider other)
        {
            _publisher.Publish(new DestroyMessage(ID));
            
            if (other.TryGetComponent(out HealthComponent health))
            {
                _publisher.Publish(new DamageMessage(health.ID, _staticData.Hero.ProjectileDamage));
                _publisher.Publish(new BlastMessage(other.ClosestPointOnBounds(transform.position)));
            }
        }
    }
}