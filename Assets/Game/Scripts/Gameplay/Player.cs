using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        private Health _health;
        private GameSettings _settings;
        private IScoreService _scoreService;
        
        [Inject]
        public void Construct(GameSettings gameSettings, IScoreService scoreService)
        {
            _settings = gameSettings;
            _scoreService = scoreService;
        }

        private void Start()
        {
            // Health — компонент на этом же GameObject, инициализируем вручную
            _health = GetComponent<Health>();
            _health.Initialize(_settings.PlayerMaxHealth);
        }

        // Будет вызываться позже, когда появятся враги
        public void OnHit(int damage)
        {
            _health.TakeDamage(damage);

            if (!_health.IsAlive)
            {
                Debug.Log($"Player died! Game Over");
                // Позже здесь будет сигнал GameOver
            }
        }
    }
}