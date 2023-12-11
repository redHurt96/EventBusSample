using _Project.Domain;
using _Project.Messages;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Presentation
{
    public class HealthView : MonoBehaviour, IActorComponent
    {
        [SerializeField] private Transform _canvas;
        [SerializeField] private Slider _slider;
        
        private string _id;
        private IMessageReceiver _receiver;
        private CompositeDisposable _disposable;
        private Camera _camera;

        [Inject]
        private void Construct(IMessageReceiver receiver, Camera camera)
        {
            _camera = camera;
            _receiver = receiver;
            _disposable = new();
        }

        private void Awake() =>
            _receiver
                .Receive<UpdateHealthMessage>()
                .Subscribe(UpdateBar)
                .AddTo(_disposable);

        private void OnDestroy() => 
            _disposable.Dispose();

        private void Update() => 
            _canvas.LookAt(_camera.transform.position);

        public void ProvideId(string id) => 
            _id = id;

        private void UpdateBar(UpdateHealthMessage message)
        {
            if (message.ID != _id)
                return;

            _slider.value = message.Value / message.MaxValue;
        }
    }
}