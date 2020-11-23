using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;

    [SerializeField] private Image messageCommonImage;

    [SerializeField] private Sprite[] startMessages = new Sprite[4];
    private int startMessageIndex = 0;
    
    private WaitForSeconds messageCommonDelay = new WaitForSeconds(1);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRace());
        StartCoroutine(DisableControlOnWin());
    }
    
    void Update()
    {
        messageCommonImage.sprite = startMessages[startMessageIndex];
    }

    IEnumerator StartRace()
    {
        for (int i = 0; i < startMessages.Length; i++)
        {
            yield return messageCommonDelay;
            startMessageIndex = i;
        }
        SwitchPlayerControl();
    }

    IEnumerator DisableControlOnWin()
    {
        while (player1.GetLapPast() < 10 && player2.GetLapPast() < 10)
        {
            yield return new WaitForSeconds(3);
        }
        SwitchPlayerControl();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Credits");
    }

    private void SwitchPlayerControl()
    {
        player1.isControlEnable = !player1.isControlEnable;
        player2.isControlEnable = !player2.isControlEnable;
    }
    
    
}
