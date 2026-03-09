using Game.Scripts.Gameplay;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject enemyPrefab;
        
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

            Container.BindFactory<Bullet, Bullet.Factory>()
                .FromComponentInNewPrefab(bulletPrefab);

            Container.BindFactory<Enemy, Enemy.Factory>()
                .FromComponentInNewPrefab(enemyPrefab);
        }
    }
}