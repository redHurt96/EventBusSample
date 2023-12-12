using System;
using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Domain.Components
{
    public class ProjectileAttackComponent : MonoBehaviour, IActorComponent
    {
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private CharacterFactory _factory;
        private IMessagePublisher _publisher;
        private StaticData _staticData;
        private string _id;
        private float _cooldown;

        [Inject]
        private void Construct(
            IMessageReceiver receiver, 
            IMessagePublisher publisher, 
            CharacterFactory factory,
            StaticData staticData)
        {
            _staticData = staticData;
            _publisher = publisher;
            _factory = factory;
            _receiver = receiver;
            _disposable = new();
        }

        public void ProvideId(string id) => 
            _id = id;

        public void Awake() =>
            _receiver
                .Receive<AttackRequestMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);

        private void Update()
        {
            if (_cooldown > 0f)
                _cooldown = Max(_cooldown - deltaTime, 0f);
        }

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Execute(AttackRequestMessage requestMessage)
        {
            if (_cooldown > 0f)
                return;
            
            _factory.CreateProjectile(transform.position + transform.forward, transform.forward);
            _publisher.Publish(new AttackMessage(_id));
            _cooldown = _staticData.ProjectileCastCooldown;
        }
    }
}