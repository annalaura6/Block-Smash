// GameManager.cs
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject _ballPrefab; 
    [SerializeField] private Transform _ballSpawnPoint;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioSource _explosionAudioSource;
    
    private AudioSource _audioSource;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
}