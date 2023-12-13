using System;

namespace _Project.Domain
{
    [Serializable]
    public class HeroConfig
    {
        public float Speed = 5;
        public float MainCharacterHealth = 20;
        public float ProjectileDamage = 2f;
        public float ProjectileSpeed = 8f;
        public float ProjectileCastCooldown = .5f;
    }
}