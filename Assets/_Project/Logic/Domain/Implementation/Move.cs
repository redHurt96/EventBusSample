using System;
using _Project.Domain.Core;
using _Project.Messages.DomainToPresentation;
using _Project.Messages.FrameworkToDomain;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Implementation
{
    public class Move : IComponent, IInitializable, IDisposable
    {
        private readonly string _id;
        private readonly Position _position;
        private readonly StaticData _staticData;
        private readonly IMessagePublisher _publisher;
        private readonly IMessageReceiver _receiver;
        private readonly CompositeDisposable _disposable;

        public Move(string id, Position position, StaticData staticData, IMessagePublisher publisher, IMessageReceiver receiver) : base()
        {
            _id = id;
            _position = position;
            _staticData = staticData;
            _publisher = publisher;
            _receiver = receiver;
            _disposable = new();
        }

        public void Initialize()
        {
            _receiver
                .Receive<MoveMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);
            
            Publish();
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void Execute(MoveMessage message)
        {
            if (message.ID != _id)
                return;
            
            Vector3 target = _position.Value + message.Delta;
            
             _position.Value = new(
                 Mathf.Clamp(target.x, -_staticData.WorldSize, _staticData.WorldSize),
                 0f,
                 Mathf.Clamp(target.z, -_staticData.WorldSize, _staticData.WorldSize));
             
             Publish();
        }

        private void Publish()
        {
            _publisher.Publish(new UpdatePositionMessage(_id, _position.Value));
        }
    }
}