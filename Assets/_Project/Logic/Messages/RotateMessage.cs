using UnityEngine;

namespace _Project.Messages
{
    public readonly struct RotateMessage : IActorMessage
    {
        public string ID { get; }
        public readonly Vector3 To;

        public RotateMessage(string id, Vector3 to)
        {
            To = to;
            ID = id;
        }
    }
}