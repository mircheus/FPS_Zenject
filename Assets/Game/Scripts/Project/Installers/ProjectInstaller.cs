using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("ProjectInstaller: installing bindings");
            
            Container.Bind<IGameStateService>()
                .To<GameStateService>()
                .AsSingle();

            Container.Bind<ISceneService>()
                .To<SceneService>()
                .AsSingle();
        }
    }
}