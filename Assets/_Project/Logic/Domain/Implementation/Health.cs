using System;
using _Project.Domain.Core;
using UniRx;
using Zenject;
using static UnityEngine.Mathf;

namespace _Project.Domain.Implementation
{
    public class Health : IComponent, IInitializable, IDisposable
    {
        private float _value;

        private readonly string _id;
        private readonly float _maxValue;
        private readonly IMessageReceiver _messageReceiver;
        private readonly IMessagePublisher _messagePublisher;
        private readonly CompositeDisposable _disposable;

        public Health(string id, float value, IMessageReceiver messageReceiver, IMessagePublisher messagePublisher)
        {
            _value = value;
            _maxValue = value;
            _messageReceiver = messageReceiver;
            _messagePublisher = messagePublisher;
            _id = id;
            _disposable = new();
        }

        public void Initialize()
        {
            _messageReceiver
                .Receive<DamageMessage>()
                .Subscribe(ReceiveDamage)
                .AddTo(_disposable);
            Publish();
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void ReceiveDamage(DamageMessage message)
        {
            if (_id != message.ID)
                return;
            
            _value = Max(_value - message.Amount, 0f);
            Publish();
        }

        private void Publish() => 
            _messagePublisher.Publish(new UpdateHealthMessage(_id, _value, _maxValue));
    }
}