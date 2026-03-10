using Game.Scripts.Gameplay;
using Game.Scripts.Project.Signals;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject pickupPrefab;
        
        public override void InstallBindings()
        {
            // Сигналы — обязательно объявить до использования
            // нужно вызвать один раз, чтобы SignalBus стал доступен в контейнере.
            // Без этой строки инжект SignalBus упадёт с ошибкой.
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<EnemyDiedSignal>();
            Container.DeclareSignal<PlayerDiedSignal>();
            Container.DeclareSignal<ScoreChangedSignal>();
            
            // GameManager — BindInterfacesTo, не BindInterfacesAndSelfTo,
            // потому что никому не нужен GameManager напрямую,
            // только его интерфейсы IInitializable и IDisposable
            Container.BindInterfacesTo<GameManager>().AsSingle();
            
            // Раньше было `Bind<IScoreService>().To<ScoreService>()`.
            // Теперь этот метод привязывает ScoreService ко всем его интерфейсам:
            // `IScoreService`, `IInitializable`, `IDisposable`.
            // Именно поэтому Zenject будет вызывать `Initialize` и `Dispose` автоматически.
            // Если бы мы оставили старый биндинг, контейнер не узнал бы,
            // что ScoreService реализует `IInitializable`, и метод `Initialize`
            // никогда бы не вызвался.
            Container.BindInterfacesAndSelfTo<ScoreService>().AsSingle();
            
            // AsSingle — один экземпляр InputService на всю сцену
            Container.Bind<IInputService>()
                .To<KeyboardInputService>()
                .AsSingle();

            Container.Bind<NormalWeapon>().AsSingle();
            Container.Bind<ShotgunWeapon>().AsSingle();
            Container.Bind<WeaponRegistry>().AsSingle();

            Container.Bind<IWeaponStrategy>()
                .FromResolveGetter<WeaponRegistry>(registry => registry.Get(WeaponType.Normal))
                .AsSingle();

            Container.BindFactory<Bullet, Bullet.Factory>()
                .FromComponentInNewPrefab(bulletPrefab);

            Container.BindFactory<Enemy, Enemy.Factory>()
                .FromComponentInNewPrefab(enemyPrefab);

            Container.BindFactory<WeaponPickup, WeaponPickup.Factory>()
                .FromComponentInNewPrefab(pickupPrefab);
        }
    }
}