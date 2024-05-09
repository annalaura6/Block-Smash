using UnityEngine;

public class TetrisShapeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tetrisShapes; 
    [SerializeField] private Vector3 _generationAreaMin; 
    [SerializeField] private Vector3 _generationAreaMax; 
    [SerializeField] private int _numberOfShapes; 
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float moveSpeed = 1f;

    private float _spawnTimer;
    private float _moveTimer;

    void Start()
    {
        _spawnTimer = 0f;
        _moveTimer = 0f;
    }

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        _moveTimer += Time.deltaTime;
        
        if (_spawnTimer >= _spawnInterval)
        {
            GenerateShape();
            _spawnTimer = 0f;
        }
        
        if (_moveTimer >= Time.deltaTime)
        {
            MoveShapes();
            _moveTimer = 0f;
        }
    }

    void GenerateShape()
    {
        GameObject shapeToSpawn = _tetrisShapes[Random.Range(0, _tetrisShapes.Length)];
        
        Vector3 spawnPosition = new Vector3(
            Random.Range(_generationAreaMin.x, _generationAreaMax.x),
            Random.Range(_generationAreaMin.y, _generationAreaMax.y),
            Random.Range(_generationAreaMin.z, _generationAreaMax.z)
        );

        Instantiate(shapeToSpawn, spawnPosition, Quaternion.identity);
    }


    void MoveShapes()
    {
        GameObject[] shapes = GameObject.FindGameObjectsWithTag("TetrisShape");
        
        foreach (GameObject shape in shapes)
        {
            shape.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
        foreach (GameObject shape in shapes)
        {
            if (shape.transform.position.x <= _generationAreaMin.x)
            {
                Destroy(shape);
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = (_generationAreaMin + _generationAreaMax) / 2;
        Vector3 size = _generationAreaMax - _generationAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}