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

    private bool isWrongWay;

    [SerializeField] private Text wrongWayText;        // Place in another script


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
        
        if (isWrongWay)
        {
            wrongWayText.text = "Wrong way";
        }
        else
        {
            wrongWayText.text = "";
        }
    }

    IEnumerator CheckWrongWayCoroutine()
    {
        while (true)
        {
            pastRotation = center.eulerAngles;
        
            yield return checkWrongWayDelay;
        
            currentRotation = center.eulerAngles;

            // добавить проверку на велосити.x больше нуля
            isWrongWay = currentRotation.y - pastRotation.y > 3f;
        }
    }
}
