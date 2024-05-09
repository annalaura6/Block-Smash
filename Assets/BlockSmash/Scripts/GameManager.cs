using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _ballSpawnPoint;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioSource _explosionAudioSource;
    [SerializeField] private TextMeshPro _scoreText;

    private int _score = 0;
    private float _ballSpawnTimer = 0f;
    private float _ballLifetime = 20f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        _ballSpawnTimer += Time.deltaTime;
        
        if (_ballSpawnTimer >= _ballLifetime)
        {
            DestroyOldBall();
            SpawnNewBall();
            _ballSpawnTimer = 0f;
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

    public void IncrementScore()
    {
        _score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + _score.ToString();
        }
    }
}