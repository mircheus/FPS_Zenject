using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Bind интерфейса к реализации
            // AsSingle — один экземпляр ScoreService на всю сцену
            Container.Bind<IScoreService>()
                .To<ScoreService>()
                .AsSingle();
            
            Container.Bind<IInputService>()
                .To<KeyboardInputService>()
                .AsSingle();
        }
    }
}