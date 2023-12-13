using UnityEngine;

namespace _Project.Messages
{
    public struct BlastMessage
    {
        public readonly Vector3 Position;

        public BlastMessage(Vector3 position)
        {
            Position = position;
        }
    }
}