using UnityEngine;

namespace _Project.Logic.Messages.DomainToPresentation
{
    internal readonly struct UpdateTransformMessage
    {
        public readonly Vector3 Rotation;
        public readonly Vector3 Position;

        public UpdateTransformMessage(Vector3 position, Vector3 rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}