using _Project.Domain;
using Zenject;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Project.Services
{
    public class EnemiesSpawnService : ITickable
    {
        private float _cooldown;
        
        private readonly StaticData _staticData;
        private readonly ActorsFactory _actorsFactory;

        public EnemiesSpawnService(StaticData staticData, ActorsFactory actorsFactory)
        {
            _staticData = staticData;
            _actorsFactory = actorsFactory;
        }

        public void Tick()
        {
            if (_cooldown > 0)
                _cooldown = Max(_cooldown - deltaTime, 0f);

            if (Approximately(_cooldown, 0f))
            {
                _actorsFactory.CreateEnemy();
                _cooldown = _staticData.Enemy.SpawnCooldown;
            }
        }
    }
}