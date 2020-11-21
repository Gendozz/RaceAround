using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{
    public void RacePressed()
    {
        SceneManager.LoadScene("Scenes/ChooseTrack");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void CreditsPressed()
    {
        SceneManager.LoadScene("Scenes/Credits");
    }
}
