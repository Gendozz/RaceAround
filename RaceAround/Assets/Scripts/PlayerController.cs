using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool isControlEnable = false;
    
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

    [SerializeField] private float maxTorque = 1f;
    
    private Vector3 MoveVector;

    private float rotationDirection;

    [SerializeField] 
    private Transform bombSpawnPosition;

    [SerializeField] 
    private GameObject bomb;
    
    [SerializeField]
    private int charges = 0;

    [SerializeField] 
    private int chargesToFire = 3;
    
    [SerializeField] 
    private LapCounter lapCounter;

    public enum ControlSchema : byte
    {
        Player1,
        Player2
    }

    public ControlSchema controlSchema;
    
    private String vertical = "Vertical";

    private String horizontal = "Horizontal";

    private String fire = "Fire";

    private String chargePointTag = "ChargePoint";

    [SerializeField] private float bombEffectDelay = 3f;

    private float axisSwap = 1f;

    [SerializeField] private ParticleSystem particleSystem;
    
    private void Start()
    {
        rigidbody.mass = mass;
        rigidbody.drag = linearDrag;
        rigidbody.angularDrag = angularDrag;
        rigidbody.maxAngularVelocity = maxTorque;

        if (controlSchema == ControlSchema.Player2)
        {
            vertical += "2";
            horizontal += "2";
            fire += "2";
            chargePointTag += "2";
        }
    }

    private void Update()
    {
        if (isControlEnable)
        {
            MoveVector.z = Input.GetAxis(vertical);
            if (MoveVector.z < 0) MoveVector.z = 0;

            rotationDirection = Input.GetAxis(horizontal) * axisSwap;

            if (Input.GetAxis(fire) > 0 && charges == 3)
            {
                FireBomb();
            }
        }
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

    private void FireBomb()
    {
        charges = 0;
        Instantiate(bomb, bombSpawnPosition.position, Quaternion.identity);
    }

    public int GetLapPast()
    {
        return lapCounter.laps;
    }

    public int GetChargesAmount()
    {
        return charges;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(chargePointTag) && charges < chargesToFire)
        {
            if (other.GetComponent<ChargePoint>().isActive)
            {
                charges++;
            }
        }

        if (other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            axisSwap = -1f;
            particleSystem.Play();
            Invoke("RestoreControl", bombEffectDelay);
        }
    }

    private void RestoreControl()
    {
        particleSystem.Stop();
        axisSwap = 1f;
    }
}
