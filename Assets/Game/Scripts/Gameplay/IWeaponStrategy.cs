using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public interface IWeaponStrategy
    {
        float FireRate { get; }
        void Fire(Vector3 position, Quaternion rotation);
    }
}