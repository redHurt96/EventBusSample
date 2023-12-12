using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class MoveComponent : MonoBehaviour, IActorComponent
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private string _id;
        private StaticData _staticData;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(StaticData staticData, IMessageReceiver receiver)
        {
            _staticData = staticData;
            _receiver = receiver;
            _disposable = new();
        }

        public void ProvideId(string id) => 
            _id = id;

        public void Awake() =>
            _receiver
                .Receive<MoveMessage>()
                .Subscribe(Execute)
                .AddTo(_disposable);

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Execute(MoveMessage message)
        {
            if (message.ID != _id)
                return;
            
            Vector3 target = transform.position + message.Delta;
            
            target = new(
                Mathf.Clamp(target.x, -_staticData.WorldSize, _staticData.WorldSize),
                0f,
                Mathf.Clamp(target.z, -_staticData.WorldSize, _staticData.WorldSize));

            _rigidbody.MovePosition(target);
        }
    }
}
