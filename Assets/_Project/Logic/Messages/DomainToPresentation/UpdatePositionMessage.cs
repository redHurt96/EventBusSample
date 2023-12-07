using UnityEngine;

namespace _Project.Logic.Messages.DomainToPresentation
{
    internal readonly struct UpdatePositionMessage
    {
        public readonly Vector3 Position;

        public UpdatePositionMessage(Vector3 position)
        {
            Position = position;
        }
    }
}