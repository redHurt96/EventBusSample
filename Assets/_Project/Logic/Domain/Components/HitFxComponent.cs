using _Project.Messages;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;
using static DG.Tweening.DOTween;
using static DG.Tweening.LoopType;
using static UnityEngine.Color;

namespace _Project.Domain.Components
{
    public class HitFxComponent : MonoBehaviour, IActorComponent
    {
        private string _id;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private Renderer[] _renderers;
        private Sequence _sequence;

        public void ProvideId(string id) => 
            _id = id;

        [Inject]
        private void Construct(IMessageReceiver receiver)
        {
            _receiver = receiver;
            _disposable = new();
            _renderers = GetComponentsInChildren<Renderer>();
        }

        private void Start() => 
            _receiver.Receive<DamageMessage>().Subscribe(PlayFx).AddTo(_disposable);

        private void OnDestroy() => 
            _disposable.Dispose();

        private void PlayFx(DamageMessage message)
        {
            if (_id != message.ID)
                return;

            if (_sequence != null && _sequence.IsPlaying())
                return;

            _sequence = Sequence();

            foreach (Renderer renderer in _renderers)
            {
                _sequence.Insert(0f, renderer.material
                    .DOColor(red, .3f)
                    .SetLoops(2, Yoyo));
            }
        }
    }
}