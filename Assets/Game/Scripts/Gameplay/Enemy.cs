using System;
using Game.Scripts.Project.Signals;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class Enemy : MonoBehaviour
    {
        private SignalBus _signalBus;
        private Health _health;
        private GameSettings _settings;
        private float _speed = 2f;
        
        [Inject]
        public void Construct(SignalBus signalBus, GameSettings settings)
        {
            _signalBus = signalBus;
            _settings = settings;
        }

        private void Start()
        {
            _health = GetComponent<Health>();
            _health.Initialize(1);
        }

        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if (transform.position.y < -6f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Bullet>(out Bullet bullet))
            {
                _health.TakeDamage(1);
                Destroy(bullet.gameObject);

                if (!_health.IsAlive)
                {
                    Die();
                }
            }
            
            // Столкновение с игроком
            if (other.TryGetComponent<Player>(out var player))
            {
                player.OnHit(1);
                Destroy(gameObject);
            }
        }

        private void Die()
        {
            // Одна строка вместо шести зависимостей.
            // Враг не знает, кто слушает. Ему всё равно.
            _signalBus.Fire(new EnemyDiedSignal(transform.position, _settings.PointsPerKill));
            Destroy(gameObject);
        }
        
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}