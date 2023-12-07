using _Project.Logic.Domain;
using _Project.Logic.Framework;
using _Project.Logic.Presentation;
using _Project.Logic.Services;
using UnityEngine;
using Zenject;

namespace _Project.Logic.Bootstrap
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            
            Container.Bind<StaticData>().FromNew().AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoveService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesSpawnService>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<Character>().AsSingle().NonLazy();
            Container.Bind<CharacterView>().FromFactory<CharacterViewFactory>().AsSingle().NonLazy();
        }
    }

    public class MainSceneRunner : MonoBehaviour
    {
        [Inject]
        private void Construct()
        {

        }
    }
}