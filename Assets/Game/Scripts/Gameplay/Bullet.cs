using UnityEngine;
using Zenject;

namespace Game.Scripts.Gameplay
{
    public class Bullet : MonoBehaviour
    {
        private float _speed = 15f;
        private float _lifetime = 3f;
        private float _timer;

        void Update()
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

            _timer += Time.deltaTime;
            if (_timer >= _lifetime)
            {
                Destroy(gameObject);
            }
        }
        // Вот и вся «магия». Один вложенный класс — и у тебя есть фабрика.
        // PlaceholderFactory говорит Zenject: «я умею создавать Bullet»
        public class Factory : PlaceholderFactory<Bullet> { }
    }
}