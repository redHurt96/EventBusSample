using _Project.Domain.Components;
using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        private ActorsFactory _factory;
        private CameraFollow _cameraFollow;

        [Inject]
        private void Construct(ActorsFactory factory, CameraFollow cameraFollow)
        {
            _cameraFollow = cameraFollow;
            _factory = factory;
        }

        private void Start()
        {
            GameObject mainCharacter = _factory.CreateMainCharacter();
            _cameraFollow.ProvideTarget(mainCharacter.transform);
        }
    }
}