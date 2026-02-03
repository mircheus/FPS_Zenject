using UnityEngine;

public interface IPlayerFactory
{
    Player Create(Vector3 position);
}