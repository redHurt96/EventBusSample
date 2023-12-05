using _Project.Logic.Messages.FrameworkToDomain;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Framework
{
    public class MoveService : ITickable
    {
        private readonly IMessagePublisher _messagePublisher;
        private readonly StaticData _staticData;

        public MoveService(IMessagePublisher messagePublisher, StaticData staticData)
        {
            _messagePublisher = messagePublisher;
            _staticData = staticData;
        }

        public void Tick()
        {
            Vector3 input = new(
                Input.GetAxis("Horizontal"),
                0f,
                Input.GetAxis("Vertical"));
            
            if (input != Vector3.zero)
            {
                input = input.normalized * _staticData.Speed * Time.deltaTime;
                _messagePublisher.Publish(new MoveMessage(input));
            }
        }
    }
}
