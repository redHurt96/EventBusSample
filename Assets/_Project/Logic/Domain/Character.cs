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
        
        private readonly IMessageReceiver _messageReceiver;
        private readonly IMessagePublisher _messagePublisher;
        private readonly CompositeDisposable _disposable;

        public Character(IMessageReceiver messageReceiver, IMessagePublisher messagePublisher)
        {
            _messageReceiver = messageReceiver;
            _messagePublisher = messagePublisher;
            _disposable = new();
        }

        public void Initialize() =>
            _messageReceiver
                .Receive<MoveMessage>()
                .Subscribe(Move)
                .AddTo(_disposable);

        private void Move(MoveMessage moveMessage)
        {
            _position += moveMessage.Delta;
            _messagePublisher.Publish(new UpdatePositionMessage(_position));
        }
    }
}
