using _Project.Logic.Framework;
using _Project.Logic.Messages.DomainToPresentation;
using _Project.Logic.Messages.FrameworkToDomain;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Domain
{
    public class Character : IInitializable
    {
        private Vector3 _position;
        private Vector3 _rotation;
        
        private readonly IMessageReceiver _messageReceiver;
        private readonly IMessagePublisher _messagePublisher;
        private readonly StaticData _staticData;
        private readonly CompositeDisposable _disposable;

        public Character(IMessageReceiver messageReceiver, IMessagePublisher messagePublisher, StaticData staticData)
        {
            _messageReceiver = messageReceiver;
            _messagePublisher = messagePublisher;
            _staticData = staticData;
            _disposable = new();
        }

        public void Initialize() =>
            _messageReceiver
                .Receive<MoveMessage>()
                .Subscribe(Move)
                .AddTo(_disposable);

        private void Move(MoveMessage moveMessage)
        {
            Vector3 target = _position + moveMessage.Delta;
            _position = new(
                Mathf.Clamp(target.x, -_staticData.WorldSize, _staticData.WorldSize),
                0f,
                Mathf.Clamp(target.z, -_staticData.WorldSize, _staticData.WorldSize));
            _rotation = moveMessage.Delta.normalized;
            _messagePublisher.Publish(new UpdateTransformMessage(_position, _rotation));
        }
    }
}
