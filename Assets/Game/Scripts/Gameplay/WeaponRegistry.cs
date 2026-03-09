using System;
using System.Collections.Generic;

namespace Game.Scripts.Gameplay
{
    public class WeaponRegistry
    {
        private readonly Dictionary<WeaponType, IWeaponStrategy> _weapons;

        public WeaponRegistry(NormalWeapon normal, ShotgunWeapon shotgun)
        {
            _weapons = new Dictionary<WeaponType, IWeaponStrategy>
            {
                { WeaponType.Normal, normal },
                { WeaponType.Shotgun, shotgun}
            };
        }
        
        public IWeaponStrategy Get(WeaponType type)
        {
            if (_weapons.TryGetValue(type, out var weapon))
                return weapon;

            throw new ArgumentException($"Weapon {type} not registered");
        }
    }
    
    public enum WeaponType
    {
        Normal,
        Shotgun
    }
}