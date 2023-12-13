using System;

namespace _Project.Domain
{
    [Serializable]
    public class EnemyConfig
    {
        public float MoveDistance = 1.5f;
        public float MeleeAttackValue = 1f;
        public float AttackCooldown = 1f;
        public float EnemySpeed = 4f;
        public float EnemyHealth = 10;
        public float AttackDistance = 1.5f;
        public float StopTime = .3f;
        public float SpawnCooldown = 1f;
    }
}