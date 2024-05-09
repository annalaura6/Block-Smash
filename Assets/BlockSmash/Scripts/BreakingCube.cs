// BreakingCube.cs
using UnityEngine;

public class BreakingCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.PlayExplosion(transform.position);
            
            Destroy(collision.gameObject);
            
            GameManager.Instance.SpawnNewBall();
            
            Destroy(gameObject);
        }
    }
}