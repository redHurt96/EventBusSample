using _Project.Messages;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static _Project.Domain.Constants;
using static UnityEngine.Mathf;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace _Project.Domain.Components
{
    public class MeleeAttackComponent : MonoBehaviour, IActorComponent
    {  
        private string _id;
        private float _cooldown;
        private bool _inRange;
        private StaticData _staticData;
        private IMessagePublisher _publisher;
        private ActorsRepository _repository;

        [Inject]
        private void Construct(StaticData staticData, IMessagePublisher publisher, ActorsRepository repository)
        {
            _repository = repository;
            _staticData = staticData;
            _publisher = publisher;
        }

        public void ProvideId(string id) => 
            _id = id;

        private void Update()
        {
            if (!_repository.HasMainCharacter)
                return;
            
            if (_cooldown > 0f)
                _cooldown = Max(_cooldown - deltaTime, 0f);

            Vector3 mainCharacterPosition = _repository.GetMainCharacterPosition();
            Vector3 currentPosition = transform.position;
            float distance = Distance(currentPosition, mainCharacterPosition);
            
            if (distance > _staticData.AttackDistance || _cooldown > 0f)
                return;
            
            _publisher.Publish(new DamageMessage(MAIN_CHARACTER_ID, _staticData.MeleeAttackValue));
            _publisher.Publish(new AttackMessage(_id));
            _publisher.Publish(new HitMessage(Lerp(mainCharacterPosition, currentPosition, .5f)));
            _cooldown = _staticData.AttackCooldown;
        }
    }
}