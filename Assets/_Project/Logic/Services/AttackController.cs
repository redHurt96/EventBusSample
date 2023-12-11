using UniRx;
using Zenject;
using static UnityEngine.Input;

namespace _Project.Services
{
    public class AttackController : ITickable
    {
        private readonly IMessagePublisher _publisher;

        public AttackController(IMessagePublisher publisher) => 
            _publisher = publisher;

        public void Tick()
        {
            if (GetMouseButtonDown(0))
                _publisher.Publish(new AttackMessage());
        }
    }
}