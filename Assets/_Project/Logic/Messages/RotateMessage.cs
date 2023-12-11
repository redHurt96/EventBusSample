using UnityEngine;

namespace _Project.Messages
{
    public readonly struct RotateMessage
    {
        public readonly string ID;
        public readonly Vector3 To;

        public RotateMessage(string id, Vector3 to)
        {
            To = to;
            ID = id;
        }
    }
}