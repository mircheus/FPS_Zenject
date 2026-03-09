using System;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class Enemy : MonoBehaviour
    {
        private IScoreService _scoreService;
        private Health _health;
        private float _speed = 2f;
        
        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
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
            // Вот она — чистая зависимость через DI.
            // Враг не знает, КТО считает очки. Просто вызывает метод.
            _scoreService.AddKillScore();
            Destroy(gameObject);
        }
        
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}