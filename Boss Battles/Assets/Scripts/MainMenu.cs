using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameObject levelLoader;
    private void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");

    }
    public void PlayGame()
    {
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel(); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
