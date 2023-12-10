using System.Collections.Generic;
using UnityEngine;
using static _Project.Services.Constants;

namespace _Project.Services
{
    public class EntitiesRepository
    {
        private readonly Dictionary<string, GameObject> _actorsRepository = new();
        
        public void Add(string id, GameObject actor) => 
            _actorsRepository.Add(id, actor);

        public Vector3 GetMainCharacterPosition() =>
            _actorsRepository[MAIN_CHARACTER_ID].transform.position;
    }
}