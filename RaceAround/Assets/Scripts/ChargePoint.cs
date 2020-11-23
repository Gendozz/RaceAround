using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePoint : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField] private Transform indicator;

    public bool isActive;

    [SerializeField] private float secondsToReactivate = 3f;

    private Material indicatorMaterial;

    private Color indicatorUnactiveColor;
    
    private Color indicatorStartColor;
    
    void Start()
    {
        
        isActive = true;
        indicatorMaterial = indicator.gameObject.GetComponent<MeshRenderer>().material;
        indicatorStartColor = indicatorMaterial.color;
        indicatorUnactiveColor = indicatorStartColor;
        indicatorUnactiveColor.a = 0.05f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject== player.gameObject)
        {
            
            indicatorMaterial.color = indicatorUnactiveColor;
            Invoke(nameof(Deactivate), 0.1f);
            Invoke(nameof(Reactivate), secondsToReactivate);
        }
    }

    private void Deactivate()
    {
        isActive = false;
    }

    private void Reactivate()
    {
        isActive = true;
        indicatorMaterial.color = indicatorStartColor;
    }
}
