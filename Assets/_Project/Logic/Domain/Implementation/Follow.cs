using _Project.Domain.Core;
using _Project.Messages.FrameworkToDomain;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Domain.Implementation
{
    public class Follow : IComponent, ITickable
    {
        public bool InAttackRange { get; private set; }
        
        private readonly string _id;
        private readonly StaticData _staticData;
        private readonly IMessagePublisher _messagePublisher;
        private readonly EntitiesRepository _repository;
        private readonly Position _position;

        public Follow(
            string id, 
            StaticData staticData, 
            IMessagePublisher messagePublisher, 
            EntitiesRepository repository,
            Position position)
        {
            _id = id;
            _staticData = staticData;
            _messagePublisher = messagePublisher;
            _repository = repository;
            _position = position;
        }

        public void Tick()
        {
            Vector3 target = _repository.GetMainCharacterPosition();
            float distance = Vector3.Distance(_position.Value, target);

            InAttackRange = distance < _staticData.AttackRange;

            if (!InAttackRange)
            {
                Vector3 delta = (target - _position.Value).normalized * _staticData.EnemySpeed * deltaTime;
                _messagePublisher.Publish(new MoveMessage(_id, delta));
            }
        }
    }
}