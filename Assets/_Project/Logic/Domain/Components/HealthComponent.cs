using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Mathf;

namespace _Project.Domain.Components
{
    public class HealthComponent : MonoBehaviour, IActorComponent
    {
        public string ID { get; private set; }
        
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
            ID = id;

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
            if (ID != damage.ID)
                return;

            _currentValue = Max(_currentValue - damage.Amount, 0f);
            PublishCurrentHealth();
            
            if (Approximately(_currentValue, 0f))
                _publisher.Publish(new DestroyMessage(ID));
        }

        private void PublishCurrentHealth() => 
            _publisher.Publish(new UpdateHealthMessage(ID, _currentValue, _maxValue));
    }
}