using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Project
{
    public class AppEntryPoint : IInitializable
    {
        // private readonly ISaveService _saveService;
        // private readonly IAudioService _audioService;
        private readonly ISceneService _sceneService;
        private readonly GameSettings _gameSettings;

        public AppEntryPoint(GameSettings gameSettings, ISceneService sceneService)
        {
            _gameSettings = gameSettings;
            _sceneService = sceneService;
        }
        
        public void Initialize()
        {
            Debug.Log("=== App Starting ===");

            // Шаг 1: Загрузить сохранения — ДО всего остального,
            // потому что другие системы зависят от сохранённых данных
            // _saveService.Load();

            // Шаг 2: Инициализировать аудио с сохранёнными настройками
            // var data = _saveService.PlayerData;
            // _audioService.Initialize(data.MusicVolume, data.SfxVolume);

            // Шаг 3: Загрузить первую сцену
            Debug.Log("=== App Ready, loading Main Menu ===");
            _sceneService.LoadMainMenu();
        }
    }
}