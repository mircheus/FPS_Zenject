using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private WeaponType _weaponType;

        private WeaponRegistry _registry;
        
        [Inject]
        public void Construct(WeaponRegistry registry)
        {
            _registry = registry;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerShooting>(out var shooting))
            {
                shooting.SetWeapon(_registry.Get(_weaponType));
                Destroy(gameObject);
            }
        }

        public class Factory : PlaceholderFactory<WeaponPickup> {}
    }
}