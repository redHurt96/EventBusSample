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
        private readonly IMessageReceiver _messageReceiver;
        private readonly CompositeDisposable _disposable;

        public Health(string id, float value, IMessageReceiver messageReceiver)
        {
            _value = value;
            _messageReceiver = messageReceiver;
            _id = id;
            _disposable = new();
        }

        public void Initialize() =>
            _messageReceiver
                .Receive<DamageMessage>()
                .Subscribe(ReceiveDamage)
                .AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

        private void ReceiveDamage(DamageMessage message)
        {
            if (_id != message.ID)
                return;
            
            _value = Max(_value - message.Amount, 0f);
        }
    }
}