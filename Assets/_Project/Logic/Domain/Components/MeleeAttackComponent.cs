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
    public class MeleeAttackComponent : MonoBehaviour
    {
        private float _cooldown;
        private bool _inRange;
        private StaticData _staticData;
        private IMessagePublisher _publisher;
        private EntitiesRepository _repository;

        [Inject]
        private void Construct(StaticData staticData, IMessagePublisher publisher, EntitiesRepository repository)
        {
            _repository = repository;
            _staticData = staticData;
            _publisher = publisher;
        }
        
        private void Update()
        {
            if (_cooldown > 0f)
                _cooldown = Max(_cooldown - deltaTime, 0f);

            float distance = Distance(transform.position, _repository.GetMainCharacterPosition());
            
            if (distance > _staticData.AttackDistance || _cooldown > 0f)
                return;
            
            _publisher.Publish(new DamageMessage(MAIN_CHARACTER_ID, _staticData.MeleeAttackValue));
            _cooldown = _staticData.AttackCooldown;
        }
    }
}