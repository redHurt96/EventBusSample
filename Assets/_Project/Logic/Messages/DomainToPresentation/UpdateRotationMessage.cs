using UnityEngine;

namespace _Project.Messages.DomainToPresentation
{
    public readonly struct UpdateRotationMessage
    {
        public readonly string ID;
        public readonly Vector3 Value;

        public UpdateRotationMessage(string id, Vector3 value)
        {
            ID = id;
            Value = value;
        }
    }
}