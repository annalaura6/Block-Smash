using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{ 
    [SerializeField] private CapsuleFollower _capsuleFollowerPrefab;

    private void SpawnCapsuleFollower()
    {
        var follower = Instantiate(_capsuleFollowerPrefab);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }

    private void Start()
    {
        SpawnCapsuleFollower();
    }

}
