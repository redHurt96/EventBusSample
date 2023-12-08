using System;
using System.Linq;
using _Project.Domain;
using _Project.Domain.Core;
using _Project.Domain.Implementation;
using _Project.Presentation;
using UniRx;
using UnityEngine;
using Zenject;
using static _Project.Services.Constants;
using static UnityEngine.Random;

namespace _Project.Services
{
    public class CharacterFactory
    {
        private readonly EntitiesRepository _repository;
        private readonly IMessageReceiver _receiver;
        private readonly IMessagePublisher _publisher;
        private readonly StaticData _staticData;
        private readonly IInstantiator _instantiator;

        public CharacterFactory(
            EntitiesRepository repository, 
            IMessageReceiver receiver, 
            IMessagePublisher publisher, 
            StaticData staticData,
            IInstantiator instantiator)
        {
            _repository = repository;
            _receiver = receiver;
            _publisher = publisher;
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public void CreateMainCharacter()
        {
            string id = MAIN_CHARACTER_ID;
            Position position = new();
            Rotation rotation = new();
            Move move = new(id, position, _staticData, _publisher, _receiver);
            Rotate rotate = new(id, position, rotation, _publisher, _receiver);
            Health health = new(id, _staticData.MainCharacterHealth, _receiver);
            Entity entity = new(id, position, rotation, move, rotate, health);

            _repository.Add(entity);
            CreateView(id, "MainCharacter");
            
            foreach (IInitializable initializable in entity.Components.OfType<IInitializable>())
                initializable.Initialize();
        }

        public void CreateEnemy()
        {
            string id = Guid.NewGuid().ToString();
            Position position = new();
            Rotation rotation = new();
            Move move = new(id, position, _staticData, _publisher, _receiver);
            Rotate rotate = new(id, position, rotation, _publisher, _receiver);
            Follow follow = new(id, _staticData, _publisher, _repository, position);
            MeleeAttack attack = new(_staticData, _publisher, follow);
            Health health = new(id, _staticData.EnemyHealth, _receiver);
            Entity entity = new(id, position, rotation, move, rotate, follow, attack, health);

            Vector2 random = insideUnitCircle;
            position.Value = new Vector3(random.x, 0f, random.y) * 10f;
            
            _repository.Add(entity);
            CreateView(id, "Enemy");
            
            foreach (IInitializable initializable in entity.Components.OfType<IInitializable>())
                initializable.Initialize();
        }

        private void CreateView(string id, string resourceName)
        {
            EntityView entityView = _instantiator.InstantiatePrefabResourceForComponent<EntityView>(resourceName);

            foreach (IComponentView componentView in entityView.GetComponents<IComponentView>())
                componentView.ProvideId(id);
        }
    }
}
