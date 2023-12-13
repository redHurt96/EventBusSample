using _Project.Domain;
using _Project.Messages;
using UniRx;
using UnityEngine;
using Zenject;
using static UnityEngine.Animator;
using static UnityEngine.Time;

namespace _Project.Presentation
{
    public class AnimatorAdapter : MonoBehaviour, IActorComponent
    {
        private static readonly int _run = StringToHash("Run");
        private static readonly int _attack = StringToHash("Attack");
        
        private string _id;
        private float _receiveTime;
        private Animator _animator;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private StaticData _staticData;

        [Inject]
        private void Construct(IMessageReceiver receiver, StaticData staticData)
        {
            _staticData = staticData;
            _receiver = receiver;
            _animator = GetComponentInChildren<Animator>();
            _disposable = new();
        }

        public void ProvideId(string id) => 
            _id = id;

        private void Awake()
        {
            _receiver.Receive<MoveMessage>().Subscribe(UpdateMoveAnimation).AddTo(_disposable);
            _receiver.Receive<AttackMessage>().Subscribe(InvokeAttackTrigger).AddTo(_disposable);
        }

        private void OnDestroy() => 
            _disposable.Dispose();

        private void Update()
        {
            if (time - _receiveTime > _staticData.Enemy.StopTime)
                _animator.SetBool(_run, false);
        }

        private void UpdateMoveAnimation(MoveMessage moveMessage)
        {
            if (_id != moveMessage.ID)
                return;

            _receiveTime = time;
            _animator.SetBool(_run, true);
        }

        private void InvokeAttackTrigger(AttackMessage attackMessage)
        {
            if (_id != attackMessage.ID)
                return;
            
            _animator.SetTrigger(_attack);
        }
    }
}