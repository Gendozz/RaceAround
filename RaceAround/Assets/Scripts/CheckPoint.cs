using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CheckPoint : MonoBehaviour
{
    [SerializeField] 
    private Collider checkPointCollider;

    [SerializeField] 
    private int index;
    
    public bool isChecked = false;

    [SerializeField] 
    private LapCounter lapCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == lapCounter.player.gameObject && isChecked == false)
        {
            lapCounter.RegisterCheckPoint(index);
        }
    }
}
