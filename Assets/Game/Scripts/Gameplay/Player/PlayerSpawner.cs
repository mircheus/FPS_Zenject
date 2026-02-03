using UnityEngine;
using Zenject;

public class PlayerSpawner : IInitializable
{
    private readonly Player.Factory _playerFactory;

    public PlayerSpawner(Player.Factory playerFactory)
    {
        _playerFactory = playerFactory;
    }

    public void Initialize()
    {
        Debug.Log("Spawning Player...");
        _playerFactory.Create(Vector3.zero);
        // Zenject создаёт Player через Factory
        // Под капотом:
        // Instantiate(prefab)
        // Добавляет компонент Player
        // Вызывает [Inject] Construct(...)
        // Возвращает готовый объект
        // 👉 Unity Awake вызывается ДО Inject
        // 👉 Start вызывается ПОСЛЕ Inject
    }
}