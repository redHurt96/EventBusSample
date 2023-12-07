using System;
using _Project.Logic.Presentation;
using Zenject;

namespace _Project.Logic.Domain
{
    public class CharacterFactory
    {
        public void Create(CharacterType characterType)
        {
            string id = Guid.NewGuid().ToString();
            Character character = new();
        }
    }
    public class CharacterViewFactory : IFactory<CharacterView>
    {
        private readonly IInstantiator _instantiator;

        public CharacterViewFactory(IInstantiator instantiator) => 
            _instantiator = instantiator;

        CharacterView IFactory<CharacterView>.Create() =>
            _instantiator
                .InstantiatePrefabResource("CharacterView")
                .GetComponent<CharacterView>();
    }
}