using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ApplyPushForce : MonoBehaviour
{
    [SerializeField] private float force = 500f;

    [SerializeField] private Transform pushToTransform;
    
    void OnCollisionEnter(Collision other)
    {
        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = Vector3.zero;

        Vector3 otherCoordinates = otherRb.gameObject.transform.position;
        
        if (pushToTransform != null)
        {
            direction = pushToTransform.position - otherCoordinates;
        }
        direction = otherCoordinates - transform.position;
        
        otherRb.AddForce(direction.normalized * force * otherRb.mass);
    }
}
