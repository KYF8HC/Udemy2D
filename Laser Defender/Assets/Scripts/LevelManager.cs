using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelay = 3f;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("LaserDefender");
    }
    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", sceneDelay));
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOverMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
