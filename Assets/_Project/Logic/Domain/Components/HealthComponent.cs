using _Project.Domain.Core;
using _Project.Messages;
using UniRx;
using Zenject;
using static UnityEngine.Mathf;

namespace _Project.Domain.Components
{
    public class HealthComponent : ActorComponent<DamageMessage>
    {
        private float _maxValue;
        private float _currentValue;
        private IMessagePublisher _publisher;

        [Inject]
        private void Construct(IMessagePublisher publisher) => 
            _publisher = publisher;

        public void Setup(float maxValue)
        {
            _maxValue = maxValue;
            _currentValue = _maxValue;
            PublishCurrentHealth();
        }

        protected override void OnReceive(DamageMessage message)
        {
            _currentValue = Max(_currentValue - message.Amount, 0f);
            PublishCurrentHealth();
            
            if (Approximately(_currentValue, 0f))
                _publisher.Publish(new DestroyMessage(ID));
        }

        private void PublishCurrentHealth() => 
            _publisher.Publish(new UpdateHealthMessage(ID, _currentValue, _maxValue));
    }
}