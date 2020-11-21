using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Moving Rigidbody through path of Transforms
/// </summary>
public class MoveByPath : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody rigibdody;
    
    [SerializeField] 
    private Transform[] pathPoints = new Transform[4];    // TODO: make adjustible
    
    [SerializeField]
    private Transform firstPathPoint;
    
    [SerializeField]
    private Collider[] pathPointColliders = new Collider[4];

    [SerializeField] 
    private float MoveForce = 10f;
    
    private Vector3 currentTargetDirection;

    private Vector3 currentTargetPosition;

    private int currentTargetIndex = 0;

    private void Start()
    {
        if (firstPathPoint == null)
        {
            print("Set first pathPoint");
            currentTargetIndex = 0;
        }
        else
        {
            currentTargetIndex = Array.IndexOf(pathPoints, firstPathPoint);
        }
    }

    /// <summary>
    /// Just changes direction
    /// </summary>
    void Update()
    {
        currentTargetDirection = pathPoints[currentTargetIndex].position - transform.position;
    }

    private void FixedUpdate()
    { 
        rigibdody.AddForce(currentTargetDirection.normalized * (rigibdody.mass * (MoveForce * Time.deltaTime)));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Add proof by type of collider
        if (pathPointColliders.Any(point => point.gameObject == other.gameObject))
        {
            if (currentTargetIndex < pathPoints.Length - 1)
            {
                currentTargetIndex++;
            }
            else
            {
                currentTargetIndex = 0;
            }
        }
    }
}
