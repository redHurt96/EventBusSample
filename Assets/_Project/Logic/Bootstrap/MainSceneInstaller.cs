using _Project.Domain;
using _Project.Domain.Components;
using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private Camera _camera;
        [SerializeField] private CameraFollow _cameraFollow;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            Container.Bind<CameraFollow>().FromInstance(_cameraFollow).AsSingle();
            Container.Bind<StaticData>().FromInstance(_staticData).AsSingle();
            
            Container.BindInterfacesAndSelfTo<MoveController>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectileAttackController>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesSpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActorsFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<VfxFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ActorsRepository>().AsSingle();
        }
    }
}