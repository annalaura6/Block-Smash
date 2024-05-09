using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject _ballPrefab; 
    [SerializeField] private Transform _ballSpawnPoint;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioSource _explosionAudioSource;
    
    private float _ballSpawnTimer = 0f;
    private float _ballLifetime = 30f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // Increment the timer
        _ballSpawnTimer += Time.deltaTime;

        // Check if the ball has exceeded its lifetime
        if (_ballSpawnTimer >= _ballLifetime)
        {
            DestroyOldBall();
            SpawnNewBall();
            _ballSpawnTimer = 0f; // Reset the timer
        }
    }

    public void SpawnNewBall()
    {
        Instantiate(_ballPrefab, _ballSpawnPoint.position, Quaternion.identity);
    }

    public void PlayExplosion(Vector3 position)
    {
        Instantiate(_explosionPrefab, position, Quaternion.identity);
        
        if (_explosionAudioSource != null)
        {
            _explosionAudioSource.Play(); 
        }
    }

    private void DestroyOldBall()
    {
        GameObject oldBall = GameObject.FindGameObjectWithTag("Ball");
        if (oldBall != null)
        {
            Destroy(oldBall);
        }
    }
}