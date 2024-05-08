using UnityEngine;

public class RacketController : MonoBehaviour
{
    [SerializeField] private float _impulse = 200f;
    
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 force = -collision.contacts[0].normal * _impulse; 
            ballRb.AddForce(force, ForceMode.Impulse); 
        }
    }
}