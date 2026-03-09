using Game.Scripts.Services;
using UnityEngine;
using Zenject;

public class ScoreTestComponent : MonoBehaviour
{
    private IScoreService _scoreService;
    private GameSettings _gameSettings;

    [Inject]
    public void Construct(IScoreService scoreService, GameSettings settings)
    {
        _scoreService = scoreService;
        _gameSettings = settings;
    }
    
    private void Start()
    {
        _scoreService.AddScore(_gameSettings.PointsPerKill);
    }
}
