using UnityEngine;

namespace Game.Scripts.Services
{
    public class ScoreService : IScoreService
    {
        public int CurrentScore { get; private set; }
        
        public void AddScore(int points)
        {
            CurrentScore += points;
            Debug.Log($"Score: {CurrentScore}");
        }

        public void Reset()
        {
            CurrentScore = 0;
        }
    }
}
