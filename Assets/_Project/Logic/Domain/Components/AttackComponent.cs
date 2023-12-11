using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class AttackComponent : MonoBehaviour
    {
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private CharacterFactory _factory;

        [Inject]
        private void Construct(IMessageReceiver receiver, CharacterFactory factory)
        {
            _factory = factory;
            _receiver = receiver;
            _disposable = new();
        }

        public void Awake() =>
            _receiver
                .Receive<AttackMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Execute(AttackMessage message) => 
            _factory.CreateProjectile(transform.position, transform.position + transform.forward);
    }
}