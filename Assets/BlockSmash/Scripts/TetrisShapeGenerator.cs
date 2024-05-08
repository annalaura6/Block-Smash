using UnityEngine;

public class TetrisShapeGenerator : MonoBehaviour
{
    public GameObject[] tetrisShapes; 
    public Vector3 generationAreaMin; 
    public Vector3 generationAreaMax; 
    public int numberOfShapes; 

    void Start()
    {
        GenerateShapes();
    }

    void GenerateShapes()
    {
        for (int i = 0; i < numberOfShapes; i++)
        {
            GameObject shapeToSpawn = tetrisShapes[Random.Range(0, tetrisShapes.Length)];
            
            Vector3 randomPosition = new Vector3(
                Random.Range(generationAreaMin.x, generationAreaMax.x),
                Random.Range(generationAreaMin.y, generationAreaMax.y),
                Random.Range(generationAreaMin.z, generationAreaMax.z)
            );
            
            Instantiate(shapeToSpawn, randomPosition, Quaternion.identity);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = (generationAreaMin + generationAreaMax) / 2;
        Vector3 size = generationAreaMax - generationAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}
