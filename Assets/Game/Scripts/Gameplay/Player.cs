using Game.Scripts.Project.Signals;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class Player : MonoBehaviour
    {
        private Health _health;
        private GameSettings _settings;
        private SignalBus _signalBus;
        private bool _isDead;

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
            if (_isDead) return;
            
            _health.TakeDamage(damage);

            if (!_health.IsAlive)
            {
                _isDead = true;
                Debug.Log("PlayerDied1");
                _signalBus.Fire(new PlayerDiedSignal());
                Debug.Log("PlayerDied2");
            }
        }
    }
}