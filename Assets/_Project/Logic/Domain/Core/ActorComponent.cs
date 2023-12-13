using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Core
{
    public abstract class ActorComponent : MonoBehaviour, IActorComponent
    {
        public string ID { get; private set; }

        public void ProvideId(string id) => 
            ID = id;
    }
    
    public abstract class ActorComponent<T> : ActorComponent where T : IActorMessage
    {
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;

        [Inject]
        private void Construct(IMessageReceiver receiver)
        {
            _receiver = receiver;
            _disposable = new();
        }

        protected virtual void Start() => 
            _receiver.Receive<T>().Subscribe(Receive).AddTo(_disposable);

        private void OnDestroy() => 
            _disposable.Dispose();

        private void Receive(T message)
        {
            if (message.ID != ID)
                return;

            OnReceive(message);
        }

        protected abstract void OnReceive(T message);
    }
}