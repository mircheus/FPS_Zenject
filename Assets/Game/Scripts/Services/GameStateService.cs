namespace Game.Scripts.Services
{
    public class GameStateService : IGameStateService
    {
        public int LastScore { get; private set; }
        public int HighScore { get; private set; }
        
        public void SaveScore(int score)
        {
            LastScore = score;
            
            if(score > HighScore)
                HighScore = score;
        }

        public void Reset()
        {
            LastScore = 0;
        }
    }
}