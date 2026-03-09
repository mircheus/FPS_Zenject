namespace Game.Scripts.Services
{
    public interface IScoreService
    {
        int CurrentScore { get; }
        void AddScore(int points);
        void AddKillScore();
        void Reset();
    }
}