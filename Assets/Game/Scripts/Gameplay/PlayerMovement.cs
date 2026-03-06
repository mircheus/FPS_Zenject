using Game.Scripts.Services;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        private IInputService _inputService;
        private float _speed;

        [Inject]
        public void Construct(IInputService inputService, GameSettings gameSettings)
        {
            _inputService = inputService;
            _speed = gameSettings.PlayerSpeed;
        }

        private void Update()
        {
            Vector2 direction = _inputService.MoveDirection;
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }
}