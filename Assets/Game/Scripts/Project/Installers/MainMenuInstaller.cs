using UnityEngine;
using Zenject;

namespace Game.Scripts.Project.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Меню пока ничего своего не биндит.
            // Но SceneContext нужен, чтобы инжект работал на объектах сцены.
            // Глобальные сервисы доступны автоматически из ProjectContext.
        }
    }
}