using _Project.Messages.DomainToPresentation;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Presentation
{
    public class RotateView : MonoBehaviour, IComponentView
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
        
        public void ProvideId(string id) => 
            _id = id;

        private void OnDestroy() => 
            _disposable.Dispose();

        private void Awake() =>
            _receiver
                .Receive<UpdateRotationMessage>()
                .Subscribe(UpdateRotation)
                .AddTo(_disposable);

        private void UpdateRotation(UpdateRotationMessage updateRotationMessage)
        {
            if (_id != updateRotationMessage.ID)
                return;

            transform.forward = updateRotationMessage.Value;
        }
    }
}