using UnityEngine;

namespace _Project.Messages.FrameworkToDomain
{
    public readonly struct MoveMessage
    {
        public readonly string ID;
        public readonly Vector3 Delta;

        public MoveMessage(string id, Vector3 delta)
        {
            ID = id;
            Delta = delta;
        }
    }
}