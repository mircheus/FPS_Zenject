using UnityEngine;

namespace Game.Scripts.Project.Signals
{
    public struct EnemyDiedSignal
    {
        public Vector3 Position;
        public int Points { get; }

        public EnemyDiedSignal(Vector3 position, int points)
        {
            Position = position;
            Points = points;
        }
    }
}