using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Domain.Components
{
    public class FollowComponent : MonoBehaviour, IActorComponent
    {
        private string _id;

        private StaticData _staticData;
        private CompositeDisposable _disposable;
        private ActorsRepository _repository;
        private IMessagePublisher _publisher;

        [Inject]
        private void Construct(StaticData staticData, ActorsRepository repository, IMessagePublisher publisher)
        {
            _publisher = publisher;
            _repository = repository;
            _staticData = staticData;
            _disposable = new();
        }

        public void ProvideId(string id) => 
            _id = id;

        public void OnDestroy() => 
            _disposable.Dispose();

        private void Update()
        {
            if (!_repository.HasMainCharacter)
                return;
            
            Vector3 target = _repository.GetMainCharacterPosition();
            Vector3 position = transform.position;
            float distance = Vector3.Distance(position, target);

            if (distance > _staticData.MoveDistance)
            {
                Vector3 delta = (target - position).normalized * (_staticData.EnemySpeed * deltaTime);
                _publisher.Publish(new MoveMessage(_id, delta));
                _publisher.Publish(new RotateMessage(_id, target));
            }
        }
    }
}