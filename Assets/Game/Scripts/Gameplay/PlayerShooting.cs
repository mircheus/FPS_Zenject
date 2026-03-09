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
        private IWeaponStrategy _weapon;
        private float _fireRate = 0.2f;
        private float _cooldown;

        [Inject]
        public void Construct(IInputService inputService, IWeaponStrategy weapon)
        {
            _inputService = inputService;
            _weapon = weapon;
        }

        private void Update()
        {
            _cooldown -= Time.deltaTime;

            if (_inputService.IsShooting && _cooldown <= 0)
            {
                _weapon.Fire(transform.position, transform.rotation);
                _cooldown = _fireRate;
            }
        }

        public void SetWeapon(IWeaponStrategy newWeapon)
        {
            _weapon = newWeapon;
        }
    }
}