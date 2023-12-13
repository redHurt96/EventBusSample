using _Project.Domain.Core;
using _Project.Messages;
using _Project.Services;
using Zenject;

namespace _Project.Domain.Components
{
    public class DestroyComponent : ActorComponent<DestroyMessage>
    {
        private ActorsRepository _repository;

        [Inject]
        private void Construct(ActorsRepository repository) => 
            _repository = repository;

        protected override void OnReceive(DestroyMessage message)
        {
            _repository.Remove(ID);
            Destroy(gameObject);
        }
    }
}