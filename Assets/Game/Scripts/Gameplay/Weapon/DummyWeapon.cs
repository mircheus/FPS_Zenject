using UnityEngine;

public class DummyWeapon : IWeapon
{
    public void Fire()
    {
        Debug.Log("Fire!");
    }
}