using UnityEngine;

namespace Game.Scripts.Services
{
    public interface IInputService
    {
        Vector2 MoveDirection { get; }
        bool IsShooting { get; }
    }
}