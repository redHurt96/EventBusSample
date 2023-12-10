using System;
using _Project.Domain;
using _Project.Presentation;
using _Project.Simplified;
using UnityEngine;
using Zenject;
using static _Project.Services.Constants;
using static UnityEngine.Random;

namespace _Project.Services
{
    public class CharacterFactory
    {
        private readonly EntitiesRepository _repository;
        private readonly StaticData _staticData;
        private readonly IInstantiator _instantiator;

        public CharacterFactory(EntitiesRepository repository, StaticData staticData, IInstantiator instantiator)
        {
            _repository = repository;
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public void CreateMainCharacter()
        {
            string id = MAIN_CHARACTER_ID;
            GameObject actor = CreateView(id, "MainCharacter");
            _repository.Add(id, actor);
            
            actor
                .GetComponent<HealthComponent>()
                .Setup(_staticData.MainCharacterHealth);
        }

        public void CreateEnemy()
        {
            string id = Guid.NewGuid().ToString();
            GameObject actor = CreateView(id, "Enemy");
            _repository.Add(id, actor);
            
            Vector2 random = insideUnitCircle;
            actor.transform.position = new Vector3(random.x, 0f, random.y) * 10f;
            actor
                .GetComponent<HealthComponent>()
                .Setup(_staticData.EnemyHealth);
        }

        private GameObject CreateView(string id, string resourceName)
        {
            GameObject actor = _instantiator.InstantiatePrefabResource(resourceName);

            foreach (IComponentView componentView in actor.GetComponents<IComponentView>())
                componentView.ProvideId(id);

            return actor;
        }
    }
}
