using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }
    public void AddToScore(int pointstoAdd)
    {
        score += pointstoAdd;
        scoreText.text = score.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
            TakeLife();
        else
            ResetGameSession();
    }
    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().resetScenePresist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }
}
