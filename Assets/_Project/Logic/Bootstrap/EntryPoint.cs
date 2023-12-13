using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        private ActorsFactory _factory;

        [Inject]
        private void Construct(ActorsFactory factory) => 
            _factory = factory;

        private void Start() => 
            _factory.CreateMainCharacter();
    }
}