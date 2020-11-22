using System;
using System.Linq;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    [SerializeField]
    private CheckPoint[] checkPoints = new CheckPoint[3];

    public GameObject player;

    public int laps = 0;

    private int[] correctSequence = {0, 1, 2};

    private int[] currentSequence = {0, 0, 0};
    
    public void RegisterCheckPoint(int index)
    {
        for (int i = 0; i < currentSequence.Length - 1; i++)
        {
            currentSequence[i] = currentSequence[i + 1];
        }
        currentSequence[currentSequence.Length - 1] = index;

        checkPoints[index].isChecked = true;
        checkPoints[currentSequence[1]].isChecked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player.gameObject) return;

        if (currentSequence.SequenceEqual(correctSequence))
        {
            laps++;
        }
    }
}
