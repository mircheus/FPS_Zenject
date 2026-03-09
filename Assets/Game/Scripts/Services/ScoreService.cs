using System;
using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Services
{
    public class ScoreService : IScoreService, IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;
        private readonly int _pointsPerKill;

        public int CurrentScore { get; private set; }
        
        // Zenject видит, что ScoreService нужен GameSettings,
        // и автоматически передаст его в конструктор
        public ScoreService(GameSettings settings, SignalBus signalBus)
        {
            _signalBus = signalBus;
            _pointsPerKill = settings.PointsPerKill;
        }

        // IInitializable.Initialize вызывается контейнером после создания всех объектов.
        // Это аналог Start, но для обычных C# классов.
        public void Initialize()
        {
            _signalBus.Subscribe<EnemyDiedSignal>(OnEnemyDied);
        }

        // IDisposable.Dispose — контейнер вызовет при уничтожении.
        // Всегда отписывайся от сигналов, иначе будут утечки.
        public void Dispose()
        {
            _signalBus.Unsubscribe<EnemyDiedSignal>(OnEnemyDied);
        }

        private void OnEnemyDied(EnemyDiedSignal signal)
        {
            AddScore(signal.Points);
        }

        public void AddScore(int points)
        {
            CurrentScore += points;
            // Оповещаем всех, кому интересен новый счёт (например, UI)
            _signalBus.Fire(new ScoreChangedSignal(CurrentScore));
        }

        // Удобный метод для убийства врага
        public void AddKillScore() => AddScore(_pointsPerKill);
        
        public void Reset() => CurrentScore = 0;
    }
}
