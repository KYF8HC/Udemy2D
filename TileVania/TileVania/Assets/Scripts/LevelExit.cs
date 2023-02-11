using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 5f;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
            StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
        yield return new WaitForSecondsRealtime(levelLoadDelay);
    }
}
