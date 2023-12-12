using UnityEngine;

namespace _Project.Domain
{
    [CreateAssetMenu(menuName = "Create StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        //Main character
        public float Speed = 5;
        public float WorldSize = 15;
        public float MainCharacterHealth = 20;
        public float ProjectileDamage = 2f;
        public float ProjectileSpeed = 8f;

        //Enemy
        public float MoveDistance = 1.5f;
        public float MeleeAttackValue = 1f;
        public float AttackCooldown = 1f;
        public float EnemySpeed = 4f;
        public float EnemyHealth = 10;
        public float AttackDistance = 1.5f;
        public float StopTime = .3f;
    }
}