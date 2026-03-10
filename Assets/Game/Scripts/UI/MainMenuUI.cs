using Game.Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Scripts.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private TMP_Text _highScoreText;

        private ISceneService _sceneService;
        private IGameStateService _gameState;

        [Inject]
        public void Construct(ISceneService sceneService, IGameStateService gameState)
        {
            _sceneService = sceneService;
            _gameState = gameState;
        }

        void Start()
        {
            _highScoreText.text = $"High Score: {_gameState.HighScore}";
            _playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnPlayClicked()
        {
            _gameState.Reset();
            _sceneService.LoadGameplay();
        }
    }
}