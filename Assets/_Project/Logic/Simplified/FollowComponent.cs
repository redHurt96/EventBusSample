using _Project.Domain;
using _Project.Messages.FrameworkToDomain;
using _Project.Presentation;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Simplified
{
    public class FollowComponent : MonoBehaviour, IComponentView
    {
        private string _id;

        private StaticData _staticData;
        private CompositeDisposable _disposable;
        private EntitiesRepository _repository;
        private IMessagePublisher _publisher;

        [Inject]
        private void Construct(StaticData staticData, EntitiesRepository repository, IMessagePublisher publisher)
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