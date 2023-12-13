using UnityEngine;

namespace _Project.Domain
{
    [CreateAssetMenu(menuName = "Create StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        public float WorldSize = 15;
        public HeroConfig Hero;
        public EnemyConfig Enemy;
    }
}