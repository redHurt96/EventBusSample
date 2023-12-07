using UnityEngine;

namespace _Project.Logic.Messages.FrameworkToDomain
{
    public readonly struct RotateMessage
    {
        public readonly Vector3 To;

        public RotateMessage(Vector3 to) => 
            To = to;
    }
}