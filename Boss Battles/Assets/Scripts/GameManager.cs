using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float restartDelay = 1.5f;

    private bool gameHasEnded = false;
    private int lastSceneIndex;


    private void Start()
    {
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(lastSceneIndex);
    }
    public void GameOver()
    {
        Debug.Log("Starting!");
        StartCoroutine(EndGameCoroutine());
    }
    public void NextBoss()
    {
        Invoke("NewScene", 1f);
    }
    private void NewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator EndGameCoroutine()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            yield return new WaitForSeconds(restartDelay);
            gameOverUI.SetActive(true);
        }
    }
}
