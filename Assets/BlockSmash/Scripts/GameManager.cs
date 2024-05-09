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
    [SerializeField] private TextMeshPro _timerText; 

    private int _score = 0;
    private float _ballSpawnTimer = 0f;
    private float _ballLifetime = 20f;
    private float _gameTimer = 60f; 
    private bool _isGameOver = false; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (!_isGameOver) 
        {
            _ballSpawnTimer += Time.deltaTime;
            _gameTimer -= Time.deltaTime;

            UpdateTimerText();

            if (_ballSpawnTimer >= _ballLifetime)
            {
                DestroyOldBall();
                SpawnNewBall();
                _ballSpawnTimer = 0f;
            }

            if (_gameTimer <= 0f)
            {
                EndGame();
            }
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

    private void UpdateTimerText()
    {
        if (_timerText != null)
        {
            _timerText.text = "Time: " + Mathf.RoundToInt(_gameTimer).ToString(); 
        }
    }

    private void EndGame()
    {
        _isGameOver = true;
    }
    
    public bool IsGameOver()
    {
        return _isGameOver;
    }
}
