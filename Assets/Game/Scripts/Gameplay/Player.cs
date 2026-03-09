using Game.Scripts.Services;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Game.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        private Health _health;
        private GameSettings _settings;
        private SignalBus _signalBus;
        
        [Inject]
        public void Construct(GameSettings gameSettings, SignalBus signalBus)
        {
            _settings = gameSettings;
            _signalBus = signalBus;
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
                _signalBus.Fire(new PlayerDiedSignal());
            }
        }
    }
}