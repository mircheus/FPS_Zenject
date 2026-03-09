using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        private Enemy.Factory _enemyFactory;
        private WeaponPickup.Factory _pickupFactory;
        private GameSettings _settings;
        private float _timer;

        [Inject]
        public void Construct(Enemy.Factory enemyFactory, WeaponPickup.Factory pickupFactory, GameSettings settings)
        {
            _enemyFactory = enemyFactory;
            _pickupFactory =  pickupFactory;
            _settings = settings;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _settings.EnemySpawnInterval)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void Spawn()
        {
            if (IsSpawnPickup())
            {
                SpawnPickup();
            }
            else
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.Create();
            float randomX = Random.Range(-4f, 4f);
            enemy.transform.position = new Vector3(randomX, 6f, 0);
        }

        private bool IsSpawnPickup()
        {
            var random = Random.Range(0, 10);

            return random <= 4;
        }

        private void SpawnPickup()
        {
            WeaponPickup pickup = _pickupFactory.Create();
            float randomX = Random.Range(-4f, 4f);
            pickup.transform.position = new Vector3(randomX, 6f, 0);
        }
    }
}