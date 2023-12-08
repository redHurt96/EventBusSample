using System;
using _Project.Messages.DomainToPresentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Presentation
{
    public class MoveView : MonoBehaviour, IComponentView
    {
        private string _id;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(IMessageReceiver receiver)
        {
            _receiver = receiver;
            _disposable = new();
        }

        private void Awake() =>
            _receiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(UpdatePosition)
                .AddTo(_disposable);

        public void ProvideId(string id) => 
            _id = id;

        private void OnDestroy() => 
            _disposable.Dispose();

        private void UpdatePosition(UpdatePositionMessage updatePositionMessage)
        {
            if (_id != updatePositionMessage.ID)
                return;

            transform.position = updatePositionMessage.Position;
        }
    }
}