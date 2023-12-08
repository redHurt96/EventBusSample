using System.Collections.Generic;
using _Project.Domain.Core;
using _Project.Domain.Implementation;
using UnityEngine;
using Zenject;
using static _Project.Services.Constants;

namespace _Project.Services
{
    public class EntitiesRepository : ITickable
    {
        private readonly List<Entity> _entities = new();
        
        public void Add(Entity entity) => 
            _entities.Add(entity);

        public Vector3 GetMainCharacterPosition() => 
            _entities
                .Find(x => x.ID == MAIN_CHARACTER_ID)
                .Get<Position>()
                .Value;

        public void Tick()
        {
            foreach (Entity entity in _entities) 
                entity.Tick();
        }
    }
}