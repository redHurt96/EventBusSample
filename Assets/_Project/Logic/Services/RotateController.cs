using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;
using static _Project.Domain.Constants;

namespace _Project.Services
{
    public class RotateController : ITickable
    {
        private readonly Camera _camera;
        private readonly IMessagePublisher _messagePublisher;

        public RotateController(Camera camera, IMessagePublisher messagePublisher)
        {
            _camera = camera;
            _messagePublisher = messagePublisher;
        }

        public void Tick()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit)
                && hit.collider.CompareTag("Ground"))
            {
                _messagePublisher.Publish(new RotateMessage(MAIN_CHARACTER_ID, hit.point));
            }
        }
    }
}