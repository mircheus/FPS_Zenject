using UnityEngine;

namespace Game.Scripts.Services
{
    public class ScoreService : IScoreService
    {
        private readonly int _pointsPerKill;
        
        public int CurrentScore { get; private set; }

        // Zenject видит, что ScoreService нужен GameSettings,
        // и автоматически передаст его в конструктор
        public ScoreService(GameSettings settings)
        {
            _pointsPerKill = settings.PointsPerKill;
        }
        
        public void AddScore(int points)
        {
            CurrentScore += points;
            Debug.Log($"Score: {CurrentScore}");
        }

        // Удобный метод для убийства врага
        public void AddKillScore()
        {
            AddScore(_pointsPerKill);
        }

        public void Reset()
        {
            CurrentScore = 0;
        }
    }
}
