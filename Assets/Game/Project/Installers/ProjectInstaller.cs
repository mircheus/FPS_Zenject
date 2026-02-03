using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameSettings gameSettings;
    
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<DamageSignal>();
        Container.DeclareSignal<EnemyDiedSignal>();
        Container.DeclareSignal<PlayerDiedSignal>();

        Container
            .Bind<IInputService>()
            .To<KeyboardMouseInputService>()
            .AsSingle();
        
        Container
            .Bind<IEnergyService>()
            .To<EnergyService>()
            .AsSingle();

        Container
            .BindInstance(gameSettings);
    }
}