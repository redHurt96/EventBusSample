using UnityEngine;

namespace _Project.Logic.Messages.DomainToPresentation
{
    internal readonly struct UpdatePositionMessage
    {
        public readonly Vector3 Value;

        public UpdatePositionMessage(Vector3 value) => 
            Value = value;
    }
}