// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance reference
    public GameObject ballPrefab; // Reference to the ball prefab
    public Transform ballSpawnPoint; // Transform where the new ball will spawn

    private void Awake()
    {
        // Initialize the singleton instance
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnNewBall()
    {
        Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
    }
}