using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePoint1 : MonoBehaviour
{
    //TODO: Разделить активность по игрокам
    
    [SerializeField]
    private Transform player;

    public bool isActive;

    [SerializeField] private float secondsToReactivate = 3f;

    private Material thisMaterial;

    private Color color;
    
    void Start()
    {
        isActive = true;
        thisMaterial = gameObject.GetComponent<MeshRenderer>().material;
        color = thisMaterial.color;
        color.a = 0;
        thisMaterial.color = color;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetHashCode() == player.gameObject.GetHashCode())
        {
            isActive = false;
            thisMaterial.color = Color.red;
            Invoke(nameof(Activate), secondsToReactivate);
            
            print(other.gameObject.GetHashCode().ToString());
        }
    }

    private void Activate()
    {
        isActive = true;
        thisMaterial.color = Color.black;
    }
}
