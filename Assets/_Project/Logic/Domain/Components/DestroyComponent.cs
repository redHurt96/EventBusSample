using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Domain.Components
{
    public class DestroyComponent : MonoBehaviour, IActorComponent
    {
        private string _id;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private ActorsRepository _repository;

        public void ProvideId(string id) => 
            _id = id;

        [Inject]
        private void Construct(IMessageReceiver receiver, ActorsRepository repository)
        {
            _repository = repository;
            _receiver = receiver;
            _disposable = new();
        }

        private void Start() =>
            _receiver
                .Receive<DestroyMessage>()
                .Subscribe(DestroyActor)
                .AddTo(_disposable);

        private void DestroyActor(DestroyMessage message)
        {
            if (_id != message.ID)
                return;
            
            _repository.Remove(_id);
            Destroy(gameObject);
        }
    }
}