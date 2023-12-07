using _Project.Logic.Messages.FrameworkToDomain;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Services
{
    public class RotateService : ITickable
    {
        private readonly Camera _camera;
        private readonly IMessagePublisher _messagePublisher;

        public RotateService(Camera camera, IMessagePublisher messagePublisher)
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
                _messagePublisher.Publish(new RotateMessage(hit.point));
            }
        }
    }
}