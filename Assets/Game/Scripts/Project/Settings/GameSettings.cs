using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Player")]
    public float PlayerSpeed = 5f;
    public int PlayerMaxHealth = 3;

    [Header("Enemies")]
    public float EnemySpawnInterval = 2f;
    public int EnemiesPerWave = 5;

    [Header("Scoring")]
    public int PointsPerKill = 10;
}