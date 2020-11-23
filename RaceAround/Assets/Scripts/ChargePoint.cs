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
        indicatorUnactiveColor.a = 0.1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject== player.gameObject)
        {
            isActive = false;
            indicatorMaterial.color = indicatorUnactiveColor;
            Invoke(nameof(Reactivate), secondsToReactivate);
        }
    }

    private void Reactivate()
    {
        isActive = true;
        indicatorMaterial.color = indicatorStartColor;
    }
}
