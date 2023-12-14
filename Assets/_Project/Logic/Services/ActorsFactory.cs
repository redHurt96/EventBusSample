using System;
using _Project.Domain;
using _Project.Domain.Components;
using UnityEngine;
using Zenject;
using static _Project.Domain.Constants;
using static UnityEngine.Random;

namespace _Project.Services
{
    public class ActorsFactory
    {
        private readonly ActorsRepository _repository;
        private readonly StaticData _staticData;
        private readonly IInstantiator _instantiator;

        public ActorsFactory(ActorsRepository repository, StaticData staticData, IInstantiator instantiator)
        {
            _repository = repository;
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public GameObject CreateMainCharacter()
        {
            string id = MAIN_CHARACTER_ID;
            GameObject actor = CreateView(id, "MainCharacter");
            _repository.Add(id, actor);
            
            actor
                .GetComponent<HealthComponent>()
                .Setup(_staticData.Hero.MainCharacterHealth);

            return actor;
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
                .Setup(_staticData.Enemy.EnemyHealth);
        }

        private GameObject CreateView(string id, string resourceName)
        {
            GameObject actor = _instantiator.InstantiatePrefabResource(resourceName);

            foreach (IActorComponent componentView in actor.GetComponents<IActorComponent>())
                componentView.ProvideId(id);

            return actor;
        }

        public void CreateProjectile(Vector3 from, Vector3 to)
        {
            string id = Guid.NewGuid().ToString();
            GameObject projectile = CreateView(id, "Projectile");
            _repository.Add(id, projectile);

            projectile.transform.position = from;
            projectile.transform.forward = to;
        }
    }
}
