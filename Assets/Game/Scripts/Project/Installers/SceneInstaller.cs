using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Player playerPrefab;
    
    public override void InstallBindings()
    {
        Container
            .BindFactory<Vector3, Player, Player.Factory>()
            .FromComponentInNewPrefab(playerPrefab)
            .AsSingle(); //AsSingle здесь не значит один Player, а одна фабрика.
        
        Container
            .BindInterfacesAndSelfTo<PlayerSpawner>()
            .AsSingle(); // Zenject вызовет Initialize() автоматически.
        
        Container
            .Bind<IWeapon>()
            .To<DummyWeapon>()
            .AsSingle();
    }
}