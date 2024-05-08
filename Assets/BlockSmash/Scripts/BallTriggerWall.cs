using UnityEngine;

public class BallTriggerWall : MonoBehaviour
{
    public GameObject ballPrefab; 
    public Transform spawnPoint;  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            Debug.Log("Ball collided with the wall."); // Add debug log
            
            Destroy(gameObject); // Destroy the current ball
            
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity); // Instantiate a new ball
            
            Debug.Log("New ball instantiated."); // Add debug log
        }
    }
}