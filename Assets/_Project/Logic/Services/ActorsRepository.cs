using System.Collections.Generic;
using UnityEngine;
using static _Project.Domain.Constants;

namespace _Project.Services
{
    public class ActorsRepository
    {
        public bool HasMainCharacter => _actorsRepository.ContainsKey(MAIN_CHARACTER_ID);
        
        private readonly Dictionary<string, GameObject> _actorsRepository = new();

        public void Add(string id, GameObject actor) => 
            _actorsRepository.Add(id, actor);

        public void Remove(string id) => 
            _actorsRepository.Remove(id);

        public Vector3 GetMainCharacterPosition() =>
            _actorsRepository[MAIN_CHARACTER_ID].transform.position;
    }
}