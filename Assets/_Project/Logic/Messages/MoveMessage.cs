using UnityEngine;

namespace _Project.Messages
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