using System;
using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class PlayerShooting : MonoBehaviour
    {
        private IInputService _inputService;
        private Bullet.Factory _bulletFactory;
        private float _fireRate = 0.2f;
        private float _cooldown;

        [Inject]
        public void Construct(IInputService inputService, Bullet.Factory bulletFactory)
        {
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        private void Update()
        {
            _cooldown -= Time.deltaTime;

            if (_inputService.IsShooting && _cooldown <= 0)
            {
                Fire();
                _cooldown = _fireRate;
            }
        }

        private void Fire()
        {
            Bullet bullet = _bulletFactory.Create();
            bullet.transform.position = transform.position + Vector3.up * 0.5f;
            bullet.transform.rotation = transform.rotation;
        }
    }
}