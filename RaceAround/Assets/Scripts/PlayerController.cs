using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private new Rigidbody rigidbody;
    
    /// <summary>
    /// Max speed of the player
    /// </summary>
    [SerializeField]
    private float maxSpeed = 15f;

    [SerializeField] 
    private float force = 3000f;
    
    [SerializeField] 
    private float torque = 5f;

    [SerializeField] 
    private float mass = 3f;

    [SerializeField] 
    private float linearDrag = 1.8f;

    [SerializeField]
    private float angularDrag = 3f;
    
    private Vector3 MoveVector;

    private float rotationDirection;

    [SerializeField] 
    private Transform bombSpawnPosition;

    [SerializeField] 
    private GameObject bomb;
    
    [SerializeField]
    private int charges = 0;

    [SerializeField] 
    private int chargesToFire;

    [SerializeField] private Text chargesText;
    
    private void Start()
    {
        rigidbody.mass = mass;
        rigidbody.drag = linearDrag;
        rigidbody.angularDrag = angularDrag;
    }

    private void Update()
    {
        MoveVector.z = Input.GetAxis("Vertical"); // Change on float

        rotationDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && charges == 3)
        {
            FireBomb();
        }

        chargesText.text = $"Charges - {charges}";
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(transform.forward * MoveVector.z * force * Time.deltaTime, ForceMode.Force);
        }
    }

    private void Rotate()
    {
        rigidbody.AddRelativeTorque(0, rotationDirection * torque, 0);
    }

    private Vector3 GetDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        return new Vector3(x, 0f, z);
    }

    private void FireBomb()
    {
        charges = 0;
        Instantiate(bomb, bombSpawnPosition.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargePoint") && charges < chargesToFire)
        {
            charges++;
        }
    }
}
