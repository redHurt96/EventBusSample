using _Project.Domain;
using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            Container.Bind<StaticData>().FromInstance(_staticData).AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoveController>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttackController>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesSpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VfxFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActorsRepository>().AsSingle();
        }
    }
}