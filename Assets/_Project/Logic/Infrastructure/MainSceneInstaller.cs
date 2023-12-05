using _Project.Logic.Domain;
using _Project.Logic.Framework;
using _Project.Logic.Presentation;
using Zenject;

namespace _Project.Logic.Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MoveService>().AsSingle();
            Container.Bind<StaticData>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<Character>().AsSingle().NonLazy();
            Container.Bind<CharacterView>().FromFactory<CharacterViewFactory>().AsSingle().NonLazy();
        }
    }
}