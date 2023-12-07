using _Project.Logic.Messages.DomainToPresentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Presentation
{
    public class CharacterView : MonoBehaviour
    {
        private IMessageReceiver _messageReceiver;
        private CompositeDisposable _disposable;
        private Transform _transform;

        [Inject]
        private void Construct(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
            _disposable = new();
            _transform = transform;
        }

        private void Awake()
        {
            _messageReceiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(UpdatePosition)
                .AddTo(_disposable);
            
            _messageReceiver
                .Receive<UpdateRotationMessage>()
                .Subscribe(UpdateRotation)
                .AddTo(_disposable);
        }

        private void OnDestroy() => 
            _disposable.Dispose();

        private void UpdatePosition(UpdatePositionMessage updatePositionMessage) => 
            _transform.position = updatePositionMessage.Position;

        private void UpdateRotation(UpdateRotationMessage updateRotationMessage) => 
            _transform.forward = updateRotationMessage.Rotation;
    }
}