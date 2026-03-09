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

        public void Fire(Vector3 position, Quaternion rotation)
        {
            Bullet bullet = _bulletFactory.Create();
            bullet.transform.position = position + Vector3.up * 0.5f;
            bullet.transform.rotation = rotation;
        }
    }
}