using UnityEngine;

namespace _Project.Logic.Messages.FrameworkToDomain
{
    public readonly struct MoveMessage
    {
        public readonly Vector3 Delta;

        public MoveMessage(Vector3 delta) => 
            Delta = delta;
    }
}