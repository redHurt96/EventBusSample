using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class MainSceneRunner : MonoBehaviour
    {
        private CharacterFactory _factory;

        [Inject]
        private void Construct(CharacterFactory factory) => 
            _factory = factory;

        private void Start()
        {
            _factory.CreateMainCharacter();
            _factory.CreateEnemy();
        }
    }
}