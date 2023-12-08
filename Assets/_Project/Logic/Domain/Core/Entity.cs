using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace _Project.Domain.Core
{
    public class Entity
    {
        public readonly string ID;
        public readonly IComponent[] Components;

        private readonly IEnumerable<ITickable> _tickables;

        public Entity(string id, params IComponent[] components)
        {
            ID = id;
            Components = components;

            _tickables = Components.OfType<ITickable>();
        }

        public void Tick()
        {
            foreach (ITickable tickable in _tickables) 
                tickable.Tick();
        }

        public T Get<T>() where T : IComponent =>
            Components
                .OfType<T>()
                .First();
    }
}
