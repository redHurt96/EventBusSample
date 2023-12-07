using UnityEngine;

namespace _Project.Logic.Messages.DomainToPresentation
{
    internal readonly struct UpdateRotationMessage
    {
        public readonly Vector3 Rotation;

        public UpdateRotationMessage(Vector3 rotation)
        {
            Rotation = rotation;
        }
    }
}