using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class NormalWeapon : IWeaponStrategy
    {
        private readonly Bullet.Factory _bulletFactory;

        public float FireRate => 0.2f;

        public NormalWeapon(Bullet.Factory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        
        public void Fire(Vector3 position, Vector3 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}