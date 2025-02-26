using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transistionTime = 1f;

    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        //Assuming what happens here is that we play the animation start which is the one for ending the scene 
        transition.SetTrigger("Start");
        //Wait one second
        yield return new WaitForSeconds(transistionTime);
        //Load the next level
        SceneManager.LoadScene(levelIndex);
    }
}
