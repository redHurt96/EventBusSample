using System;
using _Project.Domain.Core;
using _Project.Messages.DomainToPresentation;
using _Project.Messages.FrameworkToDomain;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Implementation
{
    public class Rotate : IComponent, IInitializable, IDisposable
    {
        private readonly string _id;
        private readonly Position _position;
        private readonly Rotation _rotation;
        private readonly IMessagePublisher _publisher;
        private readonly IMessageReceiver _receiver;
        private readonly CompositeDisposable _disposable;

        public Rotate(string id, Position position, Rotation rotation, IMessagePublisher publisher, IMessageReceiver receiver)
        {
            _id = id;
            _position = position;
            _rotation = rotation;
            _publisher = publisher;
            _receiver = receiver;
            _disposable = new();
        }

        public void Initialize()
        {
            _receiver
                .Receive<RotateMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);
            
            Publish();
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void Execute(RotateMessage message)
        {
            if (message.ID != _id)
                return;
            
            Vector3 direction = new Vector3(message.To.x, 0f, message.To.z) - _position.Value;
            _rotation.Value = direction;
            
            Publish();
        }

        private void Publish()
        {
            _publisher.Publish(new UpdateRotationMessage(_id, _rotation.Value));
        }
    }
}