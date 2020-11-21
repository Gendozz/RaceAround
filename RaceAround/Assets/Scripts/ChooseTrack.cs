using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseTrack : MonoBehaviour
{
    public void LoadFirstTrack()
    {
        GameManager.instance.SetSceneToLoad("Scenes/FirstTrack");

        SceneManager.LoadScene("Scenes/ControlShow");
    }

    public void LoadSecondTrack()
    {
        GameManager.instance.SetSceneToLoad("Scenes/SecondTrack");
        
        SceneManager.LoadScene("Scenes/ControlShow");
    }
}
