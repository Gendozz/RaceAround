using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoViewer : MonoBehaviour
{
    [SerializeField] 
    private PlayerController player;
    
    [SerializeField] private Text lapsText;

    [SerializeField] private Image chargesUI;
    [SerializeField] private Sprite[] charges = new Sprite[4];

    [SerializeField] private Image messageUI;
    [SerializeField] private Sprite[] messages;

    [SerializeField] private WrongWayChecker wrongWayChecker;

    private int lapsPast;

    private int chargesAmount;
    void Update()
    {
        lapsPast = player.GetLapPast();
        chargesAmount = player.GetChargesAmount();
        
        lapsText.text = $"Lap {lapsPast}/10";
        chargesUI.sprite = charges[chargesAmount];

        if (lapsPast >= 10)
        {
            messageUI.sprite = messages[3];
        }
        else if (wrongWayChecker.IsWrongWay)
        {
            messageUI.sprite = messages[1];
        }
        else if (chargesAmount >= 3)
        {
            messageUI.sprite = messages[2];
        }
        else
        {
            messageUI.sprite = messages[4];
        }

    }
}
