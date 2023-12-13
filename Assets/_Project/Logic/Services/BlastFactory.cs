using System;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Services
{
    public class BlastFactory : IInitializable, IDisposable
    {
        private readonly IMessageReceiver _receiver;
        private readonly IInstantiator _instantiator;
        private readonly CompositeDisposable _disposable;

        public BlastFactory(IMessageReceiver receiver, IInstantiator instantiator)
        {
            _receiver = receiver;
            _instantiator = instantiator;
            _disposable = new();
        }

        public void Initialize() => 
            _receiver.Receive<BlastMessage>().Subscribe(CreateBlast).AddTo(_disposable);

        public void Dispose() => 
            _disposable.Dispose();

        private void CreateBlast(BlastMessage message)
        {
            GameObject instance = _instantiator.InstantiatePrefabResource("Blast");
            instance.transform.position = message.Position;
        }
    }
}