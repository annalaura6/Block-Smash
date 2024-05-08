using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Racket"))
        {
            Vector3 reactionForce = collision.impulse / Time.fixedDeltaTime;
            rb.AddForce(reactionForce * 0.5f);
        }
    }
}