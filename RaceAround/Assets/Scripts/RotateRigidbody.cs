using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRigidbody : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody rigibodyToRotate;

    [SerializeField] private Vector3 rotationForce = Vector3.zero;

    [SerializeField] private float maxAngularVelocity = 1;
    private void Start()
    {
        rigibodyToRotate.maxAngularVelocity = maxAngularVelocity;
    }

    // Update is called once per frame
    void Update()
    {    
        
        rigibodyToRotate.AddTorque(rotationForce);
    }
}
