using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class DamageByCollisionComponent : MonoBehaviour, IActorComponent
    {
        private IMessagePublisher _publisher;
        private StaticData _staticData;
        private string _id;

        [Inject]
        private void Construct(IMessagePublisher publisher, StaticData staticData)
        {
            _staticData = staticData;
            _publisher = publisher;
        }

        public void ProvideId(string id) => 
            _id = id;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthComponent health))
                _publisher.Publish(new DamageMessage(health.ID, _staticData.ProjectileDamage));
        }
    }
}