using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class ProjectileAttackComponent : MonoBehaviour, IActorComponent
    {
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private CharacterFactory _factory;
        private IMessagePublisher _publisher;
        private string _id;

        [Inject]
        private void Construct(IMessageReceiver receiver, IMessagePublisher publisher, CharacterFactory factory)
        {
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

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Execute(AttackRequestMessage requestMessage)
        {
            _factory.CreateProjectile(transform.position + transform.forward, transform.forward);
            _publisher.Publish(new AttackMessage(_id));
        }
    }
}