using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;
    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingelton();
    }
    void ManageSingelton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetcurrentScore()
    {
        return currentScore;
    }
    public void UpdateScore(int ScoreEarned)
    {
        currentScore += ScoreEarned;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
}
