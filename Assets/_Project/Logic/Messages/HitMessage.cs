using UnityEngine;

namespace _Project.Messages
{
    public struct HitMessage
    {
        public readonly Vector3 Position;

        public HitMessage(Vector3 position)
        {
            Position = position;
        }
    }
}