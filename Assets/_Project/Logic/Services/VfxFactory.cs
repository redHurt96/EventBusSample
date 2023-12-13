using System;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Services
{
    public class VfxFactory : IInitializable, IDisposable
    {
        private readonly IMessageReceiver _receiver;
        private readonly IInstantiator _instantiator;
        private readonly CompositeDisposable _disposable;

        public VfxFactory(IMessageReceiver receiver, IInstantiator instantiator)
        {
            _receiver = receiver;
            _instantiator = instantiator;
            _disposable = new();
        }

        public void Initialize()
        {
            _receiver.Receive<BlastMessage>().Subscribe(CreateBlast).AddTo(_disposable);
            _receiver.Receive<HitMessage>().Subscribe(CreateHit).AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void CreateBlast(BlastMessage message) => 
            CreateVfx("Blast", message.Position);

        private void CreateHit(HitMessage message) => 
            CreateVfx("Hit", message.Position);

        private void CreateVfx(string resourceName, Vector3 position) =>
            _instantiator
                .InstantiatePrefabResource(resourceName)
                .transform.position = position;
    }
}