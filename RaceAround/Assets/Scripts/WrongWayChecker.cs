using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongWayChecker : MonoBehaviour
{
    [SerializeField] 
    private Transform center;

    [SerializeField] 
    private Transform player;

    private Vector3 pastRotation;

    private Vector3 currentRotation;
    
    [SerializeField]
    private WaitForSeconds checkWrongWayDelay = new WaitForSeconds(.5f);

    public bool IsWrongWay { get; private set; }

    private void Awake()
    {
        center.LookAt(player);
    }

    private void Start()
    {
        StartCoroutine(CheckWrongWayCoroutine());
    }

    void Update()
    {
        center.LookAt(player);
    }

    IEnumerator CheckWrongWayCoroutine()
    {
        while (true)
        {
            pastRotation = center.eulerAngles;
        
            yield return checkWrongWayDelay;
        
            currentRotation = center.eulerAngles;

            // добавить проверку на велосити.x больше нуля
            IsWrongWay = currentRotation.y - pastRotation.y > 3f;
        }
    }
}
