using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class RotateComponent : MonoBehaviour, IActorComponent
    {
        private string _id;

        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private Transform _transform;

        [Inject]
        private void Construct(IMessageReceiver receiver)
        {
            _receiver = receiver;
            _disposable = new();
            _transform = transform;
        }

        public void ProvideId(string id) => 
            _id = id;

        public void Awake() =>
            _receiver
                .Receive<RotateMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Execute(RotateMessage message)
        {
            if (message.ID != _id)
                return;
            
            Vector3 direction = new Vector3(message.To.x, 0f, message.To.z) - _transform.position;
            _transform.forward = direction;
        }
    }
}