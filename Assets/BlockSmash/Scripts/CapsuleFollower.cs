using UnityEngine;

public class CapsuleFollower : MonoBehaviour
{
    private CapsuleScript _follower;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [SerializeField]
    private float _sensitivity = 100f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 destination = _follower.transform.position;
        _rigidbody.transform.rotation = transform.rotation;

        _velocity = (destination - _rigidbody.transform.position) * _sensitivity;

        _rigidbody.velocity = _velocity;
    }

    public void SetFollowTarget(CapsuleScript capsuleFollower)
    {
        _follower = capsuleFollower;
    }
}