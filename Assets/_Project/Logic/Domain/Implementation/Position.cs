using _Project.Domain.Core;
using UnityEngine;

namespace _Project.Domain.Implementation
{
    public class Position : IComponent
    {
        public Vector3 Value { get; set; }
    }
}