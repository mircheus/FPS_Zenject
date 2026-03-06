using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "SpaceSurvivor/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private GameSettings gameSettings;

        public override void InstallBindings()
        {
            // AsSingle — один экземпляр на весь контейнер
            // Все, кто попросит GameSettings, получат именно этот объект
            Container.BindInstance(gameSettings).AsSingle();
        }
    }
}