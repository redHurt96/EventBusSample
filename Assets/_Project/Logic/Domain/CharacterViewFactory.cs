using _Project.Logic.Presentation;
using Zenject;

namespace _Project.Logic.Domain
{
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