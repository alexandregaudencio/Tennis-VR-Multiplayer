using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody body;

    [SerializeField] private float velocity = 0.2f;
    [SerializeField] private GameObject ballCollisionEffect;

    private void Awake()
    {
        body = GetComponentInChildren<Rigidbody>();
    }

    public Vector3 Normal()
    {
        return transform.position + transform.up;
    }

    private void Update()
    {
        velocity = body.velocity.magnitude;
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up*5);
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject instantiatedEffect =   Instantiate(ballCollisionEffect, transform.position, transform.rotation);
        Destroy(instantiatedEffect, 1);
    }



}
