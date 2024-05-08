using UnityEngine;

public class BallTriggerWall : MonoBehaviour
{
    public GameObject ballPrefab; 
    public Transform spawnPoint;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            Destroy(other.gameObject); 
            
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}