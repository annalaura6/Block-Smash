using UnityEngine;

public class BallTriggerWall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; 
    [SerializeField] private Transform spawnPoint;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            Debug.Log("Ball touched the wall."); // Add debug log
            
            Destroy(other.gameObject); 
            
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            
            Debug.Log("New ball instantiated."); // Add debug log
        }
    }
}