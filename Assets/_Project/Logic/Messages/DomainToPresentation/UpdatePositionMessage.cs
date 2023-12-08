using UnityEngine;

namespace _Project.Messages.DomainToPresentation
{
    public readonly struct UpdatePositionMessage
    {
        public readonly string ID;
        public readonly Vector3 Position;

        public UpdatePositionMessage(string id, Vector3 position)
        {
            ID = id;
            Position = position;
        }
    }
}