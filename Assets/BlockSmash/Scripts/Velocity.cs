using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 20f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = ColourVelocity();
    }

    private Color ColourVelocity()
    {
        float velocity = GetComponent<Rigidbody>().velocity.magnitude;
        return Color.Lerp(Color.green, Color.red, velocity / maxVelocity);
    }
}
