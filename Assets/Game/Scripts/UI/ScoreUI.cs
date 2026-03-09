using Game.Scripts.Project.Signals;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Scripts.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        
        private SignalBus _signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Start()
        {
            _scoreText.text = "Score: 0";
            _signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
        }

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
        }

        private void OnScoreChanged(ScoreChangedSignal signal)
        {
            _scoreText.text = "Score: " + signal.NewScore;
        }
    }
}