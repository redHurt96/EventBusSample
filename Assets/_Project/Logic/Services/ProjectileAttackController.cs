using UniRx;
using Zenject;
using static _Project.Domain.Constants;
using static UnityEngine.Input;

namespace _Project.Services
{
    public class ProjectileAttackController : ITickable
    {
        private readonly IMessagePublisher _publisher;

        public ProjectileAttackController(IMessagePublisher publisher) => 
            _publisher = publisher;

        public void Tick()
        {
            if (GetMouseButtonDown(0))
                _publisher.Publish(new AttackRequestMessage(MAIN_CHARACTER_ID));
        }
    }
}