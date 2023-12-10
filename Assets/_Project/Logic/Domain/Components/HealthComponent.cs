using _Project.Domain.Implementation;
using _Project.Presentation;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;

namespace _Project.Simplified
{
    public class HealthComponent : MonoBehaviour, ICharacterComponent
    {
        private string _id;
        private float _maxValue;
        private float _currentValue;

        private CompositeDisposable _disposable;
        private IMessagePublisher _publisher;
        private IMessageReceiver _receiver;

        [Inject]
        private void Construct(IMessageReceiver receiver, IMessagePublisher publisher)
        {
            _receiver = receiver;
            _publisher = publisher;
            _disposable = new();
        }

        public void Setup(float maxValue)
        {
            _maxValue = maxValue;
            _currentValue = _maxValue;
        }

        public void ProvideId(string id) => 
            _id = id;

        private void Start()
        {
            _receiver
                .Receive<DamageMessage>()
                .Subscribe(ProvideDamage)
                .AddTo(_disposable);
            PublishCurrentHealth();
        }

        public void OnDestroy() => 
            _disposable.Dispose();

        private void ProvideDamage(DamageMessage damage)
        {
            if (_id != damage.ID)
                return;

            _currentValue = Max(_currentValue - damage.Amount, 0f);
            PublishCurrentHealth();
        }

        private void PublishCurrentHealth()
        {
            _publisher.Publish(new UpdateHealthMessage(_id, _currentValue, _maxValue));
        }
    }
}