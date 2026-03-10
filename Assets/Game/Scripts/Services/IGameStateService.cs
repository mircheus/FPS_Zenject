namespace Game.Scripts.Services
{
    public interface IGameStateService
    {
        int LastScore { get; }
        int HighScore { get; }
        void SaveScore(int score);
        void Reset();
    }
}