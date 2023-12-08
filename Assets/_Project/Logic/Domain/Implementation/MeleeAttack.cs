using _Project.Domain.Core;
using _Project.Services;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Time;

namespace _Project.Domain.Implementation
{
    public class MeleeAttack : IComponent, ITickable
    {
        private readonly StaticData _staticData;
        private readonly IMessagePublisher _messagePublisher;
        private readonly Follow _follow;

        private float _cooldown;

        public MeleeAttack(
            StaticData staticData, 
            IMessagePublisher messagePublisher,
            Follow follow)
        {
            _staticData = staticData;
            _messagePublisher = messagePublisher;
            _follow = follow;
        }

        public void Tick()
        {
            if (_cooldown > 0f)
                _cooldown = Mathf.Max(_cooldown - deltaTime, 0f);
            
            if (!_follow.InAttackRange || _cooldown > 0f)
                return;
            
            _messagePublisher.Publish(new DamageMessage(Constants.MAIN_CHARACTER_ID, _staticData.MeleeAttackValue));
            _cooldown = _staticData.AttackCooldown;
        }
    }
}