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
            Vector3 force = transform.forward * 10; 
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}