using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    // 🔹 Zenject factory для создания Player из префаба
    public class Factory : PlaceholderFactory<Vector3, Player> { } // 👉 Zenject сам сгенерирует фабрику.
    
    // 🔹 Зависимости (НЕ создаются здесь)
    private IInputService _input;
    private IWeapon _weapon;

    // 🔹 Constructor Injection для MonoBehaviour
    // 👉 Unity Awake вызывается ДО Inject
    // 👉 Start вызывается ПОСЛЕ Inject
    [Inject]
    public void Construct(IInputService input, IWeapon weapon, Vector3 position)
    {
        _input = input;
        _weapon = weapon;
        transform.position = position;
    }

    private void Update()
    {
        HandleMovement();
        HandleFire();
    }

    private void HandleMovement()
    {

    }

    private void HandleFire()
    {

    }
}