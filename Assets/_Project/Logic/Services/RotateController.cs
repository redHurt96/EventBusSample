using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;
using static _Project.Domain.Constants;
using static UnityEngine.Input;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

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
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            
            Debug.DrawLine(_camera.transform.position, _camera.transform.position + ray.direction * 100f, Color.red);
            
            if (Raycast(ray, out RaycastHit hit, 100f, GetMask("Ground")))
                _messagePublisher.Publish(new RotateMessage(MAIN_CHARACTER_ID, hit.point));
        }
    }
}