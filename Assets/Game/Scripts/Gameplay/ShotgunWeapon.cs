using Game.Scripts.Gameplay;
using UnityEngine;

public class ShotgunWeapon : IWeaponStrategy
{
    private readonly Bullet.Factory _bulletFactory;

    public float FireRate => 0.5f;

    public ShotgunWeapon(Bullet.Factory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    public void Fire(Vector3 position, Quaternion rotation)
    {
        float[] angles = { -20f, -10f, 0f, 10f, 20f };

        foreach (float angle in angles)
        {
            Bullet bullet = _bulletFactory.Create();
            bullet.transform.position = position + Vector3.up * 0.5f;
            bullet.transform.rotation = rotation * Quaternion.Euler(0, 0, angle);
        }
    }
}