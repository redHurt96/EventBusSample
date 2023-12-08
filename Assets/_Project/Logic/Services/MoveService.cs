using _Project.Domain;
using _Project.Messages.FrameworkToDomain;
using UniRx;
using UnityEngine;
using Zenject;
using static _Project.Services.Constants;
using static UnityEngine.Input;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace _Project.Services
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
            Vector3 input = new(GetAxis("Horizontal"), 0f, GetAxis("Vertical"));
            
            if (input != zero)
            {
                input = input.normalized * _staticData.Speed * deltaTime;
                _messagePublisher.Publish(new MoveMessage(MAIN_CHARACTER_ID, input));
            }
        }
    }
}
