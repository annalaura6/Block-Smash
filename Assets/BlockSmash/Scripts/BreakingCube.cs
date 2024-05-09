// BreakingCube.cs
using UnityEngine;

public class BreakingCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Instantiate the explosion effect at the cube's position

            // Destroy the ball
            Destroy(collision.gameObject);

            // Notify GameManager to spawn a new ball
            GameManager.Instance.SpawnNewBall();

            // Destroy the cube
            Destroy(gameObject);
        }
    }
}