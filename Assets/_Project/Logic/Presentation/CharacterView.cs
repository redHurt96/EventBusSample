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

        [Inject]
        private void Construct(IMessageReceiver messageReceiver)
        {
            _messageReceiver = messageReceiver;
            _disposable = new();
        }

        private void Awake() =>
            _messageReceiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(UpdatePosition)
                .AddTo(_disposable);

        private void OnDestroy() => 
            _disposable.Dispose();

        private void UpdatePosition(UpdatePositionMessage updatePositionMessage) => 
            transform.position = updatePositionMessage.Value;
    }
}