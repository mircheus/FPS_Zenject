using System;
using Game.Scripts.Project.Signals;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class GameManager : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly IScoreService _scoreService;
        private readonly IGameStateService _gameState;
        private readonly ISceneService _sceneService;
        private bool _isGameOver;

        public GameManager(
            SignalBus signalBus,
            IScoreService scoreService,
            IGameStateService gameState,
            ISceneService sceneService)
        {
            _signalBus = signalBus;
            _scoreService = scoreService;
            _gameState = gameState;
            _sceneService = sceneService;
        }
        
        public void Initialize()
        {
            _signalBus.Subscribe<PlayerDiedSignal>(OnPlayerDied);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<PlayerDiedSignal>(OnPlayerDied);
        }

        private void OnPlayerDied()
        {
            if(_isGameOver) return;
            _isGameOver = true;
            
            _gameState.SaveScore(_scoreService.CurrentScore);
            _sceneService.LoadGameOver();
        }
    }
}