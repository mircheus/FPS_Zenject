using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        private Enemy.Factory _enemyFactory;
        private GameSettings _settings;
        private float _timer;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory, GameSettings settings)
        {
            _enemyFactory = enemyFactory;
            _settings = settings;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _settings.EnemySpawnInterval)
            {
                SpawnEnemy();
                _timer = 0;
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.Create();
            float randomX = Random.Range(-4f, 4f);
            enemy.transform.position = new Vector3(randomX, 6f, 0);
        }
    }
}