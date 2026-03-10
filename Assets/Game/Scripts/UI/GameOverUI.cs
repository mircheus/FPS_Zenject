using Game.Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _finalScoreText;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        
        private ISceneService _sceneService;
        private IGameStateService _gameState;

        [Inject]
        public void Construct(ISceneService sceneService, IGameStateService gameStateService)
        {
            _sceneService = sceneService;
            _gameState = gameStateService;
        }

        private void Start()
        {
            _finalScoreText.text = $"Score: {_gameState.LastScore}";
            _highScoreText.text = $"Best: {_gameState.HighScore}";

            _restartButton.onClick.AddListener(() => _sceneService.LoadGameplay());
            _menuButton.onClick.AddListener(() => _sceneService.LoadMainMenu());
        }
    }
}