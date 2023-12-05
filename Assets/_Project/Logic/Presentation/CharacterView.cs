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

        private void Awake() =>
            _messageReceiver
                .Receive<UpdateTransformMessage>()
                .Subscribe(UpdatePosition)
                .AddTo(_disposable);

        private void OnDestroy() => 
            _disposable.Dispose();

        private void UpdatePosition(UpdateTransformMessage updateTransformMessage)
        {
            _transform.position = updateTransformMessage.Position;
            _transform.forward = updateTransformMessage.Rotation;
        }
    }
}