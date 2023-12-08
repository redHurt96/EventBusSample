using System;
using _Project.Domain;
using _Project.Services;
using UnityEngine;
using Zenject;

namespace _Project.Bootstrap
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
            
            Container.Bind<StaticData>().FromNew().AsSingle();
            
            Container.BindInterfacesAndSelfTo<EntitiesRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<CharacterFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RotateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemiesSpawnService>().AsSingle();
        }
    }
}