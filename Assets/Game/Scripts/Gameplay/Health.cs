using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class Health : MonoBehaviour
    {
        private int _currentHealth;
        private int _maxHealth;

        public int CurrentHealth => _currentHealth;
        public bool IsAlive => _currentHealth > 0;

        // Принимаем максимальное здоровье как параметр,
        // потому что Health может быть и у игрока, и у врага с разными значениями.
        // Поэтому НЕ инжектим GameSettings напрямую — это сделает компонент универсальным.
        public void Initialize(int maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);
            Debug.Log($"{gameObject.name} health: {_currentHealth}/{_maxHealth}");
        }
    }
}