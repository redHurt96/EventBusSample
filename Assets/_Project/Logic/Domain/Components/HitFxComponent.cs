using _Project.Domain.Core;
using _Project.Messages;
using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;
using static DG.Tweening.LoopType;
using static UnityEngine.Color;

namespace _Project.Domain.Components
{
    public class HitFxComponent : ActorComponent<DamageMessage>
    {
        private Renderer[] _renderers;
        private Sequence _sequence;

        protected override void Start()
        {
            base.Start();
            _renderers = GetComponentsInChildren<Renderer>();
        }

        protected override void OnReceive(DamageMessage message)
        {
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