using UnityEngine;

namespace Game.Scripts.Services
{
    public class KeyboardInputService : IInputService
    {
        public Vector2 MoveDirection => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        public bool IsShooting => Input.GetKey(KeyCode.Space);
    }
}