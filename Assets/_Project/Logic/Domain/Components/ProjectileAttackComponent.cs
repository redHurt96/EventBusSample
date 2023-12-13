using _Project.Domain.Core;
using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Domain.Components
{
    public class ProjectileAttackComponent : ActorComponent<AttackRequestMessage>
    {
        private ActorsFactory _factory;
        private IMessagePublisher _publisher;
        private StaticData _staticData;
        private float _cooldown;

        [Inject]
        private void Construct(
            IMessageReceiver receiver, 
            IMessagePublisher publisher, 
            ActorsFactory factory,
            StaticData staticData)
        {
            _staticData = staticData;
            _publisher = publisher;
            _factory = factory;
        }

        private void Update()
        {
            if (_cooldown > 0f)
                _cooldown = Max(_cooldown - deltaTime, 0f);
        }

        protected override void OnReceive(AttackRequestMessage message)
        {
            if (_cooldown > 0f)
                return;
            
            _factory.CreateProjectile(transform.position + transform.forward + Vector3.up * .5f, transform.forward);
            _publisher.Publish(new AttackMessage(ID));
            _cooldown = _staticData.Hero.ProjectileCastCooldown;
        }
    }
}