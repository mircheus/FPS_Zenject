namespace Game.Scripts.Project.Signals
{
    public struct ScoreChangedSignal
    {
        public int NewScore { get; }
        
        public ScoreChangedSignal(int newScore)
        {
            NewScore = newScore;
        }
    }
}