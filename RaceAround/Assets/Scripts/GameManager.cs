using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private static String sceneToLoad;
    
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        GameManager.instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetSceneToLoad(String sceneName)
    {
        sceneToLoad = sceneName;
    }

    public void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
    
    public void LoadScene()
    {
        print($"GameManager scene to load - {sceneToLoad}");
        SceneManager.LoadScene(sceneToLoad);
    }
    
    
}
