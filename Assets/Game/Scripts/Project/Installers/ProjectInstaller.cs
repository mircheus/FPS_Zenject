using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Точка входа приложения
            Container.BindInterfacesTo<AppEntryPoint>().AsSingle();
            
            
            // Глобальные сервисы — порядок биндинга НЕ важен,
            // Zenject сам разрешит зависимости.
            // Порядок ИНИЦИАЛИЗАЦИИ контролирует AppEntryPoint.
            Container.Bind<IGameStateService>()
                .To<GameStateService>()
                .AsSingle();

            Container.Bind<ISceneService>()
                .To<SceneService>()
                .AsSingle();
        }
    }
}